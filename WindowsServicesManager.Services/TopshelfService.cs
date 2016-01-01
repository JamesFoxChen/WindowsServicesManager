using System;
using System.Timers;
using HLG.Framework.Utils.Log;

namespace WindowsServicesManager.Services
{
    class TopshelfService
    {
        public void Start()
        {
            TextLogUtil.Info("TopshelfService服务启动");
            cancelUnpayOrder();
        }

        /// <summary>
        /// 定期取消未支付订单
        /// </summary>
        private void cancelUnpayOrder()
        {
            try
            {
                //10分钟执行一次
                var interval = 1000 * 60 * 10;
                var mt = new Timer(interval);
                mt.Enabled = true;
                mt.Elapsed += (o, e) =>
                {
                    try
                    {
                        var t = (Timer)o;
                        t.AutoReset = false;
                        t.Enabled = false;
                        t.Stop();
                        TextLogUtil.Info("Test1Service[开始](10分钟一次）");
                        new Test1Service().Start();
                        TextLogUtil.Info("Test1Service[完毕](10分钟一次）");
                        t.Enabled = true;
                        t.AutoReset = true;
                        t.Start();
                    }
                    catch (Exception ex)
                    {
                        TextLogUtil.Error(ex.Message + ex.StackTrace);
                        var t = (Timer)o;
                        t.Enabled = true;
                        t.AutoReset = true;
                        t.Start();
                    }
                };
            }
            catch (Exception ex)
            {
                TextLogUtil.ErrorWithException("【Test1Service】" + ex.Message, ex);
            }
        }
    }
}

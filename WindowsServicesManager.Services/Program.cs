using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace WindowsServicesManager.Services
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(c =>
            {
                c.SetServiceName("WindowsServicesManager.Services");
                c.SetDisplayName("WindowsServicesManager.Services");
                c.SetDescription("WindowsServicesManager.Services");

                c.Service<TopshelfService>(s =>
                {
                    s.ConstructUsing(b => new TopshelfService());
                    s.WhenStarted(o => o.Start());
                    s.WhenStopped(o => o.Stop());
                });
            });
        }
    }
}

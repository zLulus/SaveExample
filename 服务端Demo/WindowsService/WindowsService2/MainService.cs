using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WcfService;

namespace WindowsService2
{
    public partial class MainService : ServiceBase
    {
        private ServiceHost host;
        public MainService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            Type serviceType = typeof(Service1);//托管REST或非REST服务，方式一样。Service1就是要托管的wcf服务的类
            host = new ServiceHost(serviceType);
            host.Open();
        }

        protected override void OnStop()
        {
            base.OnStop();
            if(host!=null)
                host.Close();
        }
    }
}

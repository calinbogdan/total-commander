using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TotalCommander
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = new WindsorContainer();
            container.Install(FromAssembly.This());

            container.Register(Component.For<MainWindow>());

            var king = container.Resolve<MainWindow>();
            king.Show();

            container.Dispose();
        }
    }
}

using Autofac;
using MathKidsCore;
using MathKidsCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.View;
using WpfUI.ViewModel;

namespace WpfUI
{

    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>();
            builder.RegisterType<GameSettingsUC>();
            builder.RegisterType<GameUC>();
            builder.RegisterType<SettingsVW>();
            builder.RegisterType<GameWindowVM>();
            builder.RegisterType<GameSettingsModel>().SingleInstance();
            builder.RegisterType<GameController>();
            IContainer container = builder.Build();

            using (ILifetimeScope scope = container.BeginLifetimeScope())
            {
                var mainWindow = scope.Resolve<MainWindow>();
                mainWindow.ShowDialog();
            }
        }
    }
}

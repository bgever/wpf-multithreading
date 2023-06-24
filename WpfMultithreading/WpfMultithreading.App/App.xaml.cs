using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfMultithreading.App.Services;

namespace WpfMultithreading.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            UiDispatcher.Register(Dispatcher);
            // TODO: Start services.
            Task.Run(async () =>
            {
                int count = 0;
                while (true)
                {
                    await Task.Delay(1000);
                    count++;
                    OutputStore.Log("Count: " + count);
                }
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
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
            OutputStore.Log("Dispatcher registered");
            // TODO: Start services.
            Task.Run(async () =>
            {
                int count = 0;
                while (true)
                {
                    count++;
                    OutputStore.Log($"Timer({count}) pre count");

                    //var result =
                    await UiDispatcher.Instance.InvokeAsync(async () =>
                    {
                        OutputStore.Log($"Timer({count}) UI pre");
                        await Task.Delay(3000);
                        OutputStore.Log($"Timer({count}) UI post");
                        //return 1;
                    });
                    OutputStore.Log($"Timer({count}) count");
                }
            });

            Thread worker = new(new ThreadStart(BackgroundWorker))
            {
                Name = "Worker",
                IsBackground = true
            };
            worker.Start();
        }

        private static void BackgroundWorker()
        {
            int count = 0;
            while(true)
            {
                count++;
                OutputStore.Log("Worker count: " + count);
                Thread.Sleep(1000);
            }
        }
    }
}

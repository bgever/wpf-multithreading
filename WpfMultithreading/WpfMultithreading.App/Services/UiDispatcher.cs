using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfMultithreading.App.Services
{
    internal class UiDispatcher
    {
        private static UiDispatcher? instance;

        public static UiDispatcher Instance
        {
            get
            {
                if (instance == null) throw new InvalidOperationException("Access to the UI Dispatcher before it has been registered.");
                return instance;
            }
        }

        public static void Register(Dispatcher dispatcher)
        {
            if(instance != null) throw new InvalidOperationException("Instance already registered.");
            instance = new(dispatcher);
        }

        readonly Dispatcher dispatcher;

        private UiDispatcher(Dispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public bool IsUiThread => this.dispatcher.Thread == Thread.CurrentThread;

        public void Invoke(Action action)
        {
            dispatcher.BeginInvoke(action);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfMultithreading.App.Services;

namespace WpfMultithreading.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<OutputEntry> OutputEntries { get; } = new();
        private readonly Timer OutputReaderTimer = new(100);

        public MainWindow()
        {
            InitializeComponent();
            OutputReaderTimer.Elapsed += OutputReaderTimer_Elapsed;
            OutputReaderTimer.Start();
        }

        private void OutputReaderTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            UiDispatcher.Instance.Invoke(() =>
            {
                while (OutputStore.Queue.TryDequeue(out var entry)) OutputEntries.Add(entry);
            });
        }
    }
}

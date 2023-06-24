using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfMultithreading.App.Services;

internal class OutputStore
{
    public static ConcurrentQueue<OutputEntry> Queue = new();

    public static void Log(string message)
    {
        var thread = Thread.CurrentThread;
        var threadLabel = (thread.Name ?? string.Empty) + '#' + thread.ManagedThreadId + ' ' + string.Join(',', thread.IsThreadPoolThread ? "TP" : null, thread.IsBackground ? "BG" : null);
        Queue.Enqueue(new OutputEntry(DateTime.Now, message, threadLabel));
    }
}

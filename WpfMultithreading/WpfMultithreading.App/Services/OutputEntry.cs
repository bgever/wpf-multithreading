using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMultithreading.App.Services;

public record OutputEntry(DateTime Timestamp, string Message, string ThreadLabel);
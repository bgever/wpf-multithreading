using System;

namespace WpfMultithreading.App.Services;

public record OutputEntry(DateTime Timestamp, string Message, string ThreadLabel);
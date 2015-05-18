using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using CefSharp;

namespace CefSharp_JSExample
{
    class Program
    {
        // Use when debugging the actual SubProcess, to make breakpoints etc. inside that project work.
        private static readonly bool DebuggingSubProcess = Debugger.IsAttached;

        static void Main(string[] args)
        {
            CefSettings settings = new CefSettings();

            settings.RemoteDebuggingPort = 8088;
            settings.LogSeverity = LogSeverity.Verbose;

            if (DebuggingSubProcess) { settings.BrowserSubprocessPath = "CefSharp.BrowserSubprocess.exe"; }

            Cef.OnContextInitialized = delegate { Cef.SetCookiePath("cookies", true); };

            if (!Cef.Initialize(settings, shutdownOnProcessExit: true, performDependencyCheck: !DebuggingSubProcess))
            {
                throw new Exception("Unable to Initialize Cef");
            }







            Cef.Shutdown();

        }
    }
}

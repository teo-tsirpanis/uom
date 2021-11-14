using System.Runtime.InteropServices;

namespace Dai19090.DistributedSystems.SigmaBank;

public static class ErrorHandling
{
    /// <summary>
    /// Registers handlers for common abnormal events (Ctrl+C, SIGTERM which is used
    /// for Docker, and unobserved task exceptions which might be thrown by the server).
    /// </summary>
    /// <param name="doCancel">An action that is triggered
    /// by any of the aforementioned signals.</param>
    /// <param name="registerCtrlC">Whether to trigger <paramref name="doCancel"/>
    /// and suspend termination on Ctrl+C instead of simply exiting.</param>
    /// <remarks>
    public static void RegisterErrorHandlers(Action doCancel, bool registerCtrlC = true)
    {
        if (registerCtrlC)
            Console.CancelKeyPress += (sender, e) =>
            {
                e.Cancel = true;
                Console.WriteLine("Received console signal, shutting down...");
                doCancel();
            };

        PosixSignalRegistration.Create(PosixSignal.SIGTERM, _ =>
        {
            Console.WriteLine("Received SIGTERM, shutting down...");
            doCancel();
        });

        TaskScheduler.UnobservedTaskException += (sender, e) =>
        {
            Console.WriteLine($"Unobserved task exception: {e.Exception}");
        };
    }
}

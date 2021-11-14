using System.Runtime.InteropServices;

namespace Dai19090.DistributedSystems.SigmaBank;

public static class ErrorHandling
{
    /// <summary>
    /// Registers handlers for common abnormal events (Ctrl+C, SIGTERM which is used
    /// for Docker, and unobserved task exceptions which might be thrown by the server).
    /// </summary>
    /// <param name="doCancel">An action that triggers</param>
    /// <remarks>
    public static void RegisterErrorHandlers(Action doCancel)
    {
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

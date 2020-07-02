using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Dai19090.Pdp
{
    public static class PiCalculator
    {
        private const int NumSteps = 1_000_000;
        private static readonly int P = Environment.ProcessorCount;
        // Ακούμε στο localhost, στην θύρα 12345.
        private static readonly EndPoint _endPoint = new IPEndPoint(IPAddress.Loopback, 12345);

        public static void ServerMain()
        {
            var sock = new Socket(SocketType.Stream, ProtocolType.Tcp);
            sock.Bind(_endPoint);
            sock.Listen(1000);
            while (true)
            {
                var dataSock = sock.Accept();
                var serverThread = new Thread(() => ServerThreadMain(dataSock));
                serverThread.Start();
            }
        }

        private static void ServerThreadMain(Socket sock)
        {
            var stream = new NetworkStream(sock);
            // Το προτόκολλο είναι δυαδικό.
            var reader = new BinaryReader(stream);
            var writer = new BinaryWriter(stream);

            // Ένας ακέραιος 32 bit για την αρχή των υπολογισμών.
            var start = reader.ReadInt32();
            // Και ένας ακόμα για το τέλος
            var stop = reader.ReadInt32();

            var result = CalculatePiIntegral(start, stop);

            // Η απάντηση είναι ένας πραγματικός αριθμός διπλής ακρίβειας των 64 byte.
            writer.Write(result);
            writer.Flush();
        }

        private static double CalculatePiIntegral(int start, int stop)
        {
            double sum = 0.0;
            const double step = 1.0 / NumSteps;
            for (int i = start; i < stop; ++i)
            {
                double x = (i + 0.5) * step;
                sum += 4.0 / (1.0 + x * x);
            }

            return sum;
        }

        // Η συνάρτηση αυτή χρησιμοποιείται από τον εκάστοτε client για στείλει το αίτημά του στον server.
        // Ο server θα επιστρέψει το κομμάτι του από το ολοκλήρωμα για τον υπολογισμό του π.
        public static double SendClientRequest(int start, int end)
        {
            var sock = new Socket(SocketType.Stream, ProtocolType.Tcp);
            // Κάνουμε connect στο ίδιο endpoint με τον server.
            sock.Connect(_endPoint);

            var stream = new NetworkStream(sock);
            // Χρησιμοποιούμε το ίδιο δυαδικό πρωτόκολλο.
            var reader = new BinaryReader(stream);
            var writer = new BinaryWriter(stream);

            writer.Write(start);
            writer.Write(end);

            return reader.ReadDouble();
        }

        public static void Test()
        {
            new Thread(ServerMain).Start();

            Console.WriteLine(SendClientRequest(0, 1_000_000));
        }
    }
}

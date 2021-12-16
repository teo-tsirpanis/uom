namespace Dai19090.SimulationTechniques.RandomNumbers.Analyzers
{
    public sealed class RunsTestAnalyzer : IRandomNumberAnalyzer
    {
        private struct RunCounts
        {
            public int UpRuns, DownRuns;
        }

        private readonly RunCounts[] _runCounts;
        private int _currentRunStreak = -1;
        private bool _currentRunIsUp;

        private static bool IsUp(double x) => x >= 0.5;

        private ref int GetRunCount(int runStreak, bool isUp)
        {
            ref RunCounts runCounts = ref _runCounts[runStreak];
            return ref isUp ? ref runCounts.UpRuns : ref runCounts.DownRuns;
        }

        public RunsTestAnalyzer(int maxRuns)
        {
            _runCounts = new RunCounts[maxRuns];
        }

        public void RecordMeasurement(double measurement)
        {
            var isUp = IsUp(measurement);
            var isRunBroken = _currentRunStreak >= 0 && (isUp != _currentRunIsUp || _currentRunStreak == _runCounts.Length - 1);
            if (isRunBroken)
            {
                GetRunCount(_currentRunStreak, _currentRunIsUp)++;
                _currentRunStreak = 0;
                _currentRunIsUp = isUp;
            }
            else
            {
                _currentRunStreak++;
            }
        }

        public void WriteResultsTo(TextWriter output)
        {
            // Flush the last pending run.
            if (_currentRunStreak >= 0)
                GetRunCount(_currentRunStreak, _currentRunIsUp)++;
            _currentRunStreak = -1;

            output.WriteLine("--------------------RUNS TEST--------------------");
            output.WriteLine("This test measures the \"runs\" of numbers above/below 0.5.");
            output.WriteLine("For each run both should occur about the same number of times.");
            for (int i = 0; i < _runCounts.Length; i++)
            {
                ref var runCounts = ref _runCounts[i];
                double totalRuns = runCounts.UpRuns + runCounts.DownRuns;
                double upRatio = runCounts.UpRuns / totalRuns;
                double downRatio = runCounts.DownRuns / totalRuns;
                output.WriteLine($"{i + 1}-runs: {runCounts.UpRuns}/{runCounts.DownRuns} ({upRatio:P}/{downRatio:P}, difference is {Math.Abs(upRatio - downRatio):E})");
            }
            output.WriteLine();
        }
    }
}

using Dai19090.SimulationTechniques.Instruments;
using System.Text.Json;

namespace Dai19090.SimulationTechniques.ElevatorSim;

public static class MarkdownRenderer
{
    private static readonly JsonSerializerOptions s_jsonSerializerOptions = new() { WriteIndented = true };

    private static readonly FileStreamOptions s_fileWriteOptions = new() { Options = FileOptions.Asynchronous, Mode = FileMode.Create, Access = FileAccess.Write };

    private static async Task WritePaddedLineAsync(this TextWriter output, string x)
    {
        await output.WriteLineAsync(x);
        await output.WriteLineAsync();
    }

    private static async Task WriteSimulationHeaderAsync(TextWriter output)
    {
        await output.WriteLineAsync("# Elevator simulation report");
    }

    private static async Task WriteOptionsAsync(TextWriter output, ElevatorSimOptions options)
    {
        await output.WritePaddedLineAsync($"The building has **{options.NumberOfFloors} floor{PluralMaybe(options.NumberOfFloors)}**.");
        await output.WritePaddedLineAsync($"The building has a system of **{options.NumberOfElevators} elevator{PluralMaybe(options.NumberOfElevators)}** that follows the **{options.ElevatorStrategy}** strategy. " +
            $"Each can fit at most **{options.ElevatorCapacity} {PluralMaybe(options.ElevatorCapacity, "person", "people")}**.");
        await output.WritePaddedLineAsync($"It takes **{options.ElevatorMovingDelay} second{PluralMaybe(options.ElevatorMovingDelay)}** for an elevator to travel from one floor to the next.");
        await output.WritePaddedLineAsync($"It takes **{options.ElevatorDoorOpeningDelay} second{PluralMaybe(options.ElevatorDoorOpeningDelay)}** for the elevator doors to open.");
        await output.WritePaddedLineAsync($"The elevator doors stay open for **{options.ElevatorDoorOpeningDuration} second{PluralMaybe(options.ElevatorDoorOpeningDuration)}**.");
        await output.WritePaddedLineAsync($"**{options.TotalArrivals}** people came in the building.");
        await output.WritePaddedLineAsync($"The time between each arrival follows an exponential distribution with mean equal to **{options.MeanTimeBetweenArrivals.ToSeconds()}**.");
        await output.WritePaddedLineAsync($"The number of floors each person visited follows a normal distribution with mean equal to **{options.NumberOfFloorsVisited.Mean}** " +
            $"and standard deviation equal to **{options.NumberOfFloorsVisited.Stdev}**.");
        await output.WritePaddedLineAsync($"The time each person stays on a floor follows a normal distrubution with mean equal to **{options.DurationOfStayOnFloor.Mean.ToSeconds()}** " +
            $"and standard deviation equal to **{options.DurationOfStayOnFloor.Stdev.ToSeconds()}**.");
        await output.WritePaddedLineAsync($"The simulation's random number generator seed is **{options.Seed.GetValueOrDefault()}**");
        await output.WritePaddedLineAsync("You can replay the simulation by running the program with the following JSON file:");
        await output.WriteLineAsync("``` json");
        await output.WriteLineAsync(JsonSerializer.Serialize(options, s_jsonSerializerOptions));
        await output.WriteLineAsync("```");
        await output.WriteLineAsync();

        static string PluralMaybe(int x, string singular = "", string plural = "s") => x == 1 ? singular : plural;
    }

    private static async Task WriteWorkItemQueueInstrumentAsync(TextWriter output, WorkItemQueueInstrument instrument)
    {
        await output.WriteLineAsync("### System");
        await output.WriteLineAsync("|||");
        await output.WriteLineAsync("|----|-----|");
        await output.WriteLineAsync($"|**Simulation duration**|{instrument.SimulationDuration} time units ({TimeSpan.FromSeconds(instrument.SimulationDuration)})|");
        await output.WriteLineAsync($"|**Total productive time units (where work was done)**|{instrument.TotalProductiveTimeUnits} time units|");
        await output.WriteLineAsync($"|**% of simulation in idle**|{instrument.SimulationPercentageInIdle:P2}|");
        await output.WriteLineAsync($"|**Total work items executed**|{instrument.TotalWorkItems}|");
        await output.WriteLineAsync($"|**Average work items per time unit**|{instrument.AverageWorkItemsPerTimeUnit:G3}|");
        await output.WriteLineAsync($"|**Average work items per productive time unit**|{instrument.AverageWorkItemsPerProductiveTimeUnit:G3}|");
        await output.WriteLineAsync();
    }

    private static async Task WritePeopleInstrumentAsync(TextWriter output, PeopleInstrument instrument)
    {
        await output.WriteLineAsync("### People");
        await output.WriteLineAsync("|Name|Average|Min|Max|");
        await output.WriteLineAsync("|----|-------|---|---|");
        await output.WriteLineAsync($"|**Time spent in the building overall**|{instrument.AverageTimeSpent}|{instrument.MinTimeSpent}|{instrument.MaxTimeSpent}|");
        await output.WriteLineAsync($"|**Time spent in the building waiting**|{instrument.AverageWaitingTime}|{instrument.MinWaitingTime}|{instrument.MaxWaitingTime}|");
        await output.WriteLineAsync($"|**% of time spent in the building waiting**|{instrument.AverageWaitingTimePercentage:P2}|{instrument.MinWaitingTimePercentage:P2}|{instrument.MaxWaitingTimePercentage:P2}|");
        await output.WriteLineAsync();
    }

    private static async Task WriteWaitingQueueInstrumentsAsync(TextWriter output, IEnumerable<WaitingQueueInstrument> instruments)
    {
        await output.WriteLineAsync("### Waiting Queues");
        await output.WriteLineAsync("|Name|Total arrivals|Waiting time (total/average/max)|Average queue length|Max queue length|");
        await output.WriteLineAsync("|----|--------------|--------------------------------|--------------------|----------------|");
        foreach (var instrument in instruments)
            await output.WriteLineAsync($"|{instrument.QueueName}|{instrument.TotalQueueArrivals}|{TimeSpan.FromSeconds(instrument.TotalWaitingTime)} / " +
                $"{instrument.AverageWaitingTime.ToSeconds()} / {TimeSpan.FromSeconds(instrument.MaxWaitingTime)}|{instrument.AverageQueueLength:G3}|{instrument.MaxQueueLength}|");
        await output.WriteLineAsync();
    }

    private static async Task WriteElevatorInstrumentsAsync(TextWriter output, IEnumerable<ElevatorInstrument> instruments)
    {
        await output.WriteLineAsync("### Elevators");
        await output.WritePaddedLineAsync("> An elevator gets activated when it starts moving after being put to rest.");
        await output.WritePaddedLineAsync("> The \"Average occupancy\" column's two values show the average number of passengers on an elevator at all times, and excluding the times when it is empty.");
        await output.WriteLineAsync("|Name|Floors travelled|Time in motion (% of simulation)|Activations|Passengers served|Average occupancy|");
        await output.WriteLineAsync("|----|----------------|--------------------------------|-----------|-----------------|-----------------|");
        foreach (var instrument in instruments)
            await output.WriteLineAsync($"|{instrument.ElevatorName}|{instrument.TotalFloorsTraveled}|{instrument.TimeInMotion} ({instrument.PercentageInMotion:P2})" +
                $"|{instrument.TotalActivations}|{instrument.TotalPassengersServed}|{instrument.AverageOccupancy:G3} / {instrument.AverageNonEmptyOccupancy:G3}|");
        await output.WriteLineAsync();
    }

    private static async Task WriteFloorInstrumentsAsync(TextWriter output, IEnumerable<FloorInstrument> instruments)
    {
        await output.WriteLineAsync("### Floors");
        await output.WritePaddedLineAsync("> The \"Average people on floor\" column's two values show the average people on a floor at all times, and excluding the times when it is empty.");
        await output.WriteLineAsync("|Number|Total arrivals|Average people on floor|Max people on floor|Time spent on floor (average/max/min)|Waiting time (average/max)|% of waiting time (average/max)|");
        await output.WriteLineAsync("|------|--------------|-----------------------|-------------------|-------------------------------------|--------------------------|-------------------------------|");
        foreach (var instrument in instruments)
            await output.WriteLineAsync($"|{instrument.FloorNumber}|{instrument.TotalArrivalsOnFloor}|{instrument.AveragePeopleOnFloor:G3} / {instrument.AveragePeopleOnFloorNonZero:G3}|{instrument.MaxPeopleOnFloor}|" +
                $"{instrument.AverageTimeSpentOnFloor} / {instrument.MaxTimeSpentOnFloor} / {instrument.MinTimeSpentOnFloor}|" +
                $"{instrument.AverageWaitingTime} / {instrument.MaxWaitingTime}|" +
                $"{instrument.AverageWaitingTimePercentage:P2} / {instrument.MaxWaitingTimePercentage:P2}|");
        await output.WriteLineAsync();
    }

    private static async Task WriteInstrumentsAsync(TextWriter output, ISimulationInstrument[] instruments)
    {
        await output.WriteLineAsync("## Statistics");

        await WriteWorkItemQueueInstrumentAsync(output, instruments.OfType<WorkItemQueueInstrument>().Single());
        await WritePeopleInstrumentAsync(output, instruments.OfType<PeopleInstrument>().Single());
        await WriteElevatorInstrumentsAsync(output, instruments.OfType<ElevatorInstrument>().OrderBy(x => x.ElevatorName));
        await WriteFloorInstrumentsAsync(output, instruments.OfType<FloorInstrument>().OrderBy(x => x.FloorNumber));
        await WriteWaitingQueueInstrumentsAsync(output, instruments.OfType<WaitingQueueInstrument>().OrderBy(x => x.QueueName));
    }

    private static async Task WriteLogAsync(TextWriter output, List<string> logItems)
    {
        await output.WriteLineAsync("## Simulation Log");
        await output.WriteLineAsync("<details>");
        await output.WritePaddedLineAsync($"<summary>Click to expand ({logItems.Count} lines)</summary>");
        await output.WriteLineAsync("```");
        foreach (var logItem in logItems) await output.WriteLineAsync(logItem);
        await output.WriteLineAsync("```");
        await output.WriteLineAsync("</details>");
    }

    public static async Task WriteElevatorSimResultsToFileAsync(string path, ElevatorSimOptions options, SimulationResult result, List<string> logItems)
    {
        await using var sw = new StreamWriter(path, s_fileWriteOptions);
        await WriteSimulationHeaderAsync(sw);
        await WriteOptionsAsync(sw, options);
        await WriteInstrumentsAsync(sw, result.Instruments);
        await WriteLogAsync(sw, logItems);
    }
}

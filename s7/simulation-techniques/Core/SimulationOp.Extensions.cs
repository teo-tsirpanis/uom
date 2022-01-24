namespace Dai19090.SimulationTechniques;

public partial class SimulationOp
{
    // I know it is super unpolished, there are lots of correctness and efficiency concerns over this.
    public static SimulationOp<SimulationOp<TResult>?> WhenAny<TResult>(params SimulationOp<TResult>?[] ops)
    {
        var resultOp = new SimulationOp<SimulationOp<TResult>?>();
        var sawNonNull = false;

        foreach (var op in ops)
        {
            if (op is null) continue;
            _ = ContinuationCore(op, resultOp);
            sawNonNull = true;
        }

        if (!sawNonNull)
            resultOp.SetResult(null);

        return resultOp;

        static async SimulationOp ContinuationCore(SimulationOp<TResult> op, SimulationOp<SimulationOp<TResult>?> resultOp)
        {
            try
            {
                await op;
                resultOp.SetResult(op);
            }
            catch (Exception e)
            {
                resultOp.TrySetException(e);
            }
        }
    }
}

namespace IMM_Events;
public class SequenceSummator
{
    private long N;
    public long Result { get; private set; }
    public SequenceSummator(long n)
    {
        N = n;
    }
    public void Start()
    {
        CalcSum();
    }

    private void CalcSum()
    {
        long r = 0;
        for (long i = 1; i <= N; i++)
        {
            r += i;
        }
        Result = r;
    }
}
namespace IMM_Events;

public delegate void ResultReady(long result);

public class ParallelSummator
{
    private long N;
    public long Result { get; private set; }
    private int resCount = 0;
    public event ResultReady OnResultReady;

    private object common = new ();
    public ParallelSummator(long n)
    {
        N = n;
    }
    public void Start(int threadCount = 16)
    {
        resCount = threadCount;
        int k = 1;
        while (k <= threadCount)
        {
            new Thread(_ =>
                {
                    CalcSum(k++, threadCount);
                })
                .Start();
        }
    }
    private void CalcSum(long start, int threadCount)
    {
        long r = 0;
        for (long i = start; i <= N; i+=threadCount)
        {
            r += i;
        }

        //Console.WriteLine("Поток {0}, сумма: {1}", start, r);
        lock (common)
        {
            Result += r;
            resCount--;
            if (resCount == 0)
            {
                OnResultReady(Result);
            }
        }
    }
}
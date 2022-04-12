// See https://aka.ms/new-console-template for more information

using IMM_Events;

var ss = new SequenceSummator(2000000000);
ss.Start();
Console.WriteLine(ss.Result);

var ps = new ParallelSummator(2000000000);
ps.OnResultReady += ShowResult;
ps.Start();

void ShowResult(long result)
{
    Console.WriteLine(result);
}
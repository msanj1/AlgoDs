using Timer = System.Timers.Timer;

namespace Application;

public class TokenBucket : IDisposable
{
    private readonly int _configuredTokenSize;
    private readonly Timer _timer;

    private int _tokenSize;
    private static object _throttleLock = new object();

    public TokenBucket(int tokenSize, int refillRateInMillisecond, bool enableAutoRefill)
    {
        _tokenSize = tokenSize;
        _timer = new Timer(refillRateInMillisecond);
        _timer.AutoReset = true;
        _timer.Elapsed += (_, _) => Refill();
        _timer.Enabled = enableAutoRefill;
        _configuredTokenSize = tokenSize;
    }

    public void Dispose()
    {
        _timer.Dispose();
    }

    private bool ShouldThrottle(string request)
    {
        if (_tokenSize > 0) return false;

        return true;
    }

    public void Throttle(string request)
    {
        var lockTaken = Monitor.TryEnter(_throttleLock, TimeSpan.FromMilliseconds(500));
        if (lockTaken)
        {
            if (ShouldThrottle(request))
                throw new RequestThrottledException();

            _tokenSize--;

            Monitor.Exit(_throttleLock);
        }
    }

    private void Refill()
    {
        var lockTaken = Monitor.TryEnter(_throttleLock, TimeSpan.FromMilliseconds(500));
        if (lockTaken)
        {
            _tokenSize = _configuredTokenSize;
            Monitor.Exit(_throttleLock);
        }
    }
}
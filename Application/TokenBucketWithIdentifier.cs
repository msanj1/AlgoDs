using System.Collections.Concurrent;
using Timer = System.Timers.Timer;

namespace Application;

public class TokenBucketWithIdentifier : IDisposable
{
    private readonly int _configuredTokenSize;
    private readonly Timer _timer;

    private readonly ConcurrentDictionary<Guid, int> _requestBuckets = new();
    private static object tokenLock = new();

    public TokenBucketWithIdentifier(int tokenSize, int refillRateInMillisecond, bool enableAutoRefill)
    {
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

    private bool ShouldThrottle(Guid identifier)
    {
        _requestBuckets.TryAdd(identifier, _configuredTokenSize);

        if (_requestBuckets[identifier] <= 0) return true;

        return false;
    }

    public void Throttle(Guid identifier)
    {
        var lockTaken = Monitor.TryEnter(tokenLock, TimeSpan.FromMilliseconds(1000));
        if (lockTaken)
        {
            if (ShouldThrottle(identifier))
                throw new RequestThrottledException();

            _requestBuckets[identifier]--;

            Monitor.Exit(tokenLock);
        }
    }

    private void Refill()
    {
        foreach (var key in _requestBuckets.Keys) _requestBuckets[key] = _configuredTokenSize;
    }
}
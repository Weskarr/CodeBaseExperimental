using System.Collections.Generic;
using System.Diagnostics;
using Unity.Profiling;

public static class PerformanceUtility
{
    private static readonly Dictionary<string, Stopwatch> _timers = new();
    private static readonly Dictionary<string, ProfilerMarker> _markers = new();

    public static void Start(string name)
    {
        if (_timers.ContainsKey(name))
        {
            UnityEngine.Debug.LogWarning($"Performance timer '{name}' is already running.");
            return;
        }

        Stopwatch stopwatch = Stopwatch.StartNew();
        _timers.Add(name, stopwatch);

        GetMarker(name).Begin();
    }

    public static double End(string name)
    {
        if (!_timers.TryGetValue(name, out Stopwatch stopwatch))
        {
            UnityEngine.Debug.LogWarning($"Performance timer '{name}' was never started.");
            return -1;
        }

        stopwatch.Stop();
        _timers.Remove(name);

        GetMarker(name).End();

        double milliseconds = stopwatch.Elapsed.TotalMilliseconds;

        UnityEngine.Debug.LogWarning($"[Performance] {name}: {milliseconds:F4} ms");

        return milliseconds;
    }

    private static ProfilerMarker GetMarker(string name)
    {
        if (!_markers.TryGetValue(name, out ProfilerMarker marker))
        {
            marker = new ProfilerMarker(name);
            _markers.Add(name, marker);
        }

        return marker;
    }
}
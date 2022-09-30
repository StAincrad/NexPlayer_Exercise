using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class Test_dll : MonoBehaviour
{
    [DllImport("NexPlayer_dll.dll")]
    private static extern IntPtr createTracker();
    
    [DllImport("NexPlayer_dll.dll")]
    private static extern void freeTracker(IntPtr instance);
    
    [DllImport("NexPlayer_dll.dll")]
    private static extern void onPlayPause(IntPtr instance, long timeStamp);
    
    [DllImport("NexPlayer_dll.dll")]
    private static extern int getNumberPlayPauseEvents(IntPtr instance);
    
    [DllImport("NexPlayer_dll.dll")]
    private static extern long getLastTimeStamp(IntPtr instance);
    
    // Start is called before the first frame update
    void Start()
    {
        IntPtr test = createTracker();
        int n = getNumberPlayPauseEvents(test);
        long t = getLastTimeStamp(test);
        Debug.Log("Address: " + test);
        Debug.Log("Number: " + n);
        Debug.Log("Time: " + t);

        long time = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
        onPlayPause(test, time);
        n = getNumberPlayPauseEvents(test);
        t = getLastTimeStamp(test);
        Debug.Log("New Number: " + n);
        Debug.Log("New Time: " + t);
        
        freeTracker(test);
    }
}

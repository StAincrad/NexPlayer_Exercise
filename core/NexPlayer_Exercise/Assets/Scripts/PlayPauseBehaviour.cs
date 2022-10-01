using System;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class PlayPauseBehaviour : MonoBehaviour
{
    #region DLL_IMPORT

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

    #endregion

    [SerializeField] 
    private TextMeshProUGUI events;
    
    [SerializeField] 
    private TextMeshProUGUI timeStamp;
    
    private IntPtr tracker;
    
//--------------------------------------------------------------------------------------------------------------------//
    
    private void Start()
    {
        tracker = createTracker();
    }
    
//--------------------------------------------------------------------------------------------------------------------//
    
    public void OnPlayPause()
    {
        var time = new DateTimeOffset(DateTime.Now);
        var unix = time.ToUnixTimeSeconds();
        onPlayPause(tracker, unix);
        PrintNumberPlayPauseEvents();
        PrintLastTimeStamp(time);
    }

    private void PrintNumberPlayPauseEvents()
    {
        int n = getNumberPlayPauseEvents(tracker);
        events.text = "Play/Pause events: " + n;
    }

    private void PrintLastTimeStamp(DateTimeOffset time)
    {
        long t =  getLastTimeStamp(tracker);
        timeStamp.text = "LastTimeStamp: " + t + "\n" 
                         + "Date: " + time.DateTime;
    }

    private void OnDestroy()
    {
        freeTracker(tracker);
    }
}

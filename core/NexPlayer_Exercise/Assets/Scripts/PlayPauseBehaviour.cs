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
        long time = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
        onPlayPause(tracker, time);
        PrintNumberPlayPauseEvents();
        PrintLastTimeStamp();
    }

    private void PrintNumberPlayPauseEvents()
    {
        int n = getNumberPlayPauseEvents(tracker);
        events.text = "Play/Pause events: " + n;
    }

    public void PrintLastTimeStamp()
    {
        long t =  getLastTimeStamp(tracker);
        timeStamp.text = "LastTimeStamp: " + t;
    }

    private void OnDestroy()
    {
        freeTracker(tracker);
    }
}

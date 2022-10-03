using System;
using System.Runtime.InteropServices;
using NexPlayerAPI;
using NexPlayerSample;
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
    private static extern void onPlayPause(IntPtr instance, int timeStamp);
    
    [DllImport("NexPlayer_dll.dll")]
    private static extern int getNumberPlayPauseEvents(IntPtr instance);
    
    [DllImport("NexPlayer_dll.dll")]
    private static extern int getLastTimeStamp(IntPtr instance);
    #endregion

    [SerializeField] 
    private TextMeshProUGUI eventsUI;
    
    [SerializeField] 
    private TextMeshProUGUI timeStampUI;
    
    [SerializeField]
    private NexPlayer npManager;

    private IntPtr tracker;

//--------------------------------------------------------------------------------------------------------------------//
    
    private void Start()
    {
        tracker = createTracker();
    }

    private void Update()
    {
        // Printing every frame
        PrintNumberPlayPauseEvents();
        PrintLastTimeStamp();
    }
    //--------------------------------------------------------------------------------------------------------------------//

    /// <summary>
    /// Invoke onPlayPause from the dll to change
    /// lastTimeStamp and add 1 to events count
    /// </summary>
    public void OnPlayPause()
    {
        int t = npManager.GetCurrentTime() / 1000;
        onPlayPause(tracker, t);
    }

    private void PrintNumberPlayPauseEvents()
    {
        int n = getNumberPlayPauseEvents(tracker);
        eventsUI.text = "Play/Pause eventsUI: " + n;
    }

    private void PrintLastTimeStamp()
    {
        int t = getLastTimeStamp(tracker);
        timeStampUI.text = "LastTimeStamp: " + t + " sec";
    }

    private void OnDestroy()
    {
        freeTracker(tracker);
    }
}

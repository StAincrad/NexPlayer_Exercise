#pragma once

#ifdef NEXPLAYERDLL_EXPORTS
#   define EXPORT __declspec(dllexport)
#else
#   define EXPORT __declspec(dllimport)
#endif

class NPTracker
{
public:
	NPTracker();
	~NPTracker();

	/// <summary>
	/// When the state of NexPlayer changes (Play or Pause),
	/// the time stamp will be saved.
	/// </summary>
	/// <param name="currentTimeStamp">Time to save</param>
	void OnPlayPause(int currentTimeStamp);
	/// <summary>
	///	Return Number of state changes during the execution.
	/// </summary>
	int GetNumberOfEvents();
	/// <summary>
	/// Return the last time stamp saved
	/// </summary>
	int GetLastTimestamp();

private:
	// Number of times of Play/Pause
	int _numberPlayPause = 0;
	// Last time stamp saved
	int  _lastTimeStamp = 0;
};

/// <summary>
/// Create a new NPTracker
/// </summary>
extern "C" EXPORT NPTracker * createTracker();
/// <summary>
/// Destroy an sepecified NPTracker
/// </summary>
/// <param name="instance">NPTracker to release</param>
extern "C" EXPORT void freeTracker(NPTracker* instance);
/// <summary>
/// When the state of NexPlayer changes (Play or Pause),
/// the time stamp will be saved.
/// </summary>
/// <param name="currentTimeStamp">Time to save</param>
extern "C" EXPORT void onPlayPause(NPTracker * instance, int currentTimeStamp);
/// <summary>
///	Return Number of state changes during the execution.
/// </summary>
extern "C" EXPORT int getNumberPlayPauseEvents(NPTracker * instance);
/// <summary>
/// Return the last time stamp saved
/// </summary>NPTracker* instance
extern "C" EXPORT int getLastTimeStamp(NPTracker * instance);

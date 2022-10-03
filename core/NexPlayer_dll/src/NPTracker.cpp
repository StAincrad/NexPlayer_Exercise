#include "NPTracker.h"

NPTracker::NPTracker()
{
}

NPTracker::~NPTracker()
{
}

void NPTracker::OnPlayPause(int currentTimeStamp)
{
	_numberPlayPause++;
	_lastTimeStamp = currentTimeStamp;
}

int NPTracker::GetNumberOfEvents()
{
	return _numberPlayPause;
}

int NPTracker::GetLastTimestamp()
{
	return _lastTimeStamp;
}

//-------------------------------------------------------------//
EXPORT NPTracker* createTracker()
{
	return new NPTracker();
}

EXPORT void freeTracker(NPTracker* instance)
{
	delete instance;
}

EXPORT void onPlayPause(NPTracker* instance, int currentTimeStamp)
{
	instance->OnPlayPause(currentTimeStamp);
}

int getNumberPlayPauseEvents(NPTracker* instance)
{
	return instance->GetNumberOfEvents();
}

int getLastTimeStamp(NPTracker* instance)
{
	return instance->GetLastTimestamp();
}

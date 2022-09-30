#include "NPTracker.h"

NPTracker::NPTracker()
{
}

NPTracker::~NPTracker()
{
}

void NPTracker::OnPlayPause(unsigned long long  currentTimeStamp)
{
	_numberPlayPause++;
	_lastTimeStamp = currentTimeStamp;
}

int NPTracker::GetNumberOfEvents()
{
	return _numberPlayPause;
}

long long NPTracker::GetLastTimestamp()
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

EXPORT void onPlayPause(NPTracker* instance, unsigned long long  currentTimeStamp)
{
	instance->OnPlayPause(currentTimeStamp);
}

int getNumberPlayPauseEvents(NPTracker* instance)
{
	return instance->GetNumberOfEvents();
}

unsigned long long getLastTimeStamp(NPTracker* instance)
{
	return instance->GetLastTimestamp();
}

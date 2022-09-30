# NexPlayer_Exercise
This project is a little exercise using [NexPlayer SDK](https://assetstore.unity.com/packages/tools/video/nexplayer-video-streaming-player-with-drm-free-demo-197902) with **Unity**. It is an exercise asked by [NexPlayer SDK S.L.](https://nexplayersdk.com/) to get an **Intership** as a **Software Engeneer**. 

The project consists of integrating the SDK in Unity, creating also a little **dll** in **C++** which contains the following functions: 

- **void OnPlayPause(long long currentTimeStamp)**: used to accumulate the number of times the player has been paused/resumed. It also saves the last timeStamp when the player has been paused/resumed. 
  
- **int GetNumberOfEvents()**:  returns the number of play/pause events during the execution of the game.

- **long long GetLastTimestamp()**: returns the last timeStamp saved.

## What is NexPlayer about?

It is an multiplatform SDK created to make multimedia content inside different projects. It allows the users to connect inside the project with different streaming platforms. For example, with this SDK, the users could create a little metaverse cinema where they can watch in VR and real time a movie with different people. 


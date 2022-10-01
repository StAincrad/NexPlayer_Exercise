# NexPlayer_Exercise
This project is a little exercise using [NexPlayer SDK](https://assetstore.unity.com/packages/tools/video/nexplayer-video-streaming-player-with-drm-free-demo-197902) with **Unity**. It is an exercise asked by [NexPlayer SDK S.L.](https://nexplayersdk.com/) to get an **Intership** as a **Software Engeneer**. 

## What is NexPlayer about?

It is an multiplatform SDK created to make multimedia content inside different projects. It allows the users to connect inside the project with different streaming platforms. For example, with this SDK, the users could create a little metaverse cinema where they can watch in VR and real time a movie with different people. 

## What did I do?

The project consists of integrating the SDK in Unity, creating also a little **dll** in **C++** which contains the following functions: 

- **void OnPlayPause(long long currentTimeStamp)**: used to accumulate the number of times the player has been paused/resumed. It also saves the last timeStamp when the player has been paused/resumed. 
  
- **int GetNumberOfEvents()**:  returns the number of play/pause events during the execution of the game.

- **long long GetLastTimestamp()**: returns the last timeStamp saved.

After building the **dll** the information about **Number of events** and **Last timestamp** have to being showed in the UI interface. 

I created a single cube with a material, so with NexPlayer I can show a [video sample](https://dash.akamaized.net/akamai/bbb_30fps/bbb_30fps.mpd) integrated in the cube. The cube has movement and rotation effects, such that the cube is connected with the **Play/Pause** and **Stop** buttons. If the user press **Play/Pause** button the cube will be **played/paused** and if it is tha cease of **Stop** button, the cube will reset their position and rotation. 

The information about **Number of Play/Pause events** is showed all the time at the upper of the screen. On the other hand, **Last timestamp** is showed also all the time in **Unix** number, moreover the date of that unix number is showed too. The information is also appreciated in full screen.

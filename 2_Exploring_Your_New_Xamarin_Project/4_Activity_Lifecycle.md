# Activity Lifecycle

We want our application to run as fast as possible with no memory leaks. For this reason, Android manages the lifetime of activities. An activity can be in a number of **states**: Running, Stopped, and more. When we transition from on state to another an event will be triggered that we can hook into. This is an example of how an activity could run:

1. When the application gets started it launches it's main activity. The activity view will be visible and that activity will be in the **Running** state.
2. A second activity is triggered that takes up the whole screen, and while that second activity is **Running** our main activity will switch to the **Paused** state.
3. If the user switches to another app or to the phone home screen, our activities will all change to the **Backgrounded** state.
4. If the user presses the **Back** button on the device to exit the app, the activity will switch to the **Stopped** state and the activity will be removed from memory.

There are "On" methods for each state of an activity:

**OnCreate**: Gets called when the activity is launched the first time to set things up. Even if the activity gets hidden by another activity and then unhidden, OnCreate will not fire again. As long as the activity isn't removed from memory, OnCreate won't fire again.

**OnStart**: Gets called before an activity becomes active and it is called every time the activity is going to be shown. Typically you'll use it to refresh data that you download from a service so the user doesn't have stale data while navigating through the app. 

**OnResume**: Gets called right before an activity becomes active. 

**OnPause**: Gets called when the activity is no longer on the screen. It is typically usd to clean up resources and free up memory.

**OnStop**: Gets called when the activity is no longer on the screen and when there is no chance the activity will return to the screen.

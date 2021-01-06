# Creating The First Screen

To add a new activity we'll right-click on our mobile solution (Not the .NET Standard Solution) and then click "New File", then "Activity C#". since we'll be debugging this activity, we can add "MainLauncher=true" to the Activity annotation so that this activity will open by default when we run the application. We'll have to remove MainLauncher from the MainActivity.cs file since we can't have to screens that our app starts on.

```c#
[Activity(Label = "WorkExperience", MainLauncher = true)] // New activity set to open first in the app

[Activity(Label = "Cody Portfolio App", Theme = "@style/AppTheme")] // Old MainActivity temporarily not opening first
```
 
 Now we'll need to create a user interface for our activity, so we'll go to the Resources/layout folder and right click the folder, add a new file, add an "Android Layout". Then we'll SetContextView in our new activity to that axml file so that they are tied together like this:

 ```c#
namespace Cody_Portfolio_App
{
    [Activity(Label = "WorkExperience", MainLauncher = true)]
    public class WorkExperience : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.work_experience);
        }
    }
}
 ```

 
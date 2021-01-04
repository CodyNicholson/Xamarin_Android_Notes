# Creating The Project

In Visual Studio we can go to file, new project, Blank Android App and select the Modern Platform which is JellyBean at the time these notes were written. The select a directory for the project and create it.

## Understanding the Default Project

Under "References" we can see we have all the .NET default libraries along with Mono. Mono.Android is the entry point to all APIs from Android that you access from your .NET code. It's the bridge from .NET to Android. 

### Activities

Android & Xamarin.Android apps are built around the concept of an **Activity**. An App is a collection of activities that each contain functionality of the application. Each activity is loosely coupled with each other. Activities contain code that interacts with a view. All activities inherit from the class "BaseActivity" in the Xamarin.Android library that give it navigation functionality and much more. Each activity needs to be annotated with the "Activity" attribute. Each activity is standalone but an activity is capable of starting another activity using **indents**.

Example Activity:

```C#
[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
public class MainActivity : AppCompatActivity
{
    // code or activity
}
```

The above activity inherits from the **AppCompatActivity** which is an Android class that adds some extra background compatibility options. The class is also marked with the **Activity** attribute and because of this Android will treat this class as an Activity and register it as such. This is important because we'll need to navigate to this activity from another activity, and this will only work if Android knows this is an activity. Note that there is also an attribute parameter called **MainLauncher** and it is set to **true**. This marks this activity as the starting activity that will be run when the application starts. 

After we create our blank app, we can navigate to the **MainActivity.cs** file. This activity will contain the code functionality for the first screen our user will see in our app.

### Views

A view is a screen that is written in XML code. In Xamarin.Android we will use **axml** (Android XML Files) which are teh same as the ones we would use for regular Android development.

## How does the application start?

Each Xamarin Android Application has a starting activity instead of a main method to start the application.
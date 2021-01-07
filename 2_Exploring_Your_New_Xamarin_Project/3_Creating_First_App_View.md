# Creating Our First App View

- Looking at a view
- Adding a widget
- Accessing the widget from code

OnCreate, as the name implies, is really going to be called upon creation of this activity. So this code will execute very early in the lifecycle of this main activity. Now there's a very important line here that we'll look at now and that's **SetContentView**. Remember the activity is just code that is executing. It's not really the visible part of our application, that is covered by a view. 

**ContentView** is really used to specify which view should be really showing at this point. **SetContentView** accepts an integer that comes from the **Resource.Designer.cs** file. In SetContentView, we pass **Resource.Layout.activity_main**. This maps to the file at: **Resource/Layout/activity_main.axml**. That is going to be the view that is going to be associated with this activity. When we open an axml in Visual Studio, we will get this designer interface, this split view that shows on the left in this case my preview window, and on the right, the XML code that makes up the UI of the application.

Now let's start adding some code in here. Visual Studio supports a toolbox and we can for example, drag a button onto the designer interface. Code is being generated inside of the XML as well. I will give my button a name. Let's call it **MyButton**. Now pay attention; the Android id is not just MyButton, it's @+id/MyButton. This references the Id from the Resource.Designer.cs file and is the unique identifier Android uses to select the button. Our activity_main.axml looks like this:

```
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:orientation="vertical">
    <Button
        android:text="Button"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:minWidth="25px"
        android:minHeight="25px"
        android:id="@+id/MyButton"/>
</LinearLayout>
```

In the activity code, we reference the button like this:

```c#
protected override void OnCreate(Bundle savedInstanceState)
{
    base.OnCreate(savedInstanceState);
    Xamarin.Essentials.Platform.Init(this, savedInstanceState);
    SetContentView(Resource.Layout.activity_main);

    Button myButton = FindViewById<Button>(Resource.Id.MyButton);
}
```

We write code that will search for the button using a built-in method called **FindFewById**. So I'm going to write Button and I'm going to give it the same name, myButton. Then I'll say I want you to search Android for that button, **FindViewById**. I'm going to use the generic version, passing in the type Button so I don't need to cast it, and which is going to be the resource value. Again an integer value is going to be **Resource.Id.MyButton**. And now at the runtime of my application, my button is actually going to be searched for by Android. It's going to find it and it's going to give me back a reference, and I can now use that here in my code as we would do typically. 

I can now for example attach a click event handler to my button, saying myButton.Click += tap tap to insert an event handler, and then I can write my code that will be triggered when I click on the button in the UI. To react to the button click, I'm going to show a small toast message. That can be done by using the static **Toast.MakeText** method, and I pass in a small message that is then going to be shown inside of a toast. Let's run the application and see if we can effectively see our toast message.

```c#
namespace Cody_Portfolio_App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Button myButton = FindViewById<Button>(Resource.Id.MyButton);
            myButton.Click += MyButton_Click;
        }


        private void MyButton_Click(object sender, EventArgs eventArgs)
        {
            var toastMsg = Toast.MakeText(this, "MyButton was clicked!", ToastLength.Short);
            toastMsg.Show();
        }
    }
}
```

And when I run the application on the emulator, we see our button showing up, and when I click it, it says that the button, a button was clicked. We also talked in the slides about the **manifest**. The manifest editor is accessible by going to the Properties of the application, and then you see here Android Manifest. This contains quite a few options that we'll use throughout this course including setting the application icons. You'll also see a long list of permissions in the manifest that you can enable for your application. We'll need to enable extra permissions in our application, and these are actually used by Android to warn the user about things that the application will want to do if the user accepts to install and run the application. If you have an Android device, I'm sure you have seen these warnings when you install a new application from the Google Play Store. Now with that we already have a small application running, and you already start grasping the basic foundational concepts of Android.

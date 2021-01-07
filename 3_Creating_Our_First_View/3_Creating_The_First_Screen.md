# Creating The First Screen

To add a new activity we'll right-click on our mobile solution (Not the .NET Standard Solution) and then click "New File", then "Activity C#". since we'll be debugging this activity, we can add "MainLauncher=true" to the Activity annotation so that this activity will open by default when we run the application. We'll have to remove MainLauncher from the MainActivity.cs file since we can't have to screens that our app starts on.

```c#
[Activity(Label = "ProjectActivity", MainLauncher = true)] // New activity set to open first in the app

[Activity(Label = "Cody Portfolio App")] // Old MainActivity temporarily not opening first
```
 
Now we'll need to create a user interface for our activity, so we'll go to the Resources/layout folder and right click the folder, add a new file, add an "Android Layout". Then we'll SetContextView in our new activity to that axml file so that they are tied together like this:

```c#
namespace Cody_Portfolio_App
{
    [Activity(Label = "ProjectActivity", MainLauncher = true)]
    public class ProjectActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.single_project);
        }
    }
}
```

## Adding Our Data Layer To Our Activity

So that we can start displaying data from our mock database, we'll need to include the DAO we made in "2_Exploring_Your_New_Xamarin_Project/5_Code_Sharing.md". We'll also create a private variable to hold the project we will read from our database:

```c#
using Cody_Portfolio_App_Core.Models;
using Cody_Portfolio_App_Core.DAO;
using Android.App;
using Android.OS;

namespace Cody_Portfolio_App
{
    [Activity(Label = "ProjectActivity", MainLauncher = true)]
    public class ProjectActivity : Activity
    {
        private ProjectDAO _projectDAO;
        private Project _selectedProject;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.single_project);

            _projectDAO = new ProjectDAO();
            _selectedProject = _projectDAO.GetFirstProject();
        }
    }
}
```

We can now access a project object from our database!

## Creating Our Single Project View

In our single project view we want to display all the information for a single project. We want the project title, a project image, the duration of time the project was created in, and the project description. So we'll create a view with TextViews an ImageView to display all of this information. Then we'll add CSS styles to format our page and make it all visually appealing.

```
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout
	xmlns:android="http://schemas.android.com/apk/res/android"
	android:orientation="vertical"
	android:layout_width="match_parent"
	android:layout_height="match_parent">
	<TextView
		android:id="@+id/projectTitle"
		android:text="Project Title"
		android:textColor="@android:color/black"
		android:textSize="20dp"
		android:textStyle="bold"
		android:layout_marginTop="20dp"
		android:layout_width="match_parent"
		android:layout_height="wrap_content"
		android:paddingLeft="20dp"/>
	<ImageView
		android:id="@+id/projectImg"
		android:maxHeight="25dp"
		android:paddingBottom="10dp"
		android:layout_marginTop="10dp"
		android:layout_marginLeft="10dp"
		android:layout_marginRight="10dp"
		android:layout_width="match_parent"
		android:layout_height="120dp"
		android:layout_gravity="center_horizontal"
		android:contentDescription="Project Image" />
	<TextView
		android:id="@+id/projectDuration"
		android:text="Project Duration"
		android:textStyle="italic"
		android:textSize="15dp"
		android:textColor="@android:color/darker_gray"
		android:layout_width="match_parent"
		android:layout_height="wrap_content"
		android:paddingLeft="20dp"/>
	<TextView
		android:id="@+id/projectDescription"
		android:text="Some text for the project"
		android:textColor="@android:color/black"
		android:textSize="15dp"
		android:paddingTop="8dp"
		android:layout_width="match_parent"
		android:layout_height="wrap_content"
		android:paddingLeft="20dp"/>
	<Button
		android:id="@+id/backButton"
		android:text="Back"
		android:textColor="@android:color/black"
		android:layout_width="100dp"
		android:layout_height="wrap_content"
		android:layout_gravity="right"
		android:layout_marginTop="15dp"
		android:layout_marginRight="30dp" />
</LinearLayout>
```
 
In the above code, inside of a root LinearLayout you'll see all of the elements that make up our single_project view. Notice how all of the CSS properties change the text color, size, and value. How we can use CSS to format our elements with padding and margins. Now we can go back to our ProjectActivity file and start using all of these new elements.

## Selecting Our New Elements

Now that we've created our new elements in our axml file, we'll need to reference them in our ProjectActivity file. We can do this by creating TextViews and an ImageView in our activity just like we did in our axml but now in a class:

```c#
using Cody_Portfolio_App_Core.Models;
using Cody_Portfolio_App_Core.DAO;
using Android.App;
using Android.OS;
using Android.Widget;

namespace Cody_Portfolio_App
{
    [Activity(Label = "ProjectActivity", MainLauncher = true)]
    public class ProjectActivity : Activity
    {
        private ProjectDAO _projectDAO;
        private Project _selectedProject;
        private ImageView _selectedProjectImageView;
        private TextView _selectedProjectTitleTextView;
        private TextView _selectedProjectDurationTextView;
        private TextView _selectedProjectDescriptionTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.single_project);

            _projectDAO = new ProjectDAO();
            _selectedProject = _projectDAO.GetFirstProject();

            FindViews();
        }

        private void FindViews()
        {
            _selectedProjectImageView = FindViewById<ImageView>(Resource.Id.projectImg);
            _selectedProjectTitleTextView = FindViewById<TextView>(Resource.Id.projectTitle);
            _selectedProjectDurationTextView = FindViewById<TextView>(Resource.Id.projectDuration);
            _selectedProjectDescriptionTextView = FindViewById<TextView>(Resource.Id.projectDescription);
        }
    }
}
```

We're now getting the data for our first project, then selecting the elements in our axml file that we wan to populate with our data. Time to populate the data!

## Populating Our View With Database Values

In order to bind our database data to our view we'll create one last function called BindData() that will send the data we stored in our _selectedProject variable to our view:

```c#
using Cody_Portfolio_App_Core.Models;
using Cody_Portfolio_App_Core.DAO;
using Android.App;
using Android.OS;
using Android.Widget;
using Cody_Portfolio_App.Utility;

namespace Cody_Portfolio_App
{
    [Activity(Label = "ProjectActivity", MainLauncher = true)]
    public class ProjectActivity : Activity
    {
        private ProjectDAO _projectDAO;
        private Project _selectedProject;
        private ImageView _selectedProjectImageView;
        private TextView _selectedProjectTitleTextView;
        private TextView _selectedProjectDurationTextView;
        private TextView _selectedProjectDescriptionTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.single_project);

            _projectDAO = new ProjectDAO();
            _selectedProject = _projectDAO.GetFirstProject();

            FindViews();
            BindData();
        }

        private void FindViews()
        {
            _selectedProjectImageView = FindViewById<ImageView>(Resource.Id.projectImg);
            _selectedProjectTitleTextView = FindViewById<TextView>(Resource.Id.projectTitle);
            _selectedProjectDurationTextView = FindViewById<TextView>(Resource.Id.projectDuration);
            _selectedProjectDescriptionTextView = FindViewById<TextView>(Resource.Id.projectDescription);
        }

        private void BindData()
        {
            var projectImgBitMap = ImageHelper.GetImageBitmapFromUrl(_selectedProject.ImageUrl);
            _selectedProjectImageView.SetImageBitmap(projectImgBitMap);

            _selectedProjectTitleTextView.Text = _selectedProject.Name;
            _selectedProjectDurationTextView.Text = _selectedProject.StartDate.ToShortDateString() + " - " +
                (_selectedProject.EndDate != null ? _selectedProject.EndDate.Value.ToShortTimeString() : "Present");
            _selectedProjectDescriptionTextView.Text = _selectedProject.Description;
        }
    }
}
```

>**NOTE**: For our image to populate correctly we needed to create an ImageHelper class that would go to the internet, download out image, and send it to our user's view. The code for that image helper I put into a new directory called "Utility" in our Mobile App directory. The code looks like this to download an image from the internet and send it to a bitmap:

```c#
using System.Net;
using Android.Graphics;

namespace Cody_Portfolio_App.Utility
{
    public class ImageHelper
    {
        public static Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                byte[] imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
    }
}
```

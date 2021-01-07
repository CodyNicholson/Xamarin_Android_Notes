using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;

namespace Cody_Portfolio_App
{
    [Activity(Label = "Cody Portfolio App")]
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
            var toastMsg = Toast.MakeText(this, "MyButton was clicked", ToastLength.Short);
            toastMsg.Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

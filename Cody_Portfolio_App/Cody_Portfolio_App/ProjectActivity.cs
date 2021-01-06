
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
            SetContentView(Resource.Layout.project);

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

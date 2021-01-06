using System;
using System.Linq;
using System.Collections.Generic;
using Cody_Portfolio_App_Core.Models;
using Cody_Portfolio_App_Core.DAO;

namespace Cody_Portfolio_App_Core.Repositories
{
    public class ProjectRepository
    {
        private ProjectDAO _projectDAO;

        private static readonly List<Project> AllProjects = new List<Project>()
        {
            new Project {Id = 1, Name = "International Space Station Tracker", ImageUrl = "https://raw.githubusercontent.com/CodyNicholson/ISS_Tracking_Project/master/flask_app/static/img/srcimg.jpg", StartDate = new DateTime(2020, 9, 1), EndDate = null, Description = "tracking the space station" },
            new Project {Id = 2, Name = "Finding Lane Lines", ImageUrl = "https://raw.githubusercontent.com/CodyNicholson/ISS_Tracking_Project/master/flask_app/static/img/srcimg.jpg", StartDate = new DateTime(2016, 11, 1), EndDate = new DateTime(2017, 1, 1), Description = "software to help self driving cars find the lane lines" },
            new Project {Id = 3, Name = "Project Tracker", ImageUrl = "https://raw.githubusercontent.com/CodyNicholson/ISS_Tracking_Project/master/flask_app/static/img/srcimg.jpg", StartDate = new DateTime(2020, 9, 1), EndDate = null, Description = "A tracker for all my personal projects" }
        };

        public Project GetProjectById(int id)
        {
            return AllProjects.FirstOrDefault(p => p.Id == id);
        }

        public Project GetFirstProject()
        {
            return GetProjectById(1);
        }
    }
}

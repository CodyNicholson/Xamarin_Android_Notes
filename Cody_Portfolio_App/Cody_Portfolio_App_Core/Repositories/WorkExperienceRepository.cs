using System;
using System.Collections.Generic;
using System.Linq;
using Cody_Portfolio_App_Core.Models;

namespace Cody_Portfolio_App_Core.Repositories
{
    public class WorkExperienceRepository
    {
        private static readonly List<WorkExperience> AllWorkExperiences = new List<WorkExperience>()
        {
            new WorkExperience { Id = 1, CompanyName = "Textura", CompanyLocation = "Deerfield, IL", Title = "Software Engineer in Test Intern", StartDate = new DateTime(2015, 6, 1), EndDate = new DateTime(2016, 4, 1), Description = "Intern testing code using Selenium Webdriver", CompanyWebsiteURL = "Textura.com" },
            new WorkExperience { Id = 2, CompanyName = "CNA", CompanyLocation = "Chicago, IL", Title = "Lead Software Engineer in Test", StartDate = new DateTime(2016, 9, 1), EndDate = new DateTime(2017, 6, 1), Description = "Led team testing code using Selenium Webdriver", CompanyWebsiteURL = "Cna.com" }
        };

        public List<WorkExperience> GetAllWorkExperiences()
        {
            return AllWorkExperiences;
        }

        public WorkExperience GetWorkExperienceById(int id)
        {
            return AllWorkExperiences.FirstOrDefault(w => w.Id == id);
        }
    }
}

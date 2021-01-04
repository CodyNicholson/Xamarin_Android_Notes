using System;
using System.Collections.Generic;
using System.Linq;
using Cody_Portfolio_App_Core.Models;

namespace Cody_Portfolio_App_Core.Repositories
{
    public class WorkExperienceRepository
    {
        private static readonly List<Skill> AllSkills = new List<Skill>()
        {
            new Skill {SkillId = 1, Name = "Kotlin", YearsOfExperience = 2 },
            new Skill {SkillId = 2, Name = "Java", YearsOfExperience = 5 },
            new Skill {SkillId = 3, Name = "Python", YearsOfExperience = 6 },
            new Skill {SkillId = 4, Name = "JavaScript", YearsOfExperience = 3 },
            new Skill {SkillId = 5, Name = "TypeScript", YearsOfExperience = 1 },
            new Skill {SkillId = 6, Name = "C#", YearsOfExperience = 2 }
        };

        private static readonly List<WorkExperience> AllWorkExperiences = new List<WorkExperience>()
        {
            new WorkExperience { WorkExperienceId = 1, CompanyName = "Textura", CompanyLocation = "Deerfield, IL", Title = "Software Engineer in Test Intern", StartDate = new DateTime(2015, 6, 1), EndDate = new DateTime(2016, 4, 1), Description = "Intern testing code using Selenium Webdriver", CompanyWebsiteURL = "Textura.com" },
            new WorkExperience { WorkExperienceId = 2, CompanyName = "CNA", CompanyLocation = "Chicago, IL", Title = "Lead Software Engineer in Test", StartDate = new DateTime(2016, 9, 1), EndDate = new DateTime(2017, 6, 1), Description = "Led team testing code using Selenium Webdriver", CompanyWebsiteURL = "Cna.com" }
        };

        public List<Skill> GetAllSkills()
        {
            return AllSkills;
        }

        public List<WorkExperience> GetAllWorkExperiences()
        {
            return AllWorkExperiences;
        }

        public Skill GetSkillById(int id)
        {
            return AllSkills.FirstOrDefault(s => s.SkillId == id);
        }

        public WorkExperience GetWorkExperienceById(int id)
        {
            return AllWorkExperiences.FirstOrDefault(w => w.WorkExperienceId == id);
        }
    }
}

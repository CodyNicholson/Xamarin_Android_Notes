using System.Collections.Generic;
using System.Linq;
using Cody_Portfolio_App_Core.Models;

namespace Cody_Portfolio_App_Core.Repositories
{
    public class SkillRepository
    {
        private static readonly List<Skill> AllSkills = new List<Skill>()
        {
            new Skill {Id = 1, Name = "Kotlin", YearsOfExperience = 2 },
            new Skill {Id = 2, Name = "Java", YearsOfExperience = 5 },
            new Skill {Id = 3, Name = "Python", YearsOfExperience = 6 },
            new Skill {Id = 4, Name = "JavaScript", YearsOfExperience = 3 },
            new Skill {Id = 5, Name = "TypeScript", YearsOfExperience = 1 },
            new Skill {Id = 6, Name = "C#", YearsOfExperience = 2 }
        };

        public List<Skill> GetAllSkills()
        {
            return AllSkills;
        }

        public Skill GetSkillById(int id)
        {
            return AllSkills.FirstOrDefault(s => s.Id == id);
        }
    }
}

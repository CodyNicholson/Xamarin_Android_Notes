# Code Sharing W/ Xamarin

We're ready to start building our app. To begin, we'll create models. However, a model is not specific to an operating system. Models can be shared among Android, iOS, and any other operating systems. So now we'll talk about Code-Sharing With Xamarin. Around 60% of the code in most applications will not be platform specific - meaning it can be shared. Sharing code can save you a tremendous amount of time because you won't have to repeat yourself while writing your code for each platform. Where will we go to share the code?

The preferred option is to use **.NET Standard** which opens a very large API that we can use for shared code. Other options include **Shared Projects** (Rarely used) and **Portable Class Libraries** (Deprecated).

The most common features to be shared among platforms/operating systems are: Models, Data Access, Services, and Service Access.

***

We'll use .NET Standard. By right-clicking on our solution in the solution explorer in Visual Studio we can then go to the "Add" menu and "Add a New Project". Search for **.NET Standard Library** as the project type. Name the project your project name with "_Core" at the end because this is going to be the "Core" shared functionality of the project. Then create the app!

In our new project we can create a "Model" folder to hold our models and we can put some models in that folder. Then we should add a "Repository" directory that will connect to our database access layer. 

***

## Models

```c#
using System;
namespace Cody_Portfolio_App_Core.Models
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public short YearsOfExperience { get; set; }
    }
}
```

```c#
using System;
namespace Cody_Portfolio_App_Core.Models
{
    public class WorkExperience
    {
        public int WorkExperienceId { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CompanyWebsiteURL { get; set; }
    }
}
```

## Repository

```c#
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
```

***

### NOTE

Don't forget to add a reference in the Xamarin.Android project to the new .NET Standard project. You do this by right-clicking the project name, then Add, then Reference, then select the "Core" project we created.

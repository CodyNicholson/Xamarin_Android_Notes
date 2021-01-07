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
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
    }
}
```

## Repository

A repository is used to make all of our database calls. In this case, we're going to use a hardcoded list of data so we can make our view quickly, but the code would be almost identical if we swapped out our hardcoded data for a database call.

```c#
using System;
using System.Linq;
using System.Collections.Generic;
using Cody_Portfolio_App_Core.Models;
using Cody_Portfolio_App_Core.DAO;

namespace Cody_Portfolio_App_Core.Repositories
{
    public class ProjectRepository
    {
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
```

## DAO

A DAO is used to encapsulate all of our data processing so that we don't mix in all that logic with the business logic of our application. DAOs help separate concerns and keep things clean. Our DAO will just do the simple action of calling the methods of our repository for now:

```c#
using Cody_Portfolio_App_Core.Models;
using Cody_Portfolio_App_Core.Repositories;

namespace Cody_Portfolio_App_Core.DAO
{
    public class ProjectDAO
    {
        private ProjectRepository _projectRepository = new ProjectRepository();

        public Project GetFirstProject()
        {
            return _projectRepository.GetFirstProject();
        }
    }
}
```

***

### NOTE

Don't forget to add a reference in the Xamarin.Android project to the new .NET Standard project. You do this by right-clicking the project name, then Add, then Reference, then select the "Core" project we created.

using Cody_Portfolio_App_Core.Models;
using Cody_Portfolio_App_Core.Repositories;

namespace Cody_Portfolio_App_Core.DAO
{
    public class ProjectDAO
    {
        private ProjectRepository _projectRepository = new ProjectRepository();
        private WorkExperienceRepository _workExperienceRepository = new WorkExperienceRepository();
        private SkillRepository _skillRepository = new SkillRepository();

        public Project GetFirstProject()
        {
            return _projectRepository.GetFirstProject();
        }
    }
}

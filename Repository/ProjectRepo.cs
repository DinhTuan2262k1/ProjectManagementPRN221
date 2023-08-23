using ProjectManagementPRN221.Models;

namespace ProjectManagementPRN221.Repository
{
    public class ProjectRepo : IRepository<Project>
    {
        public ProjectRepo(ProjectManagementContext context) : base(context)
        {
        }
    }
}

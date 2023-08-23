using ProjectManagementPRN221.Models;

namespace ProjectManagementPRN221.Repository
{
    public class StudentRepo : IRepository<Student>
    {
        public StudentRepo(ProjectManagementContext context) : base(context)
        {
        }

        public Student Get(string id)
        {
            return _context.Students.Find(id);
        }

        public Student GetStudentByAccountId(int id)
        {
            return _context.Students.Where(s => s.AccountId == id).SingleOrDefault();
        }
    }
}


using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectManagementPRN221.Models;
using System.Data;

namespace ProjectManagementPRN221.Repository
{
    public class TeamRepo : IRepository<Team>
    {
        private ProjectManagementContext _context;
        private DataProvider _provider;
        public TeamRepo(ProjectManagementContext context, DataProvider provider) : base(context)
        {
            _provider = provider;
        }

        public List<Student> getMemberTeam(int id)
        {
            List<Student> members = new List<Student>();
            string str = "select * from StudentTeam where TeamId = @teamid";
            List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@teamid", id)
                };

            DataTable dt = new DataTable();
            dt.Load(_provider.executeQuery2(str, sqlParameters.ToArray()));

            foreach (DataRow row in dt.Rows)
            {
                Student model = _context.Students.Find(row[1].ToString());

                if (model != null)
                {
                    members.Add(model);
                }
            }
            return members;
        }

        public void InsertMemberTeam(List<string> ids, int teamId)
        {
            string str = "delete from StudentTeam where TeamId = @teamId";
            List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@teamId", teamId),
                };
            _provider.ExecuteNonQuery2(str, sqlParameters.ToArray());
            foreach (string id in ids)
            {
                str = "insert into StudentTeam values(@teamId,@studentId)";
                sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@teamId", teamId),
                    new SqlParameter("@studentId", id)
                };

                _provider.ExecuteNonQuery2(str, sqlParameters.ToArray());
            }
        }
    }
}

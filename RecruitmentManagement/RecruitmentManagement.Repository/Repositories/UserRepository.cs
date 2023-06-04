using FIK.DAL;
using RecruitmentManagement.Model;
using System.Text;

namespace RecruitmentManagement.DAL.Repositories
{
    public class UserRepository : Repository
    {
       
        public UserRepository(string connection)
        {
           dbConnection = connection;
            _sql = new SQL(dbConnection);
            baseQuery = @"SELECT * FROM [USER]";
        }

        public List<User> GetList()
        {   
            List<User> users = _sql.Select<User>(baseQuery, ref msg);
            if(!string.IsNullOrEmpty(msg))
            {
                throw new Exception(msg);
            }

            return users;
        }

    }
}

using RecruitmentManagement.DAL;
using RecruitmentManagement.DAL.Repositories;
using RecruitmentManagement.Interface;
using RecruitmentManagement.Model;

namespace RecruitmentManagement.Service
{
    public class UserService : IUserService
    {
        UserRepository repository;
        public UserService() {
            repository = new UserRepository(ConnectionHelper.DefaultConnection);
        }    
        public IList<User> GetList()
        {
            return repository.GetList();
        }

      
    }
}

using RecruitmentManagement.Model;

namespace RecruitmentManagement.Interface
{
    public interface IUserService
    {
        IList<User> GetList();
    }
}

using HexagonalMinAPI.BusinessLayer.Models;

namespace HexagonalMinAPI.Core.Application
{
    public interface IUserService
    {
        UserModel GetUserById(int id);
        List<UserModel> GetAllUsers();
        void AddUser(UserModel userModel);
        void UpdateUser(UserModel userModel);
        void DeleteUser(int id);
    }
}

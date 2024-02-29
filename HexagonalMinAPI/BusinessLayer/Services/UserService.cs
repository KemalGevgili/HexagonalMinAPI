using HexagonalMinAPI.BusinessLayer.Models;
using HexagonalMinAPI.Core.Application;
using HexagonalMinAPI.Core.Domain;

namespace HexagonalMinAPI.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel GetUserById(int id)
        {
            User user = _userRepository.GetUserById(id);

            if (user != null)
            {
                return MapUserToUserModel(user);
            }

            return null;
        }

        public List<UserModel> GetAllUsers()
        {
            List<User> users = _userRepository.GetAllUsers();
            List<UserModel> userModels = new List<UserModel>();

            foreach (var user in users)
            {
                userModels.Add(MapUserToUserModel(user));
            }

            return userModels;
        }

        public void AddUser(UserModel userModel)
        {
            User user = MapUserModelToUser(userModel);
            _userRepository.AddUser(user);
        }

        public void UpdateUser(UserModel userModel)
        {
            User user = MapUserModelToUser(userModel);
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        private UserModel MapUserToUserModel(User user)
        {
            return new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname
            };
        }

        private User MapUserModelToUser(UserModel userModel)
        {
            return new User
            {
                Id = userModel.Id,
                Name = userModel.Name,
                Surname = userModel.Surname
            };
        }
    }
}

using BulletinReports.Models.UsersViewModel;

namespace BulletinReports.UIHelper
{
    public class CurrentUserrSessionDataManager
    {
        private const string ManagerId = "E132BD3C-F639-40D3-8731-639956B845D8";

        private readonly string _currentUserKey = ManagerId + "_currentUserKey";

        private readonly TempDataManager _dataManager;

        public CurrentUserrSessionDataManager(TempDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public CurrentUserViewModel GetCurrentUser(string username)
        {
            var value = (CurrentUserViewModel)_dataManager.Get(_currentUserKey);

            if (value == null)
            {
                value = UserHelper.GetUserInformation(username);
                _dataManager.AddOrUpdate(_currentUserKey, value);
            }

            return value;
        }
    }
}
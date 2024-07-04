namespace BulletinReports.UIHelper
{
    public class ServiceRequestInformationDataManager
    {
        private const string ManagerId = "D44B5025-B9DC-4C6A-8C14-9E5D5D4BC43E";

        private readonly TempDataManager _dataManager;

        public ServiceRequestInformationDataManager(TempDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        #region RequestNumber
        private string _requestNumberKey = ManagerId + "_ReqeustNumber";
        public string RequestNumber
        {
            get
            {
                return (string)_dataManager.Get(_requestNumberKey);
            }
            set
            {
                _dataManager.AddOrUpdate(_requestNumberKey, value);
            }
        }
        #endregion
    }
}
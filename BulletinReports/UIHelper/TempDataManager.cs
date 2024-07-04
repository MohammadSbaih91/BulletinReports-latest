using System.Web.Mvc;

namespace BulletinReports.UIHelper
{
    public class TempDataManager
    {
        private readonly Controller _controller;

        public TempDataManager(Controller controller)
        {
            _controller = controller;
        }

        public void AddOrUpdate(string key, object value, bool usableOnlyInThisRequest = true)
        {
            if (_controller.TempData.ContainsKey(key))
            {
                _controller.TempData[key] = value;
            }
            else
            {
                _controller.TempData.Add(key, value);
            }

            if (usableOnlyInThisRequest)
            {
                var val = _controller.TempData[key]; // read the value once to be deleted on the end of the http reqeust
            }
        }

        public object Get(string key)
        {
            if (_controller.TempData.ContainsKey(key))
                return _controller.TempData[key];
            return null;
        }
    }
}
using System;
using System.Collections.Generic;

namespace BulletinReports.PagedList.UIHelper
{
    public class PagedListModel<T> : List<T>, IPagedListModel
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public string UrlStringFormat { get; set; }
        public string ItemId { get; set; }


        public int TotalPages
        {
            get { return TotalItems <= 0 ? 0 : (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }

        public List<T> ItemsList
        {
            get
            {
                return base.GetRange(0, base.Count);
            }
            set
            {
                base.Clear();
                base.AddRange(value);
            }
        }
    }
}
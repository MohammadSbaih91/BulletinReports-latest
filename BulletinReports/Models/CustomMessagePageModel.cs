namespace BulletinReports.Models
{
    public class CustomMessagePageModel
    {
        // TODO: convert onto HTMLString 
        //  HTMLString: Represents an HTML-encoded string that should not be encoded again.
        //public HtmlString Message { get; set; }
        public string Message { get; set; }
        public bool HasButton { get; set; }
        public string ButtonLabel { get; set; }
        public string ButtonLink { get; set; }
    }
}
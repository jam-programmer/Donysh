namespace Application.ViewModels.Ui.Home
{
    public class RequestInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public List<string> Services { get; set; }

        public RequestInfo()
        {
            Services = new List<string>();
        }
    }
}

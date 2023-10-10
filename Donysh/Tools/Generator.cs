namespace Donysh.Tools
{
    public class Generator
    {
        private readonly IHttpContextAccessor _accessor;
        public Generator(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public string UrlSite()
        {
            var request = _accessor.HttpContext?.Request;
            var baseUrl = $"{request?.Scheme}://{request?.Host}";
            return baseUrl;
        }
    }
}

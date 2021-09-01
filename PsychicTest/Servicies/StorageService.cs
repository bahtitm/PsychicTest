using Microsoft.AspNetCore.Http;

namespace PsychicTest.Servicies
{
    public class StorageService : IStorageService
    {
      
        private readonly IHttpContextAccessor httpContextAccessor;

        public StorageService(IHttpContextAccessor httpContextAccessor)
        {
             this.httpContextAccessor = httpContextAccessor;
        }
        public T GetFromStorge<T>(string key)
        {
            return httpContextAccessor.HttpContext.Session.GetObjectFromJson<T>(key);
        }

        public void SetIntoStorge(string key, object value)
        {
            httpContextAccessor.HttpContext.Session.SetObjectAsJson(key, value);
        }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicTest.Servicies
{
    public class StorageService : IStorageService
    {
        private readonly ISession session;
        private readonly IHttpContextAccessor httpContextAccessor;

        public StorageService(IHttpContextAccessor httpContextAccessor)
        {
           // this.session = session;
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

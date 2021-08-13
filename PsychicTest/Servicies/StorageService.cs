using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicTest.Servicies
{
    public class StorageService : IStorageServise
    {
        private readonly ISession session;

        public StorageService(ISession session)
        {
            this.session = session;
        }
      

        public T GetFromStorge<T>(string key)
        {
            return session.GetObjectFromJson<T>(key);
        }

        public void SetIntoStorge(string key, object value)
        {
            session.SetObjectAsJson(key, value);
        }
    }
}

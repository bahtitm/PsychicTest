using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicTest.Servicies
{
    public interface IStorageService
    {
        void SetIntoStorge(string key, object value);
        
        T GetFromStorge<T>(string key);
    }
}

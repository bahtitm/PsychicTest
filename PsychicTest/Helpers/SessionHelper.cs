using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace PsychicTest.Helpers
{
    public static class SessionHelper
    {

        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            var SerializerSettings = new JsonSerializerSettings()
            {

                NullValueHandling = NullValueHandling.Ignore,
               
                

            };          

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value,SerializerSettings);
        }


    }
}

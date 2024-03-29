﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace PsychicTest.Servicies
{
    public static class SessionExtension
    {

        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new IncludePrivateStateContractResolver();
           
            return value == null ? default : JsonConvert.DeserializeObject<T>(value,serializerSettings);
        }
    }
}

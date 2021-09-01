﻿using System.Linq;
using System.Reflection;

namespace PsychicTest.Servicies
{
    public static class TypeExtensions
    {
        public static bool HasSetter(this PropertyInfo property)
        {
            //In this way we can check for private setters in base classes
            return property.DeclaringType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                                         .Any(m => m.Name == "set_" + property.Name);
        }

        public static bool HasGetter(this PropertyInfo property)
        {
            //In this way we can check for private getters in base classes
            return property.DeclaringType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                                         .Any(m => m.Name == "get_" + property.Name);
        }
    }
}

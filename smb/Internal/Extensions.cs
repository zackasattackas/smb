using System;
using System.Reflection;

namespace BananaHomie.Smb.Internal
{
    internal static class Extensions
    {
        public static bool IsDefined<T>(this MemberInfo member) where T : Attribute
        {
            return member.IsDefined(typeof(T));
        }
    }
}
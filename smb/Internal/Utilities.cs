using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BananaHomie.Smb.Management;

namespace BananaHomie.Smb.Internal
{
    internal class Utilities
    {
        public static void Print(string value, bool newLine = true, ConsoleColor? color = default)
        {
            ConsoleColor? currentColor = null;

            if (color.HasValue)
            {
                currentColor = Console.ForegroundColor;
                Console.ForegroundColor = color.Value;
            }

            if (newLine)
                value += "\r\n";

            Console.Out.Write(value);

            if (currentColor.HasValue)
                Console.ForegroundColor = currentColor.Value;
        }
    }

    internal static class Extensions
    {
        public static bool IsDefined<T>(this MemberInfo member) where T : Attribute
        {
            return member.IsDefined(typeof(T));
        }
    }
}

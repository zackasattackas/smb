using System;
using System.Management;
using System.Net;

namespace BananaHomie.Smb.Management
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ManagementObjectAttribute : Attribute
    {
        public ManagementObjectAttribute(string className)
        {
            ClassName = className;
        }

        public string Namespace { get; set; }
        public string ClassName { get; set; }

        public ObjectQuery GetQuery()
        {
            return new ObjectQuery($"SELECT * FROM {ClassName}");
        }

        public ManagementScope GetScope(string computerName = ".", NetworkCredential credentials = default)
        {
            var options = computerName == "."
                ? default
                : new ConnectionOptions
                {
                    Username = credentials?.UserName,
                    Password = credentials?.Password
                };

            return new ManagementScope(Namespace, options);
        }
    }
}
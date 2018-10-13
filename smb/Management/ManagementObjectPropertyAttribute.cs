using System;

namespace BananaHomie.Smb.Management
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ManagementObjectPropertyAttribute : Attribute
    {
        public ManagementObjectPropertyAttribute()
        {            
        }
        public ManagementObjectPropertyAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
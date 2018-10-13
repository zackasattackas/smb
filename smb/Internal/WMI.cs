using System;
using System.Linq;
using System.Management;
using System.Reflection;
using BananaHomie.Smb.Management;

namespace BananaHomie.Smb.Internal
{
    internal static class WMI
    {
        public static ManagementObjectCollection Query(ObjectQuery query, ManagementScope scope)
        {
            using (var searcher = new ManagementObjectSearcher(scope, query))
                return searcher.Get();
        }

        public static T Bind<T>(ManagementObject o) where T : IManagementObjectWrapper
        {
            if (!typeof(T).IsDefined(typeof(ManagementObjectAttribute)))
                throw new ArgumentException("{T} must define the ManagementObjectAttribute attribute.");

            var instance = (T) Activator.CreateInstance(typeof(T));
            var members = typeof(T).GetMembers().Where(m => m.IsDefined(typeof(ManagementObjectPropertyAttribute)));

            foreach (var member in members)
            {
                if (member.Name == "BaseObject")
                {
                    ((PropertyInfo) member).SetValue(instance, o);
                    continue;
                }

                var mgmtPropertyAttr = member.GetCustomAttribute<ManagementObjectPropertyAttribute>();
                var mgmtPropertyValue = o.GetPropertyValue(mgmtPropertyAttr.Name ?? member.Name);

                switch (member)
                {
                    case FieldInfo field:
                        field.SetValue(instance, mgmtPropertyValue);
                        break;
                    case PropertyInfo property:
                        property.SetValue(instance, mgmtPropertyValue);
                        break;
                }
            }

            return instance;
        }
    }
}
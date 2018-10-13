using System.Management;

namespace BananaHomie.Smb.Management
{
    public interface IManagementObjectWrapper
    {
        ManagementObject BaseObject { get; }
    }
}
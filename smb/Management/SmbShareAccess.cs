using System.Collections.Generic;

namespace BananaHomie.Smb.Management
{
    public class SmbShareAccess
    {
        public List<string> FullAccess { get; set; }
        public List<string> ChangeAccess { get; set; }
        public List<string> ReadAccess { get; set; }
        public List<string> NoAccess { get; set; }
        public string SecurityDescriptor { get; set; }
    }
}
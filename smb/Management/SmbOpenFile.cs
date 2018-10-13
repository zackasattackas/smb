using System;
using System.Collections.Generic;

namespace BananaHomie.Smb.Management
{
    [ManagementObject("MSFT_SmbOpenFile", Namespace = "Root\\Microsoft\\Windows\\Smb")]
    public class SmbOpenFile
    {
        public static IEnumerable<SmbOpenFile> EnumerateInstances()
        {
            throw new NotImplementedException();
        }
    }
}
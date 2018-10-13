using System;
using System.Collections.Generic;

namespace BananaHomie.Smb.Management
{
    [ManagementObject("MSFT_SmbShare", Namespace = "Root\\Microsoft\\Windows\\Smb")]
    public class SmbShare
    {
        public static IEnumerable<SmbShare> EnumerateInstances()
        {
            throw new NotImplementedException();
        }
    }
}
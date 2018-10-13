namespace BananaHomie.Smb.Management
{
    public class SmbShareCreationOptions
    {
        public uint ConcurrentUserLimit { get; set; }
        public FolderEnumerationMode FolderEnumerationMode { get; set; }
        public CachingMode CachingMode { get; set; }
        public bool IsTemporary { get; set; }
        public bool IsContinuouslyAvailable { get; set; }
        public uint CATimeout { get; set; }
        public bool EncryptData { get; set; }
        public SmbShareAccess AccessControl { get; set; }
    }
}
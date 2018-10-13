namespace BananaHomie.Smb.Management
{
    public enum CachingMode : uint
    {
        None = 0,
        Manual = 1,
        Documents = 2,
        Programs = 3,
        BranchCache = 4,
        Unknown = 5
    }
}
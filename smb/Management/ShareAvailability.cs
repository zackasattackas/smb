namespace BananaHomie.Smb.Management
{
    public enum ShareAvailability : uint
    {
        NonClustered = 0,
        Clustered = 1,
        ScaleOut = 2,
        ClusterSharedVolume = 3,
        DFS = 4
    }
}
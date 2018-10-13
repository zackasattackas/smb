namespace BananaHomie.Smb.Management
{
    public enum ShareType : uint
    {
        FileSystem = 0,
        PrintQueue = 1,
        CommunicationDevice = 2,
        IPC = 3,
        Unknown = 4,
    }
}
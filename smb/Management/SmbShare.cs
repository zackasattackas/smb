using System;
using BananaHomie.Smb.Internal;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Management;
using System.Net;
using System.Reflection;

namespace BananaHomie.Smb.Management
{
    [ManagementObject("MSFT_SmbShare", Namespace = "Root\\Microsoft\\Windows\\Smb")]
    public class SmbShare : IManagementObjectWrapper
    {
        #region Properties

        [UsedImplicitly]
        public ManagementObject BaseObject { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public ShareAvailability AvailabilityType { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public CachingMode CachingMode { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public uint CATimeout { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public uint ConcurrentUserLimit { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public bool ContinuouslyAvailable { get; private set; }

        [UsedImplicitly]
        [TableColumn("Users", 5, Order = 3)]
        [ManagementObjectProperty]
        public uint CurrentUsers { get; private set; }

        [UsedImplicitly]
        [TableColumn("Desc.", -25, Order = 1)]
        [ManagementObjectProperty]
        public string Description { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public bool EncryptData { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public FolderEnumerationMode FolderEnumerationMode { get; private set; }

        [UsedImplicitly]
        [TableColumn("Name", -20, Order = 0)]
        [ManagementObjectProperty]
        public string Name { get; private set; }

        [UsedImplicitly]
        [TableColumn("Path", -30, Order = 1)]
        [ManagementObjectProperty]
        public string Path { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public bool Scoped { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public string ScopeName { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public string SecurityDescriptor { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public bool ShadowCopy { get; private set; }

        [UsedImplicitly]
        [TableColumn("State", -7, Order = 5)]
        [ManagementObjectProperty]
        public ShareState ShareState { get; set; }

        [UsedImplicitly]
        [TableColumn("Type", -12, Order = 4)]
        [ManagementObjectProperty]
        public ShareType ShareType { get; set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public SmbInstance SmbInstance { get; set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public bool Special { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public bool Temporary { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public string Volume { get; private set; }

        #endregion

        #region Static methods

        public static IEnumerable<SmbShare> EnumerateInstances(
            string computerName = ".",
            NetworkCredential credentials = default)
        {
            var classInfo = typeof(SmbShare).GetCustomAttribute<ManagementObjectAttribute>();

            foreach (var o in WMI.Query(classInfo.GetQuery(), classInfo.GetScope(computerName, credentials)))
                yield return WMI.Bind<SmbShare>((ManagementObject) o);
        }

        public static SmbShare Create(string name, string scope, string path, string description, SmbShareCreationOptions options)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Public methods

        public int Block(List<string> accounts)
        {
            throw new NotImplementedException();
        }

        public int Unblock(List<string> accounts)
        {
            throw new NotImplementedException();
        }

        public int Grant(List<string> accounts, int accessRights)
        {
            throw new NotImplementedException();
        }

        public int Revoke(List<string> accounts, int accessRights)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
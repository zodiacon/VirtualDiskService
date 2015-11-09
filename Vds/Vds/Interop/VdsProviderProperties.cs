using System;
using System.Runtime.InteropServices;

namespace Vds.Interop {
	public enum VdsProviderType : uint {
		Unknown = 0,
		Software = 1,
		hardware = 2,
		VirtualDisk = 3,
		Max = 4
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct VdsProviderProperties {
		public Guid Id;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Name;
		public Guid VersionId;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Version;
		public VdsProviderType Type;
		public uint Flags;
		public uint StripSizeFlags;
		public short RebuildPriority;
	}
}
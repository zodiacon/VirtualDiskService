using System;
using System.Runtime.InteropServices;

namespace Vds.Interop {
	[Flags]
	public enum VdsServiceFlags : uint {
		SupportDynamic				= 1,
		SupportFaultTolerant		= 2,
		SupportGpt					= 4,
		SupportDynamic1394			= 8,
		ClusterServiceConfigured	= 0x10,
		AutoMountOff				= 0x20,
		OSUninstallValid			= 0x40,
		EFI							= 0x80,
		SupportMirror				= 0x100,
		SupportRaid5				= 0x200,
		SupportRefs					= 0x400
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct VdsServiceProperties {
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Version;
		public VdsServiceFlags Flags;
	}
}
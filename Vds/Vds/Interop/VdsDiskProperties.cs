using System;
using System.Runtime.InteropServices;

namespace Vds.Interop {
	public enum VdsDiskStatus {
		Unknown = 0,
		Online = 1,
		NotReady = 2,
		NoMedia = 3,
		Failed = 5,
		Missing = 6,
		Offline = 4
	}

	public enum VdsLunReserveMode {
		None = 0,
		ExclusiveReadWrite = 1,
		ExlcusiveRead = 2,
		SharedReadOnly = 3,
		SharedReadWrite = 4
	}

	public enum VdsHealth {
		Unknown = 0,
		Healthy = 1,
		Rebuilding = 2,
		Stale = 3,
		Failing = 4,
		FailingRedundancy = 5,
		FailedRedundancy = 6,
		FailedRedundancyFailing = 7,
		Failed = 8,
		Replaced = 9,
		PendingFailure = 10,
		Degraded = 11
	}

	public enum VdsPartitionStyle {
		Unknown = 0,
		MBR = 1,
		GPT = 2
	}

	public enum VdsStorageBusType {
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct VdsDiskProperties {
		[FieldOffset(0)] public Guid Id;
		[FieldOffset(16)] public VdsDiskStatus Status;
		[FieldOffset(20)] public VdsLunReserveMode ReserveMode;
		[FieldOffset(24)] public VdsHealth Health;
		[FieldOffset(28)] public uint DeviceType;
		[FieldOffset(32)] public uint MediaType;
		[FieldOffset(36)] public ulong Size;
		[FieldOffset(44)] public uint BytesPerSector;
		[FieldOffset(48)] public uint SectorsPerTrack;
		[FieldOffset(52)] public uint TracksPerCylinder;
		[FieldOffset(56)] public uint Flags;
		[FieldOffset(60)] public VdsStorageBusType BusType;
		[FieldOffset(64)] public VdsPartitionStyle partitionStyle;

		[FieldOffset(68)] public uint Signature;
		[FieldOffset(68)] public Guid DiskGuid;

		[FieldOffset(84), MarshalAs(UnmanagedType.LPWStr)] public string DiskAddress;
#if X86
		[FieldOffset(88), MarshalAs(UnmanagedType.LPWStr)] public string Name;
		[FieldOffset(92), MarshalAs(UnmanagedType.LPWStr)] public string FriendlyName;
		[FieldOffset(96), MarshalAs(UnmanagedType.LPWStr)] public string AdaptorName;
		[FieldOffset(100), MarshalAs(UnmanagedType.LPWStr)] public string DevicePath;
#else
		[FieldOffset(90), MarshalAs(UnmanagedType.LPWStr)] public string Name;
		[FieldOffset(96), MarshalAs(UnmanagedType.LPWStr)] public string FriendlyName;
		[FieldOffset(102), MarshalAs(UnmanagedType.LPWStr)] public string AdaptorName;
		[FieldOffset(108), MarshalAs(UnmanagedType.LPWStr)] public string DevicePath;
#endif
	}
}
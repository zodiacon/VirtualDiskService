using System;
using System.Runtime.InteropServices;

namespace Vds.Interop {
	public enum VdsVolumeType {
		Unknown = 0,
		Simple = 10,
		Span = 11,
		Stripe = 12,
		Mirror = 13,
		Parity = 14
	}

	public enum VdsVolumeStatus {
		Unknown = 0,
		Online = 1,
		NoMedia = 3,
		Failed = 5,
		Offline = 4
	}

	public enum VdsTransitionState {
		Unknown = 0,
		Stable = 1,
		Extending = 2,
		Shrinking = 3,
		Reconfiging = 4,
		Restriping = 5
	}

	public enum VdsFileSystemType {
		Unknown = 0,
		RAW,
		FAT,
		FAT32,
		NTFS,
		CDFS,
		UDF,
		EXFAT,
		CSVFS,
		REFS
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct VdsVolumeProperties {
		public Guid Id;
		public VdsVolumeType Type;
		public VdsVolumeStatus Status;
		public VdsHealth Health;
		public VdsTransitionState TransitionState;
		public ulong Size;
		public uint Flags;
		public VdsFileSystemType RecommendedFileSystemType;
		[MarshalAs(UnmanagedType.LPWStr)] public string Name; 
	}
}
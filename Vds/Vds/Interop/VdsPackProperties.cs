using System;
using System.Runtime.InteropServices;

namespace Vds.Interop {

	public enum VdsPackStatus {
		Unknown		= 0,
		Online		= 1,
		Offline		= 4
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct VdsPackProperties {
		public Guid Id;
		[MarshalAs(UnmanagedType.LPWStr)] public string Name;
		public VdsPackStatus Status;
		public uint Flags;
	}
}
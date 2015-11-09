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

	[StructLayout(LayoutKind.Sequential)]
	public struct VdsDiskProperties {
		public Guid Id;
		public VdsDiskStatus Status;
		public VdsLunReserveMode ReserveMode;
		public VdsHealth Health;
	}
}
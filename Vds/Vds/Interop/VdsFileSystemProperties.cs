using System;

namespace Vds.Interop {
	public class VdsFileSystemProperties {
		public VdsFileSystemType Type;
		public Guid VolumeId;
		public uint Flags;
		public ulong TotalAllocationUnits;
		public ulong AvailableAllocationUnits;
		public uint AllocationUnitSize;
	}
}
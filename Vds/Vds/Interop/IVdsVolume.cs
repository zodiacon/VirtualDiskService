using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Vds.Interop {
	[ComImport, Guid("88306bb2-e71f-478c-86a2-79da200a0f11"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVdsVolume {
		[PreserveSig]
		int GetProperties(out VdsVolumeProperties properties);

		[PreserveSig]
		int GetPack(out IVdsPack pack);

		[PreserveSig]
		int QueryPlexes(out IEnumVdsObject plexEnumerator);
	}
}

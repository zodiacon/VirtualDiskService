using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Vds.Interop {
	[ComImport, Guid("e0393303-90d4-4a97-ab71-e9b671ee2729"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVdsServiceLoader {
		[PreserveSig]
		int LoadService([In, MarshalAs(UnmanagedType.LPWStr)] string machineName, out IVdsService vdsService);
	}
}

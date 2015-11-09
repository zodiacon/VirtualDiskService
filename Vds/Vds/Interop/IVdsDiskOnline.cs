using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Vds.Interop {
	[ComImport, Guid("90681B1D-6A7F-48e8-9061-31B7AA125322"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVdsDiskOnline {
		[PreserveSig]
		int Online();

		[PreserveSig]
		int Offline();
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Vds.Interop {
	[ComImport, Guid("07e5c822-f00c-47a1-8fce-b244da56fd06"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVdsDisk {
		[PreserveSig]
		int GetProperties(out VdsDiskProperties properties);

		[PreserveSig]
		int GetPack(out IVdsPack pack);

		//[PreserveSig]
		//int GetIdentificationData(out VdsLunInformation data);

		
	}
}

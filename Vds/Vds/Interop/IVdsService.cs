using System.Runtime.InteropServices;

namespace Vds.Interop {
	[ComImport, Guid("0818a8ef-9ba9-40d8-a6f9-e22833cc771e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVdsService {
		[PreserveSig]
		int IsServiceReady();
		[PreserveSig]
		int WaitForServiceReady();

	}
}
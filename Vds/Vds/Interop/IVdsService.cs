using System.Runtime.InteropServices;

namespace Vds.Interop {
	public enum VdsProviderMask : uint {
		Software = 1,
		Hardware = 2,
		VirtualDisk = 4
	}

	[ComImport, Guid("0818a8ef-9ba9-40d8-a6f9-e22833cc771e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVdsService {
		[PreserveSig]
		int IsServiceReady();
		[PreserveSig]
		int WaitForServiceReady();

		[PreserveSig]
		int GetProperties(out VdsServiceProperties properties);

		[PreserveSig]
		int QueryProviders(VdsProviderMask mask, out IEnumVdsObject providerEnumerator);
	}
}
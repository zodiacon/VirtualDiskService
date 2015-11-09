using System.Runtime.InteropServices;

namespace Vds.Interop {
	[ComImport, Guid("10c5e575-7984-4e81-a56b-431f5f92ae42"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVdsProvider {
		[PreserveSig]
		int GetProperties(out VdsProviderProperties properties);
	}
}
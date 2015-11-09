using System.Runtime.InteropServices;

namespace Vds.Interop {
	[ComImport, Guid("3b69d7f5-9d94-4648-91ca-79939ba263bf"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVdsPack {
		[PreserveSig]
		int GetProperties(out VdsPackProperties properties);

		[PreserveSig]
		int GetProvider(out IVdsProvider provider);

		[PreserveSig]
		int QueryVolumes(out IEnumVdsObject volumesEnumerator);

		[PreserveSig]
		int QueryDisks(out IEnumVdsObject disksEnumerator);

	}
}
using System.Runtime.InteropServices;

namespace Vds.Interop {
	[ComImport, Guid("118610b7-8d94-4030-b5b8-500889788e4e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumVdsObject {
		[PreserveSig]
		int Next(int count, [MarshalAs(UnmanagedType.IUnknown)] out object iface, out int fetched);
		
		[PreserveSig]
		int Skip(int count);
		
		[PreserveSig]
		int Reset();
		
		[PreserveSig]
		int Clone(out IEnumVdsObject clonedEnumerator); 
	}
}
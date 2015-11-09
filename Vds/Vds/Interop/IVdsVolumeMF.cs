using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Vds.Interop {
	[ComImport, Guid("ee2d5ded-6236-4169-931d-b9778ce03dc6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVdsVolumeMF {
		[PreserveSig]
		int GetFileSystemProperties(out VdsFileSystemProperties properties);

		[PreserveSig]
		int Format(VdsFileSystemType type, [MarshalAs(UnmanagedType.LPWStr)] string label, uint unitAllocationSize,
			[MarshalAs(UnmanagedType.Bool)] bool force, [MarshalAs(UnmanagedType.Bool)] bool quickFormat,
			[MarshalAs(UnmanagedType.Bool)] bool enableCompression, out IVdsAsync operation);

		[PreserveSig]
		int AddAccessPath([MarshalAs(UnmanagedType.LPWStr)] string accessPath);

		[PreserveSig]
		int QueryAccessPaths([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] out string[] paths, out int count);
		
		[PreserveSig]
		int QueryReparsePoints();		// TODO
		
		[PreserveSig] 
		int DeleteAccessPath([MarshalAs(UnmanagedType.LPWStr)] string accessPath);

		[PreserveSig]
		int Mount();

		[PreserveSig]
		int Dismount([MarshalAs(UnmanagedType.Bool)] bool force, [MarshalAs(UnmanagedType.Bool)] bool permanent);

		[PreserveSig]
		int SetFileSystemFlags(uint flags);

		[PreserveSig]
		int ClearFileSystemFlags(uint flags);
	}
}

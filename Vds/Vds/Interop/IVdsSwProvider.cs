using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Vds.Interop {
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("9aa58360-ce33-4f92-b658-ed24b14425b8")]
	public interface IVdsSwProvider {
		[PreserveSig]
		int QueryPacks(out IEnumVdsObject packEnumerator);

		[PreserveSig]
		int CreatePack(out IVdsPack pack);
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vds.Interop;

namespace Vds {
	public static class VdsService {
		public static IVdsService Create(string computerName = null) {
			var vdsLoader = (IVdsServiceLoader)new VdsServiceLoader();
			IVdsService vdsService;
			int hr = vdsLoader.LoadService(computerName, out vdsService);
			Marshal.ThrowExceptionForHR(hr);

			hr = vdsService.WaitForServiceReady();
			Marshal.ThrowExceptionForHR(hr);

			return vdsService;
		}

	}
}

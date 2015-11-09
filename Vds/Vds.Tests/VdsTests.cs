using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vds.Interop;

namespace Vds.Tests {
	[TestClass]
	public class VdsTests {
		[TestMethod]
		public void TestLoader() {
			var vdsLoader = (IVdsServiceLoader)new VdsServiceLoader();
			IVdsService vdsService;
			int hr = vdsLoader.LoadService(null, out vdsService);
			Marshal.ThrowExceptionForHR(hr);
			hr = vdsService.WaitForServiceReady();
			Marshal.ThrowExceptionForHR(hr);
		}
	}
}

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vds.Interop;

namespace Vds.Tests {
	[TestClass]
	public class VdsTests {
		IVdsService CreateVdsService() {
			var vdsLoader = (IVdsServiceLoader)new VdsServiceLoader();
			IVdsService vdsService;
			int hr = vdsLoader.LoadService(null, out vdsService);
			Marshal.ThrowExceptionForHR(hr);

			hr = vdsService.WaitForServiceReady();
			Marshal.ThrowExceptionForHR(hr);

			return vdsService;
		}

		[TestMethod]
		public void TestLoader() {
			var vdsService = CreateVdsService();

			VdsServiceProperties properties;
			int hr = vdsService.GetProperties(out properties);
			Marshal.ThrowExceptionForHR(hr);

		}


		[TestMethod]
		public void TestProviders() {
			var vdsService = CreateVdsService();
			IEnumVdsObject providerEnum;
			int hr = vdsService.QueryProviders(VdsProviderMask.Hardware | VdsProviderMask.Software | VdsProviderMask.VirtualDisk, out providerEnum);
			Marshal.ThrowExceptionForHR(hr);

			object iface;
			int fetched;
			while(0 == providerEnum.Next(1, out iface, out fetched)) {
				var provider = iface as IVdsProvider;
				VdsProviderProperties properties;
				provider.GetProperties(out properties);
				Debug.WriteLine($"{properties.Name} {properties.Id}");

                var swProvider = iface as IVdsSwProvider;
				if(swProvider != null) {
					IEnumVdsObject packEnum;
					Marshal.ThrowExceptionForHR(swProvider.QueryPacks(out packEnum));

					EnumPacks(packEnum);
				}
			}
		}

		private void EnumPacks(IEnumVdsObject packEnum) {
			object iface;
			int fetched;
			while(0 == packEnum.Next(1, out iface, out fetched)) {
				var pack = iface as IVdsPack;
				IEnumVdsObject diskEnum;
				Marshal.ThrowExceptionForHR(pack.QueryDisks(out diskEnum));

				EnumDisks(diskEnum);

				IEnumVdsObject volumeEnum;
				Marshal.ThrowExceptionForHR(pack.QueryVolumes(out volumeEnum));
				EnumVolumes(volumeEnum);
			}
		}

		private void EnumVolumes(IEnumVdsObject volumeEnum) {
			object iface;
			int fetched;
			while(0 == volumeEnum.Next(1, out iface, out fetched)) {
				var volume = iface as IVdsVolume;
				VdsVolumeProperties properties;
				Marshal.ThrowExceptionForHR(volume.GetProperties(out properties));

				var volumeMF = volume as IVdsVolumeMF;
			}
		}

		private void EnumDisks(IEnumVdsObject diskEnum) {
			object iface;
			int fetched;
			while(0 == diskEnum.Next(1, out iface, out fetched)) {
				var disk = iface as IVdsDisk;
				VdsDiskProperties properties;
				Marshal.ThrowExceptionForHR(disk.GetProperties(out properties));

				Debug.WriteLine($"{properties.FriendlyName} {properties.DiskGuid} {properties.Status}");

            }  
		}
	}
}

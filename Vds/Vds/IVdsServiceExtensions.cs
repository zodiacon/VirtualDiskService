using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vds.Interop;

namespace Vds {
	public static class IVdsServiceExtensions {
		public static IEnumerator<IVdsDisk> GetDisks(this IVdsService vdsService, VdsProviderMask providerMask = VdsProviderMask.Software) {

			foreach(var pack in vdsService.GetPacks(providerMask)) {
				IEnumVdsObject diskEnum;
				Marshal.ThrowExceptionForHR(pack.QueryDisks(out diskEnum));
				object iface;
				int fetched;

				while(0 == diskEnum.Next(1, out iface, out fetched)) {
					yield return iface as IVdsDisk;
				}
			}
		}

		public static IEnumerable<IVdsProvider> GetProviders(this IVdsService vdsService, VdsProviderMask providerMask = VdsProviderMask.Software) {
			IEnumVdsObject providerEnum;
			int hr = vdsService.QueryProviders(providerMask, out providerEnum);
			Marshal.ThrowExceptionForHR(hr);

			object iface;
			int fetched;
			while(0 == providerEnum.Next(1, out iface, out fetched)) {
				yield return iface as IVdsProvider;
			}
		}

		public static IEnumerable<IVdsPack> GetPacks(this IVdsService vdsService, VdsProviderMask providerMask = VdsProviderMask.Software) {
			foreach(var provider in vdsService.GetProviders(providerMask)) {
				var swProvider = provider as IVdsSwProvider;
				if(swProvider != null) {
					IEnumVdsObject packEnum;
					Marshal.ThrowExceptionForHR(swProvider.QueryPacks(out packEnum));
					object iface;
					int fetched;
					while(0 == packEnum.Next(1, out iface, out fetched)) {
						yield return iface as IVdsPack;
					}
				}
			}
		}

		public static IEnumerable<IVdsVolume> GetVolumes(this IVdsService vdsService, VdsProviderMask providerMask = VdsProviderMask.Software) {
			foreach(var pack in vdsService.GetPacks(providerMask)) {
				IEnumVdsObject volumeEnum;
				pack.QueryVolumes(out volumeEnum);
				object iface;
				int fetched;
				while(0 == volumeEnum.Next(1, out iface, out fetched)) {
					yield return iface as IVdsVolume;
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vds.Interop;

namespace Vds {
	public class PackData {
		public IEnumerable<IVdsDisk> Disks { get; internal set; }
		public IEnumerable<IVdsVolume> Volumes { get; internal set; }
	}

	public static class IVdsPackExtensions {
		public static PackData GetDisksAndVolumes(this IVdsPack pack) {
			return new PackData {
				Disks = pack.GetDisks(),
				Volumes = pack.GetVolumes()
			};
		}

		public static IEnumerable<IVdsDisk> GetDisks(this IVdsPack pack) {
			IEnumVdsObject diskEnum;
			Marshal.ThrowExceptionForHR(pack.QueryDisks(out diskEnum));
			object iface;
			int fetched;

			var disks = new List<IVdsDisk>();
			while(0 == diskEnum.Next(1, out iface, out fetched)) {
				yield return iface as IVdsDisk;
			}
		}

		public static IEnumerable<IVdsVolume> GetVolumes(this IVdsPack pack) {
			IEnumVdsObject volumeEnum;
			Marshal.ThrowExceptionForHR(pack.QueryVolumes(out volumeEnum));

			object iface;
			int fetched;
			while(0 == volumeEnum.Next(1, out iface, out fetched)) {
				yield return iface as IVdsVolume;
			}
		}
	}
}

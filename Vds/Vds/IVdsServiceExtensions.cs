using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vds.Interop;

namespace Vds
{
	public static class IVdsServiceExtensions
	{
		public static ICollection<IVdsDisk> GetDisks(this IVdsService vdsService, VdsProviderMask providerMask = VdsProviderMask.Software)
		{
			IEnumVdsObject providerEnum;
			int hr = vdsService.QueryProviders(providerMask, out providerEnum);
			Marshal.ThrowExceptionForHR(hr);

			var disks = new List<IVdsDisk>();

			object iface;
			int fetched;
			while (0 == providerEnum.Next(1, out iface, out fetched))
			{
				var swProvider = iface as IVdsSwProvider;
				if (swProvider != null)
				{
					IEnumVdsObject packEnum;
					Marshal.ThrowExceptionForHR(swProvider.QueryPacks(out packEnum));

					while (0 == packEnum.Next(1, out iface, out fetched))
					{
						disks.AddRange(GetDisks(iface as IVdsPack));
					}

				}
			}
			return disks;
		}

		public static ICollection<IVdsDisk> GetDisks(this IVdsPack pack)
		{
			IEnumVdsObject diskEnum;
			Marshal.ThrowExceptionForHR(pack.QueryDisks(out diskEnum));

			object iface;
			int fetched;
			var disks = new List<IVdsDisk>();
			while (0 == diskEnum.Next(1, out iface, out fetched))
			{
				var disk = iface as IVdsDisk;
				Debug.Assert(disk != null);
				disks.Add(disk);
			}
			return disks;
		}
	}
}

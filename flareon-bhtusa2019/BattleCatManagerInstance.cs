using System;
using System.Collections.Generic;
using System.Linq;

namespace MemeCatBattlestation
{
	// Token: 0x02000002 RID: 2
	public static class BattleCatManagerInstance
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static byte[] InitializeBattleCat(byte[] cat, byte[] data)
		{
			return BattleCatManagerInstance.AssignFelineDesignation(cat, data).ToArray<byte>();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002060 File Offset: 0x00000260
		private static byte[] InvertCosmicConstants(byte[] cat)
		{
			byte[] array = (from i in Enumerable.Range(0, 256)
			select (byte)i).ToArray<byte>();
			int j = 0;
			int num = 0;
			while (j < 256)
			{
				num = (num + (int)cat[j % cat.Length] + (int)array[j] & 255);
				BattleCatManagerInstance.CatFact(array, j, num);
				j++;
			}
			return array;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020D4 File Offset: 0x000002D4
		private static IEnumerable<byte> AssignFelineDesignation(byte[] cat, IEnumerable<byte> data)
		{
			byte[] s = BattleCatManagerInstance.InvertCosmicConstants(cat);
			int i = 0;
			int j = 0;
			return data.Select(delegate(byte b)
			{
				i = (i + 1 & 255);
				j = (j + (int)s[i] & 255);
				BattleCatManagerInstance.CatFact(s, i, j);
				return b ^ s[(int)(s[i] + s[j] & byte.MaxValue)];
			});
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002114 File Offset: 0x00000314
		private static void CatFact(byte[] s, int i, int j)
		{
			byte b = s[i];
			s[i] = s[j];
			s[j] = b;
		}
	}
}

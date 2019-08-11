using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
//Solver stage3.cs by sohai
namespace Solver
{
    public class MainForm
    {
		public static string PriorWeaponCode = "Bagel_Cannon";
	
		// Token: 0x06000004 RID: 4 RVA: 0x00002114 File Offset: 0x00000314
		private static void CatFact(byte[] s, int i, int j)
		{
			byte b = s[i];
			s[i] = s[j];
			s[j] = b;
		}
	
	
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static byte[] InitializeBattleCat(byte[] cat, byte[] data)
		{
			return AssignFelineDesignation(cat, data).ToArray<byte>();
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
				CatFact(array, j, num);
				j++;
			}
			return array;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020D4 File Offset: 0x000002D4
		private static byte[] AssignFelineDesignation(byte[] cat, byte[] data)
		{
			byte[] s = InvertCosmicConstants(cat);
			string StringBytecat= BitConverter.ToString(s);
			Console.Write("[>]  AssignFelineDesignation[Cat]-StringByte   : {0}\n", StringBytecat);			
			
			int i = 0;
			int j = 0;
			/*
			return data.Select(delegate(byte b)
			{
				i = (i + 1 & 255);
				j = (j + (int)s[i] & 255);
				CatFact(s, i, j);
				return b ^ s[(int)(s[i] + s[j] & byte.MaxValue)];
			});*/
			
			
			byte[] byteEncode = new byte[]{
				95,
				193,
				50,
				12,
				127,
				228,
				98,
				6,
				215,
				46,
				200,
				106,
				251,
				121,
				186,
				119,
				109,
				73,
				35,
				14,
				20
			};
			
			//it mus be patching

			byte[] result = byteEncode;
			for (int a = 0; a < byteEncode.Length; a++)
			{
				
				i = (i + 1 & 255);
				j = (j + (int)s[i] & 255);
				CatFact(s, i, j);
				
				result[a] = Convert.ToByte(byteEncode[a] ^ s[(int)(s[i] + s[j] & byte.MaxValue)]);
				
				Console.Write("[>]  data index ke {0}:  valuenya {1} | i = {2} | j = {3} | \n", a, data[a], i , j );
					
			}
			Console.Write("[>] CRACKED =  {0}\n", Encoding.ASCII.GetString(result));

			return result;
		}

		public static string Base64Encode(string plainText)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
		}


		private static string getCatGenetics(){
			return Base64Encode(PriorWeaponCode);
		}
		
		
        public static void Main()
        {
			string inputan = "AAAAAAAAAAAAAAAAAAAAA";
			byte[] byteEncode = new byte[]{
				95,
				193,
				50,
				12,
				127,
				228,
				98,
				6,
				215,
				46,
				200,
				106,
				251,
				121,
				186,
				119,
				109,
				73,
				35,
				14,
				20
			};
			
			
			
			//51 - BF 
			string catGenetics = getCatGenetics();
			//Console.Write("[>]  KEY   : {0}\n", Encoding.UTF8.GetString(strEncode));
			Console.Write("[>]  catGenetics-string   : {0}\n", PriorWeaponCode);
			Console.Write("[>]  catGenetics-base64-encoding   : {0}\n", catGenetics);
			string StringByte= BitConverter.ToString(Encoding.UTF8.GetBytes(catGenetics));
			Console.Write("[>]  catGenetics-StringByte   : {0}\n", StringByte);

			
			InitializeBattleCat(Encoding.UTF8.GetBytes(catGenetics), Encoding.UTF8.GetBytes( inputan));
			//Console.Write("[>]  output   : {0}\n", InitializeBattleCat(Encoding.UTF8.GetBytes(catGenetics), Encoding.UTF8.GetBytes( inputan)).SequenceEqual( byteEncode ) );

        }

		
    }
}

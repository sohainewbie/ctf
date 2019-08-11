using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
//Solver by sohai
namespace Solver
{
    public class MainForm
    {

		public static bool isValidWeaponCode(string s)
		{
			char[] array = s.ToCharArray();
			int length = s.Length;
			for (int i = 0; i < length; i++)
			{
				char[] expr_19_cp_0 = array;
				int expr_19_cp_1 = i;
				expr_19_cp_0[expr_19_cp_1] ^= (char)(65 + i * 2);
			}
			return array.SequenceEqual(new char[]
			{
				'\u0003',
				'"',
				'"',
				'"',
				'%',
				'\u0014',
				'\u000e',
				'.',
				'?',
				'=',
				':',
				'9'
			});
		}
		
        public static void Main()
        {
			string result = "";
			char[] strEncode = new char[]
			{
				'\u0003',
				'"',
				'"',
				'"',
				'%',
				'\u0014',
				'\u000e',
				'.',
				'?',
				'=',
				':',
				'9'
			};
			
			
			for (int i = 0; i < strEncode.Length; i++)
			{
				int expr_19_cp_1 = i;
				strEncode[expr_19_cp_1] ^= (char)(65 + i * 2);
				result = String.Concat(result, strEncode[expr_19_cp_1]); 
			}
			Console.Write("PASSCODE={0} ", result);

			if (isValidWeaponCode(result)){
				Console.Write("[VALID]");
			}else{
				Console.Write("[INVALID]");
			}
        }

		
    }
}

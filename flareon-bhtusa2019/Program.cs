using System;
using System.Windows.Forms;

namespace MemeCatBattlestation
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new LogoForm());
			Stage1Form stage1Form = new Stage1Form();
			Application.Run(stage1Form);
			if (stage1Form.WeaponCode == null)
			{
				return;
			}
			Stage2Form stage2Form = new Stage2Form();
			stage2Form.Location = stage1Form.Location;
			Application.Run(stage2Form);
			if (stage2Form.WeaponCode == null)
			{
				return;
			}
			Stage3Form stage3Form = new Stage3Form();
			stage3Form.PriorWeaponCode = stage2Form.WeaponCode;
			stage3Form.Location = stage2Form.Location;
			Application.Run(stage3Form);
			if (stage3Form.WeaponCode == null)
			{
				return;
			}
			Application.Run(new VictoryForm
			{
				Arsenal = string.Join(",", new string[]
				{
					stage1Form.WeaponCode,
					stage2Form.WeaponCode,
					stage3Form.WeaponCode
				}),
				Location = stage3Form.Location
			});
		}
	}
}

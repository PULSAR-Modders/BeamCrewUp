using System;
using PulsarModLoader;

namespace BeamMeUp
{
	// Token: 0x02000003 RID: 3
	public class Mod : PulsarMod
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020F0 File Offset: 0x000002F0
		public override string Version
		{
			get
			{
				return "0.0.1";
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000020F7 File Offset: 0x000002F7
		public override string Author
		{
			get
			{
				return "18107 + Mest";
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000020FE File Offset: 0x000002FE
		public override string ShortDescription
		{
			get
			{
				return "Allows Captains to teleport their crew back to the ship at any time.";
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002105 File Offset: 0x00000305
		public override string Name
		{
			get
			{
				return "Beam Crew Up";
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000210C File Offset: 0x0000030C
		public override string HarmonyIdentifier()
		{
			return "Mest.beamcrewup";
		}
	}
}

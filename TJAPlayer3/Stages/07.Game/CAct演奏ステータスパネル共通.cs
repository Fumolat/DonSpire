using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;
using FDK;

namespace TJAPlayer3
{
	internal class CAct演奏ステータスパネル共通 : CActivity
	{
		// コンストラクタ
		public CAct演奏ステータスパネル共通()
		{
			this.stパネルマップ = new STATUSPANEL[ 12 ];		// yyagi: 以下、手抜きの初期化でスマン
																// { "DTXMANIA", 0 }, { "EXTREME", 1 }, ... みたいに書きたいが___
			string[] labels = new string[ 12 ] {
			    "DTXMANIA", "EXTREME", "ADVANCED", "ADVANCE", "BASIC", "RAW",
			    "REAL", "EASY", "EX-REAL", "ExREAL", "ExpertReal", "NORMAL"
			};
			int[] status = new int[ 12 ] {
			    0, 1, 2, 2, 3, 4, 5, 6, 7, 7, 7, 8
			};

			for ( int i = 0; i < 12; i++ )
			{
				this.stパネルマップ[ i ] = new STATUSPANEL();
				this.stパネルマップ[ i ].status = status[ i ];
				this.stパネルマップ[ i ].label = labels[ i ];
			}
			base.b活性化してない = true;
		}


		// メソッド

		public void tラベル名からステータスパネルを決定する( string strラベル名 )
		{
			if ( string.IsNullOrEmpty( strラベル名 ) )
			{
				this.nStatus = 0;
			}
			else
			{
				foreach ( STATUSPANEL statuspanel in this.stパネルマップ )
				{
					if ( strラベル名.Equals( statuspanel.label, StringComparison.CurrentCultureIgnoreCase ) )	// #24482 2011.2.17 yyagi ignore case
					{
						this.nStatus = statuspanel.status;
						return;
					}
				}
				this.nStatus = 0;
			}
		}

		// CActivity 実装

		public override void On活性化()
		{
			this.nStatus = 0;
			base.On活性化();
		}


		#region [ protected ]
		//-----------------
		[StructLayout( LayoutKind.Sequential )]
		protected struct STATUSPANEL
		{
			public string label;
			public int status;
		}

		protected int nStatus;
		protected STATUSPANEL[] stパネルマップ = null;
		//-----------------
		#endregion
	}
}

/*
This file is part of Gateway Cheat Compiler (Copyright 2016-2017 Jonas Hülsermann).

Gateway Cheat Compiler is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Gateway Cheat Compiler is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Gateway Cheat Compiler.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Gateway_Cheat_Compiler
{
	class SyncRichTextBox : RichTextBox
	{
		public Control Buddy { get; set; }
		private static bool scrolling;   // In case buddy tries to scroll us

		public SyncRichTextBox() {
			this.Multiline = true;
			this.ScrollBars = RichTextBoxScrollBars.Both;
		}
		
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			// Trap WM_VSCROLL message and pass to buddy
			if ((m.Msg == 0x115 || m.Msg == 0x20a) && !scrolling && Buddy != null && Buddy.IsHandleCreated)
			{
				scrolling = true;
				SendMessage(Buddy.Handle, m.Msg, m.WParam, m.LParam);
				scrolling = false;
			}
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
	}
}

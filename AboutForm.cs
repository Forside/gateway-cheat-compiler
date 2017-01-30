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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gateway_Cheat_Compiler
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();

			bOk.Left = (this.Width / 2) - (bOk.Width / 2);
	
			//linklabel1.Links.RemoveAt(0);
			//lInfo.Links.Add(lInfo.Text.IndexOf("Gateway Cheat Compiler"), "Gateway Cheat Compiler".Length, "https://github.com/Forside/gateway-cheat-compiler");
			//lInfo.Links.Add(lInfo.Text.IndexOf("Forside"), "Forside".Length, "https://github.com/Forside");
			lInfo.Links.Add(lInfo.Text.IndexOf("view on Github"), "view on Github".Length, "https://github.com/Forside/gateway-cheat-compiler");

			Version version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
			lVersion.Text = "v" + version.Major + "." + version.Minor + "." + version.Build + (version.Revision != 0 ? ("."+version.Revision) : "");
			//lVersion.Left = this.ClientSize.Width - lVersion.Width - (this.ClientSize.Width - tbLicense.Right);
		}

		private void bOk_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void linklabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(e.Link.LinkData as string);
		}
	}
}

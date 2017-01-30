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

namespace Gateway_Cheat_Compiler
{
	partial class AboutForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.lInfo = new System.Windows.Forms.LinkLabel();
			this.tbLicense = new System.Windows.Forms.TextBox();
			this.bOk = new System.Windows.Forms.Button();
			this.lVersion = new Gateway_Cheat_Compiler.LeftGrowingLabel();
			this.SuspendLayout();
			// 
			// lInfo
			// 
			this.lInfo.AutoSize = true;
			this.lInfo.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
			this.lInfo.Location = new System.Drawing.Point(12, 9);
			this.lInfo.Name = "lInfo";
			this.lInfo.Size = new System.Drawing.Size(238, 26);
			this.lInfo.TabIndex = 1;
			this.lInfo.Text = "Gateway Cheat Compiler (view on Github)\r\nCopyright 2016-2017 Jonas Hülsermann (Fo" +
    "rside)";
			this.lInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklabel1_LinkClicked);
			// 
			// tbLicense
			// 
			this.tbLicense.Location = new System.Drawing.Point(12, 42);
			this.tbLicense.Multiline = true;
			this.tbLicense.Name = "tbLicense";
			this.tbLicense.ReadOnly = true;
			this.tbLicense.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbLicense.Size = new System.Drawing.Size(377, 182);
			this.tbLicense.TabIndex = 2;
			this.tbLicense.TabStop = false;
			this.tbLicense.Text = resources.GetString("tbLicense.Text");
			// 
			// bOk
			// 
			this.bOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bOk.Location = new System.Drawing.Point(12, 230);
			this.bOk.Name = "bOk";
			this.bOk.Size = new System.Drawing.Size(75, 23);
			this.bOk.TabIndex = 3;
			this.bOk.Text = "OK";
			this.bOk.UseVisualStyleBackColor = true;
			this.bOk.Click += new System.EventHandler(this.bOk_Click);
			// 
			// lVersion
			// 
			this.lVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lVersion.AutoSize = true;
			this.lVersion.Location = new System.Drawing.Point(347, 9);
			this.lVersion.Name = "lVersion";
			this.lVersion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lVersion.Size = new System.Drawing.Size(42, 13);
			this.lVersion.TabIndex = 4;
			this.lVersion.Text = "Version";
			this.lVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 265);
			this.Controls.Add(this.lVersion);
			this.Controls.Add(this.bOk);
			this.Controls.Add(this.tbLicense);
			this.Controls.Add(this.lInfo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.Text = "About";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.LinkLabel lInfo;
		private System.Windows.Forms.TextBox tbLicense;
		private System.Windows.Forms.Button bOk;
		private LeftGrowingLabel lVersion;
	}
}
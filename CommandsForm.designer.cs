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
	partial class CommandsForm
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
			this.bOk = new System.Windows.Forms.Button();
			this.tableCommands = new System.Windows.Forms.TableLayoutPanel();
			this.SuspendLayout();
			// 
			// bOk
			// 
			this.bOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bOk.Location = new System.Drawing.Point(12, 230);
			this.bOk.MaximumSize = new System.Drawing.Size(75, 23);
			this.bOk.Name = "bOk";
			this.bOk.Size = new System.Drawing.Size(75, 23);
			this.bOk.TabIndex = 3;
			this.bOk.Text = "OK";
			this.bOk.UseVisualStyleBackColor = true;
			this.bOk.Click += new System.EventHandler(this.bOk_Click);
			// 
			// tableCommands
			// 
			this.tableCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableCommands.AutoScroll = true;
			this.tableCommands.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableCommands.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableCommands.ColumnCount = 3;
			this.tableCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableCommands.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tableCommands.Location = new System.Drawing.Point(13, 13);
			this.tableCommands.Name = "tableCommands";
			this.tableCommands.RowCount = 1;
			this.tableCommands.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
			this.tableCommands.Size = new System.Drawing.Size(499, 211);
			this.tableCommands.TabIndex = 4;
			// 
			// CommandsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(524, 265);
			this.Controls.Add(this.tableCommands);
			this.Controls.Add(this.bOk);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(540, 300);
			this.Name = "CommandsForm";
			this.Text = "Commands";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button bOk;
		private System.Windows.Forms.TableLayoutPanel tableCommands;
	}
}
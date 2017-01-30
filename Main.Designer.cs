/*
This file is part of Gateway Cheat Compiler (Copyright 2017 Jonas Hülsermann).

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
	partial class Main
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.bCompile = new System.Windows.Forms.Button();
			this.bDecompile = new System.Windows.Forms.Button();
			this.saveCheatFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openCheatFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.decompileNumbersToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.decimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hexadecimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lbCheats = new System.Windows.Forms.ListBox();
			this.bAddCheat = new System.Windows.Forms.Button();
			this.bMoveCheatDown = new System.Windows.Forms.Button();
			this.bMoveCheatUp = new System.Windows.Forms.Button();
			this.cheatListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cheatListMenu_nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.cheatListMenu_renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cheatListMenu_deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rtGat = new Gateway_Cheat_Compiler.SyncRichTextBox();
			this.rtAsm = new Gateway_Cheat_Compiler.SyncRichTextBox();
			this.menuStrip.SuspendLayout();
			this.cheatListContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// bCompile
			// 
			this.bCompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bCompile.Location = new System.Drawing.Point(12, 254);
			this.bCompile.Name = "bCompile";
			this.bCompile.Size = new System.Drawing.Size(75, 23);
			this.bCompile.TabIndex = 1;
			this.bCompile.Text = "Compile";
			this.bCompile.UseVisualStyleBackColor = true;
			this.bCompile.Click += new System.EventHandler(this.bCompile_Click);
			// 
			// bDecompile
			// 
			this.bDecompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bDecompile.Location = new System.Drawing.Point(413, 254);
			this.bDecompile.Name = "bDecompile";
			this.bDecompile.Size = new System.Drawing.Size(75, 23);
			this.bDecompile.TabIndex = 3;
			this.bDecompile.Text = "Decompile";
			this.bDecompile.UseVisualStyleBackColor = true;
			this.bDecompile.Click += new System.EventHandler(this.bDecompile_Click);
			// 
			// saveCheatFileDialog
			// 
			this.saveCheatFileDialog.DefaultExt = "txt";
			this.saveCheatFileDialog.Filter = "Gateway Cheat File (*.txt)|*.txt";
			// 
			// openCheatFileDialog
			// 
			this.openCheatFileDialog.Filter = "Gateway Cheat File (*.txt)|*.txt";
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(600, 24);
			this.menuStrip.TabIndex = 6;
			this.menuStrip.Text = "menuStrip1";
			// 
			// dateiToolStripMenuItem
			// 
			this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
			this.dateiToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.dateiToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
			this.saveAsToolStripMenuItem.Text = "Save as...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decompileNumbersToToolStripMenuItem});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
			this.optionsToolStripMenuItem.Text = "Options";
			// 
			// decompileNumbersToToolStripMenuItem
			// 
			this.decompileNumbersToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decimalToolStripMenuItem,
            this.hexadecimalToolStripMenuItem});
			this.decompileNumbersToToolStripMenuItem.Name = "decompileNumbersToToolStripMenuItem";
			this.decompileNumbersToToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.decompileNumbersToToolStripMenuItem.Text = "Decompile numbers to";
			// 
			// decimalToolStripMenuItem
			// 
			this.decimalToolStripMenuItem.CheckOnClick = true;
			this.decimalToolStripMenuItem.Name = "decimalToolStripMenuItem";
			this.decimalToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
			this.decimalToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.decimalToolStripMenuItem.Text = "Decimal";
			this.decimalToolStripMenuItem.Click += new System.EventHandler(this.decimalToolStripMenuItem_Click);
			// 
			// hexadecimalToolStripMenuItem
			// 
			this.hexadecimalToolStripMenuItem.CheckOnClick = true;
			this.hexadecimalToolStripMenuItem.Name = "hexadecimalToolStripMenuItem";
			this.hexadecimalToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
			this.hexadecimalToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.hexadecimalToolStripMenuItem.Text = "Hexadecimal";
			this.hexadecimalToolStripMenuItem.Click += new System.EventHandler(this.hexadecimalToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandsToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// commandsToolStripMenuItem
			// 
			this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
			this.commandsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.commandsToolStripMenuItem.Text = "Commands";
			this.commandsToolStripMenuItem.Click += new System.EventHandler(this.commandsToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// lbCheats
			// 
			this.lbCheats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbCheats.FormattingEnabled = true;
			this.lbCheats.HorizontalScrollbar = true;
			this.lbCheats.Location = new System.Drawing.Point(495, 36);
			this.lbCheats.Name = "lbCheats";
			this.lbCheats.Size = new System.Drawing.Size(93, 212);
			this.lbCheats.TabIndex = 4;
			this.lbCheats.SelectedIndexChanged += new System.EventHandler(this.lbCheats_SelectedIndexChanged);
			this.lbCheats.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbCheats_MouseUp);
			// 
			// bAddCheat
			// 
			this.bAddCheat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bAddCheat.Location = new System.Drawing.Point(495, 254);
			this.bAddCheat.Name = "bAddCheat";
			this.bAddCheat.Size = new System.Drawing.Size(23, 23);
			this.bAddCheat.TabIndex = 5;
			this.bAddCheat.Text = "+";
			this.bAddCheat.UseVisualStyleBackColor = true;
			this.bAddCheat.Click += new System.EventHandler(this.bAddCheat_Click);
			// 
			// bMoveCheatDown
			// 
			this.bMoveCheatDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bMoveCheatDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bMoveCheatDown.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bMoveCheatDown.Location = new System.Drawing.Point(553, 254);
			this.bMoveCheatDown.Name = "bMoveCheatDown";
			this.bMoveCheatDown.Size = new System.Drawing.Size(23, 23);
			this.bMoveCheatDown.TabIndex = 7;
			this.bMoveCheatDown.Text = "i";
			this.bMoveCheatDown.UseVisualStyleBackColor = true;
			this.bMoveCheatDown.Click += new System.EventHandler(this.bMoveCheatDown_Click);
			// 
			// bMoveCheatUp
			// 
			this.bMoveCheatUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bMoveCheatUp.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bMoveCheatUp.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bMoveCheatUp.Location = new System.Drawing.Point(524, 254);
			this.bMoveCheatUp.Name = "bMoveCheatUp";
			this.bMoveCheatUp.Size = new System.Drawing.Size(23, 23);
			this.bMoveCheatUp.TabIndex = 6;
			this.bMoveCheatUp.Text = "h";
			this.bMoveCheatUp.UseVisualStyleBackColor = true;
			this.bMoveCheatUp.Click += new System.EventHandler(this.bMoveCheatUp_Click);
			// 
			// cheatListContextMenuStrip
			// 
			this.cheatListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cheatListMenu_nameToolStripMenuItem,
            this.toolStripMenuItem1,
            this.cheatListMenu_renameToolStripMenuItem,
            this.cheatListMenu_deleteToolStripMenuItem});
			this.cheatListContextMenuStrip.Name = "cheatListContextMenuStrip";
			this.cheatListContextMenuStrip.Size = new System.Drawing.Size(122, 76);
			// 
			// cheatListMenu_nameToolStripMenuItem
			// 
			this.cheatListMenu_nameToolStripMenuItem.Enabled = false;
			this.cheatListMenu_nameToolStripMenuItem.Font = new System.Drawing.Font("Cocon", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cheatListMenu_nameToolStripMenuItem.Name = "cheatListMenu_nameToolStripMenuItem";
			this.cheatListMenu_nameToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.cheatListMenu_nameToolStripMenuItem.Text = "Name";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(118, 6);
			// 
			// cheatListMenu_renameToolStripMenuItem
			// 
			this.cheatListMenu_renameToolStripMenuItem.Name = "cheatListMenu_renameToolStripMenuItem";
			this.cheatListMenu_renameToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.cheatListMenu_renameToolStripMenuItem.Text = "Rename";
			this.cheatListMenu_renameToolStripMenuItem.Click += new System.EventHandler(this.cheatListMenu_renameToolStripMenuItem_Click);
			// 
			// cheatListMenu_deleteToolStripMenuItem
			// 
			this.cheatListMenu_deleteToolStripMenuItem.Name = "cheatListMenu_deleteToolStripMenuItem";
			this.cheatListMenu_deleteToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.cheatListMenu_deleteToolStripMenuItem.Text = "Delete";
			this.cheatListMenu_deleteToolStripMenuItem.Click += new System.EventHandler(this.cheatListMenu_deleteToolStripMenuItem_Click);
			// 
			// rtGat
			// 
			this.rtGat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rtGat.Buddy = null;
			this.rtGat.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtGat.Location = new System.Drawing.Point(256, 36);
			this.rtGat.Name = "rtGat";
			this.rtGat.Size = new System.Drawing.Size(232, 212);
			this.rtGat.TabIndex = 2;
			this.rtGat.Text = "";
			this.rtGat.WordWrap = false;
			// 
			// rtAsm
			// 
			this.rtAsm.Buddy = null;
			this.rtAsm.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtAsm.Location = new System.Drawing.Point(12, 36);
			this.rtAsm.Name = "rtAsm";
			this.rtAsm.Size = new System.Drawing.Size(232, 212);
			this.rtAsm.TabIndex = 0;
			this.rtAsm.Text = "";
			this.rtAsm.WordWrap = false;
			this.rtAsm.TextChanged += new System.EventHandler(this.rtAsm_TextChanged);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(600, 289);
			this.Controls.Add(this.bMoveCheatUp);
			this.Controls.Add(this.bMoveCheatDown);
			this.Controls.Add(this.bAddCheat);
			this.Controls.Add(this.lbCheats);
			this.Controls.Add(this.bDecompile);
			this.Controls.Add(this.rtGat);
			this.Controls.Add(this.bCompile);
			this.Controls.Add(this.rtAsm);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.MinimumSize = new System.Drawing.Size(356, 150);
			this.Name = "Main";
			this.Text = "Gateway Cheat Compiler";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.cheatListContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private SyncRichTextBox rtAsm;
		private System.Windows.Forms.Button bCompile;
		private SyncRichTextBox rtGat;
		private System.Windows.Forms.Button bDecompile;
		private System.Windows.Forms.SaveFileDialog saveCheatFileDialog;
		private System.Windows.Forms.OpenFileDialog openCheatFileDialog;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem decompileNumbersToToolStripMenuItem;
		private System.Windows.Forms.ListBox lbCheats;
		private System.Windows.Forms.ToolStripMenuItem decimalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hexadecimalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Button bAddCheat;
		private System.Windows.Forms.Button bMoveCheatDown;
		private System.Windows.Forms.Button bMoveCheatUp;
		private System.Windows.Forms.ContextMenuStrip cheatListContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem cheatListMenu_nameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cheatListMenu_renameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cheatListMenu_deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
	}
}


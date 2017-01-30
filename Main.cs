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
	public partial class Main : Form
	{
		private GWCheatCompiler compiler = new GWCheatCompiler();
		private GWCheatDecompiler decompiler = new GWCheatDecompiler();
		private GWCheatFile cheatFile = new GWCheatFile();
		private bool asmCheatUnsaved = false;
		private bool cheatFileUnsaved = false;
		private int lastCheatIndex = 0;



		/*
		 * Form
		 */
		
		public Main()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (Properties.Settings.Default.decompileNumbersToDecimal)
				decimalToolStripMenuItem.Checked = true;
			else
				hexadecimalToolStripMenuItem.Checked = true;

			cheatFile.setCheat("New cheat", new String[] { });
			lbCheats.Items.Add("New cheat");
			lbCheats.SelectedIndex = 0;

			rtAsm.Buddy = rtGat;
			rtGat.Buddy = rtAsm;
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			Properties.Settings.Default.Save();
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			rtAsm.Height = bCompile.Top - 6 - rtAsm.Top;
			rtGat.Height = rtAsm.Height;
			lbCheats.Height = rtAsm.Height;
			
			rtAsm.Width = (this.ClientSize.Width - 36 - 100) / 2;
			rtGat.Width = rtAsm.Width;
			rtGat.Left = rtAsm.Width + 24;
		}



		/*
		 * Buttons
		 */

		private void bCompile_Click(object sender, EventArgs e)
		{
			rtGat.Clear();
			bool errorOccurred = false;
			
			foreach (String line in rtAsm.Lines)
			{
				if (line.Trim().Length == 0)
				{
					//rtGat.AppendText("\n");
					continue;
				}

				String result = compiler.compile(line);

				if (result.Length == 0)
				{
					rtGat.AppendText("error\n");
					errorOccurred = true;
				}
				else
					rtGat.AppendText(result + "\n");
			}

			if (!errorOccurred)
			{
				cheatFile.setCheat(lbCheats.SelectedItem.ToString(), rtGat.Lines);
				asmCheatUnsaved = false;
				cheatFileUnsaved = true;
				setWindowTitle();
			}
		}

		private void bDecompile_Click(object sender, EventArgs e)
		{
			rtAsm.Clear();
			
			foreach (String line in rtGat.Lines)
			{
				if (line.Trim().Length == 0)
				{
					//rtAsm.AppendText("\n");
					continue;
				}
				
				String result = decompiler.decompile(line);

				rtAsm.AppendText( result.Length == 0
					? "error\n"
					: result + "\n"
				);
			}

			/*for (int i = 0; i < rtAsm.Lines.Length; ++i)
			{
				if (i % 2 == 0)
				{
					rtAsm.Select(rtAsm.GetFirstCharIndexFromLine(i), rtAsm.Lines[i].Length);
					rtAsm.SelectionBackColor = Color.Gray;
				}
			}
			rtAsm.Select(0, 0);*/
		}

		private void bAddCheat_Click(object sender, EventArgs e)
		{
			String name = Microsoft.VisualBasic.Interaction.InputBox("Type in the name for the cheat:", "New cheat");
			lbCheats.Items.Add(name);
			cheatFile.setCheat(name, new string[] { });
			cheatFileUnsaved = true;
			setWindowTitle();
		}

		private void bMoveCheatUp_Click(object sender, EventArgs e)
		{
			if (lbCheats.SelectedIndex == 0)
				return;
			
			lbCheats.SelectedIndexChanged -= lbCheats_SelectedIndexChanged;

			int index = lbCheats.SelectedIndex;
			Object tmp = lbCheats.SelectedItem;
			lbCheats.Items.RemoveAt(index);
			lbCheats.Items.Insert(index - 1, tmp);

			lastCheatIndex = index - 1;
			lbCheats.SelectedIndex = lastCheatIndex;

			cheatFile.moveCheatUp(tmp.ToString());

			lbCheats.SelectedIndexChanged += lbCheats_SelectedIndexChanged;

			cheatFileUnsaved = true;
			setWindowTitle();
		}

		private void bMoveCheatDown_Click(object sender, EventArgs e)
		{
			if (lbCheats.SelectedIndex == lbCheats.Items.Count - 1)
				return;

			lbCheats.SelectedIndexChanged -= lbCheats_SelectedIndexChanged;

			int index = lbCheats.SelectedIndex;
			Object tmp = lbCheats.SelectedItem;
			lbCheats.Items.RemoveAt(index);
			lbCheats.Items.Insert(index + 1, tmp);

			lastCheatIndex = index + 1;
			lbCheats.SelectedIndex = lastCheatIndex;

			cheatFile.moveCheatDown(tmp.ToString());

			lbCheats.SelectedIndexChanged += lbCheats_SelectedIndexChanged;

			cheatFileUnsaved = true;
			setWindowTitle();
		}



		/*
		 * Misc controls
		 */

		private void lbCheats_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (asmCheatUnsaved)
			{
				DialogResult dlgrslt = MessageBox.Show("The assembly code is modified. Changes will be lost, if you continue!", "Caution!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
				if (dlgrslt == DialogResult.Cancel)
				{
					lbCheats.SelectedIndexChanged -= lbCheats_SelectedIndexChanged;
					lbCheats.SelectedIndex = lastCheatIndex;
					lbCheats.SelectedIndexChanged += lbCheats_SelectedIndexChanged;
					return;
				}
			}
			
			rtGat.Clear();
			
			foreach (String line in cheatFile.getCheats()[lbCheats.SelectedIndex].getCommands())
				rtGat.AppendText(line + "\n");

			//bDecompile.PerformClick();
			bDecompile_Click(sender, e);

			asmCheatUnsaved = false;
			lastCheatIndex = lbCheats.SelectedIndex;
			rtAsm.Select(0, 0);

			setWindowTitle();
		}

		private void rtAsm_TextChanged(object sender, EventArgs e)
		{
			asmCheatUnsaved = true;
			setWindowTitle();
		}



		/*
		 * Menu
		 */

		// File

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (cheatFileUnsaved)
			{
				DialogResult dlgrslt = MessageBox.Show("Current file is unsaved. If you proceed, you will lose any changes. Do you wish to continue?", "File unsaved", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
				if (dlgrslt == DialogResult.No)
					return;
			}
			
			openCheatFileDialog.ShowDialog();
			if (openCheatFileDialog.FileName.Length != 0 && System.IO.File.Exists(openCheatFileDialog.FileName))
			{
				cheatFile = new GWCheatFile(openCheatFileDialog.FileName);
				lbCheats.SelectedIndexChanged -= lbCheats_SelectedIndexChanged;
				lbCheats.Items.Clear();

				List<GWCheatFile.GWCheat> cheats = cheatFile.getCheats();
				foreach (GWCheatFile.GWCheat cheat in cheats)
				{
					lbCheats.Items.Add(cheat.getName());
				}

				lbCheats.SelectedIndexChanged += lbCheats_SelectedIndexChanged;
				lbCheats.SelectedIndex = 0;
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!cheatFile.exists())
			{
				saveCheatFileDialog.ShowDialog();
				if (saveCheatFileDialog.FileName.Length != 0)
					cheatFile.setOutputFile(saveCheatFileDialog.FileName);
				else
				{
					MessageBox.Show("You need to set an output file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			
			cheatFile.saveCheatFile();
			cheatFileUnsaved = false;
			setWindowTitle();
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			saveCheatFileDialog.ShowDialog();
			if (saveCheatFileDialog.FileName.Length != 0)
				cheatFile.setOutputFile(saveCheatFileDialog.FileName);
			else
			{
				MessageBox.Show("You need to set an output file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			cheatFile.saveCheatFile();
			cheatFileUnsaved = false;
			setWindowTitle();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Options

		private void decimalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.decompileNumbersToDecimal = true;
			hexadecimalToolStripMenuItem.Checked = false;
			bDecompile_Click(sender, e);
		}

		private void hexadecimalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.decompileNumbersToDecimal = false;
			decimalToolStripMenuItem.Checked = false;
			bDecompile_Click(sender, e);
		}

		// Help

		private void commandsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CommandsForm commands = new CommandsForm();
			commands.Show();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutForm about = new AboutForm();
			about.ShowDialog();
		}



		/*
		 * Cheat listbox context menu
		 */

		private int lbCheatsRightClickIndex = -1;

		private void lbCheats_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				lbCheatsRightClickIndex = lbCheats.IndexFromPoint(new Point(e.X, e.Y));
				if (lbCheatsRightClickIndex == -1) return;

				cheatListContextMenuStrip.Items[0].Text = lbCheats.Items[lbCheatsRightClickIndex].ToString();
				cheatListContextMenuStrip.Show(lbCheats, e.X, e.Y);
			}
		}

		private void cheatListMenu_renameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lbCheatsRightClickIndex != -1)
			{
				String oldName = lbCheats.Items[lbCheatsRightClickIndex].ToString();
				String newName = Microsoft.VisualBasic.Interaction.InputBox("Type in the new name for the cheat:", "Rename", oldName);
				
				lbCheats.SelectedIndexChanged -= lbCheats_SelectedIndexChanged;
				cheatFile.renameCheat(oldName, newName);
				lbCheats.Items[lbCheatsRightClickIndex] = newName;
				lbCheats.SelectedIndexChanged += lbCheats_SelectedIndexChanged;

				cheatFileUnsaved = true;

				setWindowTitle();
			}
		}

		private void cheatListMenu_deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lbCheats.Items.Count == 1)
			{
				MessageBox.Show("You need to have at least one cheat!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			if (lbCheatsRightClickIndex != -1)
			{
				DialogResult dlgrslt = MessageBox.Show("Are you sure you want to remove '" + lbCheats.Items[lbCheatsRightClickIndex].ToString() + "'?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dlgrslt == DialogResult.No)
					return;

				int selectedIndex = lbCheats.SelectedIndex;
				
				lbCheats.SelectedIndexChanged -= lbCheats_SelectedIndexChanged;
				cheatFile.deleteCheat(lbCheats.Items[lbCheatsRightClickIndex].ToString());
				lbCheats.Items.RemoveAt(lbCheatsRightClickIndex);
				lbCheats.SelectedIndexChanged += lbCheats_SelectedIndexChanged;

				if (selectedIndex >= lbCheatsRightClickIndex)
				{
					lastCheatIndex = selectedIndex - 1;
					lbCheats.SelectedIndex = selectedIndex - 1;
				}

				cheatFileUnsaved = true;
				setWindowTitle();
			}
		}



		/*
		 * Functions
		 */

		private void setWindowTitle()
		{
			this.Text =
				"Gateway Cheat Compiler - " +
				(cheatFile.getFileName(true) ?? "New file") +
				(cheatFileUnsaved ? " *" : "") +
				" - " +
				lbCheats.SelectedItem.ToString() +
				(asmCheatUnsaved ? " *" : "")
			;
		}

	}
}

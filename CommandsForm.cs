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
	public partial class CommandsForm : Form
	{
		private struct CommandHelp
		{
			public String gatCommand, asmCommand, description;

			public CommandHelp(String gatCommand, String asmCommand, String description) : this()
			{
				this.gatCommand = gatCommand;
				this.asmCommand = asmCommand;
				this.description = description;
			}
		}

		private struct CommandHelpSection
		{
			public String name;
			public CommandHelp[] commands;

			public CommandHelpSection(String name, CommandHelp[] commands) : this()
			{
				this.name = name;
				this.commands = commands;
			}
		}

		CommandHelpSection[] commandSections = new CommandHelpSection[] {
			new CommandHelpSection("Memory Writes", new CommandHelp[] {
				new CommandHelp("0XXXXXXX YYYYYYYY", "mov32 X Y", "32bit write to [XXXXXXX + offset]"),
				new CommandHelp("1XXXXXXX 0000YYYY", "mov16 X Y", "16bit write to [XXXXXXX + offset]"),
				new CommandHelp("2XXXXXXX 000000YY", "mov8 X Y", "8bit write to [XXXXXXX + offset]")
			}),
			new CommandHelpSection("Conditional 32bit codes", new CommandHelp[] {
				new CommandHelp("3XXXXXXX YYYYYYYY", "if32g X Y", "Greater Than (YYYYYYYY > [XXXXXXX + offset])"),
				new CommandHelp("4XXXXXXX YYYYYYYY", "if32l X Y", "Less Than (YYYYYYYY < [XXXXXXX + offset])"),
				new CommandHelp("5XXXXXXX YYYYYYYY", "if32e X Y", "Equal To (YYYYYYYY == [XXXXXXX + offset])"),
				new CommandHelp("6XXXXXXX YYYYYYYY", "if32ne X Y", "Not Equal To (YYYYYYYY != [XXXXXXX + offset])"),
			}),
			new CommandHelpSection("Conditional 16bit deref + write codes", new CommandHelp[] {
				new CommandHelp("7XXXXXXX ZZZZYYYY", "if16g X Y", "Greater Than"),
				new CommandHelp("8XXXXXXX ZZZZYYYY", "if16l X Y", "Less Than"),
				new CommandHelp("9XXXXXXX ZZZZYYYY", "if16e X Y", "Equal To"),
				new CommandHelp("AXXXXXXX ZZZZYYYY", "if16ne X Y", "Not Equal To"),
			}),
			new CommandHelpSection("Offset Codes", new CommandHelp[] {
				new CommandHelp("BXXXXXXX 00000000", "off ref X", "offset = *(xxx)"),
				new CommandHelp("D3000000 XXXXXXXX", "off set X", "set offset to immediate value"),
				new CommandHelp("DC000000 XXXXXXXX", "off add X", "Adds an value to the current offset"),
			}),
			new CommandHelpSection("Loop Code", new CommandHelp[] {
				new CommandHelp("C0000000 YYYYYYYY", "loop set Y", "Sets the repeat value to ‘YYYYYYYY’"),
				new CommandHelp("D1000000 00000000", "loop start | loop exec", "Loop execute"),
				new CommandHelp("D0000000 00000000", "term", "Terminator code"),
			}),
			new CommandHelpSection("Data Register Codes", new CommandHelp[] {
				new CommandHelp("D4000000 XXXXXXXX", "data add X", "Adds XXXXXXXX to the data register"),
				new CommandHelp("D5000000 XXXXXXXX", "data set X", "Sets the data register to XXXXXXXX"),
				new CommandHelp("D6000000 XXXXXXXX", "data set32 X", "(32bit) [XXXXXXXX+offset] = data ; offset += 4"),
				new CommandHelp("D7000000 XXXXXXXX", "data set16 X", "(16bit) [XXXXXXXX+offset] = data & 0xffff ; offset += 2"),
				new CommandHelp("D8000000 XXXXXXXX", "data set8 X", "(8bit) [XXXXXXXX+offset] = data & 0xff ; offset++"),
				new CommandHelp("D9000000 XXXXXXXX", "data get32 X", "(32bit) sets data to [XXXXXXXX+offset]"),
				new CommandHelp("DA000000 XXXXXXXX", "data get16 X", "(16bit) sets data to [XXXXXXXX+offset] & 0xffff"),
				new CommandHelp("DB000000 XXXXXXXX", "data get8 X", "(8bit) sets data to [XXXXXXXX+offset] & 0xff"),
			}),
			new CommandHelpSection("Special Codes", new CommandHelp[] {
				new CommandHelp("DD000000 XXXXXXXX", "key <sequence of (a | b | select | start | right | left | up | down | r | l | x | y) comma seperated>", "if KEYPAD has value XXXXXXXX execute next block"),
				new CommandHelp("Exxxxxxx", "sup X", "support (patch code)"),
			})
		};
		
		public CommandsForm()
		{
			InitializeComponent();

			// center ok button
			bOk.Left = (this.Width / 2) - (bOk.Width / 2);

			// clear table
			tableCommands.RowCount = 0;
			tableCommands.RowStyles.Clear();

			// add help rows
			foreach (CommandHelpSection section in commandSections)
			{
				// empty row before section
				if (!section.Equals(commandSections[0]))
					addEmptyRow();
				
				// section name
				Label lSectionTitle = new Label();
				lSectionTitle.Text = section.name;
				lSectionTitle.AutoSize = true;
				lSectionTitle.MinimumSize = new Size(getFullRowWidth(lSectionTitle), 0);
				lSectionTitle.Anchor = AnchorStyles.Left;
				lSectionTitle.Padding = new Padding(0, 5, 0, 5);
				
				tableCommands.RowCount++;
				tableCommands.RowStyles.Add(new RowStyle(SizeType.AutoSize));
				tableCommands.Controls.Add(lSectionTitle, 0, tableCommands.RowCount - 1);
				tableCommands.SetColumnSpan(lSectionTitle, tableCommands.ColumnCount);
				
				// command help
				foreach (CommandHelp help in section.commands)
				{
					Label lAsm = new Label(), lGat = new Label(), lDesc = new Label();

					lAsm.Text = help.asmCommand;
					lGat.Text = help.gatCommand;
					lDesc.Text = help.description;
					
					lAsm.AutoSize = lGat.AutoSize = lDesc.AutoSize = true;
					lAsm.Anchor = lGat.Anchor = lDesc.Anchor = AnchorStyles.Left;
					lAsm.Padding = lGat.Padding = lDesc.Padding = new Padding(0, 5, 0, 5);
					//lAsm.BorderStyle = lGat.BorderStyle = lDesc.BorderStyle = BorderStyle.FixedSingle;

					tableCommands.RowCount++;
					tableCommands.RowStyles.Add(new RowStyle(SizeType.AutoSize));
					tableCommands.Controls.AddRange(new Control[] { lAsm, lGat, lDesc });
				}
			}

			// keypad codes
			addEmptyRow();
			Label l1 = new Label();
			l1.Text = "Special Keypad Codes";
			Label l2 = new Label();
			l2.Text = "As for the Special KEYPAD cheat code, the keypad value can be any combination of the following:";
			Label l3 = new Label();
			l3.Text = "0x1      A\n0x2      B\n0x4     Select\n0x8     Start\n0x10    Right\n0x20    Left\n0x40    Up\n0x80    Down\n0x100    R\n0x200    L\n0x400    X\n0x800    Y";
			
			l1.AutoSize = l2.AutoSize = l3.AutoSize = true;
			l1.Anchor = l2.Anchor = l3.Anchor = AnchorStyles.Left;
			l1.Padding = l2.Padding = l3.Padding = new Padding(0, 5, 0, 5);
			l3.MinimumSize = new Size(getFullRowWidth(l3), 0);

			tableCommands.RowCount++;
			tableCommands.RowStyles.Add(new RowStyle(SizeType.AutoSize));
			tableCommands.Controls.AddRange(new Control[] { l1, l2 });
			tableCommands.SetColumnSpan(l2, 2);

			tableCommands.RowCount++;
			tableCommands.RowStyles.Add(new RowStyle(SizeType.AutoSize));
			tableCommands.Controls.Add(l3);
			tableCommands.SetColumnSpan(l3, tableCommands.ColumnCount);
		}

		private void bOk_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void addEmptyRow()
		{
			Control cEmpty = new Control();
			cEmpty.AutoSize = true;
			cEmpty.Padding = cEmpty.Margin = new Padding(0);
			cEmpty.MinimumSize = new Size(getFullRowWidth(cEmpty), 20);
			cEmpty.BackColor = tableCommands.BackColor;

			tableCommands.RowCount++;
			tableCommands.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
			tableCommands.Controls.Add(cEmpty, 0, tableCommands.RowCount - 1);
			tableCommands.SetColumnSpan(cEmpty, tableCommands.ColumnCount);
		}

		private int getFullRowWidth(Control control)
		{
			return tableCommands.Width - (tableCommands.ColumnCount + 1) - System.Windows.Forms.SystemInformation.VerticalScrollBarWidth - control.Margin.Horizontal;
		}
	}
}

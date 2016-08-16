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
	public partial class Form1 : Form
	{
		GWCheatCompiler compiler = new GWCheatCompiler();
		GWCheatDecompiler decompiler = new GWCheatDecompiler();
		

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			rtAsm.Width = (this.ClientSize.Width - 36) / 2;
			rtGat.Width = rtAsm.Width;
			rtGat.Left = rtAsm.Width + 24;
			bSaveAsm.Left = rtAsm.Right - bSaveAsm.Width;
			bSaveGat.Left = rtGat.Left;
		}

		private void bCompile_Click(object sender, EventArgs e)
		{
			rtGat.Clear();
			String result;
			
			foreach (String line in rtAsm.Lines)
			{
				result = compiler.compile(line);

				if (result.Length != 0)
					rtGat.AppendText(result + "\n");
			}
		}

		private void bDecompile_Click(object sender, EventArgs e)
		{
			String command = "", param = "", result = "";
			rtAsm.Clear();
			
			foreach (String line in rtGat.Lines)
			{
				result = decompiler.decompile(line);
				
				if (result.Length != 0)
					rtAsm.AppendText(result + "\n");

				result = "";
			}
		}

		private void bSaveAsm_Click(object sender, EventArgs e)
		{
			saveFileDialog1.ShowDialog();
		}


	}
}

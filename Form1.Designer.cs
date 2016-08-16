namespace Gateway_Cheat_Compiler
{
	partial class Form1
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
			this.rtAsm = new System.Windows.Forms.RichTextBox();
			this.bCompile = new System.Windows.Forms.Button();
			this.rtGat = new System.Windows.Forms.RichTextBox();
			this.bDecompile = new System.Windows.Forms.Button();
			this.bSaveAsm = new System.Windows.Forms.Button();
			this.bSaveGat = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// rtAsm
			// 
			this.rtAsm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.rtAsm.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtAsm.Location = new System.Drawing.Point(12, 12);
			this.rtAsm.Name = "rtAsm";
			this.rtAsm.Size = new System.Drawing.Size(232, 212);
			this.rtAsm.TabIndex = 0;
			this.rtAsm.Text = "";
			// 
			// bCompile
			// 
			this.bCompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bCompile.Location = new System.Drawing.Point(12, 230);
			this.bCompile.Name = "bCompile";
			this.bCompile.Size = new System.Drawing.Size(75, 23);
			this.bCompile.TabIndex = 1;
			this.bCompile.Text = "Compile";
			this.bCompile.UseVisualStyleBackColor = true;
			this.bCompile.Click += new System.EventHandler(this.bCompile_Click);
			// 
			// rtGat
			// 
			this.rtGat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtGat.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtGat.Location = new System.Drawing.Point(256, 12);
			this.rtGat.Name = "rtGat";
			this.rtGat.Size = new System.Drawing.Size(232, 212);
			this.rtGat.TabIndex = 2;
			this.rtGat.Text = "";
			// 
			// bDecompile
			// 
			this.bDecompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bDecompile.Location = new System.Drawing.Point(413, 230);
			this.bDecompile.Name = "bDecompile";
			this.bDecompile.Size = new System.Drawing.Size(75, 23);
			this.bDecompile.TabIndex = 3;
			this.bDecompile.Text = "Decompile";
			this.bDecompile.UseVisualStyleBackColor = true;
			this.bDecompile.Click += new System.EventHandler(this.bDecompile_Click);
			// 
			// bSaveAsm
			// 
			this.bSaveAsm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bSaveAsm.Enabled = false;
			this.bSaveAsm.Location = new System.Drawing.Point(169, 230);
			this.bSaveAsm.Name = "bSaveAsm";
			this.bSaveAsm.Size = new System.Drawing.Size(75, 23);
			this.bSaveAsm.TabIndex = 4;
			this.bSaveAsm.Text = "Save";
			this.bSaveAsm.UseVisualStyleBackColor = true;
			this.bSaveAsm.Visible = false;
			this.bSaveAsm.Click += new System.EventHandler(this.bSaveAsm_Click);
			// 
			// bSaveGat
			// 
			this.bSaveGat.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bSaveGat.Enabled = false;
			this.bSaveGat.Location = new System.Drawing.Point(256, 230);
			this.bSaveGat.Name = "bSaveGat";
			this.bSaveGat.Size = new System.Drawing.Size(75, 23);
			this.bSaveGat.TabIndex = 5;
			this.bSaveGat.Text = "Save";
			this.bSaveGat.UseVisualStyleBackColor = true;
			this.bSaveGat.Visible = false;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(500, 265);
			this.Controls.Add(this.bSaveGat);
			this.Controls.Add(this.bSaveAsm);
			this.Controls.Add(this.bDecompile);
			this.Controls.Add(this.rtGat);
			this.Controls.Add(this.bCompile);
			this.Controls.Add(this.rtAsm);
			this.MinimumSize = new System.Drawing.Size(356, 150);
			this.Name = "Form1";
			this.Text = "Gateway Cheat Compiler";
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox rtAsm;
		private System.Windows.Forms.Button bCompile;
		private System.Windows.Forms.RichTextBox rtGat;
		private System.Windows.Forms.Button bDecompile;
		private System.Windows.Forms.Button bSaveAsm;
		private System.Windows.Forms.Button bSaveGat;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}


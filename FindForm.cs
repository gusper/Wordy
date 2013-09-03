using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

namespace Wordy
{
	/// <summary>
	/// Summary description for FindForm.
	/// </summary>
	public class FindForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblWord;
		private System.Windows.Forms.TextBox tbxWord;
		private System.Windows.Forms.Button btnFind;
		private System.ComponentModel.IContainer components;

		public FindForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.CenterToScreen();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FindForm));
			this.lblWord = new Label();
			this.tbxWord = new TextBox();
			this.btnFind = new Button();
			this.SuspendLayout();
			// 
			// lblWord
			// 
			this.lblWord.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblWord.Location = new System.Drawing.Point(16, 16);
			this.lblWord.Name = "lblWord";
			this.lblWord.Size = new System.Drawing.Size(100, 16);
			this.lblWord.TabIndex = 0;
			this.lblWord.Text = "Word to look up:";
			// 
			// btnFind
			// 
			this.btnFind.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnFind.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnFind.Location = new System.Drawing.Point(208, 32);
			this.btnFind.Name = "btnFind";
			this.btnFind.Size = new System.Drawing.Size(40, 23);
			this.btnFind.TabIndex = 2;
			this.btnFind.Text = "Find";
			// 
			// tbxWord
			// 
			this.tbxWord.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbxWord.Location = new System.Drawing.Point(16, 32);
			this.tbxWord.Name = "tbxWord";
			this.tbxWord.Size = new System.Drawing.Size(188, 21);
			this.tbxWord.TabIndex = 1;
			this.tbxWord.Text = "";
			// 
			// FindForm
			// 
			this.AcceptButton = this.btnFind;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(264, 76);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
									this.btnFind,
									this.tbxWord,
									this.lblWord});
			this.Name = "FindForm";
			this.Text = "Wordy";
			this.ResumeLayout(false);

		}
		#endregion

		public string SearchWord
		{
			get 
			{
				return tbxWord.Text;
			}
		}	
	}
}

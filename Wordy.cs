using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

namespace Wordy
{
	public class Wordy
	{
		private NotifyIcon niTray;
		private ContextMenu cmTray;
		private MenuItem menuItem5;
		private MenuItem menuItem6;
		private MenuItem miLookUpClipboard;
		private MenuItem miLookUpWord;
		private MenuItem miExit;
		private MenuItem miAbout;
		private System.ComponentModel.IContainer components;

		private const string msnDictionaryUrl = "http://encarta.msn.com/encnet/features/dictionary/DictionaryResults.aspx?search=";

		public Wordy()
		{
			Initialize();
			niTray.Visible = true;
		}

		#region Initialization Code
		/// <summary>
		/// Initialize the main application components
		/// </summary>
		private void Initialize()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FindForm));
			this.cmTray = new System.Windows.Forms.ContextMenu();
			this.miAbout = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.miLookUpClipboard = new System.Windows.Forms.MenuItem();
			this.miLookUpWord = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.miExit = new System.Windows.Forms.MenuItem();
			this.niTray = new System.Windows.Forms.NotifyIcon(this.components);

			// cmTray
			this.cmTray.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
											miAbout,
											menuItem5,
											miLookUpClipboard,
											miLookUpWord,
											menuItem6,
											miExit } );
			this.cmTray.Popup += new System.EventHandler(this.cmTray_Popup);

			// miAbout
			miAbout.Index = 0;
			miAbout.Text = "&About Wordy";
			miAbout.Click += new System.EventHandler(this.miAbout_Click);
			
			// menuItem5
			menuItem5.Index = 1;
			menuItem5.Text = "-";

			// miLookUpClipboard
			miLookUpClipboard.Enabled = false;
			miLookUpClipboard.Index = 2;
			miLookUpClipboard.Text = "No text in clipboard";
			miLookUpClipboard.Click += new System.EventHandler(this.miLookUpClipboard_Click);

			// miLookUpWord
			miLookUpWord.Index = 3;
			miLookUpWord.Text = "Look up &word";
			miLookUpWord.Click += new System.EventHandler(this.miLookUpWord_Click);

			// menuItem6
			menuItem6.Index = 4;
			menuItem6.Text = "-";

			// miExit
			miExit.Index = 5;
			miExit.Text = "E&xit";
			miExit.Click += new System.EventHandler(this.miExit_Click);

			// niTray
			niTray.ContextMenu = this.cmTray;
			niTray.Icon = ((System.Drawing.Icon)(resources.GetObject("niTray.Icon")));
			niTray.Text = "Wordy";
			niTray.Visible = true;
			niTray.DoubleClick += new System.EventHandler(this.niTray_DoubleClick);
		}
		#endregion

		[STAThread]
		static void Main()
		{
			Wordy w = new Wordy();
			Application.Run();
		}

		private void miAbout_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Wordy\n" + 
                "Version 1.01\n" + 
                "Written by Gus Perez (gus@jixal.com)\n" + 
                "http://blogs.msdn.com/gusperez", "About Wordy");
        }

		private void miExit_Click(object sender, System.EventArgs e)
		{
			niTray.Visible = false;
			Application.Exit();
		}

		private void miLookUpWord_Click(object sender, System.EventArgs e)
		{
            using (FindForm ff = new FindForm())
            {
                if (ff.ShowDialog() == DialogResult.OK) 
                {
                    lookUp(ff.SearchWord);
                }
            }
        }

		private void miLookUpClipboard_Click(object sender, System.EventArgs e)
		{
			string word = getClipboardString();

			// If the data is text, look it up
			if (word != string.Empty) 
            {
				lookUp(word);
			}
		}

		private void cmTray_Popup(object sender, System.EventArgs e)
		{
			string word = getClipboardString();

			// If the data is text, enable the clipboard lookup option
			if (word != string.Empty) 
            {
				miLookUpClipboard.Enabled = true;
				miLookUpClipboard.Text = "Look up \"" + word + "\"";
			} 
			else 
            {
				miLookUpClipboard.Text = "No text in clipboard";
				miLookUpClipboard.Enabled = false;
			}
		}

		private void niTray_DoubleClick(object sender, System.EventArgs e)
		{
			if (getClipboardString() != string.Empty) 
			{
				miLookUpClipboard_Click(this, new EventArgs());
			} 
			else 
			{
				miLookUpWord_Click(this, new EventArgs());
			}
		}

        private void lookUp(string word)
        {
            Process.Start(msnDictionaryUrl + word);			
        }

        private string getClipboardString()
        {
            IDataObject data = Clipboard.GetDataObject();

            // If the data is text, enable the clipboard lookup option
            if (data.GetDataPresent(DataFormats.Text)) 
            {
                string word = data.GetData(DataFormats.Text).ToString();
                word = (string)(word.Split(new char[] {' '}, 2).GetValue(0));
                return word.TrimStart();
            } 
            else 
            {
                return string.Empty;
            }
        }
    }
}

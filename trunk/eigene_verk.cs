/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Michael
 * Datum: 19.02.2009
 * Zeit: 17:56
 * 
 * Sie k�nnen diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader �ndern.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using IWshRuntimeLibrary; 

namespace sendto_editieren
{
	/// <summary>
	/// Description of eigene_verk.
	/// </summary>
	public partial class eigene_verk : Form
	{
		MainForm hauptform;
		string path;
		public eigene_verk(MainForm sender)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			hauptform = sender;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Label1Click(object sender, EventArgs e)
		{
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if(textBox1.Text != "")
			{
				
				if(radioButton2.Checked == true)
				{
					
					openFileDialog1.ShowDialog();
					path = openFileDialog1.SafeFileName;
				}
				if(radioButton1.Checked == true)
				{
					
					folderBrowserDialog1.ShowDialog();
					path = folderBrowserDialog1.SelectedPath;
				}
				if (path != "")
				{
					WshShell wsh = new IWshRuntimeLibrary.WshShell(); 
					WshShortcut sc = (WshShortcut)wsh.CreateShortcut(String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.SendTo), "\\",textBox1.Text,".lnk")); 
					sc.TargetPath = path; 
					sc.Description = textBox1.Text;  
					sc.Save();
					this.Close();
					hauptform.einlesen(this);
				}
			}
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}

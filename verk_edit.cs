/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Michael
 * Datum: 21.02.2009
 * Zeit: 12:05
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace sendto_editieren
{
	/// <summary>
	/// Description of verk_edit.
	/// </summary>
	public partial class verk_edit : Form
	{
		MainForm hauptform;
		string pfad;
		string dateiname;
		public verk_edit(MainForm hauptform_hand,string path)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			hauptform = hauptform_hand;
			pfad =path;
			dateiname = path.Replace(String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.SendTo), "\\" ),"");
			
			string anzuzeigen;
			
			if(dateiname == "Compressed (zipped) Folder.ZFSendToTarget")
					{
					anzuzeigen = "ZIP-komprimierten Ordner";
					}
				
			if(dateiname == "Desktop (create shortcut).DeskLink")
					{
					anzuzeigen = "Desktop (Verknüpfung erstellen)";
					}
			
			if(dateiname == "Dokumente.mydocs")
					{
					anzuzeigen = "Dokumente";
					}
				
			if(dateiname == "Mail Recipient.MAPIMail")
					{
					anzuzeigen = "E-Mail-Empfänger";
					}
			
			anzuzeigen= dateiname.Replace(".lnk","");
			anzuzeigen= anzuzeigen.Replace(".DeskLink","");
			anzuzeigen= anzuzeigen.Replace(".ZFSendToTarget","");
			anzuzeigen= anzuzeigen.Replace(".MAPIMail","");
			anzuzeigen= anzuzeigen.Replace(".mydocs","");
			
			textBox1.Text = anzuzeigen;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Label1Click(object sender, EventArgs e)
		{
			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			string endung = endung_heraus(dateiname,new string[] {".lnk",".DeskLink",".ZFSendToTarget",".MAPIMail",".mydocs"});
			string neuername = String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.SendTo), "\\",textBox1.Text,endung);
			
			try
			{
			File.Move(pfad,neuername);
			this.Close();
			hauptform.einlesen();
			}
			catch(IOException)
			{
				MessageBox.Show("Eine Verknüpfung dieses Namens existiert bereits. Wähle einen Anderen !","Verknüpfung bearbeiten",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}

		}
		string endung_heraus(string name,string[] mgl)
		{
			foreach (string aktuell in mgl)
			{
				if(name.EndsWith(aktuell))
				{
					return aktuell;
				}
			}
			return "";
		}
	}
}

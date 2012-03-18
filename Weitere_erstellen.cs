/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Michael
 * Datum: 15.02.2009
 * Zeit: 13:53
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
	/// Description of Weitere_erstellen.
	/// </summary>
	public partial class Weitere_erstellen : Form
	{
		MainForm hauptform;
		public Weitere_erstellen(MainForm sender)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			hauptform = sender;
			
		
			InitializeComponent();
			comboBox1.SelectedIndex = 0;
			
			if(isXP())
			{
				comboBox1.Items.RemoveAt(1);
			}
			else
			{
				comboBox1.Items.RemoveAt(3);	
			}
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
	bool isXP()
	{
 		OperatingSystem myOSSystem = System.Environment.OSVersion;


 			
  		if (myOSSystem.Version.Major == 5)
  				{
					return true;
  				}
  		else
  				{
					return false;  					
  				}

 }




		
		void Button2Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if(comboBox1.SelectedIndex == 0)
			{
				FileInfo FI = new FileInfo(String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.SendTo),"\\Desktop (Verknüpfung erstellen).DeskLink"));
				FileStream FS = FI.Create();
				FS.Close();
				this.Close();
				hauptform.einlesen();
			}
			
			if(comboBox1.SelectedIndex == 1)
			{
				//E-Mail Empfänger
				if(isXP())
				{
				FileInfo FI = new FileInfo(String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.SendTo),"\\E-Mail-Empfänger.MAPIMail"));
				FileStream FS = FI.Create();
				FS.Close();
				this.Close();
				hauptform.einlesen();
				}
				// Dokumente
				else
				{
				FileInfo FI = new FileInfo(String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.SendTo),"\\Dokumente.mydocs"));
				FileStream FS = FI.Create();
				FS.Close();
				this.Close();
				hauptform.einlesen();
				}
			}
			
			if(comboBox1.SelectedIndex == 2)
			{
				// Eigene Dateien
				if(isXP())
				{
				FileInfo FI = new FileInfo(String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.SendTo),"\\Eigene Dateien.mydocs"));
				FileStream FS = FI.Create();
				FS.Close();
				this.Close();
				hauptform.einlesen();	
				}
				// E-Mail Empfänger
				else
				{
				FileInfo FI = new FileInfo(String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.SendTo),"\\E-Mail-Empfänger.MAPIMail"));
				FileStream FS = FI.Create();
				FS.Close();
				this.Close();
				hauptform.einlesen();
				}
			}
			
			if(comboBox1.SelectedIndex == 3)
			{
//				Eigene Verknüfung
				
				this.Close();
				hauptform.eigene_verk_offnen();

			}
			
			if(comboBox1.SelectedIndex == 4)
			{
				FileInfo FI = new FileInfo(String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.SendTo),"\\ZIP-komprimierten Ordner.ZFSendToTarget"));
				FileStream FS = FI.Create();
				FS.Close();
				this.Close();
				hauptform.einlesen();
			}
		}
	}
}

/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Michael
 * Datum: 15.02.2009
 * Zeit: 13:53
 * 
 * Sie k�nnen diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader �ndern.
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
		public Weitere_erstellen()
		{		
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
		}
		
		bool isXP()
		{
  			return (System.Environment.OSVersion.Version.Major == 5);
 		}




		
		void Button2Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if(comboBox1.SelectedIndex == 3)
			{
				// Eigene Verkn�fung
				eigene_verk dialog2 = new eigene_verk();
				dialog2.ShowDialog();
				this.Close();
			}
			else
			{
				FileInfo FI;
				
				if(comboBox1.SelectedIndex == 0)
				{
					FI = new FileInfo(String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.SendTo),"\\Desktop (create shortcut).DeskLink"));
				}
			
				else if(comboBox1.SelectedIndex == 1)
				{
					//E-Mail Empf�nger
					if(isXP())
					{
						FI = new FileInfo(String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.SendTo),"\\Mail Recipient.MAPIMai"));

					}
					
					// Dokumente
					else
					{
						FI = new FileInfo(String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.SendTo),"\\Dokumente.mydocs"));
					}
				}
			
				else if(comboBox1.SelectedIndex == 2)
				{
					// Eigene Dateien
					if(isXP())
					{
						FI = new FileInfo(String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.SendTo),"\\Eigene Dateien.mydocs"));

					}
					// E-Mail Empf�nger
					else
					{
						FI = new FileInfo(String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.SendTo),"\\Mail Recipient.MAPIMail"));
					}
				}
					
				else
				{
					FI = new FileInfo(String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.SendTo),"\\Compressed (zipped) Folder.ZFSendToTarget"));
				}
				
				FileStream FS = FI.Create();
				FS.Close();
				this.Close();
			}
		}
	}
}

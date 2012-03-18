using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace sendto_editieren
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		string[] auswahl_dateien;
		MainForm diesesform;
		public MainForm()
		{

			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

			listBox1.MouseDown += new MouseEventHandler(listBox1_down);
			
			einlesen();
			diesesform = this;
			
			
		}
		
		public void einlesen()
		{
			
			listBox1.Items.Clear();

			// Sendto Ordner
			string sendto = Environment.GetFolderPath(Environment.SpecialFolder.SendTo);

			// Einlesen aller Dateien im Sendtordner
			string[] Files = System.IO.Directory.GetFiles(sendto);
			
			// Array für gefilterte Liste
			auswahl_dateien = new string[Files.Length];
			
			// Pfad zu Desktop.ini
			
			string desktop = String.Concat(sendto, "\\Desktop.ini" ).ToLower();
			int i = 0;
			foreach (string datei in Files)
			{
				// Desktop.ini ist kein SendTo Element
				if(datei.ToLower() != desktop)
				{	
					string name = datei.Replace(String.Concat(sendto, "\\" ),"");
				
					if(name == "Compressed (zipped) Folder.ZFSendToTarget")
					{
						name = "ZIP-komprimierten Ordner";
					}
				
					if(name == "Desktop (create shortcut).DeskLink")
					{
						name = "Desktop (Verknüpfung erstellen)";
					}
				
					if(name == "Dokumente.mydocs")
					{
						name = "Dokumente";
					}
				
					if(name == "Mail Recipient.MAPIMail")
					{
						name = "E-Mail-Empfänger";
					}
					
					name= name.Replace(".lnk","");
					name= name.Replace(".DeskLink","");
					name= name.Replace(".ZFSendToTarget","");
					name= name.Replace(".MAPIMail","");
					name= name.Replace(".mydocs","");
					// Pfad dem Array hinzufügen, Name der Auflistung
					listBox1.Items.Add(name);
					auswahl_dateien[i] = datei;
					i++;
				
				}
			
			
			}
		}

		
		void listBox1_down(object sender,MouseEventArgs e)
		{
			try
			{
				//Selects the item that was clicked on
				if(e.Button == MouseButtons.Right && listBox1.IndexFromPoint(e.X,e.Y) != ListBox.NoMatches)
				{
					listBox1.SelectedIndex = listBox1.IndexFromPoint(e.X,e.Y);
					contextMenuStrip1.Show(listBox1,e.X,e.Y);
				}
			}
			catch(Exception)
			{
				
			}
		}
		
		
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			if(listBox1.SelectedIndex != -1)
			{
				button1.Enabled = true;
				button3.Enabled = true;
			}

		}
		
		void Button1Click(object sender, EventArgs e)
		{
			System.IO.File.Delete(auswahl_dateien[listBox1.SelectedIndex]);
			einlesen();
		}
		
		void Button2Click(object sender, EventArgs e)
		{

			
			Weitere_erstellen dialog = new Weitere_erstellen(diesesform);
			dialog.ShowDialog();
		}
		
		public void eigene_verk_offnen()
		{
			eigene_verk dialog2 = new eigene_verk(diesesform);
			dialog2.ShowDialog(diesesform);
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			verk_edit bearbeiten= new verk_edit(diesesform,auswahl_dateien[listBox1.SelectedIndex]);
			bearbeiten.ShowDialog();
		}
		
		void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			about_st fenster = new about_st();
			fenster.ShowDialog();
		}
	}
}

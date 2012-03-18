/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Michael
 * Datum: 06.02.2009
 * Zeit: 18:29
 * 
 * Sie k�nnen diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader �ndern.
 */

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

			einlesen(this);
			diesesform = this;
		}
		
		public void einlesen(object sender)
		{
			
			listBox1.Items.Clear();
			
			// Sendto Ordner
			string sendto = Environment.GetFolderPath(Environment.SpecialFolder.SendTo);

			// Einlesen aller Dateien im Sendtordner
			string[] Files = System.IO.Directory.GetFiles(sendto);
			
			// Array f�r gefilterte Liste
			auswahl_dateien = new string[Files.Length];
			
			// Pfad zu Desktop.ini
			
			string desktop = String.Concat(sendto, "\\Desktop.ini" );
			string desktop2 = String.Concat(sendto, "\\desktop.ini" );
			int i = 0;
			foreach (string datei in Files)
			{
				// Desktop.ini ist kein SendTo Element
				if(datei != desktop && datei != desktop2)
				{
				
				
				string name = datei.Replace(String.Concat(sendto, "\\" ),"");
				
				if(name == "Compressed (zipped) Folder.ZFSendToTarget")
					{
					name = "ZIP-komprimierten Ordner";
					}
				
				if(name == "Desktop (create shortcut).DeskLink")
					{
					name = "Desktop (Verkn�pfung erstellen)";
					}
				
				if(name == "Dokumente.mydocs")
					{
					name = "Dokumente";
					}
				
				if(name == "Mail Recipient.MAPIMail")
					{
					name = "E-Mail-Empf�nger";
					}
				name= name.Replace(".lnk","");
				name= name.Replace(".DeskLink","");
				name= name.Replace(".ZFSendToTarget","");
				name= name.Replace(".MAPIMail","");
				name= name.Replace(".mydocs","");
				// Pfad dem Array hinzuf�gen, Name der Auflistung
				listBox1.Items.Add(name);
				auswahl_dateien[i] = datei;
				i++;
				
				}
			
			
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
			einlesen(sender);
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

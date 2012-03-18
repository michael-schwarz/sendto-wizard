/*
 * Developed by Michael Schwarz
 * See programs.xe.cx or 7fonline.de.vu for futher information
 * Developed with Sharp Develeop
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace sendto_editieren
{
	/// <summary>
	/// Description of about_st.
	/// </summary>
	public partial class about_st : Form
	{
		public about_st()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			textBox2.Text = Application.ProductVersion;
		}
		
		void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://programs.xe.cx/");			
		}
	}
}

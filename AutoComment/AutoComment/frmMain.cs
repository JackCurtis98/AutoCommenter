using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoComment
{
    public partial class frmMain : Form
    {

        private string[] dirFiles; // The path and filename's

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string initalLine = @"/*
*
*       Server: OurCompany
*       AUTHOR: Jack Curtis
*       Copyright OurCompany (C) 2017
*
*/"; //Inital block of text for our textbox.

            txtComment.Text = initalLine; // Assigning our textbox the string.
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (dirFiles != null)
            {
                foreach (var item in dirFiles)
                {
                    using (StreamWriter sw = new StreamWriter(item)) // Using StreamWriter to write our text.
                    {
                        for (int i = 0; i < txtComment.Lines.Length; i++) // Itterating through the lines inside of our RTB.
                        {
                            sw.WriteLine(txtComment.Lines[i]); // Writing to File..
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a directory to get started.."); //Catching
            }
        }

        private void btnDir_Click(object sender, EventArgs e)
        {
            DialogResult result = fbdDir.ShowDialog(); //Result is equal to our ShowDialog.
            
            if (result == DialogResult.OK)
            {
                dirFiles = Directory.GetFiles(fbdDir.SelectedPath); //Directory Files getting from the path of our FolderBrowserDialog.
                frmMain.ActiveForm.Text = "Auto Commenting - JCurtis (DIR = " + fbdDir.SelectedPath + ")" //Setting title to directory to give the user some sense of security.
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ConditionalMethodsExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.btnCopyFile.Click += new System.EventHandler(this.btnCopyFile_Click);

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // The BuildVersionMessage setting will be set at compile time:
            this.lblHeader.Text = Properties.Settings.Default.BuildVersionMessage;
        }


        private void btnCopyFile_Click(object sender, EventArgs e)
        {
            this.CopyFile();
        }


        private void CopyFile()
        {
            // The correct output file path will be defined at compile time, 
            // and made available through the settings file:
            string outputDirectory = Properties.Settings.Default.OutputFolderPath;

            // Make sure the directory exists:
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = 
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                fileDialog.Multiselect = false;

                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string oldFullFileName = fileDialog.FileName;
                    string safeFileName = fileDialog.SafeFileName;

                    // Create a new File Name using the output directory 
                    // defined at compile time:
                    string newFullFileName = outputDirectory + safeFileName;

                    // Check to see if a file with the same name already exists:
                    if (File.Exists(newFullFileName))
                    {
                        // File.Copy won't let us overwrite. Since the user has no knowledge 
                        // of this directory, we just delete the old, and save the new:
                        File.Delete(newFullFileName);
                    }

                    // Copy the file into our secret hidden directory:
                    File.Copy(oldFullFileName, newFullFileName);

                    // ...
                    // Add code here to persist the file path and other information 
                    // to the data store for access within the application . . .
                    // ...
                }              
            }
        }
    }
}

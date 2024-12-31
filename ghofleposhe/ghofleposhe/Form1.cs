using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ghofleposhe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;

                try
                {
                    String username = Environment.UserName;
                    DirectorySecurity ds = Directory.GetAccessControl(path);
                    FileSystemAccessRule accessRule=new FileSystemAccessRule(username,FileSystemRights.FullControl,AccessControlType.Deny);

                    ds.AddAccessRule(accessRule);
                    Directory.SetAccessControl(path, ds);
                    MessageBox.Show("پوشه قفل شد");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog2.SelectedPath;
                groupBox1.Visible = true;


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String passwoed = textBox1.Text;

            if (passwoed == "ali.ir1382" && !String.IsNullOrEmpty(passwoed))
            {
                string path = folderBrowserDialog2.SelectedPath;

                try
                {
                    String username = Environment.UserName;
                    DirectorySecurity ds = Directory.GetAccessControl(path);
                    FileSystemAccessRule accessRule = new FileSystemAccessRule(username, FileSystemRights.FullControl, AccessControlType.Deny);

                    ds.RemoveAccessRule(accessRule);
                    Directory.SetAccessControl(path, ds);
                    MessageBox.Show("پوشه باز شد");

                    groupBox1.Visible=false;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

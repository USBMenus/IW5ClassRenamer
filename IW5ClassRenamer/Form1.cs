using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Memory;

namespace IW5ClassRenamer
{
    public partial class Form1 : Form
    {
        Mem m = new Mem();
        public string[] classes = 
        {
        "01CE53F8",
        "01CE545A",
        "01CE54BC",
        "01CE551E",
        "01CE5580",
        "01CE55E2",
        "01CE5644",
        "01CE56A6",
        "01CE5708",
        "01CE576A",
        "01CE57CC",
        "01CE582E",
        "01CE5890",
        "01CE58F2",
        "01CE5954" 
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Process[] proc = Process.GetProcessesByName("plutonium-bootstrapper-win32");
            if (proc.Length == 0) MessageBox.Show("Make Sure the Game Is Running", "Game Not Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (proc.Length > 1) MessageBox.Show("Too Many Instances Open\nTry Closing The Others With Task Manager", "Too Many Instances", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                m.OpenProcess(Process.GetProcessesByName("plutonium-bootstrapper-win32").FirstOrDefault().Id);
                textBox1.Text = m.ReadString(classes[comboBox1.SelectedIndex], "", 20);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Process[] proc = Process.GetProcessesByName("plutonium-bootstrapper-win32");
            if (proc.Length == 0) MessageBox.Show("Make Sure the Game Is Running", "Game Not Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (proc.Length > 1) MessageBox.Show("Too Many Instances Open\nTry Closing The Others With Task Manager", "Too Many Instances", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (comboBox1.SelectedIndex == -1) MessageBox.Show("You Must Select A Class", "Select A Class", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                m.OpenProcess(Process.GetProcessesByName("plutonium-bootstrapper-win32").FirstOrDefault().Id);
                m.WriteMemory(classes[comboBox1.SelectedIndex], "bytes", "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0");
                m.WriteMemory(classes[comboBox1.SelectedIndex], "string", textBox1.Text);
            }
        }
    }
}

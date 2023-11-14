using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyLogger
{
    public partial class Form1 : Form
    {
        string file = "Record.txt";
        string pass = "Password.txt";
        string decode = "Decode.txt";
        int s = 0;
        string k = "";
        byte[] key = new byte[16];
        byte[] iv = new byte[16];
        public Form1()
        {
            InitializeComponent();
        }
    }
}

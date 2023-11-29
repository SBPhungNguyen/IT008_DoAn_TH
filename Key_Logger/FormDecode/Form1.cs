using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormDecode
{
    public partial class Form1 : Form
    {
        string file;
        string pass;
        string decode;
        string strkey = "A171AA811A6D353C8BC40F82B689F889";
        string striv = "C87799A3280FE1BC574DED5BC85D003F";
        public Form1()
        {
            InitializeComponent();
        }
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

        private void FilePick_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog.FileName;
                FileLocation.Text = file;
            }
        }

        private void DecodeButton_Click(object sender, EventArgs e)
        {
            FileContent.Text = "";
            string line;
            if (/*Key.Text == "" || IV.Text == "" || */FileLocation.Text == "")
            {
                FileContent.Text = "Vui lòng chọn File và nhập đầy đủ Key và IV (đây không phải giải mã)";
            }
            else
            {
                try
                {
                    byte[] key = new byte[16];
                    byte[] iv = new byte[16];
                    for (int i = 0; i < 32; i += 2)
                    {
                        key[i / 2] = Convert.ToByte(strkey.Substring(i, 2), 16);
                    }
                    for (int i = 0; i < 32; i += 2)
                    {
                        iv[i / 2] = Convert.ToByte(striv.Substring(i, 2), 16);
                    }
                    using (StreamReader sr = new StreamReader(file))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            byte[] encrypted_k = Convert.FromBase64String(line);
                            string decrypted_k = Decrypt(encrypted_k, key, iv);
                            FileContent.Text = FileContent.Text + " " + decrypted_k;
                        }
                    }
                }
                catch(Exception) 
                {
                    FileContent.Text = "Key và IV sai (đây không phải giải mã)";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Key.Text = "";
            IV.Text = "";
            FileContent.Text = "";
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Model;
using BLL;


namespace ComManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ActiveUser au = new ActiveUser();
        AuManager am=new AuManager();
        string psw = "南&%山%+-南%*/";
        string xyz;//加密后的用户名
        private void button2_Click(object sender, EventArgs e)
        {
            au = new ActiveUser()
            {
                Login_name = uname.Text.Trim(),
                Password = upass.Text.Trim()
            };
            string messageStr = null;

            if (am.Login(au, out messageStr))
            {
                MessageBox.Show("登录成功");
                TextEncrypt(uname.Text.Trim(),psw);
                string[] strs = {xyz};
                File.WriteAllLines(@"c:\xinyutian\User.data", strs);
                //MessageBox.Show("保存成功!");
                Form2 fm2 = new Form2();
                fm2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(messageStr);
                uname.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            //userInfo = new UserInfo()
            //{
            //    Username = uname.Text.Trim(),
            //    Password = upass.Text.Trim()
            //};
            //string messageStr = null;

            //if (lm.Add(userInfo, out messageStr))
            //{
            //    MessageBox.Show("添加成功");
                
            //}
            //else
            //{
            //    MessageBox.Show(messageStr);
            //    uname.Focus();
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form10 fm2 = new Form10();
            fm2.Show();
            this.Hide();
        }
        private char[] TextEncrypt(string content, string secretKey)
        {
            char[] data = content.ToCharArray();
            char[] key = secretKey.ToCharArray();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= key[i % key.Length];
                xyz += data[i];
            }
            return data;
        }
        private string TextDecrypt(char[] data, string secretKey)
        {
            char[] key = secretKey.ToCharArray();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= key[i % key.Length];
            }
            return new string(data);
        }
    }
}

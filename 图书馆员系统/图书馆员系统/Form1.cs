using Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 图书馆员系统
{
    public partial class Form1 : Form
    {
     
        public Form1()
        {
            InitializeComponent();
        }

        Form2 Form2;
        Form3 Form3;
        private void Form1_Load(object sender, EventArgs e)
        {
            label5.Text = "";
        }
     

        private void button1_Click(object sender, EventArgs e)
        {
            
            string uid = textuid.Text;
            string pwd = textpwd.Text;
            if (uid !="" && pwd !="")
            {
                userdal userdal = new userdal();
                if (userdal.Logon(uid, pwd))
                {
                    label5.Text = "";
                    MessageBox.Show("登录成功！");
                    this.Hide();
                 
                   Form3 = new Form3() { 
                   sid = uid
                   }  ;
                    Form3.Tag = this;
                    Form3.Show();

                }
                else
                {
                    label5.Text = "账户密码错误！";
                }
            }else
            {

                MessageBox.Show("请输入账户密码");
            }
            

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 = new Form2();
            Form2.Tag = this;
            Form2.Show();
            
        }

       

        private void textuid_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 检查输入的字符是否是字母或数字，如果不是则取消输入
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            // 检查输入的字符是否是中文，如果是则取消输入
            else if (e.KeyChar >= 0x4e00 && e.KeyChar <= 0x9fbb)
            {
                e.Handled = true;
            }
        }

        private void textpwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '\u4e00' && e.KeyChar <= '\u9fff')
            {
                e.Handled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}

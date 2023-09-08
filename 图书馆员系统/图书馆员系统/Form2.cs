using Bll;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 图书馆员系统
{
    public partial class Form2 : Form
    {
       private List<libraryusermod> list = new List<libraryusermod>();
        List<role> rl = new List<role>();

        public Form2()
        {
            InitializeComponent();
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            libraryusermod lib = new libraryusermod();

            if(textBox1.Text !="" && textBox2.Text!="" && textBox3.Text != "")
            {
                
                lib.Sid = textBox1.Text;
                lib.Pwd = textBox2.Text;
                lib.Sname = textBox3.Text;

                if (radioButton1.Checked)
                {
                    lib.Sex = radioButton1.Text;
                }
                else
                {
                    lib.Sex = radioButton2.Text;
                }

                if (radioButton3.Checked)
                {
                    lib.States = radioButton3.Text;
                }
                else
                {
                    lib.States = radioButton4.Text;
                }

                 lib.Roleid = (int)comboBox1.SelectedValue;



                if (selectbll.selects(textBox1.Text))
                {
                    if (adduserbll.addusers(lib))
                    {

                        MessageBox.Show("注册成功！");

                    }
                    else
                        MessageBox.Show("注册失败！");
                }
                else
                    MessageBox.Show("用户名重复,请更换");
                
            }
            else
            {
                MessageBox.Show("请填入完整信息");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '\u4e00' && e.KeyChar <= '\u9fff')
            {
                e.Handled = true;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            Form1 form1 = (Form1)this.Tag;  
            form1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string connString = @"server=127.0.0.1;uid=sa;pwd=123456;database=Library";
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from role";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable roletable = new DataTable();
                adapter.Fill(roletable);
              
                comboBox1.DataSource = roletable;
                comboBox1.DisplayMember = "rolename";
                comboBox1.ValueMember = "roleid";

            }
            catch (Exception ex)
            {

            }
            finally { con.Close(); }

        }
    }
}


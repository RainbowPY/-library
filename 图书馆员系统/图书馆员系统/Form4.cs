using Bll;
using Dal;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 图书馆员系统
{
    public partial class Form4 : Form
    {

       
        public static BindingList<bookmod> bookmods = null;
        bool del =true;
        public Form4()
        {
            InitializeComponent();
        }


       //    提交按钮
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
               
                if (Regex.IsMatch(textBox1.Text, @"^[1-9]+$"))    //利用正则进行判断 仅数字 查询 编号
                {
                    int  sel =int.Parse(textBox1.Text);
                    selectbll.Selectbook(sel);
                    NewMethod();
                }
                else if (Regex.IsMatch(textBox1.Text, @"\w+$"))   // 查询 书本名字
                {
                    string sel = textBox1.Text;
                    selectbll.Selectbook(sel);
                    NewMethod();
                }
                else
                {
                    MessageBox.Show("输入不规范");
                }
            }
            else
            {
                MessageBox.Show("请输入想要查找的书籍名称或编号");
            }
            del = true;
            checkBox2.Checked = false;
        }


        // 页面加载
        private void Form4_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
   
            selectbll.selectbook();
            NewMethod();

            // treeview 加载
            selectbll.selectbooktype();
            foreach(DataRow row in userdal.dataTable.Rows)      //根节点
            {
                TreeNode node = new TreeNode();
                int a = 0;
                if (int.Parse(row["parentid"].ToString()) == 0)
                {
                    node.Text = row["typename"].ToString();

                    a = int.Parse(row["typeid"].ToString());

                    treeView1.Nodes.Add(node);
                   
                }
                foreach(DataRow rows in userdal.dataTable.Rows)     //子节点
                {
                    int b = int.Parse(rows["parentid"].ToString());
                    TreeNode nodes = new TreeNode();
                    if (a == b)
                    {
                        nodes.Text= rows["typename"].ToString();
                        node.Nodes.Add(nodes);
                    }
                }
            }
        }

        // 向dataGridView1视图中添加数据
        private void NewMethod()
        {
            bookmods = new BindingList<bookmod>();

            // 加载数据源
            foreach (DataRow row in userdal.dataTable.Rows)
            {

                bookmod bookmod = new bookmod();

                bookmod.Id = (int)row["id"];
                bookmod.Bookname = (string)row["bookname"];
                bookmod.Typeid = (int)row["typeid"];
                bookmod.Price = (int)row["price"];
                bookmod.Num = (int)row["num"];
                bookmod.Indate = (DateTime)row["indate"];
                bookmod.Pricture = row["pricture"].ToString();
                bookmods.Add(bookmod);

            }
            dataGridView1.DataSource = bookmods;


            // 绑定combox 下拉框数据
            selectbll.selectbooktype();
            foreach (DataGridViewRow row in dataGridView1.Rows) {

                DataGridViewComboBoxCell comboxCell = new DataGridViewComboBoxCell();
                row.Cells[3] = comboxCell;
                comboxCell.DataSource = userdal.dataTable;

                comboxCell.DisplayMember = "typename";
                comboxCell.ValueMember = "typeid";

            }
            
           
        }


        //   全选 按钮
        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;

                    // 设置为Checked状态  
                    cell.Value = true;
                }

            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;

                    // 设置为Checked状态  
                    cell.Value = null;
                }
            }
        }

        //  双击 dataGridView1 事件
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            NewMethod1(sender, e,del);
        }


        //   检测 点击位置
        private void NewMethod1(object sender, DataGridViewCellEventArgs e,bool del)
        {
            if (e.ColumnIndex == 6)   // 修改
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                int index = dataGridView1.CurrentCell.OwningRow.Index;

                Form5 form5 = new Form5(bookmods[index], true);
                form5.Tag = bookmods[index];
                form5.ShowDialog();
            }
            if (e.ColumnIndex == 7)  //删除
            {
                if (del)
                {
                    button3_Click(sender, e, true);
                }
                else
                {
                    button3_Click(sender, e, false);
                }


            }
        }

        // 删除按钮
        private void button3_Click(object sender, EventArgs e, bool del)
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            if (del)
            {

                if (deletebll.deletebook(id))
                {
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                    MessageBox.Show("删除成功");
                }
                else
                    MessageBox.Show("删除失败");

            }
            else
            {
                if (deletebll.deletedel(id))
                {
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                    MessageBox.Show("删除成功");
                }
                else
                    MessageBox.Show("删除失败");
            }



        }


        // 添加按钮
        private void button2_Click(object sender, EventArgs e)
        {
            new Form5(false).ShowDialog();
            selectbll.selectbook();
            NewMethod();

        }

     
        //  已删除
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                selectbll.selectdel();
                NewMethod();
                del = false;
            }else
            {
                selectbll.selectbook();
                NewMethod();
                del = true;
            }
        }

        private void 程序类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectbll.selectbooktype(3);
            NewMethod();
        }

        private void 文学类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectbll.selectbooktype(1);
            NewMethod();
        }

        private void 体育类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectbll.selectbooktype(5);
            NewMethod();
        }

        private void 数学类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectbll.selectbooktype(6);
            NewMethod();
        }

        private void 文艺类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectbll.selectbooktype(4);
            NewMethod();
        }

        private void 游戏类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectbll.selectbooktype(2);
            NewMethod();
        }

        private void button3_Click(object sender, EventArgs e)  //删除
        {

            if (del)    //现有书籍删除
            {
                

                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];

                    DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;

                    if (cell.Value != null)
                    {
                        int idd = int.Parse(row.Cells[1].Value.ToString());

                        deletebll.deletebook(idd);
                        bookmods.RemoveAt(i);
                    }

                }
               
            }
            else  // 删除书籍 删除
            {

                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];

                    DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;

                    if (cell.Value != null)
                    {
                        int idd = int.Parse(row.Cells[1].Value.ToString());

                        deletebll.deletedel(idd);
                        bookmods.RemoveAt(i);
                    }

                }

            }
        }

        private  void button4_Click(object sender, EventArgs e) //恢复
        {
            if (del) { }
            else{
                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];

                    DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;

                    if (cell.Value != null)
                    {
                        int cc = int.Parse(row.Cells[1].Value.ToString());
                        selectbll.selectdelbook(cc);
                        bookmod book = NewMethod2();
                        adduser.Huifu(book);
                        deletebll.deletedel(cc);

                        bookmods.RemoveAt(i);
                    }

                }
            }
            
            
        }

        // bookmod  实体数据封装
        private static bookmod NewMethod2()
        {
            bookmod bookmod = new bookmod();

            foreach (DataRow row in userdal.dataTable.Rows)
            {
                bookmod.Id = (int)row["id"];
                bookmod.Bookname = (string)row["bookname"];
                bookmod.Typeid = (int)row["typeid"];
                bookmod.Price = (int)row["price"];
                bookmod.Num = (int)row["num"];
                bookmod.Indate = (DateTime)row["indate"];
                bookmod.Pricture = row["pricture"].ToString();
            }

            return bookmod;
        }

        // treeview 菜单栏
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string type = treeView1.SelectedNode.Text;
          
            selectbll.selectbooktype(type);
            NewMethod();


        }

       
    }
}


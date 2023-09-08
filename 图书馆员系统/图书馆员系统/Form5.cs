using Bll;
using Dal;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace 图书馆员系统
{
    public partial class Form5 : Form
    {
        bookmod bookmod=null;
        bool isupdat = false;
        string name = string.Empty;
        ArrayList list = new ArrayList();
        bool updatebook = false;
        public Form5()
        {
            InitializeComponent();
        }
        public Form5( bool isadd)
        {
           
            this.isupdat = isadd;
            InitializeComponent();
     
        }
        public Form5(bookmod bookmod, bool isadd)
        {
            
            this.bookmod = bookmod;
            
            this.isupdat = isadd;
            InitializeComponent();
        }



        //   打开保存图片
        private void button3_Click(object sender, EventArgs e)
        {
        
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog(this);
            string str = ofd.FileName;
           
            Console.WriteLine(str);
            if (str != "")
            {
                using (FileStream fs = new FileStream(str, FileMode.Open))
                {

                    name = Path.GetFileName(str);
                    textBox3.Text = name;
                    string distPath = Path.Combine(Directory.GetCurrentDirectory(), name);
                    using (FileStream fsWrites = new FileStream(distPath, FileMode.Create))
                    {
                        while (true)
                        {
                            byte[] bytes = new byte[1024 * 1024];
                            int len = fs.Read(bytes, 0, bytes.Length);
                            if (len <= 0) break;
                            fsWrites.Write(bytes, 0, len);
                        }
                    }

                    Console.WriteLine(distPath);
                }
            }
            
            NewMethod();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
           

            selectbll.selectbooktype();
           
            comboBox1.DataSource = userdal.dataTable; ;
            comboBox1.DisplayMember = "typename";
            comboBox1.ValueMember = "typeid";

            if (isupdat)
            {
                list.Add(bookmod.Id);
                list.Add(bookmod.Bookname);
                list.Add(bookmod.Typeid);
                list.Add(bookmod.Price);
                list.Add(bookmod.Num);
                list.Add(bookmod.Indate);
                list.Add(bookmod.Pricture);
                

                textid.DataBindings.Add("Text", bookmod, "id", true, DataSourceUpdateMode.Never);
                textname.DataBindings.Add("Text", bookmod, "bookname", true, DataSourceUpdateMode.OnPropertyChanged);
                comboBox1.DataBindings.Add("SelectedValue", bookmod, "typeid", true, DataSourceUpdateMode.OnPropertyChanged);
                numericUpDown1.DataBindings.Add("Value", bookmod, "price", true, DataSourceUpdateMode.OnPropertyChanged);
                numericUpDown2.DataBindings.Add("Value", bookmod, "num", true, DataSourceUpdateMode.OnPropertyChanged);
                dateTimePicker1.DataBindings.Add("Text", bookmod, "indate", true, DataSourceUpdateMode.OnPropertyChanged);
                textBox3.DataBindings.Add("Text", bookmod, "pricture", true, DataSourceUpdateMode.OnPropertyChanged);

                textid.Text = bookmod.Id.ToString();
                textname.Text = bookmod.Bookname.ToString();
                comboBox1.SelectedValue = bookmod.Typeid;
                numericUpDown1.Value = bookmod.Price;
                numericUpDown2.Value = bookmod.Num;
                dateTimePicker1.Text = bookmod.Indate.ToString();
                textBox3.Text = bookmod.Pricture;
            }

            NewMethod();

           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textid.Text != "" && textname.Text != "" && numericUpDown1.Value != 0 && numericUpDown2.Value != 0)
            {
                updatebook = true;
                bookmod bookmod = new bookmod();
                bookmod.Id = int.Parse(textid.Text);
                bookmod.Bookname = textname.Text;
                bookmod.Typeid = (int)comboBox1.SelectedValue;
                bookmod.Price = (int)numericUpDown1.Value;
                bookmod.Num = (int)numericUpDown2.Value;
                bookmod.Indate = dateTimePicker1.Value;
                bookmod.Pricture = textBox3.Text;

                if (isupdat)
                {
                    if (adduser.Updatebook(bookmod))
                    {
                        MessageBox.Show("更改成功");


                    }
                    else
                    {
                        MessageBox.Show("更改失败");
                    }
                }
                else
                {
                    if (adduserbll.addbook(bookmod))
                    {
                        MessageBox.Show("添加成功");
                        textid.Text = null; textname.Text = null;

                        comboBox1.SelectedValue = 1;
                        numericUpDown1.Value = 0;
                        numericUpDown2.Value = 0;
                        dateTimePicker1.Value = DateTime.Now;
                        textBox3.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("添加失败");

                    }

                }
            }
            else
            {
                MessageBox.Show("请添加数据");
            }

           
        }
            
        

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (isupdat)
            {
                if (updatebook)
                {
                    Console.WriteLine("已更新");
                }
                else
                {
                    textid.Text = list[0].ToString();
                    textname.Text = list[1].ToString();
                    comboBox1.SelectedValue = list[2].ToString();
                    int a = int.Parse(list[3].ToString());
                    numericUpDown1.Value = a;
                    int b = int.Parse(list[4].ToString());
                    numericUpDown2.Value = b;
                    dateTimePicker1.Text = list[5].ToString();
                    textBox3.Text = list[6].ToString();
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //加载图片

        private void NewMethod()
        {
            string direcString = Directory.GetCurrentDirectory();
            if (!string.IsNullOrEmpty(name))
            {
                string pathSting = Path.Combine(direcString, name);
                if (File.Exists(pathSting))
                {
                    Image image = Image.FromFile(pathSting);
                    pictureBox1.Image = image;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                }
            }else
            {
                string pathSting = Path.Combine(direcString, textBox3.Text);
                if (File.Exists(pathSting))
                {
                    
                    Image image = Image.FromFile(pathSting);
                    pictureBox1.Image = image;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

        }
    }
}

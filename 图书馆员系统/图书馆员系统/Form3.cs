using Bll;
using Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 图书馆员系统
{
    public partial class Form3 : Form
    {
        public string sid { get; set; }
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(string sid)
        {
            this.sid = sid;
            InitializeComponent();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = (Form1)this.Tag;
            form1.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;//取消跨线程
            selectbll.Selectsidroe(sid);

            labsid.Text = userdal.ArrayList[0].ToString();
            labrole.Text = userdal.ArrayList[1].ToString();


            Timer tmr = new Timer();
            tmr.Interval = 100;
            tmr.Tick += Tmr_Tick;
            tmr.Start();

            //Task t1 = Task.Run(() =>
            //{
            //    System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
            //    tmr.Interval = 100;
            //    tmr.Tick += Tmr_Tick;
            //    tmr.Start();
            //    // 创建一个运行消息循环的上下文，以支持Windows Forms Timer。
            //    System.Windows.Forms.Application.Run();
            //});

        }

 


       private void Tmr_Tick(object sender, EventArgs e)
        {

            toolStripStatusLabel1.Text = DateTime.Now.ToString();

            // 检查是否需要在其他线程上调用。
            //if (this.InvokeRequired)
            //{
            //    // 如果需要，使用同样的函数但在UI线程上调用。
            //    this.Invoke(new MethodInvoker(() => Tmr_Tick(sender, e)));
            //}
            //else
            //{
            //    toolStripStatusLabel1.Text = DateTime.Now.ToString();
            //}

        }
        private void button1_Click(object sender, EventArgs e)
        {

            Form4 form4 = new Form4();
            form4.Show();

        }
    }
}

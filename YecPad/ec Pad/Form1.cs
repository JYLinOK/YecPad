using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ec_Pad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

//*************************************************************************************************************
     // 全局参数设定

        private bool flag_ZiDongHuiShou = false;
        public static bool ChaRu = false;
        private int index;
        private int line;
        private int col;
        private int zonghangshu;
        private int guanBiaoHangZiFuShu;
        private int SuoJin ;
        private int suoYin_jiShuHang;
        private int suoYin_zongShuHang;
        private int yiDongLine;
        private int jiShuHang;
        public static int shuDuJianGe = 100;   //时间间隔调节   
        public static string  ziFuChuan = "";   //插入字符串

 //*************************************************************************************************************   

        private void Form1_Load(object sender, EventArgs e)
        {
            this.richTextBox1.AllowDrop = true;
            richTextBox1.EnableAutoDragDrop = true;
            richTextBox1.AcceptsTab = true;

            timer1.Interval = 100;
            timer1.Start();

            richTextBox1.WordWrap = true;
        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag_ZiDongHuiShou == true)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.tabControl1.Location = new Point(0, 0);
                    this.tabControl1.Height = 115 - 20;
                    this.richTextBox1.Location = new Point(0, 115 - 20);
                    this.richTextBox1.Height = 660 + 20;
                }
                else if (this.WindowState == FormWindowState.Normal)
                {
                    this.tabControl1.Location = new Point(0, 0);
                    this.tabControl1.Height = 115 - 20;
                    this.richTextBox1.Location = new Point(0, 115 - 20);
                    this.richTextBox1.Height = 506 + 20;
                }

            }
        }


       

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
            if ( flag_ZiDongHuiShou == true )
            {
                if(this.WindowState == FormWindowState.Maximized )
                {
                    this.tabControl1.Location = new Point(0, 0);
                    this.tabControl1.Height = 20;
                    this.richTextBox1.Location = new Point(0, 20);
                    this.richTextBox1.Height = 814 - 60;
                }
                else if (this.WindowState == FormWindowState.Normal)
                {
                    this.tabControl1.Location = new Point(0, 0);
                    this.tabControl1.Height = 20;
                    this.richTextBox1.Location = new Point(0, 20);
                    this.richTextBox1.Height = 656 - 60;
                    
                }
                
            }
         
        }

        private void button33_Click(object sender, EventArgs e)
        {
            flag_ZiDongHuiShou = false;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            flag_ZiDongHuiShou = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string FileExtension = System.IO.Path.GetExtension(openFileDialog1.FileName);

                if (FileExtension == ".txt")        
                {
                    StreamReader str = new StreamReader(openFileDialog1.FileName, Encoding.Default);  // 新建读取流
                    richTextBox1.Text = str.ReadToEnd();  // 读到底
                    str.Close();  // 关闭读取流

                }
                else if (FileExtension == ".rtf")
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName);  // 装在rtf文件
                }

            }


        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            // 保存

            StreamWriter writerStream;
            saveFileDialog1.Filter = " .*|*.*| .rtf| *.rtf| .txt|*.txt";
            saveFileDialog1.RestoreDirectory = true;

            saveFileDialog1.FileName = openFileDialog1.FileName;
            saveFileDialog1.OverwritePrompt = false;
            this.DialogResult = DialogResult.OK;

            string FileExtension = System.IO.Path.GetExtension(saveFileDialog1.FileName);

            if (FileExtension == ".txt")
            {
                writerStream = new StreamWriter(saveFileDialog1.FileName);  // 新建写入文件的写入流
                writerStream.Write(richTextBox1.Text);
                writerStream.Close();//关闭流

            }
            else if (FileExtension == ".rtf")
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);  // 直接保存rtf
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

           if (MessageBox.Show("是否确定要提出程序？", "退出提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { 
                this.Dispose();
                System.Environment.Exit(0); //退出程序
            }

                
        }

        private void button40_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            // 打印按钮
            printPreviewDialog1.Document = printDocument1;
           // printPreviewDialog1.ShowDialog();
            pageSetupDialog1.Document = printDocument1;

           // 显示页面设置对话框  
           // 下面类的方法用于判断时会执行一次
            if( printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = e.MarginBounds.Left;    // 打印页左边距
            int y = e.MarginBounds.Top;     // 打印页上边距   



            // 使用 Graphics 类 画刷的DrawString 进行绘制      
            e.Graphics.DrawString(this.richTextBox1.Text, this.richTextBox1.Font, Brushes.Black, x, y);
                       
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
           
        }

        private void button41_Click(object sender, EventArgs e)
        {
            StreamWriter writerStream;
            saveFileDialog1.Filter = " .*|*.*| .rtf| *.rtf| .txt|*.txt";
            saveFileDialog1.RestoreDirectory = true;

            this.saveFileDialog1.Title = "另存为 ";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string FileExtension = System.IO.Path.GetExtension(saveFileDialog1.FileName);

                if (FileExtension == ".txt")
                {
                    writerStream = new StreamWriter(saveFileDialog1.FileName);  // 新建写入文件的写入流
                    writerStream.Write(richTextBox1.Text);
                    writerStream.Close();//关闭流

                }
                else if (FileExtension == ".rtf")
                { 
                    richTextBox1.SaveFile(saveFileDialog1.FileName);  // 直接保存rtf
                }

            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            
            StreamWriter writerStream;
            saveFileDialog1.Filter = " .*|*.*| .rtf| *.rtf| .txt|*.txt";
            saveFileDialog1.RestoreDirectory = true;

            this.saveFileDialog1.Title = "请选择新建文件的保存位置和题写文件名 ";

            //**********************************************************************************************************
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string FileExtension = System.IO.Path.GetExtension(saveFileDialog1.FileName);

                if (FileExtension == ".txt")
                {
                    writerStream = new StreamWriter(saveFileDialog1.FileName);  // 新建写入文件的写入流
                    writerStream.Write(richTextBox1.Text);
                    writerStream.Close();//关闭流

                }
                else if (FileExtension == ".rtf")
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName);  // 直接保存rtf
                }

            }
            //**********************************************************************************************************

            richTextBox1.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确定要清空文件所有内容？", "清空提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                richTextBox1.Clear();
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否项目符号圆点？", "编辑提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                richTextBox1.SelectionBullet = true;
            }
            else
            {
                richTextBox1.SelectionBullet = false;
            }
           
        }

        private void button44_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionIndent -= SuoJin;
        }

        private void button45_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionIndent += SuoJin;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 插入字符*****************************************************
            if ( ChaRu == true )
            {
                this.richTextBox1.SelectedText = "";
                this.richTextBox1.SelectedText = ziFuChuan;
                this.richTextBox1.Paste();
                ChaRu = false;
            }


            //**************************************************************


            //***************************************************************
            if (flag_ZiDongHuiShou == false)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.tabControl1.Location = new Point(0, 0);
                    this.tabControl1.Height = 115 - 20;
                    this.richTextBox1.Location = new Point(0, 115 - 20);
                    this.richTextBox1.Height = 660 + 20;
                }
                else if (this.WindowState == FormWindowState.Normal)
                {
                    this.tabControl1.Location = new Point(0, 0);
                    this.tabControl1.Height = 115 - 20;
                    this.richTextBox1.Location = new Point(0, 115 - 20);
                    this.richTextBox1.Height = 506 + 20;
                }

            }
            //***************************************************************

            //实时数据
            //***************************************************************************************************

            index = richTextBox1.GetFirstCharIndexOfCurrentLine();   //光标行第一个字符索引
            line = richTextBox1.GetLineFromCharIndex(index) + 1;    //光标行的行号，从0开始，所以加1
            col = richTextBox1.SelectionStart - index + 1;    //光标列的列号，从0开始，所以加1
            zonghangshu = richTextBox1.GetLineFromCharIndex(richTextBox1.Text.Length) + 1;  //总行数

            //**************************************************
            //求出每一行的字符数

            int ZongHangIndex = richTextBox1.Text.Length;
            int lineNextIndex = richTextBox1.GetFirstCharIndexFromLine(line );
            if( lineNextIndex > 0)
            {
                guanBiaoHangZiFuShu = lineNextIndex - index - 1;
            }
            else   // 避免最末一行的index < 0 的bug
            {
                guanBiaoHangZiFuShu = ZongHangIndex - index;
            }
            //**************************************************

            //************************************************************
            // 定义缩进单位速度
            SuoJin = trackBar1.Value;
            label3.Text = "缩进速度单位: " + SuoJin;

            //************************************************************     
            //**************************************************************************
            // 自动阅读后台处理程序

            shuDuJianGe = 1001 - trackBar2.Value;
            timer2.Interval = shuDuJianGe;
            label4.Text = "阅读速度: " + trackBar2.Value;

            suoYin_zongShuHang = richTextBox1.GetFirstCharIndexFromLine(zonghangshu - 1);   //获取指定行号的第  zonghangshu  行所在的第一个字符索引
                                                                                           
            //**************************************************************************
                                                                                            
            //***************************************************************************************************

            int jiShu = jiShuHang + 1;     
            int yiDongShuDu = 1000 - shuDuJianGe;

            //*****************************************************************************
            //调试信息

            label2.Text =
            "richTextBox1.Site :  " + richTextBox1.Size
          + "  richTextBox1.Height :  " + richTextBox1.Height + Environment.NewLine
          + "  richTextBox1.WordWrap :  " + richTextBox1.WordWrap + Environment.NewLine
          + " richTextBox1.ZoomFactor :  " + richTextBox1.ZoomFactor + Environment.NewLine
          + " index :  " + index + Environment.NewLine
          + " line :  " + line + Environment.NewLine
          + " col :  " + col + Environment.NewLine
          + " zonghangshu :  " + zonghangshu + Environment.NewLine
          + " guanBiaoHangZiFuShu :  " + guanBiaoHangZiFuShu + Environment.NewLine
          + " lineNextIndex :  " + lineNextIndex + Environment.NewLine
          + " ZongHangIndex :  " + ZongHangIndex + Environment.NewLine
          + " 计数行：" + jiShu + Environment.NewLine
          + " 移动速度：" + yiDongShuDu + Environment.NewLine
          + " suoYin_jiShuHang：" + suoYin_jiShuHang.ToString() + Environment.NewLine
          + " suoYin_zongShuHang：" + suoYin_zongShuHang.ToString() + Environment.NewLine
          + " shuDuJianGe：" + shuDuJianGe + Environment.NewLine
          + " 文件拓展名：" + System.IO.Path.GetExtension(openFileDialog1.FileName) + Environment.NewLine
          + " 文件名：" + System.IO.Path.GetFileName(openFileDialog1.FileName) + Environment.NewLine
          + " 缩进单位速度： " + trackBar2.Value + Environment.NewLine
          + " richTextBox1.SelectionIndent： " + richTextBox1.SelectionIndent + Environment.NewLine
          + " richTextBox1.SelectionLength： " + richTextBox1.SelectionLength + Environment.NewLine
          + " richTextBox1.Size： " + richTextBox1.Size + Environment.NewLine
          + " 窗体大小：  " + this.Size + Environment.NewLine

          
          ;
            //*****************************************************************************
            //显示信息
            label1.Text =
                "光标索引： " + index + "    总数行： " + zonghangshu + "          光标行字符数： " + guanBiaoHangZiFuShu + "                   文件类型： " + System.IO.Path.GetExtension(openFileDialog1.FileName) + "                                   已选字符数：  " + richTextBox1.SelectionLength + Environment.NewLine + Environment.NewLine
              + "行号： " + line + "        自动阅读速度： " + trackBar2.Value + "      缩放比例： " + (richTextBox1.ZoomFactor * 100).ToString() + " %" + "                   文档区宽高度： " + richTextBox1.Size + "       所选字体颜色： " + richTextBox1.SelectionColor + Environment.NewLine + Environment.NewLine
              + "列号： " + col + "        缩进单位速度： " + trackBar1.Value + "      所选内容类型为： " + richTextBox1.SelectionType + "             阅读背景色： " + richTextBox1.BackColor +  "                   总字符数： "  + richTextBox1.TextLength +Environment.NewLine + Environment.NewLine
              ;

            //*****************************************************************************
            //工具栏信息
            toolStripStatusLabel1.Text = "行号： " + line;
            toolStripStatusLabel2.Text = "列号： " + col;
            toolStripStatusLabel3.Text = "缩放比例： " + (richTextBox1.ZoomFactor * 100).ToString() + " %";
            toolStripStatusLabel4.Text = "总行数： " + zonghangshu;
            toolStripStatusLabel5.Text = "所选字数： " + richTextBox1.SelectionLength;
            toolStripStatusLabel6.Text = "字符索引： " + index;

            //***************************************************************************************************



        }

        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if ( colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.SelectionBackColor = this.colorDialog1.Color;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.SelectionFont = this.fontDialog1.Font;
            }
        }

     

        private void timer2_Tick(object sender, EventArgs e)
        {

        //**************************************************************************************
        // 自动阅读功能程序

            if (suoYin_jiShuHang < suoYin_zongShuHang)
            {
                jiShuHang++;  //计数行加1
                              //配置计数的行第一个字符的索引
                suoYin_jiShuHang = this.richTextBox1.GetFirstCharIndexFromLine(jiShuHang);   //获取指定行号的第  jiShuHang  行所在的第一个字符索引

                yiDongLine = suoYin_jiShuHang;
               this.richTextBox1.SelectionStart = yiDongLine;   // 设置要移动到的索引点为获取指定行的第一个字符索引  
               this.richTextBox1.ScrollToCaret();   // 光标移动到设定的索引点

            }
            else
            {
                timer2.Enabled = false;
                MessageBox.Show("您已阅读完成");
            }

         //**************************************************************************************

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            timer2.Dispose();
            // 计数行复位
            jiShuHang = 0;

            // 索引复位
            suoYin_jiShuHang = this.richTextBox1.GetFirstCharIndexFromLine(jiShuHang);

            // 光标 复位
            int Line = this.richTextBox1.GetFirstCharIndexFromLine(0);  //获取指定行号的第 1 行所在的第一个字符索引
            richTextBox1.SelectionStart = Line;   // 设置要移动到的点为获取指定行的第一个字符索引  
            richTextBox1.ScrollToCaret();   // 光标移动到设定点
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (fontDialog2.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.Font = fontDialog2.Font;
            }
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            this.richTextBox1.BackColor = this.button18.BackColor;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.richTextBox1.BackColor = this.button19.BackColor;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.richTextBox1.BackColor = this.button20.BackColor;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.richTextBox1.BackColor = this.button22.BackColor;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            this.richTextBox1.BackColor = this.button23.BackColor;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            this.richTextBox1.BackColor = this.button24.BackColor;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            this.richTextBox1.BackColor = this.button25.BackColor;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            this.richTextBox1.BackColor = this.button26.BackColor;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            this.richTextBox1.BackColor = this.button27.BackColor;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.SelectionBackColor = this.colorDialog2.Color;
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            label2.Enabled = true;
            label2.Visible = true;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            label2.Enabled = false;
            label2.Visible = false;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            String str =
                "***********************************" + Environment.NewLine +
                "***********************************" + Environment.NewLine +
                "*****       版权所有林进威    *****" + Environment.NewLine +
                "*****       ©JY.Lin 2017      *****" + Environment.NewLine +
                "***********************************" + Environment.NewLine +
                "***********************************" + Environment.NewLine;

            MessageBox.Show(str,"版权信息");
        }

        private void button35_Click(object sender, EventArgs e)
        {
            String str =
                "***********************************" + Environment.NewLine +
                "***********************************" + Environment.NewLine +
                "*****          ecPad             *****" + Environment.NewLine +
                "*****       ©JY.Lin 2017      *****" + Environment.NewLine +
                "***********************************" + Environment.NewLine +
                "***********************************" + Environment.NewLine +
                " 1. ecPad ,中文 简单本，秉持简单便捷，轻松愉快的办公理念！ " + Environment.NewLine +
                " 2. ecPad 具有txt文档和rtf文档编辑阅读的功能，支持word的rtf格式文档，可实现完美衔接互用！ " + Environment.NewLine +
                " 3. ecPad 具有9大常用阅读主题，并且可以自主设定主题！" + Environment.NewLine +
                " 4. ecPad 具有60级缩进距离调整，以瞒住您的文档缩进编辑要求！ " + Environment.NewLine +
                " 5. ecPad 具有1000级自动阅读速度调整，以瞒住您的快慢自由的阅读体验要求！ " + Environment.NewLine +
                " 6. ecPad 具有撤回，前进，左对齐，右对齐，居中对齐，左右缩进的文字处理功能。 " + Environment.NewLine +
                " 7. ecPad 具有阅读主题背景选择，阅读和编辑字体选择，全文立即清空，个别字体颜色大小编辑等功能！ " + Environment.NewLine +
                " 8. ecPad 具有类似 office word 的选项卡功能，可以方便快捷地进行功能切换和选择！ " + Environment.NewLine +
                " 9. ecPad 具有选项卡自动回收设定功能，这是一个有趣而新颖的功能，可以方便快捷地进行阅读和编辑视区切换和选择！ " + Environment.NewLine +
                "10. ecPad 具有实时信息统计显示功能，您可以方便实时掌握文档阅读和编辑的所有有用信息！ " + Environment.NewLine +
                "11. ecPad 具有开发者实时信息统计监控显示功能，作为开发者，您可以方便实时掌握软件的所有有用参数信息，以便您的软件的升级与维护！ " + Environment.NewLine +
                "12. ecPad 为本人个人独立设计编写，历时二十多天日夜完成，版权所有，法律保护，不得未获权的商用等私用。 " + Environment.NewLine +
                "                                                                       " + Environment.NewLine +
                "                                                                       " + Environment.NewLine +
                "                                                               软件设计版权人：林进威" + Environment.NewLine +
                "                                                                    2017/12/28" + Environment.NewLine +
                
                "  " + Environment.NewLine 
               


                ;

            MessageBox.Show(str, "帮助信息");

        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (colorDialog3.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.BackColor = this.colorDialog3.Color;
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(new object(), new EventArgs());
        }

        private void 返回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4_Click(new object(), new EventArgs());
        }

        private void 前级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button5_Click(new object(), new EventArgs());
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button7_Click(new object(), new EventArgs());
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button8_Click(new object(), new EventArgs());
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button9_Click(new object(), new EventArgs());
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBullet = true;
        }

        private void 去除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBullet = false;
        }

        private void 红ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.ForeColor = Color.Red;
        }

        private void 绿ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.ForeColor = Color.Green;
        }

        private void 蓝ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.ForeColor = Color.Blue;
        }

        private void 黄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.ForeColor = Color.Yellow;
        }

        private void 紫ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.ForeColor = Color.Purple;
        }

        private void 黑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.ForeColor = Color.Black;
        }

        private void 白ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.ForeColor = Color.White;
        }

        private void 自定义ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button32_Click(new object(), new EventArgs());
        }

        private void 字体设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button14_Click(new object(), new EventArgs());
        }

        private void 左对齐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button10_Click(new object(), new EventArgs());
        }

        private void 右对齐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button12_Click(new object(), new EventArgs());
        }

        private void 居中ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button11_Click(new object(), new EventArgs());
        }

        private void 启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button34_Click(new object(), new EventArgs());
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPage6_Click(new object(), new EventArgs());
            button33_Click(new object(), new EventArgs());
        }

        private void 阅读背景ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button28_Click(new object(), new EventArgs());
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (colorDialog4.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.ForeColor = this.colorDialog4.Color;
            }
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void 关闭ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button38_Click(object sender, EventArgs e)
        {
            // 打开特殊字符输入框
            Form2 form2 = new Form2();
            form2.Show();
        }


       
    }
}

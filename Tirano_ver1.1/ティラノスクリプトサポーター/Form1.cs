using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ティラノスクリプトサポーター
{
	public partial class Form1 : Form
	{
        //private string[] inputFiles;
        //private object path;


        public static UserControl1 userControl11;
        public static UserControl2 userControl21;
        public static UserControl3 userControl31;

        public Form1()
		{
			InitializeComponent();

            //userControl11.Visible = true;
            //userControl11.Dock = DockStyle.Fill;

            //userControl21.Visible = false;
            //userControl31.Visible = false;
        }

		private void Form1_Load(object sender, EventArgs e)
		{
            
            panel1.Dock = DockStyle.Fill;

            // わかりやすいようにPanelの背景色を設定
            panel1.BackColor = Color.DarkOrange;
        }

		private void button1_Click(object sender, EventArgs e)
		{
			//ファイル作成
			FileEncoder fileEncoder;
			fileEncoder = new FileEncoder();
			fileEncoder.CreateFiles(ref sender, ref e);
		}

        private void button2_Click(object sender, EventArgs e)
        {
            userControl11.Visible = true;
            userControl11.Dock = DockStyle.Fill;

            userControl21.Visible = false;
            userControl31.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
               e.Effect = DragDropEffects.All;//所定位置でカーソル変更
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            // ファイルがなければ、何もしない
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            foreach (var TextPath in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                //
                string stFilePath = System.IO.Path.GetFullPath(@"..\..\test.txt");
                FileEncoder fileEncoder;//クラス呼ぶ
                fileEncoder = new FileEncoder();//インスタンス生成
                fileEncoder.SetTextPath(TextPath);//パス呼ぶ
                Debug.WriteLine("TextPath={0}",TextPath);//値検証
            }
        }
    }
}

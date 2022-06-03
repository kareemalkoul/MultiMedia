using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace DesktopApp1
{
    public partial class Form1 : Form
    {

        Video videoHandler;
        int indexFrame = 0;
        bool start = false;
        public Form1()
        {

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks!");
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imageBox1.AllowDrop = true;
        }

        private void Button1_Click_2(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(saveFileDialog1.FileName);
                videoHandler.SaveVideo(saveFileDialog1.FileName);
            }

        }

        private void Button1_Click_3(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String path = openFileDialog1.FileName;
                label1.Text = path;
                //pictureBox2.Load(path);
                //original = new Bitmap(path);
                //imageHandler = new MyImage(path);
                //imageExist = true;
                videoHandler = new Video(path);
                save.Enabled = true;
                showVideo.Enabled = true;
                info.Enabled = true;
                restart.Enabled = true;
                imageBox1.Image = videoHandler.Frames.First();
                IndexFrame = 0;
                timer1.Interval = (int)videoHandler.Delay;
                timer1.Stop();
                Start = false;
                button_pause_start.Enabled = true;
                resize.Enabled = true;
                scroll_video.Enabled = true;
                scroll_video.Maximum = videoHandler.Frames.Count+ scroll_video.LargeChange - 1;

            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void MatrixBox1_Load(object sender, EventArgs e)
        {

        }

        private void ShowVideo_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click_4(object sender, EventArgs e)
        {
            String info = videoHandler.GetInfo();
            MessageBox.Show(info);
        }

        private void ImageBox1_DobuleClick(object sender, EventArgs e)
        {
            Start = !Start;
        }

        private void Tick(object sender, EventArgs e)
        {    
            IndexFrame++;
        }


        private void ImageBox1_DragEnter(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            var filenames = data as string[];
            String ext = "";
            try
            {
                ext = filenames[0].Split('\\').Last().Split('.').Last();
            }
            catch (Exception ex)
            {

            }
            if (ext == "mp4")
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void ImageBox1_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var filenames = data as string[];
                if (filenames.Length > 0)
                {
                    String path = filenames[0];
                    label1.Text = path;
                    videoHandler = new Video(path);
                    save.Enabled = true;
                    showVideo.Enabled = true;
                    info.Enabled = true;
                    resize.Enabled = true;
                    button_pause_start.Enabled = true;
                    imageBox1.Image = videoHandler.Frames.First();
                    IndexFrame = 0;
                    timer1.Interval = (int)videoHandler.Delay;
                    Start = false;
                    restart.Enabled = true;
                    scroll_video.Enabled = true;
                    scroll_video.Maximum = videoHandler.Frames.Count+ scroll_video.LargeChange-1;
                }
            }
        }

        private void Button1_Click_5(object sender, EventArgs e)
        {
            IndexFrame = 0;
            Start = false;
           
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            videoHandler.ResizeVideo(new Size(720, 720));
        }

        private void ImageBox1_MouseDown(object sender, MouseEventArgs e)
        {
            imageBox1.DoDragDrop(imageBox1.Image, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Button_pause_start_Click(object sender, EventArgs e)
        {
            Start = !Start;
         
        }

        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }


        public bool Start
        {
            get { return start; }
            set
            {
                start = value;
                if (start)
                {
                    timer1.Start();
                    button_pause_start.BackgroundImage = DesktopApp1.Properties.Resources.pause;
                }
                else
                {
                    timer1.Stop();
                    button_pause_start.BackgroundImage = DesktopApp1.Properties.Resources.play;
                }
            }
        }

        public int IndexFrame
        {
            get { return indexFrame; }
            set
            {
                indexFrame = value;
                if (indexFrame >= videoHandler.Frames.Count)
                    indexFrame = 0;
                imageBox1.Image = videoHandler.Frames[indexFrame];
                frame_index.Text = "Frame Index= " + indexFrame;
                scroll_video.Value = indexFrame;

            }
        }

        private void HScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            //scroll_video.Maximum = 1000;
            //Console.WriteLine(scroll_video.Value);
            //Console.WriteLine(scroll_video.Maximum);
            //Console.WriteLine(scroll_video.Width);
            IndexFrame = scroll_video.Value;
        }

        private void Delete_Part_Click(object sender, EventArgs e)
        {
            videoHandler.DeletePartOfVideo(0, 20);
        }
    }
}

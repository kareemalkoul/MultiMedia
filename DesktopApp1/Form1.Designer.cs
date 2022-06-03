namespace DesktopApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.save = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.showVideo = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.restart = new System.Windows.Forms.Button();
            this.resize = new System.Windows.Forms.Button();
            this.button_pause_start = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.frame_index = new System.Windows.Forms.Label();
            this.scroll_video = new System.Windows.Forms.HScrollBar();
            this.delete_Part = new System.Windows.Forms.Button();
            this.create_video = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // save
            // 
            this.save.Enabled = false;
            this.save.Location = new System.Drawing.Point(495, 12);
            this.save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 0;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.Button1_Click_2);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Location = new System.Drawing.Point(12, 7);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 31);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Address";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // imageBox1
            // 
            this.imageBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox1.Location = new System.Drawing.Point(12, 44);
            this.imageBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(557, 316);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            this.imageBox1.Click += new System.EventHandler(this.ShowVideo_Click);
            this.imageBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.ImageBox1_DragDrop);
            this.imageBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.ImageBox1_DragEnter);
            this.imageBox1.DoubleClick += new System.EventHandler(this.ImageBox1_DobuleClick);
            this.imageBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageBox1_MouseDown);
            // 
            // showVideo
            // 
            this.showVideo.Enabled = false;
            this.showVideo.Location = new System.Drawing.Point(413, 12);
            this.showVideo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showVideo.Name = "showVideo";
            this.showVideo.Size = new System.Drawing.Size(75, 23);
            this.showVideo.TabIndex = 4;
            this.showVideo.Text = "Show Video";
            this.showVideo.UseVisualStyleBackColor = true;
            this.showVideo.Click += new System.EventHandler(this.ShowVideo_Click);
            // 
            // info
            // 
            this.info.Enabled = false;
            this.info.Location = new System.Drawing.Point(301, 12);
            this.info.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(107, 23);
            this.info.TabIndex = 5;
            this.info.Text = "Information";
            this.info.UseVisualStyleBackColor = true;
            this.info.Click += new System.EventHandler(this.Button1_Click_4);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Tick);
            // 
            // restart
            // 
            this.restart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("restart.BackgroundImage")));
            this.restart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.restart.Enabled = false;
            this.restart.Location = new System.Drawing.Point(52, 7);
            this.restart.Margin = new System.Windows.Forms.Padding(4);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(33, 31);
            this.restart.TabIndex = 6;
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.Button1_Click_5);
            // 
            // resize
            // 
            this.resize.Enabled = false;
            this.resize.Location = new System.Drawing.Point(134, 8);
            this.resize.Margin = new System.Windows.Forms.Padding(4);
            this.resize.Name = "resize";
            this.resize.Size = new System.Drawing.Size(64, 31);
            this.resize.TabIndex = 7;
            this.resize.Text = "Resize";
            this.resize.UseVisualStyleBackColor = true;
            this.resize.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button_pause_start
            // 
            this.button_pause_start.BackgroundImage = global::DesktopApp1.Properties.Resources.play;
            this.button_pause_start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_pause_start.Enabled = false;
            this.button_pause_start.Location = new System.Drawing.Point(93, 7);
            this.button_pause_start.Margin = new System.Windows.Forms.Padding(4);
            this.button_pause_start.Name = "button_pause_start";
            this.button_pause_start.Size = new System.Drawing.Size(33, 31);
            this.button_pause_start.TabIndex = 8;
            this.button_pause_start.UseVisualStyleBackColor = true;
            this.button_pause_start.Click += new System.EventHandler(this.Button_pause_start_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog1_FileOk);
            // 
            // frame_index
            // 
            this.frame_index.AutoSize = true;
            this.frame_index.Location = new System.Drawing.Point(12, 400);
            this.frame_index.Name = "frame_index";
            this.frame_index.Size = new System.Drawing.Size(109, 17);
            this.frame_index.TabIndex = 9;
            this.frame_index.Text = "Frame index = 0";
            // 
            // scroll_video
            // 
            this.scroll_video.Enabled = false;
            this.scroll_video.LargeChange = 1;
            this.scroll_video.Location = new System.Drawing.Point(12, 362);
            this.scroll_video.Name = "scroll_video";
            this.scroll_video.Size = new System.Drawing.Size(558, 21);
            this.scroll_video.TabIndex = 10;
            this.scroll_video.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBar1_Scroll);
            // 
            // delete_Part
            // 
            this.delete_Part.Location = new System.Drawing.Point(206, 11);
            this.delete_Part.Name = "delete_Part";
            this.delete_Part.Size = new System.Drawing.Size(75, 25);
            this.delete_Part.TabIndex = 11;
            this.delete_Part.Text = "delete";
            this.delete_Part.UseVisualStyleBackColor = true;
            this.delete_Part.Click += new System.EventHandler(this.Delete_Part_Click);
            // 
            // create_video
            // 
            this.create_video.Cursor = System.Windows.Forms.Cursors.Default;
            this.create_video.Enabled = false;
            this.create_video.Location = new System.Drawing.Point(454, 394);
            this.create_video.Name = "create_video";
            this.create_video.Size = new System.Drawing.Size(115, 23);
            this.create_video.TabIndex = 12;
            this.create_video.Text = "create video";
            this.create_video.UseVisualStyleBackColor = true;
            this.create_video.Click += new System.EventHandler(this.Create_video_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(581, 455);
            this.Controls.Add(this.create_video);
            this.Controls.Add(this.delete_Part);
            this.Controls.Add(this.scroll_video);
            this.Controls.Add(this.frame_index);
            this.Controls.Add(this.button_pause_start);
            this.Controls.Add(this.resize);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.info);
            this.Controls.Add(this.showVideo);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.save);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button showVideo;
        private System.Windows.Forms.Button info;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button restart;
        private System.Windows.Forms.Button resize;
        private System.Windows.Forms.Button button_pause_start;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label frame_index;
        private System.Windows.Forms.HScrollBar scroll_video;
        private System.Windows.Forms.Button delete_Part;
        private System.Windows.Forms.Button create_video;
    }
}


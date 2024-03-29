using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace MultiMedia
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //"C:\\Users\\kareem\\Downloads\\Telegram Desktop\\video_2022-01-30_19-12-20.mp4"

            //CvInvoke.WaitKey(0);

            //videoCapture.DisposeObject();

            //showvideo();

            //String path = "C:\\Users\\kareem\\source\\repos\\DesktopApp1\\DesktopApp1\\video_2022-04-08_08-19-44.mp4";

            //Video video = new Video(path);
            //video.ShowInfo();
            //video.showFrames();

            //float i = 30 / 25f;
            //Console.WriteLine(i.ToString());
            //float k = 0;
            //int kemo = 0;
            //for (int j = 0; j < 29; j++)
            //{
            //    k += i;
            //    Console.WriteLine(k);
            //    if ((float)Math.Floor(k) == k)
            //    {
            //        kemo++;
            //        Console.WriteLine("aasas");

            //    }
            //    bool isInt = k == Math.Truncate(k);

            //    if (isInt)
            //    {
            //        Console.WriteLine("qqqqqqqqqqqqqqqqqqq");

            //    }
            //    if (Math.Round(k, 4) == Math.Round(k))
            //    {
            //        Console.WriteLine("aaaaaaaaaaaaaaaaaaaaa");
            //    }


            //}
            //Console.WriteLine(kemo);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MultiMedia());
        }


        static void showvideo()
        {
            String path = "C:\\Users\\kareem\\source\\repos\\DesktopApp1\\DesktopApp1\\video_2022-04-08_08-19-44.mp4";
            VideoCapture videoCapture = new VideoCapture(path, VideoCapture.API.Any);
            Mat image = new Mat();
            List<Mat> images = new List<Mat>();

            double length = videoCapture.GetCaptureProperty(CapProp.FrameCount);
            double fps = videoCapture.GetCaptureProperty(CapProp.Fps);
            double hieght = videoCapture.GetCaptureProperty(CapProp.FrameHeight);
            double width = videoCapture.GetCaptureProperty(CapProp.FrameWidth);
            double Seconds = videoCapture.GetCaptureProperty(CapProp.FrameWidth);

            Console.WriteLine(fps.ToString());

            Console.WriteLine(length.ToString());
            Console.WriteLine((int)(1000 / fps) * length);
            while (videoCapture.IsOpened)
            {
                videoCapture.Read(image);
                if (image.IsEmpty)
                    break;
                images.Add(image);
                CvInvoke.Imshow("video", image);
                char c = (char)CvInvoke.WaitKey((int)(1000 / fps));
                if (c == 27)
                    break;
            }
            videoCapture.Dispose();
            CvInvoke.DestroyAllWindows();



            //for (int i = 0; i < images.Count; i++)

            //{
            //    CvInvoke.Imwrite("C:\\Users\\kareem\\Desktop\\"+i.ToString() +".png", images[i]);
            //}
        }
    }
}

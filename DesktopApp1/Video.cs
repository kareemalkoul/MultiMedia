using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ExtensionMethods;
using System.Windows.Forms;
using System.IO;

namespace DesktopApp1
{

    using Emgu.CV;
    using Emgu.CV.CvEnum;

    /// <summary>
    /// <para/> Requirments
    /// <para/> Basics:
    /// <para/>     1.Delete a Part.
    /// <para/>     2.Move a part.
    /// <para/>     3.Add WaterMark.
    /// <para/>     4.Save Video. ✔
    /// <para/>     5.Change FPS.
    /// <para/> Addtional:
    /// <para/>     6.undo Last Action.
    /// <para/>     7.Resize Video.
    /// <para/>     8.Create Video from Photos.
    /// <para/>     9.Merge Video.
    /// <para/>     10.Add Stickers.
    /// <para/>     11.Add Audio.
    /// <para/></summary>
    public class Video
    {
        /// <summary>
        /// Name of The Video.
        /// </summary>
        private readonly String name;

        /// <summary>
        /// The Frames in The Video.
        /// </summary>
        private List<Mat> frames;

        /// <summary>
        /// Number of Frames in Video.
        /// </summary>
        private uint framesNum;

        /// <summary>
        /// width and height in order.
        /// Size(Width,Height).
        /// </summary>
        private Size size;

        /// <summary>
        /// Time Of The Video.
        /// </summary>
        private float seconds;

        /// <summary>
        /// The Delay between Two frames. The Time in ms .
        /// </summary>
        private float delay;

        /// <summary>
        /// Frame Rate in a Second.
        /// </summary>
        private float fps;

        /// <summary>
        /// Refrence To original Video if This video is copr/clone frorm anthor(original).
        /// </summary>
        private Video originalVideo;

        #region Constractor
        public Video(String path)
        {
            VideoCapture videoCapture = new VideoCapture(path, VideoCapture.API.Any);
            Mat frame = new Mat();

            name = path.Split('\\').Last();
            frames = new List<Mat>();
            framesNum = (uint)videoCapture.GetCaptureProperty(CapProp.FrameCount);
            fps = (float)videoCapture.GetCaptureProperty(CapProp.Fps);
            int height = (int)videoCapture.GetCaptureProperty(CapProp.FrameHeight);
            int width = (int)videoCapture.GetCaptureProperty(CapProp.FrameWidth);
            size = new Size(width, height);
            this.delay = 1000 / fps; //delay in ms
            // delay between frames * num frames
            this.seconds = (((delay) / 1000) * framesNum);


            while (videoCapture.IsOpened)
            {
                videoCapture.Read(frame);
                if (frame.IsEmpty)
                    break;
                frames.Add(frame.Clone());
                if (frame.IsEmpty)
                {
                    Console.WriteLine("is  empty");
                }
            }
            videoCapture.Dispose();
            if (frame.IsEmpty)
            {
                Console.WriteLine("is  empty");
            }
        }

        public Video(uint framesNum, Size size, float seconds, float fps, List<Mat> frames)
        {
            this.framesNum = framesNum;
            this.size = size;
            this.seconds = seconds;
            this.fps = fps;
            this.frames = frames;
            //fps = framesNum/seconds
        }
        public Video(uint framesNum, Size size, float fps, List<Mat> frames)
        {
            this.framesNum = framesNum;
            this.size = size;
            this.seconds = framesNum/fps;
            this.fps = fps;
            this.frames = frames;
            //fps = framesNum/seconds
        }

        public Video(Video video)
        {
            this.originalVideo = video;
            this.framesNum = video.framesNum;
            this.size = video.size.Clone();
            this.seconds = video.seconds;
            this.fps = video.fps;
            this.frames = video.frames.Clone();
            this.delay = video.delay;
            this.name = video.name;
        }


        #endregion Constractor


        #region RequirementsBasics
        /// <summary>
        /// 1.Delete a Part.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Video DeletePartOfVideo(uint start, uint end)
        {
            if (end >= this.framesNum)
                throw new Exception("end index is big than frames number");
            //frames number to delte it.
            uint diff = end - start + 1;
            uint framesNum = this.framesNum - diff;
            List<Mat> frames = this.frames.GetRange((int)start, (int)end);

            //frames/fps=seconds
            float seconds = framesNum / fps;


            // favouriteCities.AddRange(popularCities);
            return this;
        }

        /// <summary>
        /// move part of video from section to anthor
        /// the part start ,end
        /// the start index to put in it s into .
        /// <para/>2.Move a part.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="into"></param>
        /// <returns></returns>
        public Video MovePartOfVideo(uint start, uint end, uint into)
        {

            if (end >= this.framesNum || into >= this.framesNum)
                throw new Exception("end index is big than frames number");

            if (end >= into && into >= start)
                throw new Exception("into between srat and end");

            uint diff = end - start + 1;
            uint framesNum = this.framesNum - diff;
            List<Mat> framesOFPart = this.frames.GetRange((int)start, (int)end);
            List<Mat> framesBeforpart = this.frames.GetRange(0, (int)start - 1);
            List<Mat> framesAfterpart = this.frames.GetRange((int)end + 1, (int)framesNum);
            List<Mat> withoutpart = framesOFPart.ToList();
            withoutpart.AddRange(framesAfterpart);

            if (into < start)
            {
                // withoutpart.AddRange()
            }
            else if (into > end)
            {

            }

            return this;

        }

        //TODO:Lana
        //TODO:AddWatermark  
        /// <summary>
        ///  3.Add WaterMark.
        /// </summary>
        /// <param name="waterMark"></param>
        /// <returns></returns>
        public Video AddWatermark(Mat waterMark)
        {
            return this;
        }

        public Video AddWatermark(Video waterMark)
        {
            return this;
        }

        public Video AddWatermark(String waterMark)
        {
            return this;
        }

        /// <summary>
        /// 4.Save Video.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Video SaveVideo(String fullPath)
        {
            int codec = VideoWriter.Fourcc('M', 'P', '4', 'V');
            MessageBox.Show(Directory.GetCurrentDirectory());
            VideoWriter videoWriter = new VideoWriter(fullPath, codec, (int)this.fps, this.size, true);

            for (int i = 0; i < framesNum; i++)
            {
                videoWriter.Write(frames[i]);
            }
            videoWriter.Dispose();

            return this;
        }

        //TODO:kareem
        /// <summary>
        /// 5.Change FPS.
        /// </summary>
        /// <param name="newFPs"></param>
        /// <returns></returns>
        public Video ChangeFps(float newFPs)
        {
            float oldfps = this.fps;
            float ratio = oldfps / newFPs;

            float newdelay = this.delay * ratio;

            return this;
        }

        #endregion RequirementsBasics

        #region RequirementsAddtional

        /// <summary>
        /// 6.undo Last Action.
        /// </summary>
        /// <returns></returns>
        public Video UndoLastAcction()
        {
            return this;
        }

        /// <summary>
        ///  7.Resize Video.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public Video ResizeVideo(Size size)
        {
            this.size = size;
            //foreach (Mat frame in frames)
            //{
            //    CvInvoke.Resize(frame, frame, size);
            //}

            Parallel.ForEach(frames, frame =>
            {
                CvInvoke.Resize(frame, frame, size);
            });
            return this;
        }

        /// <summary>
        /// 8.Create Video from Photos.
        /// make a copy
        /// </summary>
        /// <param name="paths"></param>
        /// <param name="fps"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public Video CreateVideoFromPhotos(List<String>paths,float fps,Size size)
        {
            List<Mat> frames = this.PathsPhotosToMats(paths);
            Video video = new Video((uint)frames.Count, size, fps, frames);
            return video;
        }

        /// <summary>
        ///  9.Merge Video.
        /// </summary>
        /// <param name="video1"></param>
        /// <param name="video2"></param>
        /// <returns></returns>
        public Video MergeVideos(Video video1,Video video2)
        {
            List<Mat> mergedFrames = video1.frames.Clone().Concat(video2.frames).ToList();
            //TODO: frames reduce  to the min fps between the both
            Video mergedVideo = new Video(" ");
            return mergedVideo;
        }

        /// <summary>
        ///  10.Add Stickers.
        /// </summary>
        /// <param name="offest"></param>
        /// <param name="sticker"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public Video AddStickers(Size offest,Mat sticker, Size size)
        {
            CvInvoke.Resize(sticker, sticker, size);
            //TODO:puth the stiker in all frames.
            return this;
        }

        /// <summary>
        /// 11.Add Audio.
        /// </summary>
        /// <returns></returns>
        public Video AddAudio()
        {
            return this;
        }
        #endregion RequirementsAddtional


        public Video showFrames()
        {
            for (int i = 0; i < framesNum; i++)
            {
                if (frames[i].IsEmpty)
                {
                    Console.WriteLine(i);
                    break;
                }

                CvInvoke.Imshow("Show Video", frames[i]);

                char c = (char)CvInvoke.WaitKey((int)delay);
                //if press 'Esc' stop showing 
                if (c == 27)
                    break;
            }
            CvInvoke.DestroyAllWindows();
            return this;
        }

        public void ShowInfo()
        {
            Console.Write(this.GetInfo());
        }

        public String GetInfo()
        {
            String info;
            info = "Name Video: " + this.name;
            info += "\nNumber of Frames: " + this.framesNum;
            info += "\nNumber of List: " + this.frames.Count;
            info += "\nSeconds of Video: " + this.seconds;
            info += "\nframe rate: " + this.fps;
            info += "\nSize of video (width,height): " + this.size.ToString();
            return info;
        }

        private List<Mat> PathsPhotosToMats(List<String> paths)
        {
            List<Mat> frames = new List<Mat>();
            for (int i=0;i< paths.Count;i++)
            {
                string path = paths[i];
                frames.Add(CvInvoke.Imread(path));
            }
            return frames;
        }

        #region getter
        public List<Mat> Frames
        {
            get { return frames; }
            //set { frames = value; }
        }
        public float Delay
        {
            get { return delay; }
            //set { delay = value; }
        }
        #endregion getter

    }

}

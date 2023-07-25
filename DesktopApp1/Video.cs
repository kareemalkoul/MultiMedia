using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using ExtensionMethods;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Emgu.CV.CvEnum;

namespace MultiMedia
{

    using Emgu.CV;
    using Emgu.CV.CvEnum;
    using Emgu.CV.Structure;

    /// <summary>
    /// <para/> Requirments
    /// <para/> Basics:
    /// <para/>     1.Delete a Part. ✔
    /// <para/>     2.Move a part. ✔
    /// <para/>     3.Add WaterMark. ✔
    /// <para/>     4.Save Video. ✔
    /// <para/>     5.Change FPS. ✔
    /// <para/> Addtional:
    /// <para/>     6.undo Last Action.
    /// <para/>     7.Resize Video. ✔
    /// <para/>     8.Create Video from Photos. ✔
    /// <para/>     9.Merge Video. ✔
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
            //framesNum = (uint)videoCapture.GetCaptureProperty(CapProp.FrameCount);

            fps = (float)videoCapture.GetCaptureProperty(CapProp.Fps);
            int height = (int)videoCapture.GetCaptureProperty(CapProp.FrameHeight);
            int width = (int)videoCapture.GetCaptureProperty(CapProp.FrameWidth);
            size = new Size(width, height);
            this.delay = 1000 / fps; //delay in ms
                                     // delay between frames * num frames



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
            framesNum = (uint)frames.Count;
            this.seconds = (((delay) / 1000) * framesNum);
            videoCapture.Dispose();
            if (frame.IsEmpty)
            {
                Console.WriteLine("is  empty");
            }
        }

        public Video(uint framesNum, Size size, float fps, List<Mat> frames)
        {
            this.framesNum = framesNum;
            this.size = size;
            this.FPS = fps;
            this.frames = frames;
            //fps = framesNum/seconds
        }
        public Video(uint framesNum, Size size, float fps, float seconds, List<Mat> frames)
        {
            this.framesNum = framesNum;
            this.size = size;
            this.seconds = framesNum / fps;
            this.fps = fps;
            this.frames = frames;
            this.delay = 1000 / fps;
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
            this.frames.RemoveRange((int)start, (int)diff);

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
            List<Mat> newFrames = new List<Mat>();
            //withoutpart.AddRange(framesAfterpart);

            if (into < start)
            {
               
                List<Mat> framesBeforPartToInto = this.frames.GetRangeByIndex(0,(int) into-1);
                List<Mat> framesIntoToPart = this.frames.GetRangeByIndex((int)into , (int)start-1);
                List<Mat> framesAfterpart = this.frames.GetRangeByIndex((int)end + 1, (int)framesNum);

                this.frames = newFrames.Concat(framesBeforPartToInto).Concat(framesOFPart).Concat(framesIntoToPart).Concat(framesAfterpart).ToList();
            }
            else if (into > end)
            {
                List<Mat> framesBeforpart = this.frames.GetRangeByIndex(0, (int)start - 1);
                List<Mat> framesAfterpartToInto = this.frames.GetRangeByIndex((int)end + 1, (int)into-1);
                List<Mat> framesIntoToEnd = this.frames.GetRangeByIndex((int)into, (int)framesNum);

                this.frames=newFrames.Concat(framesBeforpart).Concat(framesAfterpartToInto).Concat(framesOFPart).Concat(framesIntoToEnd).ToList();
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

        public Video AddWatermark(String textWaterMark, Point p, MCvScalar textcolor, FontFace font = FontFace.HersheySimplex, double fontscale = 3.5)
        {
            Mat textMat = Mat.Zeros(frames[0].Rows, frames[0].Cols, DepthType.Cv8U, 3);
            CvInvoke.PutText(
                 textMat,
                  textWaterMark,
                  p,
                  font,
                  fontscale,
                  textcolor
                     );
            CvInvoke.Imshow("kemo", textMat);
            Parallel.ForEach(this.frames, frame =>
            {

                CvInvoke.AddWeighted(
                        frame,          //src1 first image
                        1,            //alpha src1
                        textMat,      //src2 second image
                        0.3,            //alpha src2
                        0,              //The output array has the same size and number of channels as the input two arrays. dst = src1[I] * alpha + src2[I] * beta + gamma
                        frame           //dist
                        );

            });
            return this;
        }

        public Video AddWatermark(String path)
        {

            String ext = path.GetExtension();
            if (ext == "mp4")
            {
                Video waterMark = new Video(path);

                if (waterMark.frames.Count == 0)
                {
                    Console.WriteLine("nooo frames here");
                }
                else
                {
                    Parallel.ForEach(waterMark.frames, frame2 =>
                    {
                        CvInvoke.Resize(
                        frame2,  //src
                        frame2, //dis
                        this.frames[0].Size //size
                        );
                    });
                    int i = 0;
                    Parallel.ForEach(this.frames, frame =>
                    {
                        if (i == waterMark.frames.Count - 1)
                        {
                            i = 0;
                        }
                        CvInvoke.AddWeighted(
                                frame,              //src1 first image
                                0.6,                //alpha src1
                                waterMark.frames[i],//src2 second image
                                0.3,                //alpha src2
                                0,                  //The output array has the same size and number of channels as the input two arrays. dst = src1[I] * alpha + src2[I] * beta + gamma
                                frame               //dist
                                );
                        i++;
                    });
                }
            }
            else if (ext == "jpg" || ext == "jpeg" || ext == "png")
            {
                //Watermark for photo
                Mat waterMark = new Mat();
                waterMark = Emgu.CV.CvInvoke.Imread(path);

                CvInvoke.Resize(
                        waterMark,      //src
                        waterMark,      //dis
                        frames[0].Size  //size
                        );
                Parallel.ForEach(this.frames, frame =>
                {
                    CvInvoke.AddWeighted(
                        frame,          //src1 first image
                        0.6,            //alpha src1
                        waterMark,      //src2 second image
                        0.3,            //alpha src2
                        0,              //The output array has the same size and number of channels as the input two arrays. dst = src1[I] * alpha + src2[I] * beta + gamma
                        frame           //dist
                        );
                });
            }

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
            //MessageBox.Show(Directory.GetCurrentDirectory());
            VideoWriter videoWriter = new VideoWriter(fullPath, codec, (int)this.fps, this.size, true);

            for (int i = 0; i < frames.Count; i++)
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
            this.FPS = newFPs;
            return this;

            //float oldFps = this.fps;
            //bool IsDelete = false;
            //float ratio;
            //float diff = oldFps - newFPs;

            //if (diff>0)
            //{
            //    IsDelete = true;
            //    ratio = oldFps / newFPs;
            //}
            //else
            //{
            //    IsDelete = false;
            //    ratio = newFPs / oldFps;
            //    diff = -diff;
            //}


            //float sum = 0;
            //for (int i = 0; i < framesNum; i++)
            //{

            //    sum += ratio;
            //    bool ThisRound = Math.Round(sum, 4) == Math.Round(sum);
            //    if (IsDelete)
            //    {

            //        if (ThisRound)
            //        {
            //            Console.WriteLine(sum);
            //            this.frames.RemoveAt(i);
            //            i--;
            //            framesNum--;
            //            Console.WriteLine("delete");
            //        }
            //    }
            //    else
            //    {
            //        if (ThisRound)
            //        {

            //        }
            //    }

            //    if (diff == 0)
            //    {

            //    }
            //}


            ////float newdelay = this.delay * ratio;

            //return this;
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
        public Video CreateVideoFromPhotos(List<String> paths, float fps, Size size)
        {
            List<Mat> frames = this.PathsPhotosToMats(paths);
            Video video = new Video((uint)frames.Count, size, fps, frames);

            //Resiaze Because The Frames dont have The Same Size.
            video.ResizeVideo(size);
            return video;
        }

        /// <summary>
        ///  9.Merge Video.
        /// </summary>
        /// <param name="video1"></param>
        /// <param name="video2"></param>
        /// <returns></returns>
        public Video MergeVideos(Video video1, Video video2)
        {
            Size size = video1.size;
            video2.ResizeVideo(size);
            List<Mat> mergedFrames = video1.frames.Clone().Concat(video2.frames).ToList();
            String name = "merged" + video1.name + "+" + video2.name;
            float fps = (video1.fps + video2.fps) / 2f;
            Video mergedVideo = new Video((uint)mergedFrames.Count,size,fps, mergedFrames);
            return mergedVideo;
        }

        /// <summary>
        ///  10.Add Stickers.
        /// </summary>
        /// <param name="offest"></param>
        /// <param name="sticker"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public Video AddStickers(Size offest, Mat sticker, Size size)
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

        #region methods
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
            info += "\nDelay: " + this.delay;
            info += "\nSeconds of Video: " + this.seconds;
            info += "\nframe rate: " + this.fps;
            info += "\nSize of video (width,height): " + this.size.ToString();
            return info;
        }


        private List<Mat> PathsPhotosToMats(List<String> paths)
        {
            List<Mat> frames = new List<Mat>();
            for (int i = 0; i < paths.Count; i++)
            {
                string path = paths[i];
                frames.Add(CvInvoke.Imread(path));
            }
            return frames;
        }
        #endregion methods

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

        public float FPS
        {
            get { return fps; }
            set
            {
                fps = value;
                this.delay = 1000 / fps;
                this.seconds = framesNum / fps;

            }
        }
        #endregion getter

    }

}

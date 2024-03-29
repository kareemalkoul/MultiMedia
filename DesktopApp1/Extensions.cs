﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MultiMedia;

namespace ExtensionMethods
{
    public static class Extensions
    {
        public static Size Clone(this Size size)
        {
            return new Size(size.Width, size.Height);
        }
        public static List<T> Clone<T>(this List<T> list)
        {
            return list.ToList();
        }

        public static Video Clone(this Video video)
        {
            return new Video(video);
        }

        public static String GetExtension(this String path)
        {
            String nameFile = path.Split('\\').Last();
            String ext = nameFile.Split('.').Last();
            return ext;
        }

        public static List<T> GetRangeByIndex<T>(this List<T> list, int start, int end)
        {
            return list.Where((value, index) => index >= start && index <= end).ToList();
        }




    }


}
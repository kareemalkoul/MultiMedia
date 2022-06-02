using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DesktopApp1;

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

    }


}
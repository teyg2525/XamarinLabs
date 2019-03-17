﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace labs.Controls.VideoPlayerLibrary
{
    [TypeConverter(typeof(VideoSourceConverter))]
    public class VideoSource : Element
    {
        public static VideoSource FromUri(string uri)
        {
            return new UriVideoSource() { Uri = uri };
        }

        public static VideoSource FromFile(string file)
        {
            return new FileVideoSource() { File = file };
        }

        public static VideoSource FromResource(string path)
        {
            return new ResourceVideoSource() { Path = path };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using labs.Controls.Enums;
using labs.Controls.VideoPlayerLibrary;

namespace labs.Controls.Interfaces
{
    public interface IVideoPlayerController
    {
        VideoStatus Status { set; get; }

        TimeSpan Duration { set; get; }
    }
}

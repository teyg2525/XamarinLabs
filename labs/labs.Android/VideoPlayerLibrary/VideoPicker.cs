using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using labs.Controls.Interfaces;
using System.Threading.Tasks;

[assembly: Dependency(typeof(labs.Droid.VideoPlayerLibrary.VideoPicker))]
namespace labs.Droid.VideoPlayerLibrary
{
    class VideoPicker : IVideoPicker
    {
        public Task<string> GetVideoFileAsync()
        {
            Intent intent = new Intent();
            intent.SetType("video/*");
            intent.SetAction(Intent.ActionGetContent);
            
            MainActivity activity = MainActivity.Current;
            
            activity.StartActivityForResult(
                Intent.CreateChooser(intent, "Select Video"),
                MainActivity.PickImageId);
            
            activity.PickImageTaskCompletionSource = new TaskCompletionSource<string>();
            
            return activity.PickImageTaskCompletionSource.Task;
        }
    }
}
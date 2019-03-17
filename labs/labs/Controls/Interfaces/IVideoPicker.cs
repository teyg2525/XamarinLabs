using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace labs.Controls.Interfaces
{
    public interface IVideoPicker
    {
        Task<string> GetVideoFileAsync();
    }
}

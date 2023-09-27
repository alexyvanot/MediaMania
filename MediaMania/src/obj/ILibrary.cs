using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaMania.src.obj
{
    public interface ILibrary
    {
        public void AddMedia(Media media);
        public void AddMedia(List<Media> medias);
        public string GetName();
    }
}

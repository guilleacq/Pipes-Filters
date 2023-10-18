using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        private const string SAVED_PICTURE_PATH = @"editedPhoto.jpg";
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");

            IPicture filteredPicture = Send(picture, new FilterBlurConvolution());
            provider.SavePicture(picture, SAVED_PICTURE_PATH);
        }

        private static IPicture Send(IPicture picture, IFilter filter)
        {
            PipeSerial pipeSerial;
            PipeSerial pipeSerial2;
            
            pipeSerial2 = new PipeSerial(filter, null);
            pipeSerial = new PipeSerial(filter, pipeSerial2);

            return picture;
        }
    }
}

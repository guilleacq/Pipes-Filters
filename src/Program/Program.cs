using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using System.Data.Common;

namespace CompAndDel
{
    class Program
    {
        private const string SAVED_PICTURE_PATH = @"editedPhoto.jpg";
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");

            IPipe pipeEnd = new PipeNull();
            IPipe pipe2 = new PipeSerial(new FilterNegative(), pipeEnd);
            IPipe pipe1 = new PipeSerial(new FilterBlurConvolution(), pipe2);

            IPicture filteredPicture = pipe1.Send(picture);

            provider.SavePicture(filteredPicture, SAVED_PICTURE_PATH);
        }
    }
}

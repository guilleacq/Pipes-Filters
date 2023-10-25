using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using System.Data.Common;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");

            IPipe pipeEnd = new PipeNull(); 

            IPipe savePipe2 = new PipeSerial(new SaveFilter("edited2"), pipeEnd);
            IPipe filterPipe2 = new PipeSerial(new FilterNegative(), savePipe2);

            IPipe savePipe1 = new PipeSerial(new SaveFilter("edited1"), filterPipe2);
            IPipe pipe1 = new PipeSerial(new FilterBlurConvolution(), savePipe1);

            IPicture filteredPicture = pipe1.Send(picture);
        }
    }
}

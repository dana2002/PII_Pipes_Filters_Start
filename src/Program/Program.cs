using System;
using System.Collections;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;
using System.Drawing;
using CognitiveCoreUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");


            PipeSerial filter3 = new PipeSerial(new FilterNegative(), new PipeNull());
            IPicture image3 = filter3.Send(picture); //Persistir imagenes intermedias
        
            PipeSerial filter2 = new PipeSerial(new FilterBlurConvolution(), filter3);
            IPicture image2 = filter2.Send(picture);

            PipeSerial filter1 = new PipeSerial(new FilterGreyscale(), filter2);

            PipeSerial filter = new PipeSerial(new FilterFace(), filter1); //tempface imagen, no se publica pero detecta la cara

            IPicture final_image = filter.Send(picture);

            provider.SavePicture(final_image, @"resultado.jpg");

            //Publicar en Twitter
            TwitterImage post = new TwitterImage();
            post.PublishToTwitter("La imagen", @"resultado.jpg");
            Console.WriteLine("Posteado!");

        }
    }
}

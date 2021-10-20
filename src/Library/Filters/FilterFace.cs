using System;
using System.Drawing;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using CognitiveCoreUCU;

namespace CompAndDel
{
  public class FilterFace : IFilter
  {
    public bool resultado{get; set;}

    public IPicture Filter(IPicture image)
    {

      PictureProvider provider = new PictureProvider();
      provider.SavePicture(image, @"resultado.jpg");

      CognitiveFace face = new CognitiveFace(true, Color.Red);
      face.Recognize(@"resultado.jpg");

      this.resultado = face.FaceFound;

      return image;
    }

  }
}
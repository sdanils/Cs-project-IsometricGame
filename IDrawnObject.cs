using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsometryTwo
{
    internal interface IDrawnObject
    {
        int IDobject { get; }
        int YPanel { get; }
        Point DrawCoord { get; }
        int TypeObj { get; }
        Bitmap GetImage();
    }
}

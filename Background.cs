using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace IsometryTwo
{
    internal class Background
    {
        public Bitmap background;

        public Background(string fName, Sizes sizes, int speedMoveScene)
        {
            background = new Bitmap(sizes.sizeCell * sizes.numCells *2, (sizes.sizeCell) * (sizes.numCells) +(sizes.sizeCell) * (sizes.numCells) / (2 * speedMoveScene));

            if (fName != null)
            {
                SaverPicture.ReadPicture(fName, background, background.Width, background.Height);
            }
        }
    }
}

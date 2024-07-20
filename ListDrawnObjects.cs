using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace IsometryTwo
{
    internal class ListDrawnObjects
    {
        public List<IDrawnObject> ListOBJ;

        public ListDrawnObjects()
        {
            ListOBJ = new List<IDrawnObject>();
        }

        public void AddElement(IDrawnObject element)
        {
            if (ListOBJ.Count != 0)
            {
                for (int i = 0; i < ListOBJ.Count; i++)
                {
                    if (element.YPanel <= ListOBJ[i].YPanel)
                    {
                        ListOBJ.Insert(i, element);
                        return;
                    }
                }
                ListOBJ.Add(element);
            }
            else
            {
                ListOBJ.Add(element);
            }
        }

        public void SortFromY()
        {
            ListOBJ.Sort((x, y) => x.YPanel.CompareTo(y.YPanel));
        }
    }
}

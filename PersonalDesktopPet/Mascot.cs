using PersonalDesktopPet.Actions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PersonalDesktopPet
{
    class Mascot
    {
        Stand stand;
        public Mascot()
        {
            stand = new Stand();
        }

        public Image Test()
        {
            return stand.Animation.Start();
        }
    }
}

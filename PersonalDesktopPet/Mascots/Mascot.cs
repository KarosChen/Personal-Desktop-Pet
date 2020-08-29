using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using PersonalDesktopPet.Mascots.Actions;


namespace PersonalDesktopPet.Mascots
{
    class Mascot
    {

        private Stand _stand;
        private Walk _walk;
        private Mascots.Actions.Action _executingAction;

        public Mascot()
        {
            _stand = new Stand();
            _walk = new Walk();
            _executingAction = _walk;
        }
      
        public Mascots.Actions.Action GetExecutingAction()
        {
            return _executingAction;
        }
    }
}

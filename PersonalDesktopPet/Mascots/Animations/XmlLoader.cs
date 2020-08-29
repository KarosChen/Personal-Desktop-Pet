using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace PersonalDesktopPet.Mascots.Animations
{
    class XmlLoader
    {
        public XmlNode _singleActionNodes;
        public XmlNode _sequenceActionNodes;

        /// <summary>
        /// there is a new attribute in actionList node(type: single or sequence)
        /// </summary>
        public void ReadActionXML()
        {
            string actionXMLPath = Directory.GetCurrentDirectory() + "\\conf\\actions.xml";

            XmlDocument actionXML = new XmlDocument();
            actionXML.Load(actionXMLPath);
            XmlNodeList actionList = actionXML.SelectNodes("Mascot/ActionList");
        
            foreach ( XmlNode node in actionList)
            {
                string typeValue = node.Attributes["Type"].Value;
                if (typeValue == "Single")
                {
                    _singleActionNodes = node;
                }
                else if (typeValue == "Sequence")
                {
                    _sequenceActionNodes = node;
                }
            }
        }

        public XmlNode GetSingleActionNode(string name)
        {
            XmlNodeList actionList = _singleActionNodes.SelectNodes("Action");
            foreach (XmlNode node in actionList)
            {
                string nameValue = node.Attributes["Name"].Value;                
                if (nameValue == name)
                {
                    return node;
                }
                else
                {
                    continue;
                }
            }
            return null;
        }
        /*
        public XmlNode GetSingleActionNode()
        {
            return _singleActionNodes;
        }
        public XmlNode GetSequenceActionNode()
        {
            return _sequenceActionNodes;
        }
        */
    }
}

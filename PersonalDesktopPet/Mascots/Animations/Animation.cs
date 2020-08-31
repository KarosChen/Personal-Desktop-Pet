using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace PersonalDesktopPet.Mascots.Animations
{
    class Animation
    {
        private string _borderType;
        private List<Pose> _poseList;
        private int _poseIndex = 0;
        private string _currentPath = Directory.GetCurrentDirectory();

        public string BorderType
        {
            get
            {
                return _borderType;
            }
            set
            {
                _borderType = value;
            }
        }

        public Animation(string actionName)
        {
            _poseList = new List<Pose>();
            AddAllPose(actionName);
        }

        private void AddAllPose(string actionName)
        {
            XmlLoader loader = new XmlLoader();
            loader.ReadActionXML();
            XmlNode actionNode = loader.GetSingleActionNode(actionName);
            //_borderType = actionNode.Attributes["BorderType"].Value;
            XmlNode animationNode = actionNode.SelectSingleNode("Animation");
            foreach (XmlNode poseNode in animationNode.SelectNodes("Pose"))
            {
                Pose newPose = new Pose();
                newPose.Duration = int.Parse(poseNode.Attributes["Duration"].Value);
                newPose.VelocityX = int.Parse(poseNode.Attributes["Velocity"].Value.Split(',')[0]);
                newPose.VelocityY = int.Parse(poseNode.Attributes["Velocity"].Value.Split(',')[1]);
                newPose.ImageAnchor = new Point(int.Parse(poseNode.Attributes["ImageAnchor"].Value.Split(',')[0]),
                                                int.Parse(poseNode.Attributes["ImageAnchor"].Value.Split(',')[1]));
                FileStream imageStream = File.OpenRead(_currentPath + "/img" + poseNode.Attributes["Image"].Value);
                newPose.Image = Image.FromStream(imageStream);
                _poseList.Add(newPose);
            }
        }

        public Pose GetNextPose()
        {
            Pose displayingPose;
            if (_poseIndex < _poseList.Count)
            {
                displayingPose = _poseList[_poseIndex++];
            }
            else
            {
                _poseIndex = 0;
                displayingPose = _poseList[_poseIndex++];
            }

            return displayingPose;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace PersonalDesktopPet.Animations
{
    class Animation
    {
        private List<Pose> _poseList;
        private int _poseIndex = 0;
        private string _currentPath = Directory.GetCurrentDirectory();

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
            XmlNode animationNode = actionNode.SelectSingleNode("Animation");

            foreach (XmlNode poseNode in animationNode.SelectNodes("Pose"))
            {
                Pose newPose = new Pose();
                newPose.Duration = int.Parse(poseNode.Attributes["Duration"].Value);
                newPose.XVelocity = int.Parse(poseNode.Attributes["Velocity"].Value.Split(',')[0]);
                newPose.YVelocity = int.Parse(poseNode.Attributes["Velocity"].Value.Split(',')[1]);
                FileStream imageStream = File.OpenRead(_currentPath + "/img" + poseNode.Attributes["Image"].Value);
                newPose.Image = Image.FromStream(imageStream);
                _poseList.Add(newPose);
            }
        }

        public Image Start()
        {
            Image showingPose;
            showingPose = _poseList[_poseIndex].Image;
            if (_poseIndex < _poseList.Count)
            {
                _poseIndex++;
            }
            else
            {
                _poseIndex = 0;
            }
            return showingPose;
        }
    }
}

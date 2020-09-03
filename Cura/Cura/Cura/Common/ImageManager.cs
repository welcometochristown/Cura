using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;

namespace Cura.Common
{
    public class ImageManager
    {
        #region Fields
        private Dictionary<string, Image> _Images;
        #endregion

        #region Properties
        public Dictionary<string, Image> Images
        {
            get
            {
                if (_Images == null)
                {
                    _Images = new Dictionary<string, Image>();
                }

                return _Images;
            }
        }
        #endregion

        #region Singleton Stuff
        private static ImageManager instance;

        public static ImageManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ImageManager();
                }
                return instance;
            }
        }
        #endregion

        public Image GetImage(string name)
        {

            Image img;

            if (Images.TryGetValue(name, out img))
                return img;

            return (Cura.Properties.Resources.ResourceManager.GetObject(name) as Image);
        }
    }
}

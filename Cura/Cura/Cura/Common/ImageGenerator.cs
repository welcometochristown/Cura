using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace Cura.Common
{
    class ImageGenerator
    {
        #region Fields
        private Dictionary<object, Image> ImageCollection;
        #endregion

        private static ImageGenerator instance;

        public static ImageGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ImageGenerator();
                }
                return instance;
            }
        }

        public ImageGenerator()
        {
            this.ImageCollection = new Dictionary<object, Image>();
        }

        public enum WorkerImageGen
        {
            Key = 1,
            Car = 2,
            Exclamation = 4,
            ClockError = 8
        }

        public enum ServiceUserImageGen
        {
            Medical = 1,
            Exclamation = 2,
            ImportantNotes = 4
        }

        public Image GenerateServiceUserImage(ServiceUserImageGen gen)
        {

            Image img;

            if (ImageCollection.TryGetValue(gen, out img))
                return img;

            int height = 16;
            int width = Enum.GetNames(typeof(ServiceUserImageGen)).Length * 16;

            if (width == 0)
                return null;

            img = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(img);

            int left = 0;
            if ((gen & ServiceUserImageGen.Medical) == ServiceUserImageGen.Medical)
            {
                g.DrawImage(ImageManager.Instance.GetImage("pill"), new Point(left, 0));
                left += 16;
            }
          //  left += 16;
            if ((gen & ServiceUserImageGen.Exclamation) == ServiceUserImageGen.Exclamation)
            {
                g.DrawImage(ImageManager.Instance.GetImage("exclamation"), new Point(left, 0));
                left += 16;
            }
         //   left += 16;
            if ((gen & ServiceUserImageGen.ImportantNotes) == ServiceUserImageGen.ImportantNotes)
            {
                g.DrawImage(ImageManager.Instance.GetImage("note_error"), new Point(left, 0));
                left += 16;
            }
          //  left += 16;

            ImageCollection.Add(gen, img);

            return img;
        }


        public Image GenerateWorkerImage(WorkerImageGen gen)
        {
            Image img;

            if (ImageCollection.TryGetValue(gen, out img))
                return img;

            int height = 16;
            int width = Enum.GetNames(typeof(WorkerImageGen)).Length * 16;

            if (width == 0)
                return null;

            img = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(img);

            int left = 0;
            if ((gen & WorkerImageGen.Key) == WorkerImageGen.Key)
            {
                g.DrawImage(ImageManager.Instance.GetImage("key"), new Point(left, 0));
                left += 16;
            }
            //left += 16;
            if ((gen & WorkerImageGen.Car) == WorkerImageGen.Car)
            {
                g.DrawImage(ImageManager.Instance.GetImage("car"), new Point(left, 0));
                left += 16;
            }
            //left += 16;
            if ((gen & WorkerImageGen.Exclamation) == WorkerImageGen.Exclamation)
            {
                g.DrawImage(ImageManager.Instance.GetImage("exclamation"), new Point(left, 0));
                left += 16;
            }
            //left += 16;
            if ((gen & WorkerImageGen.ClockError) == WorkerImageGen.ClockError)
            {
                g.DrawImage(ImageManager.Instance.GetImage("clock_error"), new Point(left, 0));
                left += 16;
            }
            //left += 16;

            ImageCollection.Add(gen, img);


            return img;
        }

    }
}

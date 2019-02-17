using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace SchoolPrj.Setting
{
    class ImageDeal
    {
        public static Image GetBrowserImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "اختر صورة";
            ofd.Filter = "Image Files |*.jpg; *.png; *.gif;";
            Image im = null;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                im = Image.FromFile(ofd.FileName);
            }
            return im;
        }
        public static byte[] imageToByteArray(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, img.RawFormat);
            return ms.ToArray();
        }
        public static Image ByteArrayToImage(byte[] bytes)
        {

            MemoryStream ms = new MemoryStream(bytes);
            Image returnImage = Image.FromStream(ms);
            return returnImage;

        }
        public static byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}


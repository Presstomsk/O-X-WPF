using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace O_X
{
    public class FirstPlayer //Первый игрок
    {
        public ImageBrush XPainting() //установка заднего фона "X"
        {
            var brush = new ImageBrush();
             brush.ImageSource = new BitmapImage(new Uri("cross.png", UriKind.Relative));
             return brush;
        }
    }
}

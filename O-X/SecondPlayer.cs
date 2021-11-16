using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace O_X
{
    public class SecondPlayer //Второй игрок
    {
        
        public ImageBrush OPainting() //Установка заднего фона "O"
        {
           var brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("zero.png", UriKind.Relative));
            return brush;
        }
    }
}

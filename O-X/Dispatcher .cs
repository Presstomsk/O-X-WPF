using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace O_X
{
    public class Dispatcher // Класс диспетчер
    {
        FirstPlayer _firstPlayer;
        SecondPlayer _secondPlayer;
        bool _queue;

        public Dispatcher(FirstPlayer first, SecondPlayer second, bool queue)
        {
            _firstPlayer = first;
            _secondPlayer = second;
            _queue = queue;
        }

        public ImageBrush Regulation(out string tag) //чередование "Х" и "О", tag : 1 -  в ячейке "X"; 2 - в ячейке "O"
        {

            if (_queue) 
            {
                _queue = false;
                tag = "1";
                return _firstPlayer.XPainting();
            }
                
            if(!_queue)
            {
                _queue = true;
                tag = "2";
                return _secondPlayer.OPainting();               
            }
            tag = null;
            return null;
        }


    }
}

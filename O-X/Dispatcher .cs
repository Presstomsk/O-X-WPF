
using System.Windows.Media;

namespace O_X
{
    public class Dispatcher // Класс диспетчер
    {
        FirstPlayer _firstPlayer;
        SecondPlayer _secondPlayer;
        Computer _computer;
        bool _queue,_comp;

        public Dispatcher(FirstPlayer first, SecondPlayer second, Computer computer, bool queue, bool comp)
        {
            _firstPlayer = first;
            _secondPlayer = second;
            _computer = computer;
            _queue = queue;
            _comp = comp;
        }

        public ImageBrush Regulation(out string tag) //чередование "Х" и "О", tag : 1 -  в ячейке "X"; 2 - в ячейке "O"
        {

            if (_queue) 
            {
                _queue = false;
                tag = "1";
                return _firstPlayer.XPainting();
            }
                
            if(!_queue && !_comp)
            {
                _queue = true;
                tag = "2";
                return _secondPlayer.OPainting();               
            }
            if (!_queue && _comp)
            {
                _queue = true;                
                _computer.StepCalculating();
                tag = null;
                return null;
            }
            tag = null;
            return null;
        }


    }
}

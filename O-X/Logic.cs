using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace O_X
{
    public class Logic
    {
        FirstPlayer _first;   //первый игрок
        SecondPlayer _second; // второй игрок  
        Computer _computer;  //компьютер      
        bool _queue;    // очередь
        Dispatcher _disp;      //диспетчер       
        ResultChecker _resultChecker; // "проверяльщик" результата
        Button[,] _buttons;        
        Panel _panel;
        bool _comp;
        public Logic(bool queue, Grid grid)
        {
            _panel = grid;
            _first = new FirstPlayer();
            _second = new SecondPlayer();
            _buttons = Buttons();
            _computer = new Computer (_buttons);
            _queue = queue;            
            _disp = new Dispatcher(_first, _second, _computer, queue, _comp);      

            _resultChecker = new ResultChecker(_buttons);
        }

        public Button[,] Buttons() // Формирование массива кнопок
        {            
            Button[,] buttons = new Button[3, 3];
            int j = 0;
            foreach (UIElement element in _panel.Children)
            {
                if (element is Button)
                {
                    buttons[j / 3, j % 3] = (Button)element;
                    j++;
                }
            }
            return buttons;
        }

        public void NewGame(bool comp)
        {
            _comp = comp;
            _queue = true; //сброс очереди
            _disp = new Dispatcher(_first, _second, _computer, _queue, _comp); //новый диспетчер
            foreach (var item in _buttons)
            {
                item.Tag = "0"; //сброс тэгов
                item.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFFF8000"); // сброс фона             

            }
        }

        public void Action(Button button)
        {
            if ((string)button.Tag == "0")
            {
                button.Background = _disp.Regulation(out string tag); // Установка фона
                button.Tag = tag; //Установка Тэга: 1   
                if (_comp) _disp.Regulation(out string tagnull);
                Messages.GameResult(_resultChecker.Result());
            }
        }







    }
}

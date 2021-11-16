using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace O_X
{
    public class ResultChecker //Класс проверки результата
    {
        Button[,] _buttons;

        public ResultChecker(Button[,] buttons)
        {
            _buttons = buttons;
        }

        public int Result() //Проверка результата: 1 - победили "Х", 2 - победили "O", 3 - игра не закончена, 4 - ничья
        {
            for (int i = 1; i < 3; i++) // Проверяются вертикали и горизонтали
            {

                var sym = Convert.ToString(i);

                for (int j = 0; j < 3 ; j++)
                {
                    if 
                    (
                    (string)_buttons[0, j].Tag == sym && (string)_buttons[1, j].Tag == sym && (string)_buttons[2, j].Tag == sym ||
                    (string)_buttons[j, 0].Tag == sym && (string)_buttons[j, 1].Tag == sym && (string)_buttons[j, 2].Tag == sym
                    ) return i;
                }
            }

            for (int i = 1; i < 3; i++) //Проверяются диагонали
            {
                var sym = Convert.ToString(i);

                if 
                (
                (string)_buttons[0, 0].Tag == sym && (string)_buttons[1, 1].Tag == sym && (string)_buttons[2, 2].Tag == sym ||
                (string)_buttons[2, 0].Tag == sym && (string)_buttons[1, 1].Tag == sym && (string)_buttons[0, 2].Tag == sym
                ) return i;
            }

            foreach (var element in _buttons) //Проверяются, есть ли пустые клетки
            {
                if ((string)element.Tag == "0") return 3; 
            }

            return 4;
        }
    }
}

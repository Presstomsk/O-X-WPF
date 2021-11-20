using System;
using System.Windows.Controls;


namespace O_X
{
    public class Computer : SecondPlayer //Компьютер
    {
        Button[,] _buttons;

        public Computer(Button[,] buttons)
        {
            _buttons = buttons;
        }       

        private void ComputerStep(Button button) // Шаг компьютера
        {
            button.Background = OPainting(); 
            button.Tag = "2";
        }

        private Button CanWin() // проверка на возможность выйгрыша
        {
            
                for (int j = 0; j < 3; j++) // Проверяются горизонтали
                {
                    if
                    (
                    Convert.ToInt32(_buttons[0, j].Tag) + Convert.ToInt32(_buttons[1, j].Tag) + Convert.ToInt32(_buttons[2, j].Tag) == 4 &&
                    ((string)_buttons[0, j].Tag == "2" || (string)_buttons[1, j].Tag == "2" || (string)_buttons[2, j].Tag == "2")
                    ) for (int i = 0; i < 3; i++) if ((string)_buttons[i, j].Tag == "0") return _buttons[i, j];
                  
                }
                for (int j = 0; j < 3; j++) // Проверяются вертикали
                {
                     if
                    (
                    Convert.ToInt32(_buttons[j, 0].Tag) + Convert.ToInt32(_buttons[j, 1].Tag) + Convert.ToInt32(_buttons[j, 2].Tag) == 4 &&
                    ((string)_buttons[j, 0].Tag == "2" || (string)_buttons[j, 1].Tag == "2" || (string)_buttons[j, 2].Tag == "2")
                    ) for (int i = 0; i < 3; i++) if ((string)_buttons[j, i].Tag == "0") return _buttons[j, i];

                }

            if // Проверяется первая диагональ
            (
              Convert.ToInt32(_buttons[0, 0].Tag) + Convert.ToInt32(_buttons[1, 1].Tag) + Convert.ToInt32(_buttons[2, 2].Tag) == 4 &&
              ((string)_buttons[0, 0].Tag == "2" || (string)_buttons[1, 1].Tag == "2" || (string)_buttons[2, 2].Tag == "2")
            ) for (int i = 0; i < 3; i++) if ((string)_buttons[i, i].Tag == "0") return _buttons[i, i];

            if // Проверяется вторая диагональ
            (
              Convert.ToInt32(_buttons[0, 2].Tag) + Convert.ToInt32(_buttons[1, 1].Tag) + Convert.ToInt32(_buttons[2, 0].Tag) == 4 &&
              ((string)_buttons[0, 2].Tag == "2" || (string)_buttons[1, 1].Tag == "2" || (string)_buttons[2, 0].Tag == "2")
            ) for (int i = 0; i < 3; i++) if ((string)_buttons[i, 2-i].Tag == "0") return _buttons[i, 2-i];

            return null;

        }

        private Button CanLose() // проверка на возможность пройгрыша
        {

            for (int j = 0; j < 3; j++) // Проверяются горизонтали
            {
                if
                (
                Convert.ToInt32(_buttons[0, j].Tag) + Convert.ToInt32(_buttons[1, j].Tag) + Convert.ToInt32(_buttons[2, j].Tag) == 2 &&
                (string)_buttons[0, j].Tag != "2" && (string)_buttons[1, j].Tag != "2" && (string)_buttons[2, j].Tag != "2"
                ) for (int i = 0; i < 3; i++) if ((string)_buttons[i, j].Tag == "0") return _buttons[i, j];


            }
            for (int j = 0; j < 3; j++) // Проверяются вертикали
            {
                if
               (
               Convert.ToInt32(_buttons[j, 0].Tag) + Convert.ToInt32(_buttons[j, 1].Tag) + Convert.ToInt32(_buttons[j, 2].Tag) == 2 &&
               (string)_buttons[j, 0].Tag != "2" && (string)_buttons[j, 1].Tag != "2" && (string)_buttons[j, 2].Tag != "2"
               ) for (int i = 0; i < 3; i++) if ((string)_buttons[j, i].Tag == "0") return _buttons[j, i]; 

            }

            if // Проверяется первая диагональ
            (
              Convert.ToInt32(_buttons[0, 0].Tag) + Convert.ToInt32(_buttons[1, 1].Tag) + Convert.ToInt32(_buttons[2, 2].Tag) == 2 &&
              (string)_buttons[0, 0].Tag != "2" && (string)_buttons[1, 1].Tag != "2" && (string)_buttons[2, 2].Tag != "2"
            ) for (int i = 0; i < 3; i++) if ((string)_buttons[i, i].Tag == "0") return _buttons[i, i];

            if // Проверяется вторая диагональ
            (
              Convert.ToInt32(_buttons[0, 2].Tag) + Convert.ToInt32(_buttons[1, 1].Tag) + Convert.ToInt32(_buttons[2, 0].Tag) == 2 &&
              (string)_buttons[0, 2].Tag != "2" && (string)_buttons[1, 1].Tag != "2" && (string)_buttons[2, 0].Tag != "2"
            ) for (int i = 0; i < 3; i++) if ((string)_buttons[i, 2 - i].Tag == "0") return _buttons[i, 2 - i];

            return null;

        }

        private void GoToCorner() // ход в угол
        {
            for (int i = 0; i <= 2; i += 2)
            {
                for (int j = 0; j <= 2; j += 2)
                {
                    if ((string)_buttons[i, j].Tag == "0")
                    {
                        ComputerStep(_buttons[i, j]);
                        return;
                    }
                }
            }           
        }

        public void StepCalculating() //Алгоритм вычисления ходов компьютера
        {
            var canWin = CanWin();
            var canLose = CanLose();
            if (canWin != null)
            {
                ComputerStep(canWin);                
                return;
                
            }
            if (canLose != null)
            {
                ComputerStep(canLose);               
                return;
            }
            if ((string)_buttons[1, 1].Tag == "0")
            {
                ComputerStep(_buttons[1, 1]);
                return;
            }
            else
            {
                GoToCorner();
                return;
            }
        }
    }
}

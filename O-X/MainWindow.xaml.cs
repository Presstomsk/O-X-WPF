using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace O_X
{
    
    public partial class MainWindow : Window
    {
        FirstPlayer first;   //первый игрок
        SecondPlayer second;  // второй игрок
        bool queue = true;    // очередь
        Dispatcher disp;      //диспетчер
        Button[,] buttons;      //кнопки
        ResultChecker resultChecker; // "проверяльщик" результата
        int result;
        
        public MainWindow()
        {
            InitializeComponent();
            first = new FirstPlayer();
            second = new SecondPlayer();            
            disp = new Dispatcher(first, second, queue);
            buttons = Buttons();
            resultChecker = new ResultChecker(buttons);

        }
        private void ProgramClose_Click(object sender, RoutedEventArgs e) //Закрытие программы
        {
            
            Close();
        }

        private void VsPersonGame_Click(object sender, RoutedEventArgs e) // Новая игра "человек против человека"  
        {
            foreach (var item in buttons)
            {
                item.Tag = "0"; //сброс тэгов
                item.Background=(SolidColorBrush)new BrushConverter().ConvertFromString("#FFFF8000"); // сброс фона
                queue = true; //сброс очереди
                disp= new Dispatcher(first, second, queue); //новый диспетчер
            }
               
            
        }
        private void Button_Click(object sender, RoutedEventArgs e) //Обработка нажатия кнопки : 0 - кнопка не нажата
        {
            
             if ((string)(sender as Button).Tag == "0")
             {
                 (sender as Button).Background = disp.Regulation(out string tag); // Установка фона
                 (sender as Button).Tag = tag; //Установка Тэга: 1 или 2                                           
                Messages.GameResult(resultChecker.Result());              
             }

        }
        private  Button[,] Buttons() // Формирование массива кнопок
        {
            Panel panel = CrossZero;
            Button[,] buttons = new Button[3, 3];
            int j = 0;
            foreach (UIElement element in panel.Children)
            {
                if (element is Button)
                {
                    buttons[j / 3, j % 3] = (Button)element;
                    j++;
                }
            }
            return buttons;
        }
    }
}

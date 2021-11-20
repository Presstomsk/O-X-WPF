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
             
        bool queue = true;    // очередь  
      
        Logic logic; //логика событий
        
        public MainWindow()
        {
            InitializeComponent();                       
            logic = new Logic(queue, CrossZero);        
        }
        private void ProgramClose_Click(object sender, RoutedEventArgs e) //Закрытие программы
        {            
            Close();
        }

        private void VsPersonGame_Click(object sender, RoutedEventArgs e) // Новая игра "человек против человека"  
        { 
            logic.NewGame(false); //режим против человека 
        }
        private void VsComputerGame_Click(object sender, RoutedEventArgs e) // Новая игра "человек против компьютера"  
        {
            logic.NewGame(true); //режим против компьютера 
        }
        private void Button_Click(object sender, RoutedEventArgs e) //Обработка нажатия кнопки : 0 - кнопка не нажата
        {
            Button but = (Button)sender;
            logic.Action(but);  
        }

       
    }
}

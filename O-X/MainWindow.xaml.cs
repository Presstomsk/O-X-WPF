using System.Windows;
using System.Windows.Controls;


namespace O_X
{
    
    public partial class MainWindow : Window
    {            
       
        Logic logic; //логика событий
        
        public MainWindow()
        {
            InitializeComponent();                       
            logic = new Logic(CrossZero);        
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
        private void Button_Click(object sender, RoutedEventArgs e) //Обработка нажатия кнопки 
        {
            Button button = sender as Button;
            logic.Action(button);  
        }

       
    }
}

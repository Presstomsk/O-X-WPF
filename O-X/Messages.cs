
using System.Windows;

namespace O_X
{
    public static class Messages //Сообщения
    {
        public static int GameResult(int result) 
        {
            if (result == 1)
            {
                MessageBox.Show("Победа за крестиками!", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                return 1;
            }
            if (result == 2)
            {
                MessageBox.Show("Победа за нулями!", "Результат игры", MessageBoxButton.OK, MessageBoxImage.Information);
                return 2;
            }            
            if (result == 3) return 3;
            
            if (result == 4)
            {
                MessageBox.Show("Ничья!", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                return 4;
            }

            return 0;
           
        }
    }
}

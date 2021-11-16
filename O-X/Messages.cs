using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace O_X
{
    public static class Messages //Сообщения
    {
        public static void GameResult(int result) 
        {
            if (result == 1)
            {
                MessageBox.Show("Победа за крестиками!", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (result == 2)
            {
                MessageBox.Show("Победа за нулями!", "Результат игры", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }            
            if (result == 3) return;
            
            if (result == 4)
            {
                MessageBox.Show("Ничья!", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
           
           
        }
    }
}

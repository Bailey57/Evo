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
using System.Windows.Shapes;
using System.Media;
using static Evo.Sounds;
namespace Evo.Windows
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        SoundPlayer buttonClick;
        public MainMenu()
        {
            InitializeComponent();

          


                // / Windows / gameButton1_green_up.png
        }


        private void NewGame(object sender, RoutedEventArgs e)
        {
            Sounds.PlayButtonSound1();
            MainWindow subWindow = new MainWindow();
            subWindow.Show();
            this.Close();
            
        }


        private void LoadGame(object sender, RoutedEventArgs e)
        {

            Sounds.PlayButtonSound1();


        }

    }
}

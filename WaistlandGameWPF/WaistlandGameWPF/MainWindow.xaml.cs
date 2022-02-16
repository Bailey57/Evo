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
using System.Windows.Shapes;
using System.Diagnostics;

namespace WaistlandGameWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameState gameState = new GameState();
        public MainWindow()
        {
            //Hitbox tst = new Hitbox();
            //tst.testingMethod();
            InitializeComponent();
            gameState = gameState.MakeBuild1();

            consoleOutput.Text = gameState.GetPlayer().getObjectStringEvents();
            playerDirection.Text = gameState.GetPlayer().getDirectionFacing();




        }



        private void FaceNorth(object sender, RoutedEventArgs e) 
        {
            gameState.GetPlayer().setDirectionFacing("N");
        }




    }
}

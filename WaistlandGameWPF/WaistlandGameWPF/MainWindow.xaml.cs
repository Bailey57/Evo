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
            itemsInSight.ItemsSource = gameState.GetPlayer().itemsInSightList(gameState.GetMainMap());
            playerInventory.ItemsSource = gameState.GetPlayer().getInventory();
            //itemsInSight.ItemsSource = gameState.GetPlayer().itemsInSightListToString(gameState.GetMainMap());


        }

        public void GameLoop() 
        {
            double seconds = 5;
            consoleOutput.Text = gameState.GetPlayer().getObjectStringEvents();
            playerDirection.Text = gameState.GetPlayer().getDirectionFacing();
            itemsInSight.ItemsSource = gameState.GetPlayer().itemsInSightList(gameState.GetMainMap());
            playerInventory.ItemsSource = gameState.GetPlayer().getInventory();
            gameState.GetMainMap().runThroughEntityActions(gameState.GetMainMap(), gameState.GetPlayer(), seconds);

        }



        private void FaceNorth(object sender, RoutedEventArgs e) 
        {
            gameState.GetPlayer().setDirectionFacing("N");
            GameLoop();
        }
        private void FaceSouth(object sender, RoutedEventArgs e)
        {
            gameState.GetPlayer().setDirectionFacing("S");
            GameLoop();
        }
        private void FaceEast(object sender, RoutedEventArgs e)
        {
            gameState.GetPlayer().setDirectionFacing("E");
            GameLoop();
        }
        private void FaceWest(object sender, RoutedEventArgs e)
        {
            gameState.GetPlayer().setDirectionFacing("W");
            GameLoop();
        }

        private void PickUpItemOffOfGround(object sender, RoutedEventArgs e) 
        {
            gameState.GetPlayer().pickUpItemOffOfGround((BaseItem) itemsInSight.SelectedItems);
            GameLoop();
        }

        private void EquipItemAsWeapon(object sender, RoutedEventArgs e)
        {
            gameState.GetPlayer().equipItemAsWeapon((BaseItem)playerInventory.SelectedItem);
            GameLoop();
        }


        private void MovePlayer(object sender, RoutedEventArgs e)
        {
            double minutesWalking = 15;

            gameState.SetLastPosition(gameState.GetPlayerPos().toString());
            // gameState.GetPlayer().GameObjectPos.movePosition(gameState.GetMainMap().map,
            // direction);
            gameState.GetPlayer().gameObjectPos.movePlayerOnMapArea(gameState.GetMainMap(), gameState.GetPlayer(),
                    gameState.GetPlayer().getDirectionFacing(), minutesWalking);

            gameState.SetThisPosition(gameState.GetPlayerPos().toString());

            if (!gameState.GetLastPosition().Equals(gameState.GetThisPosition()))
            {
                gameState.SetDidPlayerMoveThisTurn(true);
                gameState.GetMainMap().printGameMapString();
            }
            GameLoop();


        }




    }
}

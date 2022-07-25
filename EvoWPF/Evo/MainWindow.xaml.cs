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
using System.Media;

namespace Evo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private GameState gameState = new GameState();
        private SaveLoad saveLoad = new SaveLoad();
        private EntityAction entityAction = new EntityAction();

        private SoundPlayer buttonPressSound;
        
        public MainWindow()
        {
            //Hitbox tst = new Hitbox();
            //tst.testingMethod();
            //DrawButtons();
            InitializeComponent();

           // buttonPressSound = new SoundPlayer(@"/Resources/sounds/gui/buttons/buttonClick_1.wav");
            buttonPressSound = new SoundPlayer(@"/buttonClick_1.wav");
            //buttonPressSound.Source = new Uri(@"/Resources/sounds/gui/buttons/buttonClick_1.mp3", UriKind.Relative);
            // buttonPress.routedevent
            //selcetPOI_Button.AddToEventRoute();


            gameVersionLabel.Content = "v0.5.4";

            gameState = gameState.MakeBuild1();

            consoleOutput.Text = gameState.GetPlayer().getObjectStringEvents();
            playerDirection.Content = gameState.GetPlayer().getDirectionFacing();


            itemsInSight.ItemsSource = gameState.GetPlayer().itemsInSightList(gameState.GetMainMap());
            //?
            //itemsInSightListBox.ItemsSource = gameState.GetPlayer().itemsInSightList(gameState.GetMainMap());


            pointsOfInterestListView.ItemsSource = gameState.GetMainMap().pointOfInterests;

            playerInventory.ItemsSource = gameState.GetPlayer().getInventory();
            //inventoryListBox.ItemsSource = gameState.GetPlayer().getInventory();
            DrawMap();
            DrawButtons();


            //playerInventory.ItemsSource = gameState.GetPlayer().getGameObjectHitbox().getBodyParts(); //player body parts
            //itemsInSight.ItemsSource = gameState.GetPlayer().itemsInSightListToString(gameState.GetMainMap());


        }

        public void GameLoop()
        {
            loadingStatusLabel.Content = "Loading Status: in progress";
            double seconds = 5;
            consoleOutput.Text = gameState.GetPlayer().getObjectStringEvents();
            playerDirection.Content = gameState.GetPlayer().getDirectionFacing();

            //(BaseItem)playerInventory.SelectedItem
            if (pointsOfInterestListView.SelectedItem != null) 
            {
                poi_desc.Text = ((PointOfInterest)pointsOfInterestListView.SelectedItem).GetInfo();
                pointsOfInterestListView.ItemsSource = gameState.GetMainMap().pointOfInterests;
            }
            


            itemsInSight.ItemsSource = gameState.GetPlayer().itemsInSightList(gameState.GetMainMap());
            //?
            //itemsInSightListBox.ItemsSource = gameState.GetPlayer().itemsInSightList(gameState.GetMainMap());


            playerInventory.ItemsSource = gameState.GetPlayer().getInventory();

            //inventoryListBox.ItemsSource = gameState.GetPlayer().getInventory();
            //playerInventory.ItemsSource = gameState.GetPlayer().itemsInSightList(gameState.GetMainMap());
            //playerInventory.


            entitiesInSightList.ItemsSource = gameState.GetPlayer().entitiesInSightList(gameState.GetMainMap());

            gameState.GetMainMap().runThroughEntityActions(gameState.GetMainMap(), gameState.GetPlayer(), seconds);
            consoleOutput.ScrollToEnd();

            if (gameState.GetPlayer().getEntityWeapon() != null)
            {
                equippedWeapon.Content = gameState.GetPlayer().getEntityWeapon().getObjectName();
            }
            else 
            {
                equippedWeapon.Content = "nothing";
            }

            //add to overall map loading so every gameObject gets this
            //gameState.GetPlayer().addObjectStringEvents("\n<-day: ?-------Time: ?->\n
            gameState.GetPlayer().addObjectStringEvents("\n<-------------------->\nDate: 01/01/2095\nTime: 1300\n\n");
            DrawMap();
            mapPosLabel.Content = "X: " + gameState.GetPlayer().getGameObjectPos().getCurrentArea().getPosOnMapX()
                + "Y: " + gameState.GetPlayer().getGameObjectPos().getCurrentArea().getPosOnMapY();
            loadingStatusLabel.Content = "Loading Status: done";

            //buttonPressSound.Play();
        }

        


        private void NewGame(object sender, RoutedEventArgs e)
        {
            loadingStatusLabel.Content = "Loading Status: in progress";

            gameState = gameState.MakeBuild1();
            GameLoop();
        }


        private void SaveGame(object sender, RoutedEventArgs e) 
        {
            loadingStatusLabel.Content = "Loading Status: in progress";
            saveLoad.SaveGame(gameState);
            GameLoop();
        }

        private void LoadGame(object sender, RoutedEventArgs e)
        {
            loadingStatusLabel.Content = "Loading Status: in progress";

            gameState = saveLoad.LoadGame();
            GameLoop();
        }



        private void DrawButtons() 
        {

            /*pickUpItemButton.Background = new BitmapImage(new Uri(@"/Assets/images/gui/buttons/gameButton1_green_up.png", UriKind.Relative));
            equipWeaponButton.Content = new BitmapImage(new Uri(@"/Assets/images/gui/buttons/gameButton1_green_up.png", UriKind.Relative));
            dropItemButton.Content = new BitmapImage(new Uri(@"/Assets/images/gui/buttons/gameButton1_green_up.png", UriKind.Relative));
            rackGunButton.Content = new BitmapImage(new Uri(@"/Assets/images/gui/buttons/gameButton1_green_up.png", UriKind.Relative));
            loadMagazineButton.Content = new BitmapImage(new Uri(@"/Assets/images/gui/buttons/gameButton1_green_up.png", UriKind.Relative));
            fillMagazineButton.Content = new BitmapImage(new Uri(@"/Assets/images/gui/buttons/gameButton1_green_up.png", UriKind.Relative));
            attackEntityButton.Content = new BitmapImage(new Uri(@"/Assets/images/gui/buttons/gameButton1_green_up.png", UriKind.Relative));
            fireAtEntityButton.Content = new BitmapImage(new Uri(@"/Assets/images/gui/buttons/gameButton1_green_up.png", UriKind.Relative));*/
        }

        private void DrawMap() 
        {
            string mapAreaName;
            int playerMapX = gameState.GetPlayer().getGameObjectPos().getCurrentArea().getPosOnMapX();
            int playerMapY = gameState.GetPlayer().getGameObjectPos().getCurrentArea().getPosOnMapY();

            int maxMapX = gameState.GetMainMap().getMapX_max();
            int maxMapY = gameState.GetMainMap().getMapY_max();


            //add checks in if statements for max mapPos
            if (playerMapX >= 0 && playerMapY >= 0 && playerMapX < maxMapX && playerMapY < maxMapY)
            {
                mapAreaName = gameState.GetMainMap().gameMap[playerMapX, playerMapY].getAreaName();
                mapArea_x0_y0.Source = new BitmapImage(new Uri(@"/"+ mapAreaName +".png", UriKind.Relative));
                if (mapArea_x0_y0.Source == null) 
                {
                    mapArea_x0_y0.Source = new BitmapImage(new Uri(@"/WIP_MapSquare.png", UriKind.Relative));           
                }
            }
            else 
            {
                mapArea_x0_y0.Source = new BitmapImage(new Uri(@"/gameMapBorder.png", UriKind.Relative));
            }
            //mapArea_x0_y0.Source = new BitmapImage(new Uri(@"/town.png", UriKind.Relative));//for testing purposes


            if (playerMapX + 1 >= 0 && playerMapY >= 0 && playerMapX + 1 < maxMapX && playerMapY < maxMapY)
            {
                mapAreaName = gameState.GetMainMap().gameMap[playerMapX + 1, playerMapY].getAreaName();
                mapArea_x1_y0.Source = new BitmapImage(new Uri(@"/" + mapAreaName + ".png", UriKind.Relative));
            }
            else
            {
                mapArea_x1_y0.Source = new BitmapImage(new Uri(@"/gameMapBorder.png", UriKind.Relative));
            }

            if (playerMapX + 1 >= 0 && playerMapY + 1 >= 0 && playerMapX + 1 < maxMapX && playerMapY + 1 < maxMapY)
            {
                mapAreaName = gameState.GetMainMap().gameMap[playerMapX + 1, playerMapY + 1].getAreaName();
                mapArea_x1_y1.Source = new BitmapImage(new Uri(@"/" + mapAreaName + ".png", UriKind.Relative));
            }
            else
            {
                mapArea_x1_y1.Source = new BitmapImage(new Uri(@"/gameMapBorder.png", UriKind.Relative));
            }

            if (playerMapX >= 0 && playerMapY + 1 >= 0 && playerMapX < maxMapX && playerMapY + 1< maxMapY)
            {
                mapAreaName = gameState.GetMainMap().gameMap[playerMapX, playerMapY + 1].getAreaName();
                mapArea_x0_y1.Source = new BitmapImage(new Uri(@"/" + mapAreaName + ".png", UriKind.Relative));
            }
            else
            {
                mapArea_x0_y1.Source = new BitmapImage(new Uri(@"/gameMapBorder.png", UriKind.Relative));
            }


            if (playerMapX - 1 >= 0 && playerMapY >= 0 && playerMapX - 1 < maxMapX && playerMapY < maxMapY)
            {
                mapAreaName = gameState.GetMainMap().gameMap[playerMapX - 1, playerMapY].getAreaName();
                mapArea_x_1_y0.Source = new BitmapImage(new Uri(@"/" + mapAreaName + ".png", UriKind.Relative));
            }
            else
            {
                mapArea_x_1_y0.Source = new BitmapImage(new Uri(@"/gameMapBorder.png", UriKind.Relative));
            }



            if (playerMapX - 1 >= 0 && playerMapY - 1 >= 0 && playerMapX -1 < maxMapX && playerMapY - 1 < maxMapY)
            {
                mapAreaName = gameState.GetMainMap().gameMap[playerMapX - 1, playerMapY - 1].getAreaName();
                mapArea_x_1_y_1.Source = new BitmapImage(new Uri(@"/" + mapAreaName + ".png", UriKind.Relative));
            }
            else
            {
                mapArea_x_1_y_1.Source = new BitmapImage(new Uri(@"/gameMapBorder.png", UriKind.Relative));
            }


            if (playerMapX >= 0 && playerMapY - 1 >= 0 && playerMapX < maxMapX && playerMapY - 1 < maxMapY)
            {
                mapAreaName = gameState.GetMainMap().gameMap[playerMapX, playerMapY - 1].getAreaName();
                mapArea_x0_y_1.Source = new BitmapImage(new Uri(@"/" + mapAreaName + ".png", UriKind.Relative));
            }
            else
            {
                mapArea_x0_y_1.Source = new BitmapImage(new Uri(@"/gameMapBorder.png", UriKind.Relative));
            }



            if (playerMapX - 1 >= 0 && playerMapY + 1 >= 0 && playerMapX - 1 < maxMapX && playerMapY + 1 < maxMapY)
            {
                mapAreaName = gameState.GetMainMap().gameMap[playerMapX - 1, playerMapY + 1].getAreaName();
                mapArea_x_1_y1.Source = new BitmapImage(new Uri(@"/" + mapAreaName + ".png", UriKind.Relative));
            }
            else
            {
                mapArea_x_1_y1.Source = new BitmapImage(new Uri(@"/gameMapBorder.png", UriKind.Relative));
            }



            if (playerMapX + 1 >= 0 && playerMapY - 1 >= 0 && playerMapX + 1 < maxMapX && playerMapY - 1 < maxMapY)
            {
                mapAreaName = gameState.GetMainMap().gameMap[playerMapX + 1, playerMapY - 1].getAreaName();
                mapArea_x1_y_1.Source = new BitmapImage(new Uri(@"/" + mapAreaName + ".png", UriKind.Relative));
            }
            else
            {
                mapArea_x1_y_1.Source = new BitmapImage(new Uri(@"/gameMapBorder.png", UriKind.Relative));
            }

            //mapArea.Source = new BitmapImage(new Uri(@"assets/" + mapAreaName + ".png"));
            //mapArea_x0_y0.Source = new BitmapImage(new Uri(@"/street.png", UriKind.Relative));
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
            gameState.GetPlayer().pickUpItemOffOfGround((BaseItem) itemsInSight.SelectedItem);
            GameLoop();
        }

        private void DropItem(object sender, RoutedEventArgs e)
        {
            gameState.GetPlayer().dropItem((BaseItem)playerInventory.SelectedItem);
            //gameState.GetPlayer().removeItemFromInventory
            GameLoop();
        }

        private void EquipItemAsWeapon(object sender, RoutedEventArgs e)
        {
            gameState.GetPlayer().equipItemAsWeapon((BaseItem) playerInventory.SelectedItem);

            GameLoop();
        }


        private void AttackEntity(object sender, RoutedEventArgs e)
        {

            if (gameState.GetPlayer().getEntityWeapon() != null) 
            {
                gameState.GetPlayer().attackEntity(gameState.GetMainMap(), (Entity)entitiesInSightList.SelectedItem, 0, true);
            }         

            GameLoop();
        }

        private void FireAtEntity(object sender, RoutedEventArgs e)
        {

            if (gameState.GetPlayer().getEntityWeapon() != null && gameState.GetPlayer().getEntityWeapon() is Gun)
            {
                ((Gun)gameState.GetPlayer().getEntityWeapon()).fireGunAtGameObject(gameState.GetPlayer(), (Entity)entitiesInSightList.SelectedItem);
            }

            GameLoop();
        }




        private void RackGun(object sender, RoutedEventArgs e)
        {
            if (gameState.GetPlayer().getEntityWeapon() != null && gameState.GetPlayer().getEntityWeapon() is Gun)
            {
                ((Gun)gameState.GetPlayer().getEntityWeapon()).cockGun(gameState.GetPlayer());
                GameLoop();
            }
        }
        private void LoadGun(object sender, RoutedEventArgs e)
        {
            if (gameState.GetPlayer().getEntityWeapon() != null && gameState.GetPlayer().getEntityWeapon() is Gun)
            {
                if (playerInventory.SelectedItem is Magazine)
                {
                    entityAction.LoadGun(gameState.GetPlayer(), ((Gun)gameState.GetPlayer().getEntityWeapon()),
                        ((Magazine)playerInventory.SelectedItem));
                    //((Gun)gameState.GetPlayer().getEntityWeapon()).reload();

                }

                GameLoop();
            }
        }

        private void FillMagazine(object sender, RoutedEventArgs e)
        {
            if (playerInventory.SelectedItem != null && playerInventory.SelectedItem is Magazine)
            {
                entityAction.FillMagazine(gameState.GetPlayer(), ((Magazine)playerInventory.SelectedItem));
                GameLoop();
            }
        }


        private void MovePlayer(object sender, RoutedEventArgs e)
        {
            double minutesWalking = 5;

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


        private void ReloadGUI(object sender, RoutedEventArgs e)
        {
            GameLoop();
        }


        private void SelectPOI(object sender, RoutedEventArgs e)
        {
           // buttonPressSound.Play();
            GameLoop();
        }




    }
}

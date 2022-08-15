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
using Evo.Windows;
using Evo;
using Evo.GameObjects.HitBoxes;
//using Evo.GameObjects.HitBoxes.BodyPart;
namespace Evo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private GameState gameState = new GameState();
        private SaveLoad saveLoad = new SaveLoad();
        //private EntityAction entityAction = new EntityAction();

        //private SoundPlayer buttonPressSound;

        private double secondsPassed = 0;
        public MainWindow()
        {
            //Hitbox tst = new Hitbox();
            //tst.testingMethod();
            //DrawButtons();
            InitializeComponent();

            // buttonPressSound = new SoundPlayer(@"/Resources/sounds/gui/buttons/buttonClick_1.wav");
            //buttonPressSound = new SoundPlayer(@"/buttonClick_1.wav");
            //buttonPressSound.Source = new Uri(@"/Resources/sounds/gui/buttons/buttonClick_1.mp3", UriKind.Relative);
            // buttonPress.routedevent
            //selcetPOI_Button.AddToEventRoute();


            gameVersionLabel.Content = "v0.7.7";

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
            gameState.GetPlayer().SetSecondsLeft(99999999);


            loadingStatusLabel.Content = "Loading Status: in progress";
            //System.Threading.Thread.Sleep(50);


            UpdateGUI();



            //change later to be more robust and organized(ie, move from map and organize entity decision making)
            gameState.GetMainMap().runThroughEntityActions(gameState.GetMainMap(), gameState.GetPlayer(), secondsPassed);



            gameState.GetGameTime().PassSeconds(secondsPassed);


            if (gameState.GetPlayer().getEntityWeapon() != null)
            {
                equippedWeapon.Content = gameState.GetPlayer().getEntityWeapon().getObjectName();
            }
            else
            {
                equippedWeapon.Content = "nothing equipped";
            }
            consoleOutput.Text = gameState.GetPlayer().getObjectStringEvents();
            //add to overall map loading so every gameObject gets this
            //gameState.GetPlayer().addObjectStringEvents("\n<-day: ?-------Time: ?->\n
            gameState.GetPlayer().addObjectStringEvents("\n<-------------------->\n" + gameState.GetGameTime().ToString() + "\n");
            DrawMap();
            //move a lot of the coordinate info into getter methods for gameObject
            mapPosLabel.Content = "X: " + gameState.GetPlayer().getGameObjectPos().getCurrentArea().getPosOnMapX()
                + " Y: " + gameState.GetPlayer().getGameObjectPos().getCurrentArea().getPosOnMapY();
            mapOverallPositionLabel.Content = "X: " + Math.Ceiling(gameState.GetPlayer().getGameObjectPos().GetOverallXPosition())
                + " Y: " + Math.Ceiling(gameState.GetPlayer().getGameObjectPos().GetOverallYPosition());

            if (entitiesInSightList.SelectedItem != null)
            {
                mapOverallPositionLabelEntity.Content = "X: " + Math.Ceiling(((Entity)entitiesInSightList.SelectedItem).getGameObjectPos().GetOverallXPosition())
                + " Y: " + Math.Ceiling(((Entity)entitiesInSightList.SelectedItem).getGameObjectPos().GetOverallYPosition());
            }



            loadingStatusLabel.Content = "Loading Status: done";
            

            consoleOutput.ScrollToEnd();
            secondsPassed = 0;

            //buttonPressSound.Play();
        }


        private void UpdateGUI()
        {
            //consoleOutput.Text = gameState.GetPlayer().getObjectStringEvents();
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
            //entitiesInSightList
            if (entitiesInSightList.SelectedItem != null)
            {
                bodyPartsList.ItemsSource = ((Entity)entitiesInSightList.SelectedItem).getGameObjectHitbox().getBodyParts();
            }

            consoleOutput.ScrollToEnd();

            if (gameState.GetPlayer().getEntityWeapon() != null)
            {
                equippedWeapon.Content = gameState.GetPlayer().getEntityWeapon().getObjectName();
            }
            else
            {
                equippedWeapon.Content = "nothing equipped";
            }
            DrawMap();
            mapPosLabel.Content = "X: " + gameState.GetPlayer().getGameObjectPos().getCurrentArea().getPosOnMapX()
                + " Y: " + gameState.GetPlayer().getGameObjectPos().getCurrentArea().getPosOnMapY();
            mapOverallPositionLabel.Content = "X: " + Math.Ceiling(gameState.GetPlayer().getGameObjectPos().GetOverallXPosition())
                + " Y: " + Math.Ceiling(gameState.GetPlayer().getGameObjectPos().GetOverallYPosition());

            if (entitiesInSightList.SelectedItem != null)
            {
                mapOverallPositionLabelEntity.Content = "X: " + ((Entity)entitiesInSightList.SelectedItem).getGameObjectPos().GetOverallXPosition()
                + " Y: " + ((Entity)entitiesInSightList.SelectedItem).getGameObjectPos().GetOverallYPosition();
            }

            playerDestinationDescription.Text = gameState.GetPlayer().GetPath().GetCurrentDestinationToString();

        }

        private void UpdateGUI(object sender, RoutedEventArgs e)
        {
            UpdateGUI();
        }

        private void GoToMainMenu(object sender, RoutedEventArgs e)
        {
            Sounds.PlayButtonSound1();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
            GameLoop();
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            loadingStatusLabel.Content = "Loading Status: in progress";

            gameState = gameState.MakeBuild1();
            Sounds.PlayButtonSound1();
            GameLoop();
        }


        private void SaveGame(object sender, RoutedEventArgs e)
        {
            loadingStatusLabel.Content = "Loading Status: in progress";
            saveLoad.SaveGame(gameState);
            Sounds.PlayButtonSound1();
            GameLoop();
        }

        private void LoadGame(object sender, RoutedEventArgs e)
        {
            loadingStatusLabel.Content = "Loading Status: in progress";

            gameState = saveLoad.LoadGame();
            Sounds.PlayButtonSound1();
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
                mapArea_x0_y0.Source = new BitmapImage(new Uri(@"/Resources/images/map/" + mapAreaName + ".png", UriKind.Relative));
                if (mapArea_x0_y0.Source == null)
                {
                    mapArea_x0_y0.Source = new BitmapImage(new Uri(@"/Resources/images/map/WIP_MapSquare.png", UriKind.Relative));
                }
            }
            else
            {
                //\Resources\images\map\gameMapBorder.png
                mapArea_x0_y0.Source = new BitmapImage(new Uri(@"/Resources/images/map/gameMapBorder.png", UriKind.Relative));
            }
            //mapArea_x0_y0.Source = new BitmapImage(new Uri(@"/town.png", UriKind.Relative));//for testing purposes


            if (playerMapX + 1 >= 0 && playerMapY >= 0 && playerMapX + 1 < maxMapX && playerMapY < maxMapY)
            {
                mapAreaName = gameState.GetMainMap().gameMap[playerMapX + 1, playerMapY].getAreaName();
                mapArea_x1_y0.Source = new BitmapImage(new Uri(@"/Resources/images/map/" + mapAreaName + ".png", UriKind.Relative));
            }
            else
            {
                mapArea_x1_y0.Source = new BitmapImage(new Uri(@"/Resources/images/map/gameMapBorder.png", UriKind.Relative));
            }

            if (playerMapX + 1 >= 0 && playerMapY + 1 >= 0 && playerMapX + 1 < maxMapX && playerMapY + 1 < maxMapY)
            {
                mapAreaName = gameState.GetMainMap().gameMap[playerMapX + 1, playerMapY + 1].getAreaName();
                mapArea_x1_y1.Source = new BitmapImage(new Uri(@"/Resources/images/map/" + mapAreaName + ".png", UriKind.Relative));
            }
            else
            {
                mapArea_x1_y1.Source = new BitmapImage(new Uri(@"/Resources/images/map/gameMapBorder.png", UriKind.Relative));
            }

            if (playerMapX >= 0 && playerMapY + 1 >= 0 && playerMapX < maxMapX && playerMapY + 1 < maxMapY)
            {
                mapAreaName = gameState.GetMainMap().gameMap[playerMapX, playerMapY + 1].getAreaName();
                mapArea_x0_y1.Source = new BitmapImage(new Uri(@"/Resources/images/map/" + mapAreaName + ".png", UriKind.Relative));
            }
            else
            {
                mapArea_x0_y1.Source = new BitmapImage(new Uri(@"/Resources/images/map/gameMapBorder.png", UriKind.Relative));
            }


            if (playerMapX - 1 >= 0 && playerMapY >= 0 && playerMapX - 1 < maxMapX && playerMapY < maxMapY)
            {
                mapAreaName = gameState.GetMainMap().gameMap[playerMapX - 1, playerMapY].getAreaName();
                mapArea_x_1_y0.Source = new BitmapImage(new Uri(@"/Resources/images/map/" + mapAreaName + ".png", UriKind.Relative));
            }
            else
            {
                mapArea_x_1_y0.Source = new BitmapImage(new Uri(@"/Resources/images/map/gameMapBorder.png", UriKind.Relative));
            }



            if (playerMapX - 1 >= 0 && playerMapY - 1 >= 0 && playerMapX - 1 < maxMapX && playerMapY - 1 < maxMapY)
            {
                mapAreaName = gameState.GetMainMap().gameMap[playerMapX - 1, playerMapY - 1].getAreaName();
                mapArea_x_1_y_1.Source = new BitmapImage(new Uri(@"/Resources/images/map/" + mapAreaName + ".png", UriKind.Relative));
            }
            else
            {
                mapArea_x_1_y_1.Source = new BitmapImage(new Uri(@"/Resources/images/map/gameMapBorder.png", UriKind.Relative));
            }


            if (playerMapX >= 0 && playerMapY - 1 >= 0 && playerMapX < maxMapX && playerMapY - 1 < maxMapY)
            {
                mapAreaName = gameState.GetMainMap().gameMap[playerMapX, playerMapY - 1].getAreaName();
                mapArea_x0_y_1.Source = new BitmapImage(new Uri(@"/Resources/images/map/" + mapAreaName + ".png", UriKind.Relative));
            }
            else
            {
                mapArea_x0_y_1.Source = new BitmapImage(new Uri(@"/Resources/images/map/gameMapBorder.png", UriKind.Relative));
            }



            if (playerMapX - 1 >= 0 && playerMapY + 1 >= 0 && playerMapX - 1 < maxMapX && playerMapY + 1 < maxMapY)
            {
                mapAreaName = gameState.GetMainMap().gameMap[playerMapX - 1, playerMapY + 1].getAreaName();
                mapArea_x_1_y1.Source = new BitmapImage(new Uri(@"/Resources/images/map/" + mapAreaName + ".png", UriKind.Relative));
            }
            else
            {
                mapArea_x_1_y1.Source = new BitmapImage(new Uri(@"/Resources/images/map/gameMapBorder.png", UriKind.Relative));
            }



            if (playerMapX + 1 >= 0 && playerMapY - 1 >= 0 && playerMapX + 1 < maxMapX && playerMapY - 1 < maxMapY)
            {
                mapAreaName = gameState.GetMainMap().gameMap[playerMapX + 1, playerMapY - 1].getAreaName();
                mapArea_x1_y_1.Source = new BitmapImage(new Uri(@"/Resources/images/map/" + mapAreaName + ".png", UriKind.Relative));
            }
            else
            {
                mapArea_x1_y_1.Source = new BitmapImage(new Uri(@"/Resources/images/map/gameMapBorder.png", UriKind.Relative));
            }

            //mapArea.Source = new BitmapImage(new Uri(@"assets/" + mapAreaName + ".png"));
            //mapArea_x0_y0.Source = new BitmapImage(new Uri(@"/street.png", UriKind.Relative));
        }


        private void PlayerWait(object sender, RoutedEventArgs e)
        {

            //waitButton
            //gameState.GetPlayer()
            Sounds.PlayButtonSound1();
            secondsPassed = 5 * 60;
            gameState.GetPlayer().addObjectStringEvents("Waited for 5 minutes");

            GameLoop();
        }

        private void FaceNorth(object sender, RoutedEventArgs e)
        {
            gameState.GetPlayer().setDirectionFacing("N");
            Sounds.PlayButtonSound1();
            UpdateGUI();
        }
        private void FaceSouth(object sender, RoutedEventArgs e)
        {
            gameState.GetPlayer().setDirectionFacing("S");
            Sounds.PlayButtonSound1();
            UpdateGUI();
        }
        private void FaceEast(object sender, RoutedEventArgs e)
        {
            gameState.GetPlayer().setDirectionFacing("E");
            Sounds.PlayButtonSound1();
            UpdateGUI();
        }
        private void FaceWest(object sender, RoutedEventArgs e)
        {
            gameState.GetPlayer().setDirectionFacing("W");
            Sounds.PlayButtonSound1();
            UpdateGUI();
        }

        private void PickUpItemOffOfGround(object sender, RoutedEventArgs e)
        {
            Sounds.PlayButtonSound1();
            if (itemsInSight.SelectedItem != null)
            {
                gameState.GetPlayer().pickUpItemOffOfGround((BaseItem)itemsInSight.SelectedItem);
                secondsPassed += 3;
            }
            else
            {
                gameState.GetPlayer().addObjectStringEvents("No item on ground selected");
            }


            GameLoop();
        }

        private void DropItem(object sender, RoutedEventArgs e)
        {
            Sounds.PlayButtonSound1();
            gameState.GetPlayer().dropItem((BaseItem)playerInventory.SelectedItem);
            //gameState.GetPlayer().removeItemFromInventory
            secondsPassed += 3;

            GameLoop();

        }


        private void EquipItemAsArmor(object sender, RoutedEventArgs e)
        {
            Sounds.PlayButtonSound1();
            if (playerInventory.SelectedItem != null && playerInventory.SelectedItem is Armor)
            {

                gameState.GetPlayer().getGameObjectHitbox().addArmorToHitbox((Armor)playerInventory.SelectedItem);
                gameState.GetPlayer().addObjectStringEvents("Equiped " + ((Armor)playerInventory.SelectedItem).getObjectName());
                secondsPassed += 3;
            }
            else
            {
                gameState.GetPlayer().addObjectStringEvents("Need to select armor to equip");
            }

            GameLoop();
        }

        private void EquipItemAsWeapon(object sender, RoutedEventArgs e)
        {
            Sounds.PlayButtonSound1();
            if (playerInventory.SelectedItem != null)
            {
                gameState.GetPlayer().equipItemAsWeapon((BaseItem)playerInventory.SelectedItem);
                secondsPassed += 3;
            }
            else
            {
                gameState.GetPlayer().addObjectStringEvents("Need to select something in inventory first to equip as weapon");
            }

            GameLoop();
        }


        private void AttackEntity(object sender, RoutedEventArgs e)
        {
            Sounds.PlayButtonSound1();
            if (gameState.GetPlayer().getEntityWeapon() != null)
            {
                gameState.GetPlayer().attackEntity(gameState.GetMainMap(), (Entity)entitiesInSightList.SelectedItem, 0, true);
            }
            secondsPassed += 2;

            GameLoop();
        }

        private void FireAtEntity(object sender, RoutedEventArgs e)
        {
            Sounds.PlayButtonSound1();
            if (gameState.GetPlayer().getEntityWeapon() != null && gameState.GetPlayer().getEntityWeapon() is Gun)
            {
                if (((Gun)gameState.GetPlayer().getEntityWeapon()).getLoadedProjectile() != null)
                {
                    Sounds.PlayFireSingleSig9mm();
                }

                EntityAction.FireGunAtEntityBodyPart(gameState.GetPlayer(), (Entity)entitiesInSightList.SelectedItem, (BodyPart)bodyPartsList.SelectedItem);

                //((Gun)gameState.GetPlayer().getEntityWeapon()).fireGunAtGameObject(gameState.GetPlayer(), (Entity)entitiesInSightList.SelectedItem);

                secondsPassed += 2;
            }
            else
            {
                gameState.GetPlayer().addObjectStringEvents("No firearm equipped");
            }


            GameLoop();
        }

        private void TargetCenterOfMass(object sender, RoutedEventArgs e)
        {
            Sounds.PlayButtonSound1();
            bodyPartsList.SelectedItem = null;
            UpdateGUI();
        }


        private void RackGun(object sender, RoutedEventArgs e)
        {
            Sounds.PlayButtonSound1();
            if (gameState.GetPlayer().getEntityWeapon() != null && gameState.GetPlayer().getEntityWeapon() is Gun)
            {
                ((Gun)gameState.GetPlayer().getEntityWeapon()).cockGun(gameState.GetPlayer());
                secondsPassed += 1;
                Sounds.PlayRackSig9mm();
                GameLoop();
            }
            else
            {
                gameState.GetPlayer().addObjectStringEvents("No firearm equipped");
            }

        }
        private void LoadGun(object sender, RoutedEventArgs e)
        {
            Sounds.PlayButtonSound1();
            if (gameState.GetPlayer().getEntityWeapon() != null && gameState.GetPlayer().getEntityWeapon() is Gun)
            {
                if (playerInventory.SelectedItem is Magazine)
                {
                    EntityAction.LoadGun(gameState.GetPlayer(), ((Gun)gameState.GetPlayer().getEntityWeapon()),
                        ((Magazine)playerInventory.SelectedItem));
                    //((Gun)gameState.GetPlayer().getEntityWeapon()).reload();
                    secondsPassed += 6;
                    
                }
                else if (!(playerInventory.SelectedItem is Magazine))
                {
                    gameState.GetPlayer().addObjectStringEvents("Need to select a magazine");
                }  
            }
            else
            {
                gameState.GetPlayer().addObjectStringEvents("No firearm equipped");
            }
            GameLoop();
        }

        private void FillMagazine(object sender, RoutedEventArgs e)
        {
            Sounds.PlayButtonSound1();
            if (playerInventory.SelectedItem != null && playerInventory.SelectedItem is Magazine)
            {
                EntityAction.FillMagazine(gameState.GetPlayer(), ((Magazine)playerInventory.SelectedItem));
                secondsPassed += 15;
                
                GameLoop();
            }

        }


        private void MovePlayer(object sender, RoutedEventArgs e)
        {
            if (gameState.GetPlayer().GetPath().GetCurrentDestination() != null)
            {
                int loops = 0;
                secondsPassed = 0;
                //gameState.GetPlayer().
                

                while (!gameState.GetPlayer().GetPath().CurrentDestinationReached(gameState.GetPlayer().getGameObjectPos())) 
                {
                    loops++;
                    secondsPassed = 5;
                    EntityAction.ApproachGameObjectPos(gameState.GetPlayer(), gameState.GetPlayer().GetPath().GetCurrentDestination().GetGameObjectPos(), secondsPassed);
                    //EntityAction.ApproachGameObjectPosTenthOfASecond(gameState.GetPlayer(), gameState.GetPlayer().GetPath().GetCurrentDestination().GetGameObjectPos());
                    gameState.GetMainMap().runThroughEntityActions(gameState.GetMainMap(), gameState.GetPlayer(), secondsPassed);
                    gameState.GetGameTime().PassSeconds(secondsPassed);
                    secondsPassed = 0;
                    if (gameState.GetPlayer().isSpotted() || loops >= 10000) 
                    {
                        break;
                    }

                }

            }
            else 
            {


                double minutesWalking = 5;
                double tickTimeInSec = 1;
                bool wasSpotted = gameState.GetPlayer().isSpotted();
                gameState.SetLastPosition(gameState.GetPlayerPos().toString());
                // gameState.GetPlayer().GameObjectPos.movePosition(gameState.GetMainMap().map,
                // direction);

                //for (int i = 0; i < minutesWalking * 60; i++) 
                //{

                    gameState.GetPlayer().gameObjectPos.movePlayerOnMapArea(gameState.GetMainMap(), gameState.GetPlayer(),
                            gameState.GetPlayer().getDirectionFacing(), minutesWalking);

                    gameState.SetThisPosition(gameState.GetPlayerPos().toString());

                    if (!gameState.GetLastPosition().Equals(gameState.GetThisPosition()))
                    {
                        gameState.SetDidPlayerMoveThisTurn(true);
                        gameState.GetMainMap().printGameMapString();
                    }
                    secondsPassed += minutesWalking * 60;
                    gameState.GetGameTime().PassSeconds(secondsPassed);
                    //gameState.GetMainMap().runThroughEntityActions(gameState.GetMainMap(), gameState.GetPlayer(), secondsPassed);
                    if (gameState.GetPlayer().isSpotted() && !wasSpotted) 
                    {
                        //break;
                    }

                //}
                

            }
   
            Sounds.PlayButtonSound1();
            GameLoop();


        }







        private void ReloadGUI(object sender, RoutedEventArgs e)
        {
            Sounds.PlayButtonSound1();
            GameLoop();
        }


        private void SelectPOI(object sender, RoutedEventArgs e)
        {
            PointOfInterest poi = (PointOfInterest)pointsOfInterestListView.SelectedItem;
            
            Sounds.PlayButtonSound1();
            //gameState.GetPlayer().GetPath().MakeNewDestinationFromGameObjectPos(poi.GetName(), poi.GetDescription(), poi.GetGameObjectPos());
            gameState.GetPlayer().GetPath().GetDestinationList().Clear();
            gameState.GetPlayer().GetPath().AddDestination(gameState.GetPlayer().GetPath().MakeNewDestinationFromGameObjectPos(poi.GetName(), poi.GetDescription(), poi.GetGameObjectPos()));
            // buttonPressSound.Play();
            UpdateGUI();
        }

        private void ClearPOI(object sender, RoutedEventArgs e)
        {
            Sounds.PlayButtonSound1();
            //gameState.GetPlayer().GetPath().MakeNewDestinationFromGameObjectPos(poi.GetName(), poi.GetDescription(), poi.GetGameObjectPos());
            gameState.GetPlayer().GetPath().GetDestinationList().Clear();
            // buttonPressSound.Play();
            UpdateGUI();
        }


    }
}

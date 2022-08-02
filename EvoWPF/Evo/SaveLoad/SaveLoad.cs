using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Evo
{
    public class SaveLoad
    {
        public SaveLoad() 
        {
        }


        public void SaveGame(GameState gameState) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            //string path = Directory.GetCurrentDirectory() + @"/gamesaves/save1.evogamesave";
            string savePath = Environment.CurrentDirectory + @"\gamesaves\save1.evogamesave";
            //string path = Application
            FileStream fs = new FileStream(savePath, FileMode.Create);
            
            formatter.Serialize(fs, gameState);
            fs.Close();


        }

        public GameState LoadGame() 
        {

            //string path = Directory.GetCurrentDirectory() + @"/gamesaves/save1.evogamesave";
            string savePath = Environment.CurrentDirectory + @"\gamesaves\save1.evogamesave";
            if (File.Exists(savePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fs = new FileStream(savePath, FileMode.Open);
                GameState gameState = formatter.Deserialize(fs) as GameState;
                fs.Close();
                return gameState;
            }
            else 
            {
                //could not find file
                return null;
            }
        
        }


    }




}

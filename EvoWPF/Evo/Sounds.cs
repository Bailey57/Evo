using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
namespace Evo
{
    public static class Sounds
    {
        static SoundPlayer music;
        static SoundPlayer sound;


        public static void PlayButtonSound1()
        {
            string fileToPlay = Environment.CurrentDirectory + @"\Resources\sounds\gui\buttons\buttonClick_1.wav";
            sound = new SoundPlayer(fileToPlay);
            sound.Play();
        }





    }
}

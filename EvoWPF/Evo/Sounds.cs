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
        //static SoundPlayer music;
        //static SoundPlayer sound;


        public static void PlayButtonSound1()
        {
            string fileToPlay = Environment.CurrentDirectory + @"\Resources\sounds\gui\buttons\buttonClick_1.wav";
            SoundPlayer sound = new SoundPlayer(fileToPlay);
            sound.Play();
        }



        public static void PlayFireSingleSig9mm()
        {
            string fileToPlay = Environment.CurrentDirectory + @"\Resources\sounds\weapons\guns\sig 9mm\Sig single shot1.wav";
            SoundPlayer sound = new SoundPlayer(fileToPlay);
            sound.Play();
        }


        public static void PlayRackSig9mm()
        {
            string fileToPlay = Environment.CurrentDirectory + @"\Resources\sounds\weapons\guns\sig 9mm\Sig rack1.wav";
            SoundPlayer sound = new SoundPlayer(fileToPlay);
            sound.Play();
        }




    }
}

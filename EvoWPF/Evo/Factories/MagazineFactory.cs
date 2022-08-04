using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace Evo.Factories
{
    public static class MagazineFactory
    {



        public static Magazine MakeEmpty9mmMagazine(GameObjectPos gameObjectPos) 
        {
            Magazine _9mm_mag = new Magazine(gameObjectPos, "9mm mag", .95, 6, 9);
            return _9mm_mag;

        }


        public static Magazine MakeEmptyAK47Magazine(GameObjectPos gameObjectPos)
        {
            Magazine _9mm_mag = new Magazine(gameObjectPos, "A47 mag", .95, 30, 7.62);
            return _9mm_mag;

        }




















        /**
         * @return bool same size ammo
         */
        public static bool FillMagWithNewRounds(Magazine magazine, ProjectileAmmo projectileAmmo) 
        {
            
            decimal d1 = Convert.ToDecimal(projectileAmmo.getDiameter());
            decimal d2 = Convert.ToDecimal(magazine.getMagProjectileDiamiter());


            if (d1 != d2) 
            {
                return false;
            }
            for (int i = 0; i < magazine.getAmmoCapacity(); i++) 
            {
                ProjectileAmmo newAmmo = projectileAmmo;
                magazine.addBullet(newAmmo);
            }


            return true;
        
        }

    }
}

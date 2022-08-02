using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evo.GameObjects.HitBoxes;

namespace Evo
{
    public static class ArmorFactory
    {




        public static Armor MakeArmor() 
        {
            Armor armor = new Armor();
			return armor;
        }


		public static Armor MakeGenericArmorPlate_TESTING()
		{
			Material material = new Material();
			material.getMildSteel();

			Armor genericArmorPlate = new Armor("genericArmorPlate 3mm mild", material.getMildSteel(), 3,
					-135.2273, 135.2273, 1164.015, 1425.189, 100, 108);

			return genericArmorPlate;
		}

		public static Armor MakeGenericArmorPlate_TESTING_4mm()
		{
			Material material = new Material();
			material.getMildSteel();

			Armor genericArmorPlate = new Armor("genericArmorPlate 4mm mild", material.getMildSteel(), 4,
					-135.2273, 135.2273, 1164.015, 1425.189, 100, 108);

			return genericArmorPlate;
		}

		public static Armor MakeGenericArmorPlate_TESTING_4mm_HardenedSteel()
		{
			Material material = new Material();
			material.getMildSteel();

			Armor genericArmorPlate = new Armor("genericArmorPlate 4mm hardened", material.getHardendedSteel(), 4,
					-135.2273, 135.2273, 1164.015, 1425.189, 100, 108);

			return genericArmorPlate;
		}


		public static Armor MakeGenericArmorPlate_TESTING_8mm_HardenedSteel()
		{
			Material material = new Material();
			material.getMildSteel();

			Armor genericArmorPlate = new Armor("genericArmorPlate 8mm hardened", material.getHardendedSteel(), 8,
					-135.2273, 135.2273, 1164.015, 1425.189, 100, 108);

			return genericArmorPlate;
		}





		public static Armor randomArmor()
		{

			RandomNumbers rand = new RandomNumbers();

			int randInt = rand.rollRandInt(0, 100);


			if (randInt <= 20)
			{
				return MakeGenericArmorPlate_TESTING();

			}
			else if (randInt <= 40)
			{
				return MakeGenericArmorPlate_TESTING_4mm();

			}
			else if (randInt <= 80)
			{

				return MakeGenericArmorPlate_TESTING_8mm_HardenedSteel();

			}
			else
			{
				return MakeGenericArmorPlate_TESTING_4mm_HardenedSteel();
			}


		}


	}
}

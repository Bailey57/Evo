using Evo.GameObjects.HitBoxes;
using System;


namespace Evo
{

    [System.Serializable]
	public class Armor : BaseItem
	{

	/**
	 * 
	 */
	public bool armorPlate;
	public bool helmet;
	public bool legArmor;






	public Material material;
	public double thicknessIn_mm;


	//might change to size vs coverage so it can be more useful
	public double xMinCoverage;
	public double xMaxCoverage;

	public double yMinCoverage;
	public double yMaxCoverage;


	public double zMinCoverage;
	public double zMaxCoverage;



	public Armor() :base(null, null, 1)
		{
		
	}


	public Armor(GameObjectPos gameObjectPos, String objectName, double thicknessIn_mm,
			double xMinCoverage, double xMaxCoverage, double yMinCoverage, double yMaxCoverage, double zMinCoverage,
			double zMaxCoverage) : base(gameObjectPos, objectName, 1)
		{
		
		this.thicknessIn_mm = thicknessIn_mm;
		this.xMinCoverage = xMinCoverage;
		this.xMaxCoverage = xMaxCoverage;
		this.yMinCoverage = yMinCoverage;
		this.yMaxCoverage = yMaxCoverage;
		this.zMinCoverage = zMinCoverage;
		this.zMaxCoverage = zMaxCoverage;
	}


	public Armor(String objectName, Material material, double thicknessIn_mm,
			double xMinCoverage, double xMaxCoverage, double yMinCoverage, double yMaxCoverage, double zMinCoverage,
			double zMaxCoverage) : base(null, objectName, 1)
		{
		this.material = material;
		this.thicknessIn_mm = thicknessIn_mm;
		this.xMinCoverage = xMinCoverage;
		this.xMaxCoverage = xMaxCoverage;
		this.yMinCoverage = yMinCoverage;
		this.yMaxCoverage = yMaxCoverage;
		this.zMinCoverage = zMinCoverage;
		this.zMaxCoverage = zMaxCoverage;
	}


	/**
	 * @return the material
	 */
	public Material getMaterial()
	{
		return material;
	}


	/**
	 * @param material the material to set
	 */
	public void setMaterial(Material material)
	{
		this.material = material;
	}


	/**
	 * @return the thicknessIn_mm
	 */
	public double getThicknessIn_mm()
	{
		return thicknessIn_mm;
	}


	/**
	 * @param thicknessIn_mm the thicknessIn_mm to set
	 */
	public void setThicknessIn_mm(double thicknessIn_mm)
	{
		this.thicknessIn_mm = thicknessIn_mm;
	}


	/**
	 * @return the xMinCoverage
	 */
	public double getxMinCoverage()
	{
		return xMinCoverage;
	}


	/**
	 * @param xMinCoverage the xMinCoverage to set
	 */
	public void setxMinCoverage(double xMinCoverage)
	{
		this.xMinCoverage = xMinCoverage;
	}


	/**
	 * @return the xMaxCoverage
	 */
	public double getxMaxCoverage()
	{
		return xMaxCoverage;
	}


	/**
	 * @param xMaxCoverage the xMaxCoverage to set
	 */
	public void setxMaxCoverage(double xMaxCoverage)
	{
		this.xMaxCoverage = xMaxCoverage;
	}


	/**
	 * @return the yMinCoverage
	 */
	public double getyMinCoverage()
	{
		return yMinCoverage;
	}


	/**
	 * @param yMinCoverage the yMinCoverage to set
	 */
	public void setyMinCoverage(double yMinCoverage)
	{
		this.yMinCoverage = yMinCoverage;
	}


	/**
	 * @return the yMaxCoverage
	 */
	public double getyMaxCoverage()
	{
		return yMaxCoverage;
	}


	/**
	 * @param yMaxCoverage the yMaxCoverage to set
	 */
	public void setyMaxCoverage(double yMaxCoverage)
	{
		this.yMaxCoverage = yMaxCoverage;
	}




	/**
	 * @return the zMinCoverage
	 */
	public double getzMinCoverage()
	{
		return zMinCoverage;
	}


	/**
	 * @param zMinCoverage the zMinCoverage to set
	 */
	public void setzMinCoverage(double zMinCoverage)
	{
		this.zMinCoverage = zMinCoverage;
	}


	/**
	 * @return the zMaxCoverage
	 */
	public double getzMaxCoverage()
	{
		return zMaxCoverage;
	}


	/**
	 * @param zMaxCoverage the zMaxCoverage to set
	 */
	public void setzMaxCoverage(double zMaxCoverage)
	{
		this.zMaxCoverage = zMaxCoverage;
	}


	public Armor genericArmorPlate_TESTING()
	{
		Material material = new Material();
		material.getMildSteel();

		Armor genericArmorPlate = new Armor("genericArmorPlate 3mm mild", material.getMildSteel(), 3,
				-135.2273, 135.2273, 1164.015, 1425.189, 100, 108);

		return genericArmorPlate;
	}

	public Armor genericArmorPlate_TESTING_4mm()
	{
		Material material = new Material();
		material.getMildSteel();

		Armor genericArmorPlate = new Armor("genericArmorPlate 4mm mild", material.getMildSteel(), 4,
				-135.2273, 135.2273, 1164.015, 1425.189, 100, 108);

		return genericArmorPlate;
	}

	public Armor genericArmorPlate_TESTING_4mm_HardenedSteel()
	{
		Material material = new Material();
		material.getMildSteel();

		Armor genericArmorPlate = new Armor("genericArmorPlate 4mm hardened", material.getHardendedSteel(), 4,
				-135.2273, 135.2273, 1164.015, 1425.189, 100, 108);

		return genericArmorPlate;
	}


	public Armor genericArmorPlate_TESTING_8mm_HardenedSteel()
	{
		Material material = new Material();
		material.getMildSteel();

		Armor genericArmorPlate = new Armor("genericArmorPlate 8mm hardened", material.getHardendedSteel(), 8,
				-135.2273, 135.2273, 1164.015, 1425.189, 100, 108);

		return genericArmorPlate;
	}




	public bool onArmorCheck(double xPosOnArmor, double yPosOnArmor)
	{

		if (xPosOnArmor <= xMaxCoverage && xPosOnArmor >= xMinCoverage)
		{

			if (yPosOnArmor <= yMaxCoverage && yPosOnArmor >= yMinCoverage)
			{
				return true;

			}
		}
		return false;

	}



	public Armor randomArmor()
	{

		RandomNumbers rand = new RandomNumbers();

		int randInt = rand.rollRandInt(0, 100);


		if (randInt <= 20)
		{
			return genericArmorPlate_TESTING();

		}
		else if (randInt <= 40)
		{
			return genericArmorPlate_TESTING_4mm();

		}
		else if (randInt <= 80)
		{

			return genericArmorPlate_TESTING_8mm_HardenedSteel();

		}
		else
		{
			return genericArmorPlate_TESTING_4mm_HardenedSteel();
		}







	}



}


}
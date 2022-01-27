using System;


namespace Wasteland_game
{
	/*
	package wasteland.map;

	import java.io.Serializable;

	using Wasteland.GameObject;
	using Wasteland.entity.Entity;
	using Wasteland.items.BaseItem;
	*/
	/**
	 * @author bailey
	 *
	 */
	[System.Serializable]
	public class MapArea 
	{

	/**
	 * 
	 */
	//private static final long serialVersionUID = 1L;

	//add a view distance modifier based on mapArea
	String areaName;

	String displayLetter;

	int numOfEntitiesOnArea; // entities on the map area

	double areaElevation;

	public BaseItem[] spawnableItems;

	public bool playerOnArea = false;

	public Entity[] entitiesOnArea;

	public GameObject[,] gameObjectsOnMapAreaCords = new GameObject[200, 200];

	public double mapAreaX_max;
	public double mapAreaX_min;

	public double mapAreaY_max;
	public double mapAreaY_min;

	public int posOnMapX;
	public int posOnMapY;

	public MapArea(String areaName, String displayLetter, int numOfEntitiesOnArea, double areaElevation)
	{
		this.areaName = areaName;
		this.numOfEntitiesOnArea = numOfEntitiesOnArea;
		this.displayLetter = displayLetter;
	}

	public MapArea(String areaName, String displayLetter, int numOfEntitiesOnArea, double areaElevation, int posOnMapX,
			int posOnMapY)
	{
		this.areaName = areaName;
		this.numOfEntitiesOnArea = numOfEntitiesOnArea;
		this.displayLetter = displayLetter;
		this.posOnMapX = posOnMapX;
		this.posOnMapY = posOnMapY;

		setMapAreaX_max(posOnMapX);
		setMapAreaX_min(posOnMapX);

		setMapAreaY_max(posOnMapY);
		setMapAreaY_min(posOnMapY);

		entitiesOnArea = new Entity[numOfEntitiesOnArea];// change later so less limmited
	}



	/**
	 * @return the areaName
	 */
	public String getAreaName()
	{
		return areaName;
	}

	/**
	 * @param areaName the areaName to set
	 */
	public void setAreaName(String areaName)
	{
		this.areaName = areaName;
	}

	/**
	 * @return the displayLetter
	 */
	public String getDisplayLetter()
	{
		return displayLetter;
	}

	/**
	 * @param displayLetter the displayLetter to set
	 */
	public void setDisplayLetter(String displayLetter)
	{
		this.displayLetter = displayLetter;
	}

	/**
	 * @return the areaElevation
	 */
	public double getAreaElevation()
	{
		return areaElevation;
	}

	/**
	 * @param areaElevation the areaElevation to set
	 */
	public void setAreaElevation(double areaElevation)
	{
		this.areaElevation = areaElevation;
	}

	/**
	 * @return the playerOnArea
	 */
	public bool isPlayerOnArea()
	{
		return playerOnArea;
	}

	/**
	 * @param playerOnArea the playerOnArea to set
	 */
	public void setPlayerOnArea(bool playerOnArea)
	{
		this.playerOnArea = playerOnArea;
	}

	/**
	 * @return the mapAreaX_max
	 */
	public double getMapAreaX_max()
	{
		return mapAreaX_max;
	}

	/**
	 * @param mapAreaX_max the mapAreaX_max to set
	 */
	public void setMapAreaX_max(double posOnMapX)
	{
		this.mapAreaX_max = posOnMapX * 200 + 199;
	}

	/**
	 * @return the mapAreaX_min
	 */
	public double getMapAreaX_min()
	{
		return mapAreaX_min;
	}

	/**
	 * @param mapAreaX_min the mapAreaX_min to set
	 */
	public void setMapAreaX_min(double posOnMapX)
	{
		this.mapAreaX_min = posOnMapX * 200;
	}

	/**
	 * @return the mapAreaY_max
	 */
	public double getMapAreaY_max()
	{
		return mapAreaY_max;
	}

	/**
	 * @param mapAreaY_max the mapAreaY_max to set
	 */
	public void setMapAreaY_max(double posOnMapY)
	{
		this.mapAreaY_max = posOnMapY * 200 + 199;
	}

	/**
	 * @return the mapAreaY_min
	 */
	public double getMapAreaY_min()
	{
		return mapAreaY_min;
	}

	/**
	 * @param mapAreaY_min the mapAreaY_min to set
	 */
	public void setMapAreaY_min(double posOnMapY)
	{
		this.mapAreaY_min = posOnMapY * 200;
	}




	/**
	 * @return the posOnMapX
	 */
	public int getPosOnMapX()
	{
		return posOnMapX;
	}

	/**
	 * @param posOnMapX the posOnMapX to set
	 */
	public void setPosOnMapX(int posOnMapX)
	{
		this.posOnMapX = posOnMapX;
	}

	/**
	 * @return the posOnMapY
	 */
	public int getPosOnMapY()
	{
		return posOnMapY;
	}

	/**
	 * @param posOnMapY the posOnMapY to set
	 */
	public void setPosOnMapY(int posOnMapY)
	{
		this.posOnMapY = posOnMapY;
	}




	/**
	 * @return the entitiesOnAreaCords
	 */
	public GameObject[,] getGameObjectsOnMapAreaCords()
	{
		return gameObjectsOnMapAreaCords;
	}

	/**
	 * @param entitiesOnAreaCords the entitiesOnAreaCords to set
	 */
	public void setGameObjectsOnMapAreaCords(GameObject[,] gameObjectsOnAreaCords)
	{


		this.gameObjectsOnMapAreaCords = gameObjectsOnAreaCords;
	}



	/**
	 * 
	 * @return MapAreaCordsInfo
	 */
	public String getMapAreaCordsInfo()
	{
		return "\n\nxMin: " + mapAreaX_min + "\nxMax: " + mapAreaX_max + "\n\nyMin: " + mapAreaY_min + "\nyMax: "
				+ mapAreaY_max + "\n";
	}

	public void printMapAreaCordsInfo()
	{
		Console.WriteLine(getMapAreaCordsInfo());
	}

	public static void main(String[] args)
	{
		// MapArea US_forest;

		// US_forest.makeMap1();

	}

	public String getMapAreaInfo()
	{
		return "Area: " + this.areaName + "\nEntities in the area: " + this.numOfEntitiesOnArea + "\nArea elevation: "
				+ this.areaElevation + "\n";
	}

	public void printMapAreaInfo()
	{
		Console.WriteLine(getMapAreaInfo());
	}

	public void setEntityOnMapArea(Entity entity)
	{
		for (int i = 0; i < numOfEntitiesOnArea; i++)
		{
			if (entitiesOnArea[i] == null)
			{
				entitiesOnArea[i] = entity;
			}
		}

	}

}


}
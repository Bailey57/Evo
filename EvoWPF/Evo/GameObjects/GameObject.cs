using Evo.GameObjects.HitBoxes;
using System;


//namespace WaistlandGameWPF.WastelandGame
//package wasteland;

//import java.io.Serializable;

//using Wasteland.entity.Entity;
//using Wasteland.entity.Hitbox;
//using Wasteland.entity.Material;
//using Wasteland.map.GameObjectPos;
namespace Evo
{
    [System.Serializable]
	public class GameObject{
	// add density or hardness or make material class
	//
	// 40in 8ft
	// mele: 40in, 1m
	// spear: 8ft, 2.5m

	/**
	 * 
	 */
	//private static final long serialVersionUID = 1L;

/**
 * Object Index
 */
public int gameObjectIndexNumber;

/**
 * Hitbox of the GameObject
 */
public Hitbox gameObjectHitbox;

/**
 * The position of the GameObject on the map
 */
public GameObjectPos gameObjectPos;

/**
 * Once integrity falls below 0, the objects breaks down into its basicMaterial
 */
public double integraty = 100; // once it reaches 0, it is destroyed and breaks down into materials

/**
 * Name of the object
 */
public String objectName = "unnamed object";

/**
 * An objects mass in Kilograms
 */
public double massInKg = 0;// mass in Kilograms

/**
 * Objects y/height size in meters
 */
public double heightY = 0;
/**
 * Objects x/length size in meters
 */
public double lengthX = 0;
/**
 * Objects z/width size in meters
 */
public double widthZ = 0;

/**
 * The basic material the object is made of.
 * Used to calculate damage when Hitbox is null. 
 */
public Material baseMaterial;

/**
 * If the object is spotted by something
 */
bool spotted = false;

double directionInDegrees = 0;

double camouflage = 0;
double cover = 0;

        public String directionFacing;


String objectDescription = "An object";

String objectStringEvents = "";

public GameObject(GameObjectPos gameObjectPos, String objectName)
{
	
	this.gameObjectPos = gameObjectPos;
	this.objectName = objectName;
	this.gameObjectPos = gameObjectPos;
	// gameObjectPos.setGameObject(this);

	if (gameObjectPos != null && gameObjectPos.getCurrentMap() != null)
	{
		gameObjectPos.setGameObject(this);
		gameObjectPos.getCurrentMap().addGameObjectToMapList(this);
	}

}

public GameObject(GameObjectPos gameObjectPos, String objectName, Hitbox gameObjectHitbox)
{
	
	this.gameObjectPos = gameObjectPos;
	this.objectName = objectName;
	this.gameObjectHitbox = gameObjectHitbox;
	this.gameObjectPos = gameObjectPos;
	// gameObjectPos.setGameObject(this);
	gameObjectPos.getCurrentMap().addGameObjectToMapList(this);

}

/**
 * @return the GameObjectPos
 */
public GameObjectPos getGameObjectPos()
{
	return gameObjectPos;
}

/**
 * @param GameObjectPos the GameObjectPos to set
 */
public void setGameObjectPos(GameObjectPos gameObjectPos)
{
	this.gameObjectPos = gameObjectPos;
}

/**
 * @return the integraty
 */
public double getIntegraty()
{
	return integraty;
}

/**
 * @param integraty the integraty to set
 */
public void setIntegraty(double integraty)
{
	this.integraty = integraty;
}

/**
 * @return the objectName
 */
public String getObjectName()
{
	return objectName;
}

/**
 * @param objectName the objectName to set
 */
public void setObjectName(String objectName)
{
	this.objectName = objectName;
}

/**
 * @return the heightY
 */
public double getHeightY()
{
	return heightY;
}

/**
 * @param heightY the heightY to set
 */
public void setHeightY(double heightY)
{
	this.heightY = heightY;
}

/**
 * @return the lengthX
 */
public double getLengthX()
{
	return lengthX;
}

/**
 * @param lengthX the lengthX to set
 */
public void setLengthX(double lengthX)
{
	this.lengthX = lengthX;
}

/**
 * @return the widthZ
 */
public double getWidthZ()
{
	return widthZ;
}

/**
 * @param widthZ the widthZ to set
 */
public void setWidthZ(double widthZ)
{
	this.widthZ = widthZ;
}

/**
 * @return the mass
 */
public double getMassInKg()
{
	return massInKg;
}

/**
 * @param mass the mass to set
 */
public void setMassInKg(double mass)
{
	this.massInKg = mass;
}



/**
 * @return the gameObjectIndexNumber
 */
public int getGameObjectIndexNumber()
{
	return gameObjectIndexNumber;
}

/**
 * @param gameObjectIndexNumber the gameObjectIndexNumber to set
 */
public void setGameObjectIndexNumber(int gameObjectIndexNumber)
{
	this.gameObjectIndexNumber = gameObjectIndexNumber;
}

/**
 * @return the baseMaterial
 */
public Material getBaseMaterial()
{
	return baseMaterial;
}

/**
 * @param baseMaterial the baseMaterial to set
 */
public void setBaseMaterial(Material baseMaterial)
{
	this.baseMaterial = baseMaterial;
}

/**
 * @return the spotted
 */
public bool isSpotted()
{
	return spotted;
}

/**
 * @param spotted the spotted to set
 */
public void setSpotted(bool spotted)
{
	this.spotted = spotted;
}

/**
 * @return the objectDescription
 */
public String getObjectDescription()
{
	return objectDescription;
}

/**
 * @param objectDescription the objectDescription to set
 */
public void setObjectDescription(String objectDescription)
{
	this.objectDescription = objectDescription;
}

/**
 * @return the directionInDegrees
 */
public double getDirectionInDegrees()
{
	return directionInDegrees;
}

/**
 * @param directionInDegrees the directionInDegrees to set
 */
public void setDirectionInDegrees(double directionInDegrees)
{
	this.directionInDegrees = directionInDegrees;
}





/**
 * @return the camouflage
 */
public double getCamouflage()
{
	return camouflage;
}

/**
 * @param camouflage the camouflage to set
 */
public void setCamouflage(double camouflage)
{
	this.camouflage = camouflage;
}

/**
 * @return the cover
 */
public double getCover()
{
	return cover;
}

/**
 * @param cover the cover to set
 */
public void setCover(double cover)
{
	this.cover = cover;
}

/**
 * @return the objectStringEvents
 */
public String getObjectStringEvents()
{
	return objectStringEvents;
}

/**
 * @param objectStringEvents the objectStringEvents to set
 */
public void setObjectStringEvents(String objectStringEvents)
{
	this.objectStringEvents = objectStringEvents;
}

/**
 * @param adds string to objectStringEvents 
 */
public void addObjectStringEvents(String objectStringEvents)
{
	this.objectStringEvents += "\n" + objectStringEvents;
}


// think of better name
public bool integrityCheck()
{

	if (this.integraty > 0)
	{
		return true;
	}
	else
	{
		return false;
	}

}

/**
 * @return the gameObjectHitbox
 */
public Hitbox getGameObjectHitbox()
{
	return gameObjectHitbox;
}

/**
 * @param gameObjectHitbox the gameObjectHitbox to set
 */
public void setGameObjectHitbox(Hitbox gameObjectHitbox)
{
	this.gameObjectHitbox = gameObjectHitbox;
}


        public void setDirectionFacing(String directionFacing)
        {
            this.directionFacing = directionFacing;
        }

        public String getDirectionFacing()
        {
            return this.directionFacing;
        }

		//	public GameObject(GameObjectPos gameObjectPos, int integraty, String objectName, double mass, double xSize, double ySize,
		//			double zSize) {
		//		super();
		//		this.gameObjectPos = gameObjectPos;
		//		this.integraty = integraty;
		//		this.objectName = objectName;
		//		this.mass = mass;
		//		this.xSize = xSize;
		//		this.ySize = ySize;
		//		this.zSize = zSize;
		//	}


		

		public double getDistanceFromObject(GameObject gameObject)
{
	double distance = 0;

			//		distance = Math.abs(entity.getGameObjectPos().getMapAreaXPos() - getGameObjectPos().getMapAreaXPos());
			//		distance += Math.abs(entity.getGameObjectPos().getMapAreaYPos() - getGameObjectPos().getMapAreaYPos());
			//
			//		Math.pow(entity.getGameObjectPos().getMapAreaXPos() - getGameObjectPos().getMapAreaXPos(), 2);
			//		Math.pow(entity.getGameObjectPos().getMapAreaYPos() - getGameObjectPos().getMapAreaYPos(), 2);
			if (gameObject == null) 
			{
				return -1;
			}
	distance = Math.Sqrt(
			Math.Pow(gameObject.getGameObjectPos().getMapAreaXPos() - getGameObjectPos().getMapAreaXPos(), 2) + Math
					.Pow(gameObject.getGameObjectPos().getMapAreaYPos() - getGameObjectPos().getMapAreaYPos(), 2));

	return distance;
}



public double GetDistanceFromPointOfInterest(PointOfInterest pointOfInterest)
{
	double distance = 0;

	//		distance = Math.abs(entity.getGameObjectPos().getMapAreaXPos() - getGameObjectPos().getMapAreaXPos());
	//		distance += Math.abs(entity.getGameObjectPos().getMapAreaYPos() - getGameObjectPos().getMapAreaYPos());
	//
	//		Math.pow(entity.getGameObjectPos().getMapAreaXPos() - getGameObjectPos().getMapAreaXPos(), 2);
	//		Math.pow(entity.getGameObjectPos().getMapAreaYPos() - getGameObjectPos().getMapAreaYPos(), 2);

	distance = Math.Sqrt(
			Math.Pow(pointOfInterest.GetGameObjectPos().getMapAreaXPos() - getGameObjectPos().getMapAreaXPos(), 2) + Math
					.Pow(pointOfInterest.GetGameObjectPos().getMapAreaYPos() - getGameObjectPos().getMapAreaYPos(), 2));

	return distance;
}
        //	public Material breakDownObject() {
        //		this.
        //		this.getMassInKg();
        //		
        //		
        //		return 
        //	}


        public override string ToString()
        {
	String output = objectName;

	return output;
	}

}
}
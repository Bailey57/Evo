using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wasteland_game
{
	/*
    package wasteland.entity;

using Wasteland.GameObject;
using Wasteland.calculator.BulletPenetration;
using Wasteland.calculator.RandomNumbers;
using Wasteland.items.Armor;
using Wasteland.items.ProjectileAmmo;
*/
public class Hitbox {

	// heavy/light bleed
	// heavy: 6.4L per min
	// light: 10 to 500ml per min
	// presser on bleeding
	// bandages
	//

	// brain

	// heart

	// llung
	// rlung

	// lEye
	// rEye

	// lArm
	// rArm

	// lHand
	// rHand

	// lLeg
	// rLeg

	// lFoot
	// rFoot

	// scale:

	private double xMinLocation;
	private double xMaxLocation;

	private double yMinLocation;
	private double yMaxLocation;
	
	private double zMinLocation;
	private double zMaxLocation;

	public BodyPart[] bodyParts;

	public double centerOfMassX;
	public double centerOfMassY;
	//public double centerOfMassZ;
	
	public Armor[] armorOnHitbox;
	

	public Hitbox() {
		// setHitbox(new Material[0][3][]);
	}

//	public Hitbox(int xStze, int ySize) {
//		
//	}

//	public Hitbox(double xStze, double ySize, double zSize) {
//		//hitbox = new Material[xStze][ySize][zSize];
//	}

	/**
	 * Size in mm
	 * 
	 * @param xMinLocation
	 * @param xMaxLocation
	 * @param yMinLocation
	 * @param yMaxLocation
	 */
	public Hitbox(double xMinLocation, double xMaxLocation, double yMinLocation, double yMaxLocation) {
		this.xMinLocation = xMinLocation;
		this.xMaxLocation = xMaxLocation;
		this.yMinLocation = yMinLocation;
		this.yMaxLocation = yMaxLocation;
	}

//	public void DamageHitBoxHuman(Entity human, double y) {
//
//		
//	}

	
	
	/**
	 * @return the xMinLocation
	 */
	public double getxMinLocation() {
		return xMinLocation;
	}

	public Hitbox(double xMinLocation, double xMaxLocation, double yMinLocation, double yMaxLocation, double zMinLocation,
		double zMaxLocation) {
	this.xMinLocation = xMinLocation;
	this.xMaxLocation = xMaxLocation;
	this.yMinLocation = yMinLocation;
	this.yMaxLocation = yMaxLocation;
	this.zMinLocation = zMinLocation;
	this.zMaxLocation = zMaxLocation;
}

	/**
	 * @param xMinLocation the xMinLocation to set
	 */
	public void setxMinLocation(double xMinLocation) {
		this.xMinLocation = xMinLocation;
	}

	/**
	 * @return the xMaxLocation
	 */
	public double getxMaxLocation() {
		return xMaxLocation;
	}

	/**
	 * @param xMaxLocation the xMaxLocation to set
	 */
	public void setxMaxLocation(double xMaxLocation) {
		this.xMaxLocation = xMaxLocation;
	}

	/**
	 * @return the yMinLocation
	 */
	public double getyMinLocation() {
		return yMinLocation;
	}

	/**
	 * @param yMinLocation the yMinLocation to set
	 */
	public void setyMinLocation(double yMinLocation) {
		this.yMinLocation = yMinLocation;
	}

	/**
	 * @return the yMaxLocation
	 */
	public double getyMaxLocation() {
		return yMaxLocation;
	}

	/**
	 * @param yMaxLocation the yMaxLocation to set
	 */
	public void setyMaxLocation(double yMaxLocation) {
		this.yMaxLocation = yMaxLocation;
	}
	
	

	/**
	 * @return the zMinLocation
	 */
	public double getzMinLocation() {
		return zMinLocation;
	}

	/**
	 * @param zMinLocation the zMinLocation to set
	 */
	public void setzMinLocation(double zMinLocation) {
		this.zMinLocation = zMinLocation;
	}

	/**
	 * @return the zMaxLocation
	 */
	public double getzMaxLocation() {
		return zMaxLocation;
	}

	/**
	 * @param zMaxLocation the zMaxLocation to set
	 */
	public void setzMaxLocation(double zMaxLocation) {
		this.zMaxLocation = zMaxLocation;
	}

	/**
	 * @return the bodyParts
	 */
	public BodyPart[] getBodyParts() {
		return bodyParts;
	}

	/**
	 * @param bodyParts the bodyParts to set
	 */
	public void setBodyParts(BodyPart[] bodyParts) {
		this.bodyParts = bodyParts;
	}

	/**
	 * @param bodyParts the bodyParts to set
	 */
	public void addBodyPart(BodyPart bodyPart) {
		if (bodyParts == null) {
			bodyParts = new BodyPart[1];
		}
		for (int i = 0; i <= bodyParts.GetLength(0); i++) {
			
			if (i == bodyParts.GetLength(0)) {
				increaseBodyParts();
				if (bodyParts[i] == null || bodyParts[i] == bodyPart) {
					bodyParts[i] = bodyPart;
					break;
				}

			} else if (bodyParts[i] == null || bodyParts[i] == bodyPart) {
				bodyParts[i] = bodyPart;
				break;
			} 

		}

	}

	/**
	 * @param bodyParts the bodyParts to remove
	 */
	private void removeBodyPart(BodyPart bodyPart) {
		if (bodyParts == null) {
			return;
		}
		for (int i = 0; i < bodyParts.GetLength(0); i++) {

			if (bodyParts[i] == bodyPart) {
				bodyParts[i] = null;
				break;
			}
		}
	}

	/**
	 * @param bodyParts the bodyParts to set
	 */
	private void increaseBodyParts() {
		BodyPart[] bodyParts2 = new BodyPart[bodyParts.GetLength(0) * 2];
		for (int i = 0; i < bodyParts.GetLength(0); i++) {
			bodyParts2[i] = this.bodyParts[i];

		}

		this.bodyParts = bodyParts2;
	}

	public void addProsteticBodyPart() {

	}

	public double getHitboxHeightY() {
		return this.getyMaxLocation() - this.getyMinLocation();
	}

	public double getHitboxLengthX() {
		return this.getxMaxLocation() - this.getxMinLocation();
	}

	public double getHitboxWidthZ() {
		return -1;
	}
	
	public double getHitboxCenterX() {
		return (this.getxMaxLocation() + this.getxMinLocation()) / 2;
	}
	
	public double getHitboxCenterY() {
		return (this.getyMaxLocation() + this.getyMinLocation()) / 2;
	}
	
	public double getHitboxCenterZ() {
		return (this.getzMaxLocation() + this.getzMinLocation()) / 2;
	}
	

	public void damageHitbox() {

	}

	/**
	 * q= quadrants to make graphing more accurate
	 * 
	 * By Grid:
	 * 
	 * 
	 * y47~50, x-1~3.5 heart
	 * 
	 * y36~42, x-4~4 Intestines
	 * 
	 * y36~55 x-5~5 torso y58~65 x-4~4 head y30~54 x-6~-11 rArm y0~36 x-1~-5 rLeg
	 * 
	 * 
	 * center of mass: y45, x0
	 * 
	 * 
	 * By mm: y72.0~130.0 x-10.0~10.0 Torso
	 * 
	 * y0~1750 x-347.5~347.5 humanBodyBasic mm
	 * 
	 * y133.8~144.1 x-2.6~3.9 Heart1
	 * 
	 * 
	 * 
	 * 
	 **/

	public GameObject takeBodyPartOff(GameObject bodyPartOwner, BodyPart bodyPart) {
		GameObject bodyPartObject = new GameObject(bodyPartOwner.getGameObjectPos(), bodyPart.getName());

		double length = Math.Abs(bodyPart.getxMaxLocation()) - Math.Abs(bodyPart.getxMinLocation());
		double height = Math.Abs(bodyPart.getyMaxLocation()) - Math.Abs(bodyPart.getyMinLocation());

		bodyPartObject.setHeightY(height);
		bodyPartObject.setLengthX(length);
		bodyPartObject.setWidthZ(.2);
		removeBodyPart(bodyPart);
		return bodyPartObject;
	}
	
	
	
	
	/**
	 * @param bodyParts the bodyParts to set
	 */
	public void addArmorToHitbox(Armor armor) {
		if (armorOnHitbox == null) {
			armorOnHitbox = new Armor[1];
		}
		for (int i = 0; i <= armorOnHitbox.GetLength(0); i++) {
			
			if (i == armorOnHitbox.GetLength(0)) {
				increaseArmorOnHitbox();
				if (armorOnHitbox[i] == null || armorOnHitbox[i] == armor) {
					armorOnHitbox[i] = armor;
					break;
				}

			} else if (armorOnHitbox[i] == null || armorOnHitbox[i] == armor) {
				armorOnHitbox[i] = armor;
				break;
			} 
			
		}

	}
	

	
	private void increaseArmorOnHitbox() {
		Armor[] armor2 = new Armor[armorOnHitbox.GetLength(0) * 2];
		for (int i = 0; i < armorOnHitbox.GetLength(0); i++) {
			armor2[i] = this.armorOnHitbox[i];

		}
	
	}
	
	
	private void removeArmorOnHitbox(Armor armor) {
		if (armorOnHitbox == null) {
			return;
		}
		for (int i = 0; i < armorOnHitbox.GetLength(0); i++) {

			if (armorOnHitbox[i] == armor) {
				armorOnHitbox[i] = null;
				break;
			}
		}
	}
	
	
	public void removeAndDeleteAllArmorOnHitbox() {
		if (armorOnHitbox == null) {
			return;
		}
		for (int i = 0; i < armorOnHitbox.GetLength(0); i++) {
				armorOnHitbox[i] = null;
				
			
		}
	}
	
	public void takeArmorOff(Armor armor) {
		//set new location for Armor if dropping
		removeArmorOnHitbox(armor);
	}
	

	public Hitbox newHumanHitbox() {
		Hitbox humanHitBox = new Hitbox(-347.5, 347.5, 0, 1750);
		
		Material material = new Material();
		
		
		
		//humanMuscle = humanMuscle.humanMuscle;
		
		//Material humanMuscle = new Material();
		
		// y0~1750 x-347.5~347.5 humanBodyBasic
		// y121~128.7 x-2.6~9 heart
		
		//sternum : 11mm thick 

//		BodyPart brain = new BodyPart();
//		, -1, -1
		
		//
		
		//maybe add skull, brain, eyes 
		//man skull: 6.5mm, woman skull: 7.1mm
		MaterialLayer skullLayer = new MaterialLayer(material.getHumanBone(), 6.5, 44.742);//44.742 joules to fracture skull (14.1j to 68.5j)
		BodyPart skull = new BodyPart("Skull", -78.22, 78.22, 1514.015, 1726.136, 4, 4);
		skull.addMaterialLayer(skullLayer);
		humanHitBox.addBodyPart(skull);
		
		
		
		//1300 to 1400 grams
		//150 mm long
		MaterialLayer brainLayer = new MaterialLayer(material.getHumanMuscle(), 150, 10);//
		BodyPart brain = new BodyPart("Brain", -63.6364, 63.6364, 1585.606, 1710.2273, 0, 0);
		brain.addMaterialLayer(brainLayer);
		brain.setVital(true);
		humanHitBox.addBodyPart(brain);
		
		
		
		
		//possible add rand thickness between 4 and 15mm
		MaterialLayer sternumLayer = new MaterialLayer(material.getHumanBone(), 11, 100);
		BodyPart sternum = new BodyPart("Sternum", -21.212, 21.212, 1232.955, 1430.492, 4, 4);
		sternum.addMaterialLayer(sternumLayer);
		humanHitBox.addBodyPart(sternum);
		
		
		MaterialLayer chestLayer = new MaterialLayer(material.getHumanFlesh(), 50, 100);
		BodyPart chest = new BodyPart("Chest", -1696.97, 1696.97, 901.515, 1458.3333, 4, 4);
		chest.addMaterialLayer(chestLayer);
		humanHitBox.addBodyPart(chest);
		
		//needs adjustment, too big
		MaterialLayer heartLayer = new MaterialLayer(material.getHumanMuscle(), 60, 10);
		BodyPart heart = new BodyPart("Heart", -31.8182, 92.803, 1203.788, 1297.9167, 0, 0);
		heart.addMaterialLayer(heartLayer);
		heart.setVital(true);
		humanHitBox.addBodyPart(heart);
		
		
		
		
		
		
		MaterialLayer eyeMaterial  = new MaterialLayer(material.getHumanFlesh(), 22, 10);
		BodyPart leye = new BodyPart("Left eye", 49.053, 22.538, 1618.75, 1643.939, 2, 2);
		leye.addMaterialLayer(eyeMaterial);
		humanHitBox.addBodyPart(leye);
		BodyPart reye = new BodyPart("Rignt eye", -49.053, -22.538, 1618.75, 1643.939, 2, 2);
		reye.addMaterialLayer(eyeMaterial);
		humanHitBox.addBodyPart(reye);
		
		
		
		
		
		
		MaterialLayer lungs  = new MaterialLayer(material.getHumanFlesh(), 8, 10);
		BodyPart llung = new BodyPart("Left lung", 0, 139.2045, 1239.583, 1425.189, 2, 2);
		llung.addMaterialLayer(lungs);
		humanHitBox.addBodyPart(llung);
		BodyPart rlung = new BodyPart("Right lung", -125.947, -19.8864, 1239.583, 1239.5833, 2, 2);
		rlung.addMaterialLayer(lungs);
		humanHitBox.addBodyPart(rlung);
		
		MaterialLayer intestinesMaterial  = new MaterialLayer(material.getHumanFlesh(), 16, 10);
		BodyPart intestines = new BodyPart("Intestines", -119.3182, 119.3182, 928.033, 1097.7273, 3, 3);
		intestines.addMaterialLayer(intestinesMaterial);
		humanHitBox.addBodyPart(intestines);
		
		
//
//		BodyPart lEye = new BodyPart();
//		BodyPart rEye = new BodyPart();
//
		MaterialLayer armMaterial  = new MaterialLayer(material.getHumanFlesh(), 70, 100);
		BodyPart lArm = new BodyPart("Left arm", 169.697, 271.7803, 689.394, 1405.303, 0, 0);
		lArm.addMaterialLayer(armMaterial);
		humanHitBox.addBodyPart(lArm);
		BodyPart rArm = new BodyPart("Right arm", -271.7803, -169.697, 689.394, 1405.303, 0, 0);
		rArm.addMaterialLayer(armMaterial);
		humanHitBox.addBodyPart(rArm);
//
//		
//		BodyPart lHand = new BodyPart();
//		BodyPart rHand = new BodyPart();
//
//		
		MaterialLayer legMaterial  = new MaterialLayer(material.getHumanFlesh(), 100, 100);
		BodyPart lLeg = new BodyPart("Left leg", 31.8182, 159.0909, 0, 901.515, 0, 0);
		lLeg.addMaterialLayer(legMaterial);
		humanHitBox.addBodyPart(lLeg);
		BodyPart rLeg = new BodyPart("Right leg", -159.0909, -31.8182, 0, 901.515, 0, 0);
		rLeg.addMaterialLayer(legMaterial);
		humanHitBox.addBodyPart(rLeg);
//
//		
//		BodyPart lFoot = new BodyPart();
//		BodyPart rFoot = new BodyPart();
		

		return humanHitBox;
	}

	public bool onHitboxCheck(double xPosOnHitbox, double yPosOnHitbox) {

		if (xPosOnHitbox <= xMaxLocation && xPosOnHitbox >= xMinLocation) {

			if (yPosOnHitbox <= yMaxLocation && yPosOnHitbox >= yMinLocation) {
				return true;

			}
		}
		return false;

	}

	/**
	 * Shows the bodyParts that are going to be hit when attacked at certain location
	 * @param xPosOnHitbox
	 * @param yPosOnHitbox
	 * @return
	 */
	public BodyPart[] bodyPartsHitCheck(double xPosOnHitbox, double yPosOnHitbox) {
		
		if (bodyParts == null) {
			return null;
		}
		BodyPart[] bodyParts_ = new BodyPart[bodyParts.GetLength(0)];

		for (int i = 0; i < bodyParts.GetLength(0); i++) {
			if (bodyParts[i] == null) {
				break;
			}
			
			if (xPosOnHitbox <= bodyParts[i].getxMaxLocation() && xPosOnHitbox >= bodyParts[i].getxMinLocation()) {

				if (yPosOnHitbox <= bodyParts[i].getyMaxLocation() && yPosOnHitbox >= bodyParts[i].getyMinLocation()) {
					bodyParts_[i] = bodyParts[i];

				}
			}
		}
		return bodyParts_;
	}
	
	
	
	public String bodyPartsHitCheckToString(double xPosOnHitbox, double yPosOnHitbox) {
		String output = "";
		
		BodyPart[] bodyParts = new BodyPart[0];
		bodyParts = bodyPartsHitCheck(xPosOnHitbox, yPosOnHitbox);
		
		for (int i = 0; i < bodyPartsHitCheck(xPosOnHitbox, yPosOnHitbox).GetLength(0); i++) {
			bodyParts[i] = bodyPartsHitCheck(xPosOnHitbox, yPosOnHitbox)[i];
			
			
			
		}
	
		if (bodyParts != null) {
			for (int i = 0; i < bodyParts.GetLength(0); i++) {
				if (bodyParts[i] != null) {
					
					output += bodyParts[i].getName();
					output += "\n";
					
				}				
				
			}
			
			
		} else {
			output = "No Body parts there";
		}
		
		
		return output;
	}
	
	
	
	public Armor[] armorHitCheck(double xPosOnHitbox, double yPosOnHitbox) {
		
		if (armorOnHitbox == null) {
			return null;
		}
		
		Armor[] armorHit = new Armor[armorOnHitbox.GetLength(0)];

		
		for (int i = 0; i < armorOnHitbox.GetLength(0); i++) {
			if (xPosOnHitbox <= armorOnHitbox[i].getxMaxCoverage() && xPosOnHitbox >= armorOnHitbox[i].getxMinCoverage()) {

				if (yPosOnHitbox <= armorOnHitbox[i].getyMaxCoverage() && yPosOnHitbox >= armorOnHitbox[i].getyMinCoverage()) {
					armorHit[i] = armorOnHitbox[i];

				}
			}
		}
		return armorHit;
	}
	
	public String armorHitCheckToString(double xPosOnHitbox, double yPosOnHitbox) {
		String output = "";
		
		Armor[] armor = new Armor[0];
		armor = armorHitCheck(xPosOnHitbox, yPosOnHitbox);
		if (armor == null) {
			return output;
		}
		
		for (int i = 0; i < armorHitCheck(xPosOnHitbox, yPosOnHitbox).GetLength(0); i++) {
			armor[i] = armorHitCheck(xPosOnHitbox, yPosOnHitbox)[i];
			
			
			
		}
	
		if (armor != null) {
			for (int i = 0; i < armor.GetLength(0); i++) {
				if (armor[i] != null) {
					
					output += armor[i].getObjectName();
					output += "\n";
					
				}				
				else {
					//output = "No armor there\n";
				}
				
			}
			
			
		} 
		
		
		return output;
	}
	


	/**
	 *  DO NOT USE
	 * @param projectile
	 * @param xPosOnHitbox
	 * @param yPosOnHitbox
	 * @return
	 */
	private void projectileImpactHitbox(ProjectileAmmo projectile, double xPosOnHitbox, double yPosOnHitbox) {
		
		
		
		if (bodyParts == null) {
			return;
		}
		BodyPart[] bodyParts_ = new BodyPart[bodyParts.GetLength(0)];
		
		if (armorOnHitbox != null) {
			
			for (int i = 0; i < armorOnHitbox.GetLength(0); i++) {
				if (xPosOnHitbox <= armorOnHitbox[i].getxMaxCoverage() && xPosOnHitbox >= armorOnHitbox[i].getxMinCoverage()) {

					if (yPosOnHitbox <= armorOnHitbox[i].getyMaxCoverage() && yPosOnHitbox >= armorOnHitbox[i].getyMinCoverage()) {
					
						
						
						//bodyParts_[i] = bodyParts[i];

					}
				}
			}
		}

		


		for (int i = 0; i < bodyParts.GetLength(0); i++) {
			if (xPosOnHitbox <= bodyParts[i].getxMaxLocation() && xPosOnHitbox >= bodyParts[i].getxMinLocation()) {

				if (yPosOnHitbox <= bodyParts[i].getyMaxLocation() && yPosOnHitbox >= bodyParts[i].getyMinLocation()) {
					//bodyParts[i]
					//projectile
					
					
					bodyParts_[i] = bodyParts[i];

				}
			}
		}
		
		
		
		
		
		return;
	}
	
	
	
//	public String projectileImpactHitboxToString() {
//		
//	}
	
	
	
	

	public static void main(String[] args) {
		Material materials = new Material();
		//BulletPenetration calcClass = new BulletPenetration();
		ProjectileAmmo sig_ = new ProjectileAmmo(null, "sig", 0.00745187, 9, 13, 335.4);
		sig_.setBaseMaterial(materials.getLead());
		BulletPenetration sig = new BulletPenetration("sig", 0.00745187, 9, 335.4, 0);
		sig.setProjectileAmmo(sig_);
		
		BulletPenetration sig1 = new BulletPenetration("sig", 0.00745187, 9, 335.4, 0);
		Console.WriteLine(sig1.toString2());
		
		sig1.kruppPenFormulaInput(335.4, 0.00745187, 2300, 9);
		
		sig1.kruppVelocity(0.00745187, sig1.kruppPenFormulaInput(335.4, 0.00745187, 2300, 9), 2300, 9);
		
		//double mass, double penetrationIn_mm, double velocity, double diameter
		sig1.kruppConstant(0.00745187, sig1.kruppPenFormulaInput(335.4, 0.00745187, 2300, 9), 335.4, 9);
		
		
		
		Console.WriteLine("Krupp mm of pen steel: " + sig1.kruppPenFormulaInput(335.4, 0.00745187, 2300, 9));
		Console.WriteLine("Krupp velocity steel: " + sig1.kruppVelocity(0.00745187, sig1.kruppPenFormulaInput(335.4, 0.00745187, 2300, 9), 2300, 9));
		Console.WriteLine("Krupp constant steel: " + sig1.kruppConstant(0.00745187, sig1.kruppPenFormulaInput(335.4, 0.00745187, 2300, 9), 335.4, 9));
		
		ProjectileAmmo federal_9mm_HST = new ProjectileAmmo(null, "federal_9mm_HST", 0.00803506, 9, 13, 335.4);
		federal_9mm_HST.setBaseMaterial(materials.getLead());
		BulletPenetration federal_9mm_HST_pen = new BulletPenetration("federal_9mm_HST", 0.00803506, 9, 335.4, 0);
		federal_9mm_HST_pen.setProjectileAmmo(federal_9mm_HST);
		
		Console.WriteLine("Krupp constant ballistic gell: " + sig1.kruppConstant(0.00745187, 464.82, 345.948, 9));
		
		Hitbox testHumanHitbox = new Hitbox();
		testHumanHitbox = testHumanHitbox.newHumanHitbox();
		Console.WriteLine(testHumanHitbox.getHitboxCenterX());
		Console.WriteLine(testHumanHitbox.getHitboxCenterY());
		Console.WriteLine(testHumanHitbox.getHitboxCenterZ());
		
		Armor testArmor = new Armor();
		testArmor = testArmor.genericArmorPlate_TESTING();
		testHumanHitbox.addArmorToHitbox(testArmor.randomArmor());
		

		
		
		
		
		//Console.WriteLine(testHumanHitbox.bodyPartsHitCheckToString(testHumanHitbox.getHitboxCenterX(), testHumanHitbox.getHitboxCenterY()));	
		//testHumanHitbox.bodyPartsHitCheckToString(testHumanHitbox.getHitboxCenterX(), testHumanHitbox.getHitboxCenterY());
	
		//Console.WriteLine(testHumanHitbox.bodyPartsHitCheckToString(testHumanHitbox.getHitboxCenterX(), 950));
		
		
		ProjectileAmmo ak_ = new ProjectileAmmo(null, "ak", 0.011, 9, 13, 335.4);
		
		BulletPenetration ak = new BulletPenetration("ak", 0.011, 7.62, 800, 40);
		
		
		ProjectileAmmo pelletGunAmmo = new ProjectileAmmo(null, "pelletGun", 0.00055, 4.5, 3, 335.4);
		
		BulletPenetration pelletGun = new BulletPenetration("pelletGun", 0.00055, 4.5, 292, 40);
		//BulletPenetration pelletGun = new BulletPenetration("pelletGun", 0.00055, 4.5, 292, 10.1346);
		
		//-347.5, 347.5, 0, 1750
		RandomNumbers rn = new RandomNumbers();
		
		double xMin = -347.5;
		double xMax = 347.5;
		double yMin = 0;
		double yMax = 1750;


		DateTime dt = DateTime.Now;
		long startTime = dt.Millisecond;

		RandomNumbers randNum = new RandomNumbers();
		double distance = 0;
		for (int i = 0; i < 10000; i++) {
			
			distance = randNum.rollRandInt(1000, 0);
			
			//sig = new BulletPenetration("sig", 0.00745187, 9, 335.4, 0);
			
			
			sig_ = new ProjectileAmmo(null, "sig", 0.00745187, 9, 13, 335.4);
			sig_.setBaseMaterial(materials.getLead());
			sig_.setCurrentV(335.4);
			sig = new BulletPenetration("sig", 0.00745187, 9, 335.4, distance);
			sig.setProjectileAmmo(sig_);
			
			

			
			ak_ = new ProjectileAmmo(null, "ak", 0.011, 7.62, 13, 800);
			ak_.setBaseMaterial(materials.getLead());
			ak_.setCurrentV(800);
			ak = new BulletPenetration("ak", 0.011, 7.62, 800, distance);
			ak.setProjectileAmmo(ak_);
			
			
			pelletGunAmmo = new ProjectileAmmo(null, "pelletGun", 0.000479512, 4.5, 3, 335.4);
			pelletGunAmmo.setBaseMaterial(materials.getLead());
			pelletGunAmmo.setCurrentV(292);
			pelletGun = new BulletPenetration("pelletGun", 0.000479512, 4.5, 292, distance);
			pelletGun.setProjectileAmmo(pelletGunAmmo);
			
			
			testHumanHitbox.removeAndDeleteAllArmorOnHitbox();

			testHumanHitbox.addArmorToHitbox(testArmor.randomArmor());
			
			
			
//			Hitbox testHumanHitbox2 = new Hitbox();
//			Armor testArmor2 = new Armor();
//			
//			testHumanHitbox2 = testHumanHitbox2.newHumanHitbox();
//			testArmor2 = testArmor2.genericArmorPlate_TESTING();
//			testHumanHitbox2.addArmorToHitbox(testArmor2);
			
			
			double randX_Cord = rn.rollRandDouble(xMax, xMin);
			double randY_Cord = rn.rollRandDouble(yMax, yMin);
			
			//randX_Cord = 0;
			//randY_Cord = 1205;
			
			
			//no print
			//testHumanHitbox.bodyPartsHitCheckToString(randX_Cord, randY_Cord);
			
			//print
			
			
			
			
			Console.Write("Test " + i + ":\n" + "Distance: " + distance + "m\n" + testHumanHitbox.armorHitCheckToString(randX_Cord, randY_Cord));
			Console.Write(testHumanHitbox.bodyPartsHitCheckToString(randX_Cord, randY_Cord) + "\n");
			
			
			
			Console.Write("\nSig: \n");
			Console.WriteLine("Final V: " + sig.finalVelocity());
			sig.penetraitHitBox(testHumanHitbox, randX_Cord, randY_Cord, 0);
			
			Console.Write("\nAk: \n");
			Console.WriteLine("Final V: " + ak.finalVelocity());
			ak.penetraitHitBox(testHumanHitbox, randX_Cord, randY_Cord, 0);
			
			Console.Write("\nPellet: \n");
			Console.WriteLine("Final V: " + pelletGun.finalVelocity());
			pelletGun.penetraitHitBox(testHumanHitbox, randX_Cord, randY_Cord, 0);
			
			
			
			
			
			Console.WriteLine("\n\n");
			
		}
		long endTime = (dt.Millisecond - startTime);
		Console.WriteLine("\nmil seconds: " + endTime + "\nseconds: " + endTime /1000);
		
		
		//testHumanHitbox.ge
		
		
		//testHumanHitbox.bodyPartsHitCheck();

	}

}

}

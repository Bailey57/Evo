
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//package wasteland.entity;

namespace Wasteland_game
{
	[System.Serializable]
	public class BodyPart {

	String name;
	private double xMinLocation;
	private double xMaxLocation;

	private double yMinLocation;
	private double yMaxLocation;

	private double zMinLocation;
	private double zMaxLocation;

	private BodyPart subPart;

	// brain

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
	
	/*
	 Damage types:
	 
	-blunt trauma (causes pain, loss of that body parts function)
	-puncture (body pierced, causes bleeding)
	-fracture (causes pain, loss of that body parts function)

	-brain damage(don't do what you intend to do, things aren't as they seem)
	*/
	
	
	/**
	 * lungs: 02 at half capacity limmited movement
	 * 
	 * heart: massive bleeding (25% to not bleed super bad (make % more accurate))
	 * 
	 * any other body part: bleeding based on area of hole
	 * 
	 */
	bool punctured;//
	

	private double xCenter;
	private double yCenter;
	private double zCenter;

	double integrity = 100.0;
	Boolean functinal = true;

	MaterialLayer[] layers;
	
	double coveragePercent = 100;
	
	Wound[] wounds;
	
	bool vital = false;
	bool bleedable = true;
	
	// 6in
	// heart 50.8mm(2in) from ribs

	// 68 grid tall (image used as template)

	public BodyPart(String name, double xMinLocation, double xMaxLocation, double yMinLocation, double yMaxLocation,
			double zMinLocation, double zMaxLocation) {
		this.name = name;
		this.xMinLocation = xMinLocation;
		this.xMaxLocation = xMaxLocation;
		this.yMinLocation = yMinLocation;
		this.yMaxLocation = yMaxLocation;
		this.zMinLocation = zMinLocation;
		this.zMaxLocation = zMaxLocation;
		setCenterCords();
	}

//	public BodyPart(String name, double xMinLocation, double xMaxLocation, double yMinLocation, double yMaxLocation,
//			double xMinLocation2, double xMaxLocation2, double yMinLocation2, double yMaxLocation2) {
//		BodyPart subPart = new BodyPart(name, xMinLocation2, xMaxLocation2, yMinLocation2, yMaxLocation2);
//		this.name = name;
//		this.xMinLocation = xMinLocation;
//		this.xMaxLocation = xMaxLocation;
//		this.yMinLocation = yMinLocation;
//		this.yMaxLocation = yMaxLocation;
//		this.subPart = subPart;
//		setCenterCords();
//		subPart.setCenterCords();
//	}

	private void setCenterCords() {

		this.xCenter = (xMinLocation + xMaxLocation) / 2;

		this.yCenter = (yMinLocation + yMaxLocation) / 2;

		this.zCenter = (zMinLocation + zMaxLocation) / 2;
	}

	/**
	 * @return the xMinLocation
	 */
	public double getxMinLocation() {
		return xMinLocation;
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
	 * @return the subPart
	 */
	public BodyPart getSubPart() {
		return subPart;
	}

	/**
	 * @param subPart the subPart to set
	 */
	public void setSubPart(BodyPart subPart) {
		this.subPart = subPart;
	}

	/**
	 * @return the name
	 */
	public String getName() {
		return name;
	}

	/**
	 * @param name the name to set
	 */
	public void setName(String name) {
		this.name = name;
	}

	/**
	 * @return the doubleegrity
	 */
	public Double getIntegrity() {
		return integrity;
	}

	/**
	 * @param doubleegrity the doubleegrity to set
	 */
	public void setIntegrity(Double integrity) {
		this.integrity = integrity;
	}

	/**
	 * @return the functinal
	 */
	public Boolean getFunctinal() {
		return functinal;
	}

	/**
	 * @param functinal the functinal to set
	 */
	public void setFunctinal(Boolean functinal) {
		this.functinal = functinal;
	}

	/**
	 * @return the xCenter
	 */
	public double getxCenter() {
		return xCenter;
	}

	/**
	 * @param xCenter the xCenter to set
	 */
	public void setxCenter(double xCenter) {
		this.xCenter = xCenter;
	}

	/**
	 * @return the yCenter
	 */
	public double getyCenter() {
		return yCenter;
	}

	/**
	 * @param yCenter the yCenter to set
	 */
	public void setyCenter(double yCenter) {
		this.yCenter = yCenter;
	}

	/**
	 * @return the zCenter
	 */
	public double getzCenter() {
		return zCenter;
	}

	/**
	 * @param zCenter the zCenter to set
	 */
	public void setzCenter(double zCenter) {
		this.zCenter = zCenter;
	}

	/**
	 * @return the layers
	 */
	public MaterialLayer[] getLayers() {
		return layers;
	}

	/**
	 * @param layers the layers to set
	 */
	public void setLayers(MaterialLayer[] layers) {
		this.layers = layers;
	}
	
	
	

	/**
	 * @return the vital
	 */
	public bool isVital() {
		return vital;
	}

	/**
	 * @param vital the vital to set
	 */
	public void setVital(bool vital) {
		this.vital = vital;
	}
	
	

	/**
	 * @return the bleedable
	 */
	public bool isBleedable() {
		return bleedable;
	}

	/**
	 * @param bleedable the bleedable to set
	 */
	public void setBleedable(bool bleedable) {
		this.bleedable = bleedable;
	}

	/**
	 * @param bodyParts the bodyParts to set
	 */
	public void addMaterialLayer(MaterialLayer materialLayer) {
		if (layers == null) {
			layers = new MaterialLayer[1];
		}
		for (int i = 0; i < layers.GetLength(0); i++) {

			if (layers[i] == null || layers[i] == materialLayer) {
				layers[i] = materialLayer;
				break;
			} else if (i - 1 == layers.GetLength(0)) {
				increaseMaterialLayers();

			}

		}

	}

	/**
	 * @param bodyParts the bodyParts to set
	 */
	private void increaseMaterialLayers() {
		MaterialLayer[] layers2 = new MaterialLayer[layers.GetLength(0) * 2];
		for (int i = 0; i < layers.GetLength(0); i++) {
			layers2[i] = this.layers[i];

		}

		this.layers = layers2;
	}

	/**
	 * @return the punctured
	 */
	public bool isPunctured() {
		return punctured;
	}

	/**
	 * @param punctured the punctured to set
	 */
	public void setPunctured(bool punctured) {
		this.punctured = punctured;
	}



	

	/**
	 * @return the coveragePercent
	 */
	public double getCoveragePercent() { 
		return coveragePercent;
	}

	/**
	 * @param coveragePercent the coveragePercent to set
	 */
	public void setCoveragePercent(double coveragePercent) {
		this.coveragePercent = coveragePercent;
	}

	/**
	 * @return the wounds
	 */
	public Wound[] getWounds() {
		return wounds;
	}

	/**
	 * @param wounds the wounds to set
	 */
	public void setWounds(Wound[] wounds) {
		this.wounds = wounds;
	}

	/**
	 * Adds a wound to the BodyPart
	 * @param wound
	 * 
	 */
	public void addWound(Wound wound) {
		if (wounds == null) {
			wounds = new Wound[1];
		}
		for (int i = 0; i < wounds.GetLength(0); i++) {

			if (wounds[i] == null || wounds[i] == wound) {
				wounds[i] = wound;
				break;
			} else if (i - 1 == wounds.GetLength(0)) {
				increaseWoundAmmount();

			}

		}

	}

	/**
	 * 
	 */
	private void increaseWoundAmmount() {
		Wound[] layers2 = new Wound[wounds.GetLength(0) * 2];
		for (int i = 0; i < wounds.GetLength(0); i++) {
			layers2[i] = this.wounds[i];

		}

		this.wounds = layers2;
	}
	
	/**
	 * 
	 * @param wound
	 * @return true if wound was removed
	 */
	public bool removeWound(Wound wound) {
		bool removed = false;
		if (wounds == null) {
			wounds = new Wound[1];
		}
		for (int i = 0; i < wounds.GetLength(0); i++) {

			if (wounds[i] == wound) {
				wounds[i] = null;
				removed = true;
			} 

		}
		sortWoundAmmount();
		return removed;

	}
	
	/**
	 * sorts wounds array
	 */
	private void sortWoundAmmount() {
		Wound[] layers2 = new Wound[wounds.GetLength(0)];
		for (int i = 0; i < wounds.GetLength(0); i++) {
			if (wounds[i] != null) {
				layers2[i] = this.wounds[i];
			}
			

		}

		this.wounds = layers2;
	}
	
//	public void healWound() {
//		this.getWounds()[0].setLength(coveragePercent);
//		
//		
//		
//		
//		for (int i = 0; i < wounded.bodyParts.GetLength(0); i++) {
//			if (wounded.bodyParts[i] == bodyPart) {
//				wounded.bodyParts[i].removeWound(wound);
//			}
//			
//		}		
//	}

	public double bleedingAmmount() {
		
		return 0.0;
	}
	

}
}
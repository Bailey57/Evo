using System;
using System.Diagnostics;

namespace WaistlandGameWPF {
public class BulletPenetration {

	public String name = "unnamed projectile";// _9_mm, _7_62_mm, _12_7_mm

	public String gunFiredFrom = "";

	private double mass; // mass of projectile in kg

	private double diameter; // radius of prijectile in mm

	private double initV; // initial v in m/s

	private double instantV; // instintanious velocity in m/s

	private double distance; // distance from target in meters

	private double densityOfAir;

	private double acceleration; // in m/s

	private double cd;  // coefficent of drag

	// private double currentV;

	public double finalV;

	public double finalKE;

	public ProjectileAmmo projectileAmmo;

	public BulletPenetration() {

	}

	public BulletPenetration(double mass, double diameter, double initV, double distance) {
		this.mass = mass;
		this.diameter = diameter;
		this.initV = initV;
		this.distance = distance;
		this.instantV = initV;
		this.finalV = initV;
	}

	public BulletPenetration(String name, double mass, double diameter, double initV, double distance) {
		this.name = name;
		this.mass = mass;
		this.diameter = diameter;
		this.initV = initV;
		this.distance = distance;
		this.instantV = initV;
		this.finalV = initV;
	}

	public BulletPenetration(ProjectileAmmo projectileAmmo, double distance) {
		this.projectileAmmo = projectileAmmo;
		this.mass = projectileAmmo.mass;
		this.diameter = projectileAmmo.diameter;
		this.initV = projectileAmmo.initV;
		this.instantV = initV;
		this.distance = distance;
		this.finalV = initV;
	}

	/**
	 * @return the gunFiredFrom
	 */
	public String getGunFiredFrom() {
		return gunFiredFrom;
	}

	/**
	 * @param gunFiredFrom the gunFiredFrom to set
	 */
	public void setGunFiredFrom(String gunFiredFrom) {
		this.gunFiredFrom = gunFiredFrom;
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

	public double getMass() {
		return this.mass;
	}

	public double getDiameter() {
		return this.diameter;
	}

	public double getInitV() {
		return this.initV;
	}

	public double getDistance() {
		return this.distance;
	}

	public double getArea() {
		double radius2 = (.5 * getDiameter());
		double area1 = (3.14 * (radius2 * radius2));
		return area1;
	}

	public void setMass(double mass) {
		this.mass = mass;
	}

	public void setDiameter(double diameter) {
		this.diameter = diameter;
	}

	public void setInitV(double initV) {
		this.initV = initV;
	}

	public void setDistance(double distance) {
		this.distance = distance;
	}

	public double currentKeneticEnergy() {
		return .5 * mass * (instantV * instantV);
	}

	public double initialKeneticEnergy() {
		return .5 * mass * (initV * initV);
	}
	
	

	/**
	 * @return the instantV
	 */
	public double getInstantV() {
		return instantV;
	}

	/**
	 * @param instantV the instantV to set
	 */
	public void setInstantV(double instantV) {
		this.instantV = instantV;
	}

	/**
	 * @return the densityOfAir
	 */
	public double getDensityOfAir() {
		return densityOfAir;
	}

	/**
	 * @param densityOfAir the densityOfAir to set
	 */
	public void setDensityOfAir(double densityOfAir) {
		this.densityOfAir = densityOfAir;
	}

	/**
	 * @return the acceleration
	 */
	public double getAcceleration() {
		return acceleration;
	}

	/**
	 * @param acceleration the acceleration to set
	 */
	public void setAcceleration(double acceleration) {
		this.acceleration = acceleration;
	}

	/**
	 * @return the cd
	 */
	public double getCd() {
		return cd;
	}

	/**
	 * @param cd the cd to set
	 */
	public void setCd(double cd) {
		this.cd = cd;
	}

	/**
	 * @return the finalV
	 */
	public double getFinalV() {
		return finalV;
	}

	/**
	 * @param finalV the finalV to set
	 */
	public void setFinalV(double finalV) {
		this.finalV = finalV;
	}

	/**
	 * @return the finalKE
	 */
	public double getFinalKE() {
		return finalKE;
	}

	/**
	 * @param finalKE the finalKE to set
	 */
	public void setFinalKE(double finalKE) {
		this.finalKE = finalKE;
	}

	/**
	 * @return the projectileAmmo
	 */
	public ProjectileAmmo getProjectileAmmo() {
		return projectileAmmo;
	}

	/**
	 * @param projectileAmmo the projectileAmmo to set
	 */
	public void setProjectileAmmo(ProjectileAmmo projectileAmmo) {
		this.projectileAmmo = projectileAmmo;
	}

	public double initialPenValue() {
		double energyOverArea = (.5 * getMass() * (getInitV() * getInitV())) / getArea();
		double penV = .262 * energyOverArea + 2.56;
		return penV;
	}

	/**
	 * Gets the final velocity of a projectile
	 * 
	 * @return finalV
	 */
	public double finalVelocity() {
		if (this.getDistance() <= 0) {
			return instantV;
		}
	
		double projectile_Mass = getMass();
    	double projectileRadius = getDiameter() / 2;
		double projAreaMeters = Math.PI * (projectileRadius * projectileRadius) / 1000000;
		double densityOfAir = 1.1891;
		//double instantV = getInstantV();
		double instantVcorrectTime = instantV * .001; //.001 sec
		double cd = .295;
		//double distance1 = getDistance();
		double drag;
		// double time;
		double acceleration = 0;
		
		double time = 0;
		
		
		while (distance > 0 && instantV >= 0) {

			
			drag = cd * densityOfAir * (.5 * (instantVcorrectTime * instantVcorrectTime)) * projAreaMeters;
			
			acceleration = drag / projectile_Mass;
			
			
			instantVcorrectTime = instantVcorrectTime - acceleration;
			instantV = instantVcorrectTime * 1000;
		
			
			
			distance -= instantVcorrectTime;
			time += .001;
			
			//Debug.WriteLine("Acceleration: " + acceleration);
			//Debug.WriteLine("InstantV: " + instantV);
			//Debug.WriteLine("Drag: " + drag);
			//Debug.WriteLine("Distance1: " + distance1 + "\n");
			
			
		}
		
		//Debug.WriteLine("Time: " + time);
		
		
		
		
		
		
		
//		
//		densityOfAir = 1.1891;
//		instantV = getInitV();
//		cd = .295;
//		double distance1 = getDistance();
//		double drag;
//		// double time;
//		acceleration = 0;
//		double finalV = 0;
//		while (distance1 > 0) {
//			drag = cd * densityOfAir * ((instantV * instantV) / 2) * (projAreaMeters * .000001);
//			acceleration = (getMass() - drag) / getMass();
//			instantV = instantV + (acceleration * .001);
//			distance1 -= (instantV * .001);
//			finalV = instantV;
//		}
		//this.finalV = instantV;
		return instantV;
	}
	
	
	/**
	 * Gets the velocity of a projectile after traveling for x meters
	 * 
	 * @return newVelocity
	 */
	public double velocityAfterTravelDistance(double metersTraveled) {
		densityOfAir = 1.1891;
		instantV = getInitV();
		cd = .295;
		double distance1 = getDistance();
		double drag;
		// double time;
		acceleration = 0;
		double finalV = 0;
		while (distance1 > 0) {
			drag = cd * densityOfAir * ((instantV * instantV) / 2) * (getArea() * .000001);
			
			
			
			
			acceleration = (getMass() - drag) / getMass();
			instantV = instantV + (acceleration * .001);
			distance1 -= (instantV * .001);
			finalV = instantV;
		}
		this.finalV = finalV;
		return finalV;
	}
	
	
	/**
	 * Gets the velocity of a projectile after traveling for x seconds
	 * 
	 * @return newVelocity
	 */
	public double velocityAfterTravelTime(double timeInSeconds) {

		
		densityOfAir = 1.1891;
		instantV = this.getInstantV();
		cd = .295;
		double flightTimeLeft = timeInSeconds;
		double distanceTraveled = 0;
		double drag;
		// double time;
		
		acceleration = 0;
		double finalV = 0;
		
		while (flightTimeLeft > 0) {
			drag = cd * densityOfAir * ((instantV * instantV) / 2) * (getArea() * .000001);
			acceleration = (getMass() - drag) / getMass();
			instantV = instantV + (acceleration * .001);
			//distance1 -= (instantV * .001);
			flightTimeLeft -= .001;
			finalV = instantV;
		}
		
		this.finalV = finalV;
		return finalV;
	}

	/**
	 * Gets the final pen value of a projectile in mm RHA
	 * 
	 * @return penValue
	 */
	public double finalPenValue() {
		double energyOverArea = (.5 * getMass() * (finalVelocity() * finalVelocity())) / getArea();
		double penV = .262 * energyOverArea + 2.56;
		return penV;

	}

	public double squishProjectile(double diameter) {

		return diameter / 0.70866141732283464566929133858268;

	}

	/**
	 * Krupp Armor Penetration Formula
	 * 
	 * returns armor penetration in mm of projectile
	 * 
	 * B = (V * Sqrt(P)) / (K * Sqrt(D))
	 * 
	 * B = thickness of armor penetrated in decimeters V = Velocity of projectile on
	 * impact (m/s) P = mass of projectile (kg) K = resistance constant (use 2400 by
	 * default) D = Projectile caliber (mm)
	 * 
	 * 
	 * 
	 * reference: http://www.tankarchives.ca/2014/10/penetration-equations.html
	 * 
	 * @return
	 */
	public double kruppPenFormula() {

		double B;
		double V = this.finalV;
		double P = mass;

		double K = 2400;
		double D = diameter;

		B = (V * Math.Sqrt(P)) / (K * Math.Sqrt(D));

		B = 1000 * B; // convert to mm

		return B;
	}

	/**
	 * Krupp Armor Penetration Formula
	 * 
	 * returns armor penetration in mm of projectile
	 * 
	 * B = (V * Sqrt(P)) / (K * Sqrt(D))
	 * 
	 * B = thickness of armor penetrated in decimeters V = Velocity of projectile on
	 * impact (m/s) P = mass of projectile (kg) K = resistance constant (use 2400 by
	 * default) D = Projectile caliber (mm)
	 * 
	 * 
	 * 
	 * reference: http://www.tankarchives.ca/2014/10/penetration-equations.html
	 * 
	 * @return
	 */
	public double kruppPenFormulaInput(double V, double P, double K, double D) {

		double B;

		B = (V * Math.Sqrt(P)) / (K * Math.Sqrt(D));

		B = (1000 * B); // convert to mm

		return B;
	}

	public double kruppConstant(double mass, double penetrationIn_mm, double velocity, double diameter) {

		double B = penetrationIn_mm;
		double V = velocity;
		double P = mass;

		double K;
		double D = diameter;

		// B = (V * Math.Sqrt(P)) / (K * Math.Sqrt(D));
		K = (V * Math.Sqrt(P)) / ((1000 * B) * Math.Sqrt(D));
		K *= 1000000;
		return K;
	}

	/**
	 * 
	 * @return velocuty of projectile with known penetration
	 */
	public double kruppVelocity(double mass, double penetrationIn_mm, double kruppConstant, double diameter) {
			
		double B = penetrationIn_mm;
		double V;
		double P = mass;

		double K = kruppConstant;
		double D = diameter;

		V = ((B) * Math.Sqrt(D) * K) / Math.Sqrt(P);
		V /= 1000;

		return V;
	}

	public double tilesBulletCanPen() {
		double x = currentKeneticEnergy();
		double y = getDiameter();

		double equation1_linear_with_zero = 0.00303 * x + 0.108;
		double equation2_linear = 0.0028925108 * x + 0.3223807447;

		double equation3_quadratic_with_zero = -0.0000006227983 * (x * x) + 0.003937912 * x;

		// 1271.4x\ +\ 7.62y\ =\ 4 407.13x\ +\ 9y\ =\ 1.5
		// (0.002946, 0.0334)
		double equation4_with_diameter = (x * 0.002946) + (y * 0.0334);

		// using equation from testing
		return equation4_with_diameter;
	}

	// maybe return bool
	public bool penetraiteBodyPart(BodyPart bodyPart) {
		bool penetraited = false;
		BodyPart bodyPartClone;
		MaterialLayer materialLayerClone;

		for (int i = 0; i < bodyPart.getLayers().GetLength(0); i++) {
			materialLayerClone = bodyPart.getLayers()[i];

		}

		return penetraited;
	}

	/**
	 * 
	 * @param materialLayer
	 * @return remaining velocity after pen
	 */
	public double penetraitMaterialLayer_postPenVelocity(MaterialLayer materialLayer) {
		double remainingPen;
		double remainingVelocity;
		if (materialLayer.getMaterial().getKruppConstant() != 0
				&& materialLayer.getMaterial().getKruppConstant() != -1) {
			double kruppConstant = materialLayer.getMaterial().getKruppConstant();

			remainingPen = kruppPenFormulaInput(this.finalVelocity(), mass, kruppConstant, diameter)
					- materialLayer.getThicknessIn_mm();

			remainingVelocity = this.kruppVelocity(mass, remainingPen, kruppConstant, diameter);
		} else {
			// neuton formula

			remainingVelocity = 0;

		}
		return remainingVelocity;

	}

	/**
	 * 
	 * @param materialLayer
	 * @return remaining velocity after pen
	 */
	public double penetraitMaterialLayer_mm(MaterialLayer materialLayer) {
		double remainingPen;
		double remainingVelocity;
		if (materialLayer.getMaterial().getKruppConstant() != 0
				&& materialLayer.getMaterial().getKruppConstant() != -1) {
			double kruppConstant = materialLayer.getMaterial().getKruppConstant();

			remainingPen = kruppPenFormulaInput(this.finalVelocity(), mass, kruppConstant, diameter)
					- materialLayer.getThicknessIn_mm();

			remainingVelocity = this.kruppVelocity(mass, remainingPen, kruppConstant, diameter);
		} else {
			// neuton formula

			remainingVelocity = 0;

		}

		return remainingVelocity;
	}

	/**
	 * 
	 */
	public double postPenVelocity(double penCapabilityIn_mm) {
		double remainingPen;
		double remainingVelocity = 0;
//			if (materialLayer.getMaterial().getKruppConstant() != 0 && materialLayer.getMaterial().getKruppConstant() != -1) {
//				double kruppConstant = materialLayer.getMaterial().getKruppConstant();
//
//
//				
//				remainingPen = kruppPenFormulaInput(this.finalVelocity(), mass, kruppConstant, diameter) 
//				- materialLayer.getThicknessIn_mm();
//				
//				remainingVelocity = this.kruppVelocity(mass, remainingPen, kruppConstant, diameter);
//			} else {
//				//neuton formula
//				
//				remainingVelocity = 0;
//				
//			}

		return remainingVelocity;

	}

	public double neutonsImpactDepth(MaterialLayer materialLayer) {
		// D=L * A/B
		double depth = this.getProjectileAmmo().getLength()
				* (this.getProjectileAmmo().getBaseMaterial().getDensity() / materialLayer.getMaterial().getDensity());

		return depth;
	}

	public double trySquashProjectile(ProjectileAmmo projectileAmmo, Material targetMaterial) {
		if (projectileAmmo == null || targetMaterial == null) {
			return -1;
		}

		double newDiameter = projectileAmmo.getDiameter();

//		
//		if (bodyPartHit == null || bodyPartHit.getLayers()[0].getMaterial() == null) {
//			return newDiameter;
//		}

		// 200 m/s squash threshold
		if (projectileAmmo.getBaseMaterial() == null || projectileAmmo.getCurrentV() <= 200) {
			return newDiameter;
		}

		if (projectileAmmo.getBaseMaterial().getBrinellHerdness() != 0 && targetMaterial.getBrinellHerdness() != 0
				&& projectileAmmo.getBaseMaterial().getBrinellHerdness() < targetMaterial.getBrinellHerdness()) {
			newDiameter = squashProjectile(projectileAmmo);
		} else if (projectileAmmo.getBaseMaterial().getVickersHardness() != 0
				&& targetMaterial.getVickersHardness() != 0
				&& projectileAmmo.getBaseMaterial().getVickersHardness() < targetMaterial.getVickersHardness()) {
			newDiameter = squashProjectile(projectileAmmo);
		} else if (projectileAmmo.getBaseMaterial().getDensity() < targetMaterial.getDensity()) {
			newDiameter = squashProjectile(projectileAmmo);

		}

		return newDiameter;
	}

	public double squashProjectile(ProjectileAmmo projectileAmmo) {
		double newDiameter = projectileAmmo.getDiameter() / 0.70866141732283464566929133858268;

		projectileAmmo.setDiameter(newDiameter);
		return newDiameter;

	}

	// add wounds later
	// add z functionality later
	// add percussion ie body parts behind take damage even if projectile is stopped
	public String penetraitHitBox(Hitbox hitbox, double projectileX, double projectileY, double projectileZ) {
		bool hitSomething = false;
		
		String output = "";
		double projectileVelocity = this.getFinalV();

		double layerThickness = 0;
		// double
		double mmOfArmorPierced = 0;
		double mmOfBodyPierced = 0;
		double kruppConstant = 0;

		double remainingPen = 0;
		;

		double pennetraitedLayers = 0;
		double mmPenetratedOverall = 0;

		// double diameter; //add when bullet deformation mechanic added

		if (hitbox.armorHitCheck(projectileX, projectileY) == null) {
			Debug.WriteLine("Target has no armor.\n");
			output += "\nTarget has no armor.\n";
		} else {
			double armorHitLength = hitbox.armorHitCheck(projectileX, projectileY).GetLength(0);

			// penetrait armor method

			for (int i = 0; i < armorHitLength; i++) {
				if (this.getFinalV() <= 0) {
					break;
				}

				if (hitbox.armorHitCheck(projectileX, projectileY)[i] == null) {
					// break;
				} else {

					hitbox.armorHitCheck(projectileX, projectileY)[i].getMaterial();

					// double layers = hitbox.armorHitCheck(projectileY,
					// projectileZ)[i].getLayers().length;

					// for (int k = 0; k < layers; k++) {
					kruppConstant = hitbox.armorHitCheck(projectileX, projectileY)[i].getMaterial().getKruppConstant();
					layerThickness = hitbox.armorHitCheck(projectileX, projectileY)[i].getThicknessIn_mm();
					mmOfArmorPierced = kruppPenFormulaInput(projectileVelocity, mass, kruppConstant, diameter);
					if (projectileVelocity > 60) {
						remainingPen = mmOfArmorPierced - layerThickness;

						pennetraitedLayers += 1;
					}

					trySquashProjectile(projectileAmmo,
							hitbox.armorHitCheck(projectileX, projectileY)[i].getMaterial());

					if (remainingPen <= 0 || projectileVelocity <= 60) {

						mmPenetratedOverall += mmOfArmorPierced;

						Debug.WriteLine("Projectile Stopped by: "
								+ hitbox.armorHitCheck(projectileX, projectileY)[i].getMaterial().getName() + "\n");
						output += "\n" + "Projectile Stopped by: "
								+ hitbox.armorHitCheck(projectileX, projectileY)[i].getMaterial().getName() + "\n";
						hitSomething = true;

						// apply wounds, set bullet position in body
						setFinalV(0);
						break;
					} else {
						mmPenetratedOverall += layerThickness;
						// calculate new velocity

						setFinalV(kruppVelocity(mass, remainingPen, kruppConstant, diameter));
						this.projectileAmmo.setCurrentV(this.getFinalV());
						projectileVelocity = this.getFinalV();
						Debug.WriteLine("New Projectile Velocity after penetrating "
								+ hitbox.armorHitCheck(projectileX, projectileY)[i].getMaterial().getName() + ": "
								+ kruppVelocity(mass, remainingPen, kruppConstant, diameter) + "\n");
						output += "\nNew Projectile Velocity after penetrating "
								+ hitbox.armorHitCheck(projectileX, projectileY)[i].getMaterial().getName() + ": "
								+ kruppVelocity(mass, remainingPen, kruppConstant, diameter) + "\n";
						hitSomething = true;
						// this.ve

					}

					// this.penetraitMaterialLayer(hitbox.bodyPartsHitCheck(projectileY,
					// projectileZ)[i].getLayers()[k]);
					// mmOfBodyPierced
					// projectileVelocity =
					// this.penetraitMaterialLayer(hitbox.bodyPartsHitCheck(projectileY,
					// projectileZ)[i].getLayers()[k]);
				}

			}

		}

		if (hitbox.bodyPartsHitCheck(projectileX, projectileY) == null) {
			Debug.WriteLine("Target has no body parts to hit.\n");
			output += "\nTarget has no body parts to hit.\n";
		} else {

			double bodyPartsHitLength = hitbox.bodyPartsHitCheck(projectileX, projectileY).GetLength(0);

			if (projectileX <= 21.212 && projectileX >= -21.212 && projectileY <= 1430.492 && projectileY >= 1232.955) {
				double wow;
			}

			// penetrait body part method v
			for (int i = 0; i < bodyPartsHitLength; i++) {
				if (this.getFinalV() <= 0) {
					break;
				}

				// neutonsImpactDepth
				if (hitbox.bodyPartsHitCheck(projectileX, projectileY)[i] == null
						|| hitbox.bodyPartsHitCheck(projectileX, projectileY)[i].getLayers() == null) {
					// break;
				} else {

					double layers = hitbox.bodyPartsHitCheck(projectileX, projectileY)[i].getLayers().GetLength(0);

					if (this.getFinalV() <= 0) {
						break;
					}
					for (int k = 0; k < layers; k++) {
						if (this.getFinalV() <= 0) {
							break;
						}

						if (hitbox.bodyPartsHitCheck(projectileX, projectileY)[i].getName().Equals("Sternum")) {
							bool found;
							found = true;
						}

						kruppConstant = hitbox.bodyPartsHitCheck(projectileX, projectileY)[i].getLayers()[k]
								.getMaterial().getKruppConstant();
						layerThickness = hitbox.bodyPartsHitCheck(projectileX, projectileY)[i].getLayers()[k]
								.getThicknessIn_mm();
						mmOfBodyPierced = kruppPenFormulaInput(projectileVelocity, mass, kruppConstant, diameter);
						
						
						//damage bodyParts
						double radius = getDiameter();
						Wound bulletWound = new Wound("bullet wound", mmOfBodyPierced, radius, radius, "");
						hitbox.bodyPartsHitCheck(projectileX, projectileY)[i].addWound(bulletWound);
						output += "\nwound added: " + bulletWound.getAndSetBleedRate() + "ml/sec\n";
						Debug.WriteLine("\nwound added\n"  + bulletWound.getAndSetBleedRate() + "ml/sec\n");
								
						

						remainingPen = mmOfBodyPierced - layerThickness;
						if (projectileVelocity > 60) {
							pennetraitedLayers += 1;
							if (hitbox.bodyPartsHitCheck(projectileX, projectileY)[i].isVital() == true) {
								output += "damaged vital organ, killed\n";
								
								Debug.WriteLine("damaged vital organ, killed\n");
							}
							projectileVelocity = this.getFinalV();
							
						}
						trySquashProjectile(projectileAmmo,
								hitbox.bodyPartsHitCheck(projectileX, projectileY)[i].getLayers()[k].getMaterial());

						if (remainingPen <= 0 || projectileVelocity <= 60) {
							mmPenetratedOverall += mmOfBodyPierced;
							Debug.WriteLine("Projectile Stopped by "
									+ hitbox.bodyPartsHitCheck(projectileX, projectileY)[i].getLayers()[k].getMaterial()
											.getName()
									+ "\n");
							hitSomething = true;
							setFinalV(0);
							// apply wounds, set bullet position in body
							break;
						} else {

							mmPenetratedOverall += layerThickness;

							// calculate new velocity
							setFinalV(kruppVelocity(mass, remainingPen, kruppConstant, diameter));
							this.projectileAmmo.setCurrentV(this.getFinalV());
							projectileVelocity = this.getFinalV();
							Debug.WriteLine("New Velocity after penetrating "
									+ hitbox.bodyPartsHitCheck(projectileX, projectileY)[i].getLayers()[k].getMaterial()
											.getName()
									+ ": " + kruppVelocity(mass, remainingPen, kruppConstant, diameter) + "\n");
							// this.ve
							output += "\nNew Velocity after penetrating "
									+ hitbox.bodyPartsHitCheck(projectileX, projectileY)[i].getLayers()[k].getMaterial()
											.getName()
									+ ": " + kruppVelocity(mass, remainingPen, kruppConstant, diameter) + "\n";
							hitSomething = true;
						}

						// this.penetraitMaterialLayer(hitbox.bodyPartsHitCheck(projectileY,
						// projectileZ)[i].getLayers()[k]);
						// mmOfBodyPierced
						// projectileVelocity =
						// this.penetraitMaterialLayer(hitbox.bodyPartsHitCheck(projectileY,
						// projectileZ)[i].getLayers()[k]);
					}

				}

			}
		}

		Debug.WriteLine(
				"Penetraited Layers: " + pennetraitedLayers + "\n" + "mm penetraited: " + mmPenetratedOverall + "\n");
		output += "\nPenetraited Layers: " + pennetraitedLayers + "\n" + "mm penetraited: " + mmPenetratedOverall
				+ "\n";
		if (!hitSomething) {
			Debug.WriteLine("Hit nothing\n");
			output += "\nHit nothing\n";
		}
		
		return output;
	}

//	public penetraitHitBoxToString() {
//		
//		
//		
//		
//		
//		
//		
//	}

	public String toString() {
		String output = "\n";

		if (name != null) {
			output += name;
		}

		output += "\nFinal pen value: " + finalPenValue() + "\nInitial KE " + initialKeneticEnergy() + "\nFinal KE: "
				+ currentKeneticEnergy() + "\nFinal velocity: " + finalVelocity();

		output += "\n";

		return output;
	}

	public String toString2() {
		String output = "\n";

		if (name != null) {
			output += name;
		}

		output += "\nFinal pen value: " + finalPenValue() + "\nInitial KE " + initialKeneticEnergy() + "\nFinal KE: "
				+ currentKeneticEnergy() + "\nFinal velocity: " + finalVelocity() + "\nTiles bullet can pen: "
				+ tilesBulletCanPen();

		output += "\n";

		return output;
	}

	public String toString3() {

		return String.Format(
				"Mass: %.4f kg \nDiameter: %.4f mm \nVelocity: %.4f m/s "
						+ "\nDistance from target: %.4f m \nArea of projectile:  %.4f mm^2 "
						+ "\nFinal Velocity: %.4f m/s^2 \nInitial pen value: %.4f mm " + "\nFinal pen value: %.4f mm ",
				getMass(), getDiameter(), getInitV(), getDistance(), getArea(), finalVelocity(), initialPenValue(),
				finalPenValue());
	}

//	public String toString3()
//	{
//	    
//	    return String.format("\nFinal Velocity: %.4f m/s^2 \nInitial pen value: %.4f mm "
//	    		+ "\nFinal pen value: %.4f mm \nPen value at 100m: %.4f mm \nPen value at 250m: %.4f mm \nPen value at 500m: %.4f mm", 
//	    		finalVelocity(), initialPenValue(), finalPenValue(), penValueAt100(), penValueAt250(), penValueAt500());
//	}

	public static void main(String[] args) {

		// penetraitHitBox

		BulletPenetration bp_class = new BulletPenetration();
		// 7.62

		// BulletPenetration FMJ_9mm = new BulletPenetration("FMJ_9mm", 0.00804, 9, 350,
		// 0);
		double B = 153;
		double V = 350;
		double P = 0.00804;

		double K = 2400;
		double D = 9;

		// B = (V * Math.Sqrt(P)) / (K * Math.Sqrt(D));
		K = (V * Math.Sqrt(P)) / (B * Math.Sqrt(D));

		B = 1000 * B; // convert to mm

		Debug.WriteLine("K: " + K);

		//
		B = 153;
		V = 350;
		P = 0.00804;
		D = 9;

		// B = (V * Math.Sqrt(P)) / (K * Math.Sqrt(D));
		K = (V * Math.Sqrt(P)) / (B * Math.Sqrt(D));

		B = 1000 * B; // convert to mm

		Debug.WriteLine("K2: " + K);

		B = 153;
		V = 30;// 350
		P = 0.00804;

		// double K = 2400;
		D = 9;
		B = (V * Math.Sqrt(P)) / (K * Math.Sqrt(D));
		Debug.WriteLine("B.1: " + B);

		// "calc 1", 0.011, 7.62, 800, 40);
		// B = 153;
		V = 800;
		P = 0.011;

		// double K = 2400;
		D = 7.62;
		B = (V * Math.Sqrt(P)) / (K * Math.Sqrt(D));
		Debug.WriteLine("B2: " + B);

		// "pelletGun", 0.00055, 4.5, 292, 10.1346);
		// B = 153;
		V = 292;
		P = 0.00055;

		// double K = 2400;
		D = 4.5;
		B = (V * Math.Sqrt(P)) / (K * Math.Sqrt(D));
		Debug.WriteLine("B3: " + B);

		// "slug12Gauge", 0.028349523, 18.53, 564, 200);
		// B = 153;
		V = 564;
		P = 0.028349523;

		// double K = 2400;
		D = 18.53;
		B = (V * Math.Sqrt(P)) / (K * Math.Sqrt(D));
		Debug.WriteLine("B4: " + B);

		// "M1 carbine", 0.007127885, 7.62, 604, 10.1346);
		// B = 153;
		V = 604;
		P = 0.007127885;

		// double K = 2400;
		D = 7.62;
		B = (V * Math.Sqrt(P)) / (K * Math.Sqrt(D));
		Debug.WriteLine("B5: " + B);

		V = 350;
		P = 0.00804;

		// K = 2400;
		D = 9;

		B = 1.5;
		K = (V * Math.Sqrt(P)) / (B * Math.Sqrt(D));

		Debug.WriteLine("K: " + K);

		// "calc 1", 0.011, 7.62, 800, 40);
		// B = 153;
		V = 800;
		P = 0.011;

		// double K = 2400;
		D = 7.62;
		B = (V * Math.Sqrt(P)) / (K * Math.Sqrt(D));
		Debug.WriteLine("B1_1: " + B);

		// 9mm
		V = 350;// 350
		P = 0.00804;

		// double K = 2400;
		D = 9;
		B = (V * Math.Sqrt(P)) / (K * Math.Sqrt(D));
		Debug.WriteLine("B2_1: " + B);

		// ("M1 carbine 200", 0.007127885, 7.62, 604, 200);
		V = 604;// 350
		P = 0.007127885;

		// double K = 2400;
		D = 7.62;
		B = (V * Math.Sqrt(P)) / (K * Math.Sqrt(D));
		Debug.WriteLine("B2_2: " + B);
		
		
		double travelDistance = 1;
		
		
		BulletPenetration _380ACP = new BulletPenetration("_380ACP", 0.0061559, 9, 300, 13.716);//13.716
		_380ACP.finalVelocity();
		Debug.WriteLine("pen: " + _380ACP.kruppPenFormula());
		Debug.WriteLine(_380ACP.toString2());
		
		
		BulletPenetration M855 = new BulletPenetration("M855", 0.00401753, 5.56, 944.88, travelDistance);
		M855.finalVelocity();
		Debug.WriteLine("pen: " + M855.kruppPenFormula());
		Debug.WriteLine(M855.toString2());
		
		BulletPenetration ak_762_standard = new BulletPenetration("ak_762_standard", 0.00797027, 7.62, 715.9752, travelDistance);
		ak_762_standard.finalVelocity();
		Debug.WriteLine("pen: " + ak_762_standard.kruppPenFormula());
		Debug.WriteLine(ak_762_standard.toString2());
		

		BulletPenetration FMJ_9mm = new BulletPenetration("FMJ_9mm", 0.00804, 9, 350, 0);
		Debug.WriteLine(FMJ_9mm.kruppPenFormula());
		Debug.WriteLine(FMJ_9mm.toString2());

		BulletPenetration calc1 = new BulletPenetration("calc 1", 0.011, 7.62, 800, 40);
		Debug.WriteLine(calc1.kruppPenFormula());
		Debug.WriteLine(calc1.toString2());

		BulletPenetration slug12Gauge = new BulletPenetration("slug12Gauge", 0.028349523, 18.53, 564, 200);
		Debug.WriteLine(slug12Gauge.toString2());

		BulletPenetration m1Carbine = new BulletPenetration("M1 carbine", 0.007127885, 7.62, 604, 10.1346);
		Debug.WriteLine(m1Carbine.toString2());

		BulletPenetration m1Carbine2 = new BulletPenetration("M1 carbine 200", 0.007127885, 7.62, 604, 200);
		Debug.WriteLine(m1Carbine2.toString2());

		BulletPenetration sig = new BulletPenetration("sig", 0.00745187, 9, 335.4, 10.1346);
		Debug.WriteLine("pen: " + sig.kruppPenFormula());
		Debug.WriteLine(sig.toString2());

		BulletPenetration sigAt60 = new BulletPenetration("sig at 60mps", 0.00745187, 9, 60, 10.1346);
		Debug.WriteLine(sigAt60.toString2());

		BulletPenetration sig2 = new BulletPenetration("sig 200", 0.00745187, 9, 335.4, 200);
		Debug.WriteLine(sig2.toString2());

		BulletPenetration pelletGun = new BulletPenetration("pelletGun", 0.00055, 4.5, 292, 10.1346);
		Debug.WriteLine(pelletGun.toString2());

		BulletPenetration M2HB_50cal = new BulletPenetration("M2HB_50cal", 0.04, 12.7, 929, 10.1346);
		Debug.WriteLine(M2HB_50cal.kruppPenFormula());
		Debug.WriteLine(M2HB_50cal.toString2());

		BulletPenetration M2HB_50cal_SLAP = new BulletPenetration("M2HB_50cal", 0.04, 7.7, 929, 500);

		Debug.WriteLine(M2HB_50cal_SLAP.toString2());
		Debug.WriteLine(M2HB_50cal_SLAP.kruppPenFormula());

		//Scanner scn = new Scanner(System.in); // Create a Scanner object
		Debug.WriteLine("Penetraition Calculator v2.1a \nmod: 2/24/2021 \n\n");

		Debug.WriteLine("Enter mass of projectile in kg: ");
		double mass = Convert.ToDouble(Console.ReadLine());

		Debug.WriteLine("Enter diameter of projectile in mm: ");
		double diameter = Convert.ToDouble(Console.ReadLine());

		Debug.WriteLine("Enter velocity projectile in m/s^2: ");
		double initV = Convert.ToDouble(Console.ReadLine());

		Debug.WriteLine("Enter distance from target in meters: ");
		double distance = Convert.ToDouble(Console.ReadLine());

		BulletPenetration calc = new BulletPenetration(mass, diameter, initV, distance);
		//scn.close();

		Debug.WriteLine(calc.toString());

	}

}
}
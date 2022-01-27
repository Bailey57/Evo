using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wasteland_game
{
	//package wasteland.entity;
	[System.Serializable]
	public class MaterialLayer {

	Material material;
	double thicknessIn_mm;
	double KE_damageThreshold;

	public MaterialLayer(Material material, double thicknessIn_mm, double kE_damageThreshold) {
		this.material = material;
		this.thicknessIn_mm = thicknessIn_mm;
		KE_damageThreshold = kE_damageThreshold;
	}

	/**
	 * @return the material
	 */
	public Material getMaterial() {
		return material;
	}

	/**
	 * @param material the material to set
	 */
	public void setMaterial(Material material) {
		this.material = material;
	}

	/**
	 * @return the thicknessIn_mm
	 */
	public double getThicknessIn_mm() {
		return thicknessIn_mm;
	}

	/**
	 * @param thicknessIn_mm the thicknessIn_mm to set
	 */
	public void setThicknessIn_mm(double thicknessIn_mm) {
		this.thicknessIn_mm = thicknessIn_mm;
	}

	/**
	 * @return the kE_damageThreshold
	 */
	public double getKE_damageThreshold() {
		return KE_damageThreshold;
	}

	/**
	 * @param kE_damageThreshold the kE_damageThreshold to set
	 */
	public void setKE_damageThreshold(double kE_damageThreshold) {
		KE_damageThreshold = kE_damageThreshold;
	}

}

}

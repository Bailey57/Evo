using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo.GameObjects.HitBoxes
{
    //package wasteland.entity;
    [Serializable]
    public class Material
    {



        public string name;

        /**
         * kg/m^3
         */
        public double density;

        /**
         * 
         */
        public double ductility;



        /**
         * 
         */
        public double vickersHardness;

        public double meltingPoint;

        //public double ;
        public double frictionConstant;//human skin: 0.46

        public double kruppConstant;

        public double brinellHerdness;

        //public double mass;
        public Material()
        {


        }
        //add krupp constant to materials
        public Material(string name, double density, double ductility, double vickersHardness, double meltingPoint)
        {
            this.name = name;
            this.density = density;
            this.ductility = ductility;
            this.vickersHardness = vickersHardness;

        }


        public Material(string name, double density, double ductility, double vickersHardness, double meltingPoint, double kruppConstant)
        {
            this.name = name;
            this.density = density;
            this.ductility = ductility;
            this.vickersHardness = vickersHardness;
            this.kruppConstant = kruppConstant;

        }

        //seawater density: 1020
        //-1 if not implemented


        public Material thicknessCalculate(Material material, double thicknessInMM)
        {


            return material;
        }





        /**
         * @return the name
         */
        public string getName()
        {
            return name;
        }

        /**
         * @param name the name to set
         */
        public void setName(string name)
        {
            this.name = name;
        }

        /**
         * @return the density
         */
        public double getDensity()
        {
            return density;
        }

        /**
         * @param density the density to set
         */
        public void setDensity(double density)
        {
            this.density = density;
        }

        /**
         * @return the ductility
         */
        public double getDuctility()
        {
            return ductility;
        }




        /**
         * @param ductility the ductility to set
         */
        public void setDuctility(double ductility)
        {
            this.ductility = ductility;
        }

        /**
         * @return the vickersHardness
         */
        public double getVickersHardness()
        {
            return vickersHardness;
        }

        /**
         * @param vickersHardness the vickersHardness to set
         */
        public void setVickersHardness(double vickersHardness)
        {
            this.vickersHardness = vickersHardness;
        }

        /**
         * @return the frictionConstant
         */
        public double getFrictionConstant()
        {
            return frictionConstant;
        }

        /**
         * @param frictionConstant the frictionConstant to set
         */
        public void setFrictionConstant(double frictionConstant)
        {
            this.frictionConstant = frictionConstant;
        }



        /**
         * @return the meltingPoint
         */
        public double getMeltingPoint()
        {
            return meltingPoint;
        }

        /**
         * @param meltingPoint the meltingPoint to set
         */
        public void setMeltingPoint(double meltingPoint)
        {
            this.meltingPoint = meltingPoint;
        }

        /**
         * @return the kruppConstant
         */
        public double getKruppConstant()
        {
            return kruppConstant;
        }
        /**
         * @param kruppConstant the kruppConstant to set
         */
        public void setKruppConstant(double kruppConstant)
        {
            this.kruppConstant = kruppConstant;
        }



        /**
         * @return the brinellHerdness
         */
        public double getBrinellHerdness()
        {
            return brinellHerdness;
        }
        /**
         * @param brinellHerdness the brinellHerdness to set
         */
        public void setBrinellHerdness(double brinellHerdness)
        {
            this.brinellHerdness = brinellHerdness;
        }
        public Material getMildSteel()
        {
            Material mildSteel = new Material("mild steel", 7850, -1, 140, -1, 2300);
            mildSteel.setBrinellHerdness(120);
            return mildSteel;
        }






        /**
         * @return the galvanizedSteel
         */
        public Material getGalvanizedSteel()
        {
            Material galvanizedSteel = new Material("galvanized steel", -1, -1, -1, -1, 2300);
            galvanizedSteel.setBrinellHerdness(120);
            return galvanizedSteel;
        }

        /**
         * @return the stainlessSteel
         */
        public Material getStainlessSteel()
        {
            Material stainlessSteel = new Material("stainless steel", 7982, -1, -1, -1, 2300);
            stainlessSteel.setBrinellHerdness(120);
            return stainlessSteel;
        }

        /**
         * @return the hardendedSteel
         */
        public Material getHardendedSteel()
        {
            Material hardendedSteel = new Material("hardended steel", -1, -1, 900, -1, 3600);//need to calc krupp constant
            hardendedSteel.setBrinellHerdness(700);//600 to 900
            return hardendedSteel;
        }

        /**
         * @return the hardendedSteel
         */
        public Material getRolledHomogonisArmor()
        {
            Material rolledHomogonisArmor = new Material("rolled homogonis armor", -1, -1, 900, -1, 2400);
            rolledHomogonisArmor.setBrinellHerdness(320);//302-400
            return rolledHomogonisArmor;
        }

        /**
         * @return the lead
         */
        public Material getLead()
        {
            Material lead = new Material("lead", 11343, -1, -1, -1);
            lead.setBrinellHerdness(42);//38-50
            return lead;
        }

        public Material getHumanBone()
        {
            Material humanBone = new Material("human bone", 1850, -1, -1, -1, 75.54537989187952);
            humanBone.setVickersHardness(34); //33.3 to 43.82
            return humanBone;
        }

        public Material getHumanFlesh()
        {
            Material humanFlesh = new Material("human flesh", 985, -1, -1, -1, 21.415952655313077);
            return humanFlesh;
        }

        /**
         * @return the humanMuscle
         */
        public Material getHumanMuscle()
        {
            Material humanMuscle = new Material("human muscle", 1090, -1, -1, -1, 21.415952655313077);
            return humanMuscle;
        }

        /**
         * @return the humanCartilage
         */
        public Material getHumanCartilage()
        {
            Material humanCartilage = new Material("human cartilage", 1100, -1, -1, -1, 21.415952655313077);
            return humanCartilage;
        }

        /**
         * @return the ballisticGel
         */
        public Material getBallisticGel()
        {
            Material ballisticGel = new Material("human flesh", 1060, -1, -1, -1, 21.415952655313077);
            return ballisticGel;
        }

        /**
         * @return the ceramicTile
         */
        public Material getCeramicTile()
        {
            Material ceramicTile = new Material("ceramicTile", -1, -1, 16, -1);//density between 1800 and 2200
            return ceramicTile;
        }

        /**
         * @return the ceramicTile
         */
        public Material getHudsonGlazedCeramicTile()
        {
            Material hudsonGlazedCeramicTile = new Material("hudsonGlazedCeramicTile", 1652.255, -1, 16, -1);//density between 1800 and 2200
            return hudsonGlazedCeramicTile;
        }


        /**
         * @return the ceramicTile
         */
        public Material getBallisticCeramicTile()
        {
            Material ceramicTile = new Material("PVC", -1, -1, 16, -1);
            return ceramicTile;
        }

        /**
         * @return the pVC
         */
        public Material getPVC()
        {
            Material PVC = new Material("PVC", -1, -1, 16, -1);

            return PVC;
        }














    }

}

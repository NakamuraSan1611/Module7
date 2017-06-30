using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyClassLib
{

    public class Tank
    {
        private string name;
        private int ammo;
        private int armor;
        private int maneuverability; //маневренность ёпт
        private bool isAlive = true;

        public Tank(string name)
        {
            this.name = name;
            ammo = GetRandomNumber(0, 100);
            armor = GetRandomNumber(0, 100);
            maneuverability = GetRandomNumber(0, 100);
        }
        public string getName()
        {
            return name;
        }
        public string getAmmo()
        {
            return ammo.ToString();
        }
        public string getArmor()
        {
            return armor.ToString();
        }
        public string getManeuverability()
        {
            return maneuverability.ToString();
        }
        public bool isDead()
        {
            return isAlive;
        }
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        private static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }

        public static Tank operator *(Tank tank1, Tank tank2)
        {
            int points1 = 0;
            int points2 = 0;
            if (tank1.ammo > tank2.ammo)
                points1++;
            else
                points2++;
            if (tank1.armor > tank2.armor)
                points1++;
            else
                points2++;
            if (tank1.maneuverability > tank2.maneuverability)
                points1++;
            else
                points2++;
            if (points1 > points2)
            {
                tank2.isAlive = false;
                return tank1;
            }
            else
            {
                tank1.isAlive = false;
                return tank2;
            }
        }

    }
}

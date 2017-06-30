using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLib;

namespace Module7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tank> tankList = new List<Tank>();
            tankList.Add(new Tank("T34"));
            tankList.Add(new Tank("Pantera 1"));
            tankList.Add(new Tank("Pantera 2"));
            tankList.Add(new Tank("Pantera 3"));
            tankList.Add(new Tank("Pantera 4"));
            foreach (var item in tankList)
            {
                Console.WriteLine("Имя танка: {0}\t Боекомплект: {1}\t Броня: {2}\t Маневренность: {3}", item.getName(), item.getAmmo(), item.getArmor(), item.getManeuverability());
            }
            for(int i = 0; i < tankList.Count; i++)
            {
                for(int j = 0; j < tankList.Count; j++)
                {
                    if (tankList[i].isDead() && tankList[j].isDead() && i != j)
                    {
                        Tank tempTank = tankList[i] * tankList[j];
                        Console.WriteLine("В битве {0} против {1} победил {2}", tankList[i], tankList[j], tempTank.getName());
                    }
                }
            }
            foreach (var item in tankList)
            {
                if (item.isDead())
                    Console.WriteLine("Победитель битвы {0}",item.getName());
            }

        }
    }
}

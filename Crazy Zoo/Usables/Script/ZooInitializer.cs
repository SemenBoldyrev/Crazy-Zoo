using Crazy_Zoo.Classes;
using Crazy_Zoo.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace Crazy_Zoo.Usables.Script
{
    public static class ZooInitializer
    {
        public static List<Enclosure<BaseAnimal>> GetSettedEnclosuresList()
        {
            var tmp = new List<Enclosure<BaseAnimal>>();

            var encTable = App.Services?.GetService<IAnimalDatabaseController>()?.GetEnclosureData();
            var animalTable = App.Services?.GetService<IAnimalDatabaseController>()?.GetAnimalData();

            Dictionary<string, Enclosure<BaseAnimal>> tmpDict = new Dictionary<string, Enclosure<BaseAnimal>> ();
            foreach ( DataRow enclosure in encTable.AsEnumerable() )
            {
                tmpDict.Add((string)enclosure["Name"], new Enclosure<BaseAnimal>((string)enclosure["Name"]));
            }

            foreach (DataRow animal in animalTable.AsEnumerable())
            {
                tmpDict[(string)animal["Enclosure"]].Add(AnimalFactory.CreatAnimal(
                    (string)animal["Origin"],
                    (string)animal["Name"],
                    (int)animal["Age"],
                    (string)animal["Specie"],
                    (string)animal["Voice"],
                    (string)animal["Introduction"]
                    ));
            }

            foreach (Enclosure<BaseAnimal> enc in  tmpDict.Values ) { tmp.Add(enc); }

                return tmp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Test_Taste_Console_Application.Domain.DataTransferObjects;
using System.Linq;

namespace Test_Taste_Console_Application.Domain.Objects
{
    public class Planet
    {
        public string Id { get; set; }
        public float SemiMajorAxis { get; set; }
        public ICollection<Moon> Moons { get; set; }
        public float AverageMoonGravity
        {
            get => 0.0f;
        }

        public Planet(PlanetDto planetDto)
        {
            Id = planetDto.Id;
            SemiMajorAxis = planetDto.SemiMajorAxis;
            Moons = new Collection<Moon>();
            if(planetDto.Moons != null)
            {
                foreach (MoonDto moonDto in planetDto.Moons)
                {
                    Moons.Add(new Moon(moonDto));
                }
            }
        }

        public Boolean HasMoons()
        {
            return (Moons != null && Moons.Count > 0);
        }

        public double GetAverageMoonTemperature()
        {
            if (Moons == null || !Moons.Any())
                return 0;
            Console.WriteLine($"Moon Count: {Moons.Count}");
            Console.WriteLine($"Avg Temp: {Moons.Average(x => x.AvgTemp)}");
            return Moons.Average(x => x.AvgTemp);
            
        }
    }
}

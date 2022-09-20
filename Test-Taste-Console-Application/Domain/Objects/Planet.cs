using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Test_Taste_Console_Application.Domain.DataTransferObjects;

namespace Test_Taste_Console_Application.Domain.Objects
{
    public class Planet
    {
        public string Id { get; set; }
        public float SemiMajorAxis { get; set; }
        public ICollection<Moon> Moons { get; set; }
        public float AverageMoonGravity
        {
            get;
        }

        public Planet(PlanetDto planetDto)
        {
            AverageMoonGravity = 0;
            Id = planetDto.Id;
            SemiMajorAxis = planetDto.SemiMajorAxis;
            Moons = new Collection<Moon>();
            if(planetDto.Moons != null)
            {
                foreach (MoonDto moonDto in planetDto.Moons)
                {
                    //Calculating etting the total gravity
                    AverageMoonGravity += moonDto.Gravity??=0;

                    Moons.Add(new Moon(moonDto));
                }

                //Calculating the Average Moon Gravity
                AverageMoonGravity /= Moons.Count;
            }
        }

        public bool HasMoons()
        {
            return (Moons != null && Moons.Count > 0);
        }
    }
}

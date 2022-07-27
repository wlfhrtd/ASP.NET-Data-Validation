using System;


namespace Mvc.Models
{
    public class GuitarPickup
    {
        public string Name { get; set; }

        public PickupType PickupType { get; set; }

        public PickupPosition RecommendedPosition { get; set; }

        public int NumberOfStringsSupported { get; set; }

        public int NumberOfConductorsRequired { get; set; }
    }
}

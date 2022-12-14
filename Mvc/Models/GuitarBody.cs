using System;


namespace Mvc.Models
{
    public class GuitarBody
    {
        public string Name { get; set; }

        public string ToneWood { get; set; }

        public int NumberOfStringsSupported { get; set; }

        public bool AllowBridgePickup { get; set; }

        public bool AllowMiddlePickup { get; set; }

        public bool AllowNeckPickup { get; set; }

        public BodyType BodyType { get; set; }

        public BodyStyle Style { get; set; }

        public string Color { get; set; }
    }
}

using System;


namespace Mvc.Models
{
    public class GuitarString
    {
        public string NoteAtStandardTuning { get; set; }

        public int Gage { get; set; }

        public string Material { get; set; }

        public string Name => string.Format("{0} : {1}", NoteAtStandardTuning, Gage);
    }
}

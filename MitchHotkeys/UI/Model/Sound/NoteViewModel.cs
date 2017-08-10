using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MitchHotkeys.Logic.Models;
using MitchHotkeys.Logic.Models.Sound;

namespace MitchHotkeys.UI.Model.Sound
{
    public class NoteViewModel 
    {
        public NoteViewModel(Note note, string displayName)
        {
            this.Note = note;
            this.DisplayName = displayName;
        }

        public Note Note { get; set; }
        private bool selected;
        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
            }
        }
        public string DisplayName { get; set; }
    }
}

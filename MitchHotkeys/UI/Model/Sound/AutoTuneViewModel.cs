using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Threading;
using MitchHotkeys.MiddleTier.Model.Sound;

namespace MitchHotkeys.UI.Model.Sound
{
    public class AutoTuneViewModel
    {

        private int attackTimeMilliseconds;
        private bool isEnabled;

        public int AttackTime
        {
            get { return attackTimeMilliseconds; }
            set
            {
                attackTimeMilliseconds = value;
            }
        }

        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
            }
        }
        
        public string AttackMessage
        {
            get { return String.Format("{0}ms", attackTimeMilliseconds); }
        }
        

        public ObservableCollection<NoteViewModel> Pitches { get; private set; }
        public IEnumerable<string> Scales { get { return scalesDictionary.Keys; } }
        private string selectedScale;
        public string SelectedScale
        {
            get { return selectedScale; }
            set
            {
                if (this.selectedScale != value)
                {
                    this.selectedScale = value;
                    SelectNotes();
                }
            }
        }
        private Dictionary<string, HashSet<Note>> scalesDictionary;

        private void SelectNotes()
        {
            var scale = scalesDictionary[selectedScale];
            foreach (var p in Pitches)
            {
                p.Selected = scale.Contains(p.Note);
            }
        }

        public string GetScaleFromSelectedPitches()
        {
            foreach(string currentScaleKey in scalesDictionary.Keys)
            {
                HashSet<Note> currentScale = scalesDictionary[currentScaleKey];

                bool matchesScale = true;
                foreach(NoteViewModel pitch in Pitches)
                {
                    bool currentScaleHasNote = currentScale.Contains(pitch.Note); // is this pitch selected
                    if (currentScaleHasNote != pitch.Selected)
                    {
                        matchesScale = false;
                        break;
                    }
                }

                if (matchesScale)
                {
                    return currentScaleKey;
                }
                
            }
            return null;
        }

        public AutoTuneViewModel()
        {
            scalesDictionary = new Dictionary<string, HashSet<Note>>();
            scalesDictionary.Add("Chromatic", PredefinedScales.Chromatic);
            scalesDictionary.Add("Key of C / Am", PredefinedScales.MakeMajorScale(Note.C));
            scalesDictionary.Add("Key of D / Bm", PredefinedScales.MakeMajorScale(Note.D));
            scalesDictionary.Add("Key of E / C\u266Fm", PredefinedScales.MakeMajorScale(Note.E));
            scalesDictionary.Add("Key of F / Dm", PredefinedScales.MakeMajorScale(Note.F));
            scalesDictionary.Add("Key of G / Em", PredefinedScales.MakeMajorScale(Note.G));
            scalesDictionary.Add("Key of A / F\u266Fm", PredefinedScales.MakeMajorScale(Note.A));
            scalesDictionary.Add("Key of B\u266D / Gm", PredefinedScales.MakeMajorScale(Note.ASharp));
            
            scalesDictionary.Add("Pentatonic C / Am",       PredefinedScales.MakePentatonicScale(Note.C));
            scalesDictionary.Add("Pentatonic D / Bm",       PredefinedScales.MakePentatonicScale(Note.D));
            scalesDictionary.Add("Pentatonic E / C\u266Fm", PredefinedScales.MakePentatonicScale(Note.E));
            scalesDictionary.Add("Pentatonic F / Dm",       PredefinedScales.MakePentatonicScale(Note.F));
            scalesDictionary.Add("Pentatonic G / Em",       PredefinedScales.MakePentatonicScale(Note.G));
            scalesDictionary.Add("Pentatonic A / F\u266Fm", PredefinedScales.MakePentatonicScale(Note.A));
            scalesDictionary.Add("Pentatonic B\u266D / Gm", PredefinedScales.MakePentatonicScale(Note.ASharp));
            
            
            this.Pitches = new ObservableCollection<NoteViewModel>();

            this.Pitches.Add(new NoteViewModel(Note.C,"C"));
            this.Pitches.Add(new NoteViewModel(Note.CSharp,"C\u266F"));
            this.Pitches.Add(new NoteViewModel(Note.D,"D"));
            this.Pitches.Add(new NoteViewModel(Note.DSharp, "E\u266D"));
            this.Pitches.Add(new NoteViewModel(Note.E,"E"));
            this.Pitches.Add(new NoteViewModel(Note.F, "F"));
            this.Pitches.Add(new NoteViewModel(Note.FSharp, "F\u266F"));
            this.Pitches.Add(new NoteViewModel(Note.G,"G"));
            this.Pitches.Add(new NoteViewModel(Note.GSharp, "A\u266D"));
            this.Pitches.Add(new NoteViewModel(Note.A,"A"));
            this.Pitches.Add(new NoteViewModel(Note.ASharp,"B\u266D"));
            this.Pitches.Add(new NoteViewModel(Note.B,"B"));
            this.SelectedScale = "Chromatic";
        }
    }
}

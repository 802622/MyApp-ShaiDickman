
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;

namespace MyAppMainPage

{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Notes> AllNotes;// { get; set; }//change to string?
        public string TestString = "test";
        public int iteration = 0;
        public MainPageViewModel()
        {
            AllNotes = new ObservableCollection<Notes>()
            {
                new Notes(){Note="testPrewriteNote"}
            };
            EraseCommand = new Command(() => { TheNote = string.Empty; });
            SaveCommand = new Command(() =>
            {
                System.Diagnostics.Debug.WriteLine("allNotes is: " + AllNotes[iteration].Note);
                System.Diagnostics.Debug.WriteLine("TheNote is: " + TheNote);
                AllNotes.Add(new Notes() {Note = TheNote });
                //AllNotes += TheNote;
                iteration++;
                TestString += AllNotes[iteration].Note;


                TheNote = string.Empty;
            });
        }

        //public string AllNotes = "zsfasdf";
        public event PropertyChangedEventHandler PropertyChanged;

        string theNote;
        public string TheNote
        {
            //Makes theNote change in both the view model and in the code!
            get => theNote;
            set
            {
                theNote = value;

                var args = new PropertyChangedEventArgs(nameof(TheNote));

                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command SaveCommand { get; }
        public Command EraseCommand { get; }

        public class Notes
        {
            public string Note { get; set; }
        }
        
       

    }
}


using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;

namespace MyAppMainPage

{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            EraseCommand = new Command(() => { TheNote = string.Empty; });
            SaveCommand = new Command(() =>
            {
                System.Diagnostics.Debug.WriteLine("allNotes is: " + AllNotes);
                System.Diagnostics.Debug.WriteLine("TheNote is: " +  TheNote);
                AllNotes.Add(TheNote);
                //AllNotes += TheNote;

                TheNote = string.Empty;
            });
        }
        public ObservableCollection<string> AllNotes { get; set; }//change to string?\
        AllNotes.Add("heyHeyHEY");
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
        
       

    }
}

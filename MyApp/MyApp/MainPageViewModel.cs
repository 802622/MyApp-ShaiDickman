
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
                AllNotes.Add(TheNote);

                //outputTestLabel.Text = AllNotes;

                TheNote = string.Empty;
            });
        }
        public ObservableCollection<string> AllNotes = new ObservableCollection<string>();
        //{ get; set; }
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
                System.Diagnostics.Debug.WriteLine("TheNote value is now: " + TheNote);
            }
        }

        public Command SaveCommand { get; }
        public Command EraseCommand { get; }
        
       

    }
}

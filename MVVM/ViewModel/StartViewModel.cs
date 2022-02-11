﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM.ViewModel
{
    internal class StartViewModel : INotifyPropertyChanged
    {
        public int AnzahlPersonen { get { return Model.Person.Personenliste.Count; } }

        public CustomCommand LadeDbCmd { get; set; }

        public CustomCommand ÖffneDbCmd { get; set; }

        public StartViewModel()
        {
            LadeDbCmd = new CustomCommand
                (
                    p =>
                    {
                        Model.Person.LadePersonenAusDb();
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnzahlPersonen)));
                    },
                    p => AnzahlPersonen == 0
                );

            ÖffneDbCmd = new CustomCommand
                (
                    p =>
                    {
                        //DataGrid-Fenster öffnen

                        (p as Window).Close();
                    },
                    p => AnzahlPersonen >= 1
                );
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

﻿using Castle.Core.Logging;
using EndlessModding.Common;
using EndlessModding.EndlessSpace2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EndlessModding
{
    public class MainWindowViewModel
    {
        //Public View Models
        public EndlessSpace2ViewModel EndlessSpace2 { get; }

        //Private Views
        private EndlessSpace2View EndlessSpace2Window;


        //Commands
        public ICommand EndlessSpace2Clicked { get; }


        //Fields
        private readonly ILogger _logger;



        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="es2vm">The endless space 2 view model.</param>
        public MainWindowViewModel(ILogger castleLogger, EndlessSpace2ViewModel es2vm)
        {
            //setup injections
            _logger = castleLogger;
            EndlessSpace2 = es2vm;
            //setup commands
            EndlessSpace2Clicked = new RelayCommand(Can_Endless_Space_2_Click, Endless_Space_2_Click);

        }




        private void Endless_Space_2_Click(object obj)
        {
            EndlessSpace2Window = new EndlessSpace2.EndlessSpace2View() {DataContext = EndlessSpace2 };
            EndlessSpace2Window.Show();
            Application.Current.MainWindow?.Hide();
        }
        private bool Can_Endless_Space_2_Click(object obj)
        {
            if (EndlessSpace2Window == null)
            {
                return true;
            }

            return false;
        }

        #region INotifyPropertyChanged
        /// <summary>
        /// Occurs when [property changed].
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

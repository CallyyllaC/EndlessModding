using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Simulator;
using EndlessModding.EndlessSpace2.Common.Files;

namespace EndlessModding.EndlessSpace2.SimulationModifierDescriptors
{
    class SimulationModifierDescriptorViewModel : INotifyPropertyChanged
    {
        public EndlessSpace2ViewModel MainWindow { get; set; }

        public ObservableConcurrentCollection<EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Simulator.SimulationModifierDescriptor> Sims { get; set; }
        public SimulationModifierDescriptor CurrentSim
        {
            get => _currentSim;
            set
            {
                if (_currentSim != value)
                {
                    if (MainWindow != null)
                        MainWindow.IsBusy = true;

                    /////////saveSim();
                    _currentSim = value;
                    ///////////loadSim(null);
                    RaisePropertyChanged();

                    if (MainWindow != null)
                        MainWindow.IsBusy = false;
                }
            }
        }

        private readonly ILogger _logger;
        private Data _data;
        private SimulationModifierDescriptor _currentSim;

        public SimulationModifierDescriptorViewModel(ILogger Logger, Data data)
        {
            Logger.Info($"{MethodBase.GetCurrentMethod().Name}");

            _logger = Logger;
            _data = data;
            Sims = _data.SimulationModifierDescriptorDefinitions;

            RaisePropertyChanged();
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

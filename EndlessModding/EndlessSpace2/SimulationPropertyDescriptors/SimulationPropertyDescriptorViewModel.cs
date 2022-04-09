using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Castle.Core.Logging;
using EndlessModding.Common;
using EndlessModding.Common.DataStructures;
using EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Simulator;
using EndlessModding.EndlessSpace2.Common.Files;
using SteamKit2.GC.Dota.Internal;


namespace EndlessModding.EndlessSpace2.SimulationPropertyDescriptors
{
    public class SimulationPropertyDescriptorViewModel : INotifyPropertyChanged
    {
        public EndlessSpace2ViewModel MainWindow { get; set; }
        public EndlessObservableConcurrentCollection<EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Simulator.SimulationPropertyDescriptor> Properties { get; set; }

        //properties
        public ICommand LoadSim { get; }
        public ICommand NewSim { get; }
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value?.Replace(" ", ""))
                {
                    _name = value?.Replace(" ", "");
                    RaisePropertyChanged();
                }
            }
        }
        public string Minimum
        {
            get => _minimum;
            set
            {
                if (_minimum != value)
                {
                    _minimum = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Maximum
        {
            get => _maximum;
            set
            {
                if (_maximum != value)
                {
                    _maximum = value;
                    RaisePropertyChanged();
                }
            }
        }
        public float StartingRatio
        {
            get => _startingRatio;
            set
            {
                if (_startingRatio != value)
                {
                    _startingRatio = value;
                    RaisePropertyChanged();
                }
            }
        }
        public bool Proportional
        {
            get => _proportional;
            set
            {
                if (_proportional != value)
                {
                    _proportional = value;
                    RaisePropertyChanged();
                }
            }
        }
        public bool IsSerializable
        {
            get => _isSerializable;
            set
            {
                if (_isSerializable != value)
                {
                    _isSerializable = value;
                    RaisePropertyChanged();
                }
            }
        }
        public bool IsSealed
        {
            get => _isSealed;
            set
            {
                if (_isSealed != value)
                {
                    _isSealed = value;
                    RaisePropertyChanged();
                }
            }
        }
        public SimulationPropertyRoundingFunction RoundingFunction
        {
            get => _roundingFunction;
            set
            {
                if (_roundingFunction != value)
                {
                    _roundingFunction = value;
                    RaisePropertyChanged();
                }
            }
        }
        public SimulationPropertyComposition Composition
        {
            get => _composition;
            set
            {
                if (_composition != value)
                {
                    _composition = value;
                    RaisePropertyChanged();
                }
            }
        }
        public float BaseValue
        {
            get => _baseValue;
            set
            {
                if (_baseValue != value)
                {
                    _baseValue = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string MinValue
        {
            get => _minValue;
            set
            {
                if (_minValue != value)
                {
                    _minValue = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string MaxValue
        {
            get => _maxValue;
            set
            {
                if (_maxValue != value)
                {
                    _maxValue = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Common.Classes.Amplitude_Simulator.SimulationPropertyDescriptor CurrentSim
        {
            get => _currentSim;
            set
            {
                if (_currentSim != value)
                {
                    if (MainWindow != null)
                        MainWindow.IsBusy = true;

                    saveSim();
                    _currentSim = value;
                    loadSim(null);
                    RaisePropertyChanged();

                    if (MainWindow != null)
                        MainWindow.IsBusy = false;
                }
            }
        }

        //fields

        private readonly ILogger _logger;
        private Data _data;
        private Common.Classes.Amplitude_Simulator.SimulationPropertyDescriptor _currentSim;
        private string _name;
        private string _maxValue;
        private string _minValue;
        private float _baseValue;
        private SimulationPropertyComposition _composition;
        private SimulationPropertyRoundingFunction _roundingFunction;
        private bool _isSealed;
        private bool _isSerializable;
        private bool _proportional;
        private float _startingRatio;
        private string _maximum;
        private string _minimum;


        public SimulationPropertyDescriptorViewModel(ILogger Logger, Data data)
        {
            Logger.Info($"{MethodBase.GetCurrentMethod().Name}");

            _logger = Logger;
            _data = data;
            Properties = _data.SimulationPropertyDescriptorDefinitions;
            CurrentSim = null;
            LoadSim = new RelayCommand(canLoadSim, loadSim);
            NewSim = new RelayCommand(canNewSim, newSim);
            RaisePropertyChanged();
        }

        private void loadSim(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (Properties.Count > 0 && CurrentSim != null)
            {
                MainWindow.IsBusy = true;
                Name = CurrentSim.Name;
                MaxValue = CurrentSim.MaxValue;
                MinValue = CurrentSim.MinValue;
                BaseValue = CurrentSim.BaseValue;
                Composition = CurrentSim.Composition;
                RoundingFunction = CurrentSim.RoundingFunction;
                IsSealed = CurrentSim.IsSealed;
                IsSerializable = CurrentSim.IsSerializable;
                if (CurrentSim is SimulationPropertyDescriptor_Proportional)
                {
                    Proportional = true;
                    var tmp = (SimulationPropertyDescriptor_Proportional)CurrentSim;
                    StartingRatio = tmp.StartingRatio;
                    Maximum = tmp.Maximum;
                    Minimum = tmp.Minimum;
                }
                else
                {
                    Proportional = false;
                    StartingRatio = 0f;
                    Maximum = "N/A";
                    Minimum = "N/A";
                }
                MainWindow.IsBusy = false;
            }
        }

        private bool canLoadSim(object obj)
        {
            return !MainWindow.IsBusy;
        }

        private void newSim(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            Properties.Add(new Common.Classes.Amplitude_Simulator.SimulationPropertyDescriptor() { Custom = true });
            CurrentSim = Properties.Last();
        }

        private bool canNewSim(object obj)
        {
            return !MainWindow.IsBusy;
        }

        private void saveSim()
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (Properties.Count > 0 && CurrentSim != null)
            {
                MainWindow.IsBusy = true;
                bool modified = false;

                if (Proportional)
                {
                    if (CurrentSim is SimulationPropertyDescriptor_Proportional) //if we are already proportional
                    {
                        var tmp = (SimulationPropertyDescriptor_Proportional)CurrentSim;

                        if (tmp.StartingRatio != StartingRatio)
                        {
                            tmp.StartingRatio = StartingRatio;
                            RaisePropertyChanged(tmp, "StartingRatio");
                            modified = true;
                        }

                        if (tmp.Maximum != Maximum)
                        {
                            tmp.Maximum = Maximum;
                            RaisePropertyChanged(tmp, "Maximum");
                            modified = true;
                        }

                        if (tmp.Minimum != Minimum)
                        {
                            tmp.Minimum = Minimum;
                            RaisePropertyChanged(tmp, "Minimum");
                            modified = true;
                        }
                    }
                    else //if we are becoming proportional
                    {
                        var tmp = new SimulationPropertyDescriptor_Proportional(CurrentSim);

                        if (tmp.StartingRatio != StartingRatio)
                        {
                            tmp.StartingRatio = StartingRatio;
                            RaisePropertyChanged(tmp, "StartingRatio");
                            modified = true;
                        }

                        if (tmp.Maximum != Maximum)
                        {
                            tmp.Maximum = Maximum;
                            RaisePropertyChanged(tmp, "Maximum");
                            modified = true;
                        }

                        if (tmp.Minimum != Minimum)
                        {
                            tmp.Minimum = Minimum;
                            RaisePropertyChanged(tmp, "Minimum");
                            modified = true;
                        }

                        Properties.Add(tmp);
                        _currentSim = Properties.Last();
                    }
                }
                else if(Proportional != CurrentSim.Proportional) //if we arnt proportional but used to be
                {
                    var tmp = new SimulationPropertyDescriptor((SimulationPropertyDescriptor_Proportional)CurrentSim);
                    Properties.Add(tmp);
                    _currentSim = Properties.Last();
                }

                if (CurrentSim.Name != Name)
                {
                    CurrentSim.Name = Name;
                    RaisePropertyChanged(CurrentSim, "Name");
                    modified = true;
                }

                if (CurrentSim.MaxValue != MaxValue)
                {
                    CurrentSim.MaxValue = MaxValue;
                    RaisePropertyChanged(CurrentSim, "MaxValue");
                    modified = true;
                }
                if (CurrentSim.MinValue != MinValue)
                {
                    CurrentSim.MinValue = MinValue;
                    RaisePropertyChanged(CurrentSim, "MinValue");
                    modified = true;
                }
                if (CurrentSim.BaseValue != BaseValue)
                {
                    CurrentSim.BaseValue = BaseValue;
                    RaisePropertyChanged(CurrentSim, "BaseValue");
                    modified = true;
                }
                if (CurrentSim.Composition != Composition)
                {
                    CurrentSim.Composition = Composition;
                    RaisePropertyChanged(CurrentSim, "Composition");
                    modified = true;
                }
                if (CurrentSim.RoundingFunction != RoundingFunction)
                {
                    CurrentSim.RoundingFunction = RoundingFunction;
                    RaisePropertyChanged(CurrentSim, "RoundingFunction");
                    modified = true;
                }
                if (CurrentSim.IsSealed != IsSealed)
                {
                    CurrentSim.IsSealed = IsSealed;
                    RaisePropertyChanged(CurrentSim, "IsSealed");
                    modified = true;
                }
                if (CurrentSim.IsSerializable != IsSerializable)
                {
                    CurrentSim.IsSerializable = IsSerializable;
                    RaisePropertyChanged(CurrentSim, "IsSerializable");
                    modified = true;
                }


                if (modified)
                {
                    CurrentSim.Custom = true;
                    RaisePropertyChanged(CurrentSim, "Custom");
                }
                MainWindow.IsBusy = false;
            }
        }

        private void GetObjectFromArray<T>(BindingList<T> output, T[] input)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            output.Clear();
            if (input == null)
            {
                return;
            }
            foreach (T item in input)
            {
                try
                {
                    output.Add(item);
                }
                catch (Exception e)
                {
                    _logger.Error(e.Message, e.InnerException);
                }
            }
        }
        private void GetObjectFromArray<T>(T[] output, BindingList<T> input)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            output = input.ToArray();
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

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="propertyName">Name of the property.</param>
        private void RaisePropertyChanged(object target, string propertyName)
        {
            PropertyChanged?.Invoke(target, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

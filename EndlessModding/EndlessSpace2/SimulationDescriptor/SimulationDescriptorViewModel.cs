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
using EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Simulator;
using EndlessModding.EndlessSpace2.Common.Classes.HeroDefinition;
using EndlessModding.EndlessSpace2.Common.Files;
using SteamKit2.Internal;

namespace EndlessModding.EndlessSpace2.SimulationDescriptor
{
    public class SimulationDescriptorViewModel : INotifyPropertyChanged
    {
        public EndlessSpace2ViewModel MainWindow { get; set; }

        public ObservableConcurrentCollection<EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Simulator.SimulationDescriptor> Sims { get; set; }
        public ObservableConcurrentCollection<EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Simulator.SimulationPropertyDescriptor> Properties { get; set; }
        public ObservableConcurrentCollection<EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Simulator.SimulationModifierDescriptor> Modifiers { get; set; }

        //properties
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
        public string Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
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

        public BindingList<SimulationPropertyDescriptor> Items { get; set; } =
            new BindingList<SimulationPropertyDescriptor>();
        public BindingList<SimulationModifierDescriptor> Items1 { get; set; } =
            new BindingList<SimulationModifierDescriptor>();
        public SimulationPropertyDescriptor CurrentProperty { get; set; } = null;
        public SimulationModifierDescriptor CurrentModifier { get; set; } = null;
        public SimulationModifierDescriptor SelectedCurrentModifier { get; set; } = null;
        public SimulationPropertyDescriptor SelectedCurrentProperty { get; set; } = null;
        public ICommand LoadSim { get; }
        public ICommand NewSim { get; }
        public ICommand AddModifier { get; }
        public ICommand RemoveModifier { get; }
        public ICommand AddProperty { get; }
        public ICommand RemoveProperty { get; }

        public Common.Classes.Amplitude_Simulator.SimulationDescriptor CurrentSim
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
        private Common.Classes.Amplitude_Simulator.SimulationDescriptor _currentSim;
        private string _name;
        private string _type;
        private bool _isSerializable;


        public SimulationDescriptorViewModel(ILogger Logger, Data data)
        {
            Logger.Info($"{MethodBase.GetCurrentMethod().Name}");

            _logger = Logger;
            _data = data;
            Sims = _data.SimulationDescriptorDefinitions;
            Properties = _data.SimulationPropertyDescriptorDefinitions;
            Modifiers = _data.SimulationModifierDescriptorDefinitions;
            CurrentSim = null;
            LoadSim = new RelayCommand(canLoadSim, loadSim);
            NewSim = new RelayCommand(canNewSim, newSim);
            AddProperty = new RelayCommand(canAddProperty, addProperty);
            RemoveProperty = new RelayCommand(canRemoveProperty, removeProperty);
            AddModifier = new RelayCommand(canAddModifier, addModifier);
            RemoveModifier = new RelayCommand(canRemoveModifier, removeModifier);
            RaisePropertyChanged();
        }

        private void loadSim(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (Sims.Count > 0 && CurrentSim != null)
            {
                MainWindow.IsBusy = true;
                Name = CurrentSim.Name;
                Type = CurrentSim.Type;
                IsSerializable = CurrentSim.IsSerializable;
                GetObjectFromArray(Items, CurrentSim.Items);
                GetObjectFromArray(Items1, CurrentSim.Items1);
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
            Sims.AddFromEnumerable(new Common.Classes.Amplitude_Simulator.SimulationDescriptor[] { new Common.Classes.Amplitude_Simulator.SimulationDescriptor() { Custom = true } });
            CurrentSim = Sims.Last();
        }

        private bool canNewSim(object obj)
        {
            return !MainWindow.IsBusy;
        }

        private void saveSim()
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (Sims.Count > 0 && CurrentSim != null)
            {
                MainWindow.IsBusy = true;
                bool modified = false;
                if (CurrentSim.Name != Name)
                {
                    CurrentSim.Name = Name;
                    RaisePropertyChanged(CurrentSim, "Name");
                    modified = true;
                }

                if (CurrentSim.Type != Type)
                {
                    CurrentSim.Type = Type;
                    RaisePropertyChanged(CurrentSim, "Type");
                    modified = true;
                }

                if (CurrentSim.IsSerializable != IsSerializable)
                {
                    CurrentSim.IsSerializable = IsSerializable;
                    RaisePropertyChanged(CurrentSim, "Serializable");
                    modified = true;
                }

                if (!CurrentSim.Items.Select(x => x.Name)
                    .SequenceEqual(Items.Select(x => x.Name)))
                {
                    GetObjectFromArray(CurrentSim.Items, Items);
                    RaisePropertyChanged(CurrentSim, "Items");
                    modified = true;
                }

                if (!CurrentSim.Items1.Select(x => x)
                    .SequenceEqual(Items1.Select(x => x)))
                {
                    GetObjectFromArray(CurrentSim.Items1, Items1);
                    RaisePropertyChanged(CurrentSim, "Items1");
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

        private void removeModifier(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (CurrentModifier != null)
            {
                Items1.Remove(CurrentModifier);
                if (Items1.Count != 0)
                {
                    CurrentModifier = Items1[0];
                }
                else
                {
                    CurrentModifier = null;
                }
            }
        }

        private bool canRemoveModifier(object obj)
        {
            if (Items1 != null)
            {
                return CurrentSim != null && !MainWindow.IsBusy;
            }
            else
            {
                return false;
            }
        }

        private void addModifier(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (Items1 != null)
            {
                if (!Items1.Contains(SelectedCurrentModifier))
                {
                    Items1.Add(SelectedCurrentModifier);
                }
            }
        }

        private bool canAddModifier(object obj)
        {
            if (Items1 != null)
            {
                return CurrentSim != null && !MainWindow.IsBusy;
            }
            else
            {
                return false;
            }
        }
        private void removeProperty(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (CurrentProperty != null)
            {
                Items.Remove(CurrentProperty);
                if (Items.Count != 0)
                {
                    CurrentProperty = Items[0];
                }
                else
                {
                    CurrentProperty = null;
                }
            }
        }

        private bool canRemoveProperty(object obj)
        {
            if (Items != null)
            {
                return CurrentSim != null && !MainWindow.IsBusy;
            }
            else
            {
                return false;
            }
        }

        private void addProperty(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (Items != null)
            {
                if (!Items.Contains(SelectedCurrentProperty))
                {
                    Items.Add(SelectedCurrentProperty);
                }
            }
        }

        private bool canAddProperty(object obj)
        {
            if (Items != null)
            {
                return CurrentSim != null && !MainWindow.IsBusy;
            }
            else
            {
                return false;
            }
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

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
using EndlessModding.EndlessSpace2.Common.Files;

namespace EndlessModding.EndlessSpace2.SimulationModifierDescriptors
{
    public class SimulationModifierDescriptorViewModel : INotifyPropertyChanged
    {
        public EndlessSpace2ViewModel MainWindow { get; set; }

        public ObservableConcurrentCollection<EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Simulator.SimulationModifierDescriptor> Modifiers { get; set; }

        //properties
        public ICommand LoadSim { get; }
        public ICommand NewSim { get; }

        public Common.Classes.Amplitude_Simulator.SimulationModifierDescriptor CurrentSim
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
        public string Path
        {
            get => _path;
            set
            {
                if (_path != value)
                {
                    _path = value;
                    RaisePropertyChanged();
                }
            }
        }
        public bool EnforceContext
        {
            get => _enforceContext;
            set
            {
                if (_enforceContext != value)
                {
                    _enforceContext = value;
                    RaisePropertyChanged();
                }
            }
        }
        public bool ForceFrom
        {
            get => _forceFrom;
            set
            {
                if (_forceFrom != value)
                {
                    _forceFrom = value;
                    RaisePropertyChanged();
                }
            }
        }
        public ModifierOperation Operation
        {
            get => _operation;
            set
            {
                if (_operation != value)
                {
                    _operation = value;
                    RaisePropertyChanged();
                }
            }
        }
        public float Priority
        {
            get => _priority;
            set
            {
                if (_priority != value)
                {
                    _priority = value;
                    RaisePropertyChanged();
                }
            }
        }
        public bool SearchValueFromPath
        {
            get => _searchValueFromPath;
            set
            {
                if (_searchValueFromPath != value)
                {
                    _searchValueFromPath = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string TargetProperty
        {
            get => _targetProperty;
            set
            {
                if (_targetProperty != value)
                {
                    _targetProperty = value;
                    RaisePropertyChanged();
                }
            }
        }
        public bool TooltipHidden
        {
            get => _tooltipHidden;
            set
            {
                if (_tooltipHidden != value)
                {
                    _tooltipHidden = value;
                    RaisePropertyChanged();
                }
            }
        }
        public bool TooltipHiddenIfPathInvalid
        {
            get => _tooltipHiddenIfPathInvalid;
            set
            {
                if (_tooltipHiddenIfPathInvalid != value)
                {
                    _tooltipHiddenIfPathInvalid = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string TooltipOverride
        {
            get => _tooltipOverride;
            set
            {
                if (_tooltipOverride != value)
                {
                    _tooltipOverride = value;
                    RaisePropertyChanged();
                }
            }
        }
        public bool UseIfInsteadOfWhere
        {
            get => _useIfInsteadOfWhere;
            set
            {
                if (_useIfInsteadOfWhere != value)
                {
                    _useIfInsteadOfWhere = value;
                    RaisePropertyChanged();
                }
            }
        }
        public bool ValueMustBePositive
        {
            get => _valueMustBePositive;
            set
            {
                if (_valueMustBePositive != value)
                {
                    _valueMustBePositive = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    RaisePropertyChanged();
                }
            }
        }
        public ModifierOperation BinaryOperation
        {
            get => _binaryOperation;
            set
            {
                if (_binaryOperation != value)
                {
                    _binaryOperation = value;
                    RaisePropertyChanged();
                }
            }
        }
        public bool EnforceRightAsPer
        {
            get => _enforceRightAsPer;
            set
            {
                if (_enforceRightAsPer != value)
                {
                    _enforceRightAsPer = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Left
        {
            get => _left;
            set
            {
                if (_left != value)
                {
                    _left = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Right
        {
            get => _right;
            set
            {
                if (_right != value)
                {
                    _right = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string CountPath
        {
            get => _countPath;
            set
            {
                if (_countPath != value)
                {
                    _countPath = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Multiplier
        {
            get => _multiplier;
            set
            {
                if (_multiplier != value)
                {
                    _multiplier = value;
                    RaisePropertyChanged();
                }
            }
        }
        public ModifierEnum ModifierType
        {
            get => _modifierType;
            set
            {
                if (_modifierType != value)
                {
                    _modifierType = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("Single");
                    RaisePropertyChanged("Binary");
                    RaisePropertyChanged("Count");
                }
            }
        }

        public bool Single
        {
            get
            {
                if (ModifierType == ModifierEnum.Single)
                    return true;
                else
                    return false;
            }
        }
        public bool Binary
        {
            get
            {
                if (ModifierType == ModifierEnum.Single)
                    return true;
                else
                    return false;
            }
        }
        public bool Count
        {
            get
            {
                if (ModifierType == ModifierEnum.Single)
                    return true;
                else
                    return false;
            }
        }

        //fields

        private readonly ILogger _logger;
        private Data _data;
        private Common.Classes.Amplitude_Simulator.SimulationModifierDescriptor _currentSim;
        private ModifierEnum _modifierType;
        private string _multiplier;
        private string _countPath;
        private string _right;
        private string _left;
        private bool _enforceRightAsPer;
        private ModifierOperation _binaryOperation;
        private string _value;
        private bool _valueMustBePositive;
        private bool _useIfInsteadOfWhere;
        private string _tooltipOverride;
        private bool _tooltipHiddenIfPathInvalid;
        private bool _tooltipHidden;
        private string _targetProperty;
        private bool _searchValueFromPath;
        private float _priority;
        private ModifierOperation _operation;
        private bool _forceFrom;
        private bool _enforceContext;
        private string _path;


        public SimulationModifierDescriptorViewModel(ILogger Logger, Data data)
        {
            Logger.Info($"{MethodBase.GetCurrentMethod().Name}");

            _logger = Logger;
            _data = data;
            Modifiers = _data.SimulationModifierDescriptorDefinitions;
            CurrentSim = null;
            LoadSim = new RelayCommand(canLoadSim, loadSim);
            NewSim = new RelayCommand(canNewSim, newSim);
            RaisePropertyChanged();
        }

        private void loadSim(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (Modifiers.Count > 0 && CurrentSim != null)
            {
                MainWindow.IsBusy = true;
                Path = CurrentSim.Path;
                EnforceContext = CurrentSim.EnforceContext;
                ForceFrom = CurrentSim.ForceFrom;
                Operation = CurrentSim.Operation;
                Priority = CurrentSim.Priority;
                SearchValueFromPath = CurrentSim.SearchValueFromPath;
                TargetProperty = CurrentSim.TargetProperty;
                TooltipHidden = CurrentSim.TooltipHidden;
                TooltipHiddenIfPathInvalid = CurrentSim.TooltipHiddenIfPathInvalid;
                TooltipOverride = CurrentSim.TooltipOverride;
                UseIfInsteadOfWhere = CurrentSim.UseIfInsteadOfWhere;
                ValueMustBePositive = CurrentSim.ValueMustBePositive;
                if (CurrentSim is SingleSimulationModifierDescriptor)
                {
                    ModifierType = ModifierEnum.Single;
                    var tmp = (SingleSimulationModifierDescriptor)CurrentSim;
                    Value = tmp.Value;
                }
                else if (CurrentSim is BinarySimulationModifierDescriptor)
                {
                    ModifierType = ModifierEnum.Binary;
                    var tmp = (BinarySimulationModifierDescriptor)CurrentSim;
                    BinaryOperation = tmp.BinaryOperation;
                    EnforceRightAsPer = tmp.EnforceRightAsPer;
                    Left = tmp.Left;
                    Right = tmp.Right;
                }
                else if (CurrentSim is CountSimulationModifierDescriptor)
                {
                    ModifierType = ModifierEnum.Count;
                    var tmp = (CountSimulationModifierDescriptor)CurrentSim;
                    CountPath = tmp.CountPath;
                    Multiplier = tmp.Multiplier;
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
            Modifiers.AddFromEnumerable(new Common.Classes.Amplitude_Simulator.SimulationModifierDescriptor[] { new Common.Classes.Amplitude_Simulator.SimulationModifierDescriptor() { Custom = true } });
            CurrentSim = Modifiers.Last();
        }

        private bool canNewSim(object obj)
        {
            return !MainWindow.IsBusy;
        }

        private void saveSim()
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (Modifiers.Count > 0 && CurrentSim != null)
            {
                MainWindow.IsBusy = true;
                bool modified = false;

                if (CurrentSim.Path != Path)
                {
                    CurrentSim.Path = Path;
                    RaisePropertyChanged(CurrentSim, "Path");
                    modified = true;
                }
                if (CurrentSim.EnforceContext != EnforceContext)
                {
                    CurrentSim.EnforceContext = EnforceContext;
                    RaisePropertyChanged(CurrentSim, "EnforceContext");
                    modified = true;
                }
                if (CurrentSim.ForceFrom != ForceFrom)
                {
                    CurrentSim.ForceFrom = ForceFrom;
                    RaisePropertyChanged(CurrentSim, "ForceFrom");
                    modified = true;
                }
                if (CurrentSim.Operation != Operation)
                {
                    CurrentSim.Operation = Operation;
                    RaisePropertyChanged(CurrentSim, "Operation");
                    modified = true;
                }
                if (CurrentSim.Priority != Priority)
                {
                    CurrentSim.Priority = Priority;
                    RaisePropertyChanged(CurrentSim, "Priority");
                    modified = true;
                }
                if (CurrentSim.SearchValueFromPath != SearchValueFromPath)
                {
                    CurrentSim.SearchValueFromPath = SearchValueFromPath;
                    RaisePropertyChanged(CurrentSim, "SearchValueFromPath");
                    modified = true;
                }
                if (CurrentSim.TargetProperty != TargetProperty)
                {
                    CurrentSim.TargetProperty = TargetProperty;
                    RaisePropertyChanged(CurrentSim, "TargetProperty");
                    modified = true;
                }
                if (CurrentSim.TooltipHidden != TooltipHidden)
                {
                    CurrentSim.TooltipHidden = TooltipHidden;
                    RaisePropertyChanged(CurrentSim, "TooltipHidden");
                    modified = true;
                }
                if (CurrentSim.TooltipHiddenIfPathInvalid != TooltipHiddenIfPathInvalid)
                {
                    CurrentSim.TooltipHiddenIfPathInvalid = TooltipHiddenIfPathInvalid;
                    RaisePropertyChanged(CurrentSim, "TooltipHiddenIfPathInvalid");
                    modified = true;
                }
                if (CurrentSim.TooltipOverride != TooltipOverride)
                {
                    CurrentSim.TooltipOverride = TooltipOverride;
                    RaisePropertyChanged(CurrentSim, "TooltipOverride");
                    modified = true;
                }
                if (CurrentSim.UseIfInsteadOfWhere != UseIfInsteadOfWhere)
                {
                    CurrentSim.UseIfInsteadOfWhere = UseIfInsteadOfWhere;
                    RaisePropertyChanged(CurrentSim, "UseIfInsteadOfWhere");
                    modified = true;
                }
                if (CurrentSim.ValueMustBePositive != ValueMustBePositive)
                {
                    CurrentSim.ValueMustBePositive = ValueMustBePositive;
                    RaisePropertyChanged(CurrentSim, "ValueMustBePositive");
                    modified = true;
                }
                if (ModifierType == ModifierEnum.Single)
                {
                    var tmp = (SingleSimulationModifierDescriptor)CurrentSim;
                    if (tmp.Value != Value)
                    {
                        tmp.Value = Value;
                        RaisePropertyChanged(tmp, "Value");
                        modified = true;
                    }
                }
                else if (ModifierType == ModifierEnum.Binary)
                {
                    var tmp = (BinarySimulationModifierDescriptor)CurrentSim;
                    if (tmp.BinaryOperation != BinaryOperation)
                    {
                        tmp.BinaryOperation = BinaryOperation;
                        RaisePropertyChanged(tmp, "BinaryOperation");
                        modified = true;
                    }
                    if (tmp.EnforceRightAsPer != EnforceRightAsPer)
                    {
                        tmp.EnforceRightAsPer = EnforceRightAsPer;
                        RaisePropertyChanged(tmp, "EnforceRightAsPer");
                        modified = true;
                    }
                    if (tmp.Left != Left)
                    {
                        tmp.Left = Left;
                        RaisePropertyChanged(tmp, "Left");
                        modified = true;
                    }
                    if (tmp.Right != Right)
                    {
                        tmp.Right = Right;
                        RaisePropertyChanged(tmp, "Right");
                        modified = true;
                    }
                }
                else if (ModifierType == ModifierEnum.Count)
                {
                    var tmp = (CountSimulationModifierDescriptor)CurrentSim;
                    if (tmp.CountPath != CountPath)
                    {
                        tmp.CountPath = CountPath;
                        RaisePropertyChanged(tmp, "CountPath");
                        modified = true;
                    }
                    if (tmp.Multiplier != Multiplier)
                    {
                        tmp.Multiplier = Multiplier;
                        RaisePropertyChanged(tmp, "Multiplier");
                        modified = true;
                    }
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
    public enum ModifierEnum
    {
        Single,
        Binary,
        Count
    }
}

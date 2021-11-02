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
using EndlessModding.EndlessSpace2.Common.Classes.HeroSkillTreeDefinitions;
using EndlessModding.EndlessSpace2.Common.Files;

namespace EndlessModding.EndlessSpace2.SkillTree
{
    public class SkillTreeViewModel : INotifyPropertyChanged
    {
        public EndlessSpace2ViewModel MainWindow { get; set; }
        public ObservableConcurrentCollection<HeroSkillTreeDefinition> SkillTrees { get; set; }

        private readonly ILogger _logger;
        public SkillTreeViewModel(ILogger Logger, Data data)
        {
            Logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            _logger = Logger;
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

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessModding.Common.DataStructures
{
    /// <summary>
    /// Provides a thread-safe, concurrent collection for use with data binding.
    /// </summary>
    /// <typeparam name="T">Specifies the type of the elements in this collection.</typeparam>
    [DebuggerDisplay("Count={Count}")]
    public class EndlessObservableConcurrentCollection<T> :
        ProducerConsumerCollectionBase<T>,
        INotifyCollectionChanged,
        INotifyPropertyChanged
    {
        private readonly SynchronizationContext _context;

        /// <summary>
        /// Initializes an instance of the EndlessObservableConcurrentCollection class with an underlying
        /// queue data structure.
        /// </summary>
        public EndlessObservableConcurrentCollection() : this(new ConcurrentQueue<T>()) { }

        /// <summary>
        /// Initializes an instance of the EndlessObservableConcurrentCollection class with the specified
        /// collection as the underlying data structure.
        /// </summary>
        public EndlessObservableConcurrentCollection(IProducerConsumerCollection<T> collection) : base(collection)
        {
            _context = AsyncOperationManager.SynchronizationContext;
        }

        /// <summary>Event raised when the collection changes.</summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        /// <summary>Event raised when a property on the collection changes.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies observers of CollectionChanged or PropertyChanged of an update to the dictionary.
        /// </summary>
        private void NotifyObserversOfChange()
        {
            var collectionHandler = CollectionChanged;
            var propertyHandler = PropertyChanged;
            if (collectionHandler != null || propertyHandler != null)
            {
                _context.Post(s =>
                {
                    if (collectionHandler != null)
                    {
                        collectionHandler(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                    }
                    if (propertyHandler != null)
                    {
                        propertyHandler(this, new PropertyChangedEventArgs("Count"));
                    }
                }, null);
            }
        }

        public bool AddRange(IEnumerable<T> items)
        {
            bool result = false;
            foreach (var item in items)
            {
                result = base.TryAdd(item);
            }
            if (result) NotifyObserversOfChange();
            return result;
        }

        public bool Add(T item) => TryAdd(item);
        public bool Take(out T item) => TryTake(out item);

        protected override bool TryAdd(T item)
        {
            // Try to add the item to the underlying collection.  If we were able to,
            // notify any listeners.
            bool result = base.TryAdd(item);
            if (result) NotifyObserversOfChange();
            return result;
        }

        protected override bool TryTake(out T item)
        {
            // Try to remove an item from the underlying collection.  If we were able to,
            // notify any listeners.
            bool result = base.TryTake(out item);
            if (result) NotifyObserversOfChange();
            return result;
        }
    }

}

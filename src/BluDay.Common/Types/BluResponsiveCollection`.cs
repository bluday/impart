using System.Collections.ObjectModel;
using System.Collections.Specialized;

using CollectionAction = System.Collections.Specialized.NotifyCollectionChangedAction;

using ChangedEventsArgs = System.Collections.Specialized.NotifyCollectionChangedEventArgs;

namespace BluDay.Common.Types
{
    public class BluResponsiveCollection<T> : ObservableCollection<T>
    {
        public event NotifyCollectionChangedEventHandler CollectionChanging;

        private void OnCollectionChanging(CollectionAction action, T item, int index)
        {
            OnCollectionChanging(new ChangedEventsArgs(action, item, index));
        }

        private void OnCollectionChanging(CollectionAction action, T item, int index, int oldIndex)
        {
            OnCollectionChanging(new ChangedEventsArgs(action, item, index, oldIndex));
        }

        private void OnCollectionChanging(CollectionAction action, T oldItem, T newItem, int index)
        {
            OnCollectionChanging(new ChangedEventsArgs(action, newItem, oldItem, index));
        }

        private void OnCollectionChanging(ChangedEventsArgs args)
        {
            CollectionChanging?.Invoke(this, args);
        }

        private void OnCollectionClearing()
        {
            OnCollectionChanging(new ChangedEventsArgs(CollectionAction.Reset));
        }

        protected override void ClearItems()
        {
            OnCollectionClearing();

            base.ClearItems();
        }

        protected override void InsertItem(int index, T item)
        {
            OnCollectionChanging(CollectionAction.Add, item, index);

            base.InsertItem(index, item);
        }

        protected override void MoveItem(int oldIndex, int newIndex)
        {
            OnCollectionChanging(CollectionAction.Move, this[oldIndex], newIndex, oldIndex);

            base.MoveItem(oldIndex, newIndex);
        }

        protected override void RemoveItem(int index)
        {
            OnCollectionChanging(CollectionAction.Remove, this[index], index);

            base.RemoveItem(index);
        }

        protected override void SetItem(int index, T item)
        {
            OnCollectionChanging(CollectionAction.Replace, this[index], item, index);

            base.SetItem(index, item);
        }
    }
}
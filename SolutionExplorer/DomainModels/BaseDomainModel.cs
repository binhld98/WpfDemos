using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SolutionExplorer.DomainModels
{
    [Serializable]
    internal abstract class BaseDomainModel : INotifyPropertyChanged
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Child class may call this method explicitly in the property setter.
        /// </summary>
        /// <param name="propertyName"></param>
        protected void Notify([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Set value to a property and raise the PropertyChanged event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="member"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        protected virtual void Set<T>(ref T member, T value, [CallerMemberName] string propertyName = "")
        { 
            if (Equals(member, value))
                return;

            member = value;
            Notify(propertyName);
        }

        /// <summary>
        /// Set value to a property and raise the PropertyChanged event of itself and a list of other properties.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="member"></param>
        /// <param name="value"></param>
        /// <param name="properties"></param>
        /// <param name="propertyName"></param>
        protected virtual void Set<T>(ref T member, T value, string[] properties, [CallerMemberName] string propertyName = "")
        {
            Set(ref member, value, propertyName);

            if (properties == null || properties.Length <= 0)
                return;

            foreach (var prop in properties)
                Notify(prop);
        }

        /// <summary>
        /// Set value to a property as well as a predicate to validate value.
        /// This requires the control to enable the ValidatesOnExceptions property in the binding.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="member"></param>
        /// <param name="value"></param>
        /// <param name="predicate"></param>
        /// <param name="exMessage"></param>
        /// <param name="propertyName"></param>
        /// <exception cref="Exception"></exception>
        protected virtual void Set<T>(ref T member, T value, Predicate<T> predicate, string exMessage, [CallerMemberName] string propertyName = "")
        {
            if (Equals(member, value))
                return;

            if (!predicate(value))
                throw new Exception(exMessage);

            member = value;
            Notify(propertyName);
        }
    }
}

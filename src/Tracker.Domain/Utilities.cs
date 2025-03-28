namespace Tracker.Domain
{
    using Tracker.Domain.Exceptions;

    // Just a class with some utility functions
    public static class Utilities
    {
        /// <summary>
        /// Adds to a given list, items from another list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="targetList"></param>
        /// <param name="items"></param>
        /// <exception cref="NoItemsProvidedException"></exception>
        public static void AddItemsFromList<T>(List<T> targetList, IEnumerable<T> items)
        {
            if (items == null || items.Any())
            {
                throw new NoItemsProvidedException("No items provided.");
            }
            targetList.AddRange(items);
        }

        /// <summary>
        /// Removes from a given list, items from another list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="targetList"></param>
        /// <param name="items"></param>
        /// <exception cref="NoItemsProvidedException"></exception>
        public static void RemoveItemsFromList<T>(List<T> targetList, IEnumerable<T> items)
        {
            if (items == null || items.Any())
            {
                throw new NoItemsProvidedException("No items provided.");
            }
            targetList.RemoveAll(items.Contains);
        }
    }
}

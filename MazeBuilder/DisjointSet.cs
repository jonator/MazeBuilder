using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MazeBuilder
{
   public class DisjointSet<T> : IEnumerable<T>
   {
      private List<T> items;

      public DisjointSet() : this(new T[]{})
      {
      }

      public DisjointSet(T primingItem) : this(new []{primingItem})
      {
         
      }

      public DisjointSet(IEnumerable<T> primingItems)
      {
         items = new List<T>();
         items.AddRange(primingItems);
      }

      public bool AreDisjoint(DisjointSet<T> setToCompare)
      {
         return !setToCompare.items.Intersect(items).Any();
      }

      public void Merge(DisjointSet<T> setToMerge)
      {
         items = setToMerge.items.Union(items).ToList();
      }

      public IEnumerator<T> GetEnumerator()
      {
         return items.GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return GetEnumerator();
      }
   }
}

using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.HeapsAndMaps
{
    public class LRU
    {
        public static void Execute()
        {
            //var lru = new LRU(1);
            //lru.set(2, 1);
            //lru.set(2, 2);
            //lru.get(2).Dump();
            //lru.set(1, 1);
            //lru.set(4, 1);
            //lru.get(2).Dump();
          // 7 2 G 2 S 2 6 G 1 S 1 5 S 1 2 G 1 G 2
            var lru = new LRU(2);
            //lru.get(2).Dump();
            lru.set(2, 1);
            lru.set(1, 1);
            lru.set(2, 3);
            lru.set(4, 1);
            lru.get(1).Dump();
            lru.get(2).Dump();
        }

        int _capacity;
        int _count = 0;
        Dictionary<int, int> _store;
        LinkedList<int> _lruQueue = new LinkedList<int>();

        public LRU(int capacity)
        {
            _capacity = capacity;
            _store = new Dictionary<int, int>(capacity);
        }

        public int get(int key)
        {
            if (_store.ContainsKey(key))
            {
                _lruQueue.Remove(key);
                _lruQueue.AddLast(key);
                return _store[key];
            }
            return -1;
        }

        public void set(int key, int value)
        {
            var exist = _store.ContainsKey(key);
            if (!exist)
            {
                _count++;
            }
            else
            {
                _lruQueue.Remove(key);
            }
            _lruQueue.AddLast(key);

            if (_count > _capacity)
            {
                var toRemove = _lruQueue.First();
                _store.Remove(toRemove);
                _lruQueue.RemoveFirst();
                _count--;
            }
            _store[key] = value;
        }
    }
}

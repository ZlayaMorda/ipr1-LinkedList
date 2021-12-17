using System.Collections;


namespace LinckedList
{
    class LinckList<T> : IEnumerable
    {
        public Item<T> Head{ get; private set; }
        public Item<T> Tail { get; private set; }
        public int Count { get; private set; }

        public delegate void CollHandler(string message);
        public event CollHandler Notify;

        public LinckList()
        {
            Clear();
        }
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
            Notify?.Invoke($"List has been cleared");
        }
        public LinckList(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }

        public void AddLast(T data)
        {
            var item = new Item<T>(data);
            if(Tail != null)
            {
                Tail.Next = item;
                Tail = item;
                Count++;
                Notify?.Invoke($"Item {data} has been added as the last one");
            }
            else
            {
                Head = item;
                Tail = item;
                Count = 1;
                Notify?.Invoke($"Item {data} has been added as the last one");
            }
        }

        public void AddFirst(T data)
        {
            if (Head != null)
            {
                var item = new Item<T>(data) {Next = Head };
                Head = item;
                Count++;
                Notify?.Invoke($"Item {data} has been added as the first one");
            }
            else
            {
                var item = new Item<T>(data);
                Head = item;
                Tail = item;
                Count = 1;
                Notify?.Invoke($"Item {data} has been added as the first one");
            }
        }

        public void Delete(T data)
        {
            if(Head != null)
            {
                if(Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    Notify?.Invoke($"Item {data} has been deleted");
                    return;
                }

                var Current = Head.Next;
                var Previous = Head;


                while(Current != null)
                {
                    if(Current.Data.Equals(data))
                    {
                        Previous.Next = Current.Next;
                        Count--;
                        Notify?.Invoke($"Item {data} has been deleted");
                        return;
                    }
                    Previous = Current;
                    Current = Current.Next;
                }
            }
            Notify?.Invoke($"Item {data} doesn't exist in the list");
        }

        public IEnumerator GetEnumerator()
        {
            var Current = Head;
            while(Current != null)
            {
                yield return Current.Data;
                Current = Current.Next;
            }
        }
    }
}

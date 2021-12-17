using System;

namespace LinckedList
{
    public class Item<T>
    {
        private T data = default;
        public Item(T data)
        {
            this.data = data;
        }
        public Item<T> Next { get; set; }
        public T Data
        {
            get { return data; }
            set
            {
                if(value != null)
                    data = value;
                else
                    throw new ArgumentNullException(nameof(value));
            }
        }

    }
    
}

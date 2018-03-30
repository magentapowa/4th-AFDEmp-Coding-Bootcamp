using System;

namespace Lists
{
    public class LinkedList
    {
        //Node class
        private class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            // Node Constructor
            public Node(int Value, Node previous){
                this.Value = Value;
                this.Next = null;
                this.Previous = previous;
            }
        }


        //Fields n' Properties (of LinkedList)
        private Node Head;
        private Node Tail;

        public int Count
        {
            get
            {
                int _counter = 0;
                if (Head == null)
                {
                    return _counter;
                }
                Node current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                    _counter++;
                }
                Tail = current;
                _counter++;
                return _counter;
            }
        }

        //
        // Constractor. 'Create new list.
        public LinkedList()
        {
            this.Head = null;
        }


        //
        //Methods
        //
        //
        // Append item in list
        public void Append(int value)
        {   
            //Check if list is empty
            if (Head == null)
            {
                Head = new Node(value, null);
                return;
            }

            Node current = Head;
            while (current.Next!=null)
            {
                current = current.Next;
            }

            current.Next = new Node(value,current);
        }
        // Get item
        public string GetString()
        {
            string result = "[";
            if (Head != null)
            {
                Node current = Head;
                while (current.Next != null)
                {
                    result += $"{current.Value}, ";
                    current = current.Next;

                }   
                result += $"{current.Value}";
            }
            result += "]";
            return result;
        }
        // Revert/flip
        public void Revert()
        {
            Node temp;
            Node current = Head;
            while (current.Next != null)
            {
                temp = current.Next;
                current.Next = current.Previous;
                current.Previous = temp;

                current = current.Previous;
            }

            temp = current.Next;
            current.Next = current.Previous;
            current.Previous = temp;

            Head = current;
        }
        // Access the list by index Get(i)
        public int? Get(int index)
        {
            int? result = null;
            if (Head == null)
            {
                //Console.WriteLine("List is empty.");
                return result;

            }

            int _counter = 0;
            bool flag = false;
            Node current = Head;
            while (current.Next != null)
            {
                if (_counter == index)
                {
                    flag = true;
                    break;
                }
                current = current.Next;
                _counter++;
            }

            if (flag)
            {
                return current.Value;
            }
            //Console.WriteLine("List index out of range.");
            //return result;
            throw new Exception("List index out of range.");

        }
        // Remove item at index Remove(i)
        public void Remove(int index)
        {   
            if (Head == null)
            {
                return;
            }

            bool flag = false;
            Node current = Head;
            for (int i = 0; i < Count; i++)
            {

                if (i==index)
                {
                    flag = true;
                }

                if (flag == true)
                {
                    if (current.Next==null)
                    {
                        current.Previous.Next = null;
                        current = null;
                        break;
                    }
                    else
                    {
                        current.Value = current.Next.Value;
                        //current.Next = current.Next.Next;
                        //current.Next.Previous = current;
                    }

                }
                current = current.Next;
            }
        }

    }
}

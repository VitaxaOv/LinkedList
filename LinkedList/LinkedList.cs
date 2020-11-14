using System;
using System.Collections.Generic;
using System.Text;

namespace DataDataStructures.LL
{
    public class LinkedList
    {
        public int Length { get; private set; }
        private Node _root;

        public LinkedList()
        {
            Length = 0;
            _root = null;
        }
        public LinkedList(int[] array)
        {
            Length = array.Length;

            if (array.Length != 0)
            {
                _root = new Node(array[0]);
                Node tmp = _root;
                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    tmp = tmp.Next;
                }
            }
            else
            {
                _root = null;
            }
        }

        public int this[int index]
        {
            get
            {
                Node tmp = _root;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }

            set
            {
                Node tmp = _root;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }
        public int GetLength()
        {
            return Length;
        }
        public void Reverse()
        {
            Node crnt = _root;
            for (int i = 0; i < Length / 2; i++)
            {
                Node crntend = _root;
                for (int j = 0; j < Length - 1-i; j++)
                {
                    crntend = crntend.Next;
                }

                int tmpvalue = crnt.Value;
                crnt.Value = crntend.Value;
                crntend.Value = tmpvalue;
                crnt = crnt.Next;
            }
            }
        public int IndexByValue(int value)
        {
            Node crnt = _root;
            for (int i = 0; i < Length; i++)
            {
                if (crnt.Value == value)
                {
                    return i;
                }
                crnt = crnt.Next;
            }
            return -1;
        }
        
        public void AddInBegin(int value)
        {
            AddByIndex(0, value);
        }
        public void AddInEnd(int value)
        {
            AddByIndex(Length, value);
        }
        public void AddByIndex(int index, int value)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index != 0)
            {
                Node crnt = _root;
                for (int i = 0; i < index - 1; i++)
                {
                    crnt = crnt.Next;
                }
                Node tmp = new Node(value);
                tmp.Next = crnt.Next;//tmp будет указывать на то на что указывала crnt
                crnt.Next = tmp;//говорим что crnt будет указывать на tmp
            }
            else
            {
                Node tmp = new Node(value);
                tmp.Next = _root;
                _root = tmp;
            }
            Length++;
        }
        public void PopByIndex(int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index != 0)
            {
                Node crnt = _root;
                for (int i = 0; i < index-1; i++)
                {
                    crnt = crnt.Next;
                }
                Node tmp = crnt ;
                tmp = tmp.Next;
                crnt.Next = tmp.Next;
                tmp.Next = null;
                
            }
            else
            {
                Node crnt = _root;
                Node tmp = crnt;
                tmp = tmp.Next;
                _root = tmp;
                crnt.Next = null;
            }
            Length--;
        }
        public void PopInEnd()
        {
           PopByIndex(Length-1);
        }
        public void PopInBegin()
        {
            PopByIndex(0);
        }
        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList)obj;

            if (Length != linkedList.Length)
            {
                return false;
            }

            Node tmp1 = _root;
            Node tmp2 = linkedList._root;

            for (int i = 0; i < Length; i++)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            return true;
        }
        public override string ToString()
        {
            string s = "";

            Node tmp = _root;
            for (int i = 0; i < Length; i++)
            {
                s += tmp.Value + ";";
                tmp = tmp.Next;
            }
            return s;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}

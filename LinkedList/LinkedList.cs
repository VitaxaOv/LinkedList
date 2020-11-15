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
        public int FindMinIndex()
        {
            if (Length == 0)
            {
                throw new Exception("Массив пустой");
            }
            int index = -1;
            int max = 999999;
            Node tmp=_root;
            for (int i = 0; i < Length; i++)
            {
                if (max > tmp.Value)
                {
                    max = tmp.Value;
                    index = i;
                }
                tmp = tmp.Next;
            }
            return index;
        }
        public int FindMaxIndex()
        {
            if (Length == 0)
            {
                throw new Exception("Массив пустой");
            }
            int index = 0;
            int max = -999999;
            Node tmp = _root;
            for (int i = 0; i < Length; i++)
            {
                if (max < tmp.Value)
                {
                    max = tmp.Value;
                    index = i;
                }
                tmp = tmp.Next;
            }
            return index;
        }

       public int FindMax()
        {
            Node crnt = _root;
            for(int i = 0; i < FindMaxIndex(); i++)
            {
                crnt = crnt.Next;
            }
            return crnt.Value;
        }
        public int FindMin()
        {
            Node crnt = _root;
            for (int i = 0; i < FindMinIndex(); i++)
            {
                crnt = crnt.Next;
            }
            return crnt.Value;
        }
        public void ArraySort()
        {
            Node crnti = _root;
            for(int i = 0; i < Length; i++)
            {
                Node crntj = _root;
                crntj = crntj.Next;
                for(int j = 1; j < Length; j++)
                {
                    if (j > i)
                    {
                        if (crnti.Value > crntj.Value)
                        {
                            int tmp;
                            tmp = crnti.Value;
                            crnti.Value = crntj.Value;
                            crntj.Value = tmp;
                        }
                    }
                    crntj = crntj.Next;
                }
                crnti = crnti.Next;
            }
        }
        public void ArraySortReverse()
        {
            Node crnti = _root;
            for (int i = 0; i < Length; i++)
            {
                Node crntj = _root;
                crntj = crntj.Next;
                for (int j = 1; j < Length; j++)
                {
                    if (j > i)
                    {
                        if (crnti.Value < crntj.Value)
                        {
                            int tmp;
                            tmp = crnti.Value;
                            crnti.Value = crntj.Value;
                            crntj.Value = tmp;
                        }
                    }
                    crntj = crntj.Next;
                }
                crnti = crnti.Next;
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
        public void AddByIndexArray(int index, int[]array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                AddByIndex(index + i, array[i]);
            }
        }
        public void AddBeginArray(int []array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                AddByIndex(i, array[i]);
            }
        }
        public void AddAndArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                AddByIndex(Length+i, array[i]);
            }
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
      public void PopByIndexArray(int index,int size)
        {
            if (size > Length - index)
            {
                throw new IndexOutOfRangeException();
            }
            for(int i = 0; i < size; i++)
            {
                PopByIndex(index);
            }
        }
        public void PopInEndArray(int size)
        {
            for (int i = 0; i < size; i++)
            {
                PopInEnd();
            }
        }
        public void PopInBeginArray(int size)
        {
            for (int i = 0; i < size; i++)
            {
                PopInBegin();
            }
        }
        public void PopInEnd()
        {
           PopByIndex(Length-1);
        }
        public void PopInBegin()
        {
            PopByIndex(0);
        }
        public void DeleteByFirst()
        {
            Node crnt = _root;
            crnt = crnt.Next;
            
            for (int j = 1; j < Length; j++)
            {

                if (_root.Value != crnt.Value)
                {
                    crnt = crnt.Next;

                }
                else {
                    PopByIndex(j);
                    j -= 1;
                }
            }
        }
        public void DeleteEqual()
        {
            Node crnti = _root;
            for (int i = 0; i < Length - 1; i++)
            {
                Node crntj = crnti;
                crntj = crntj.Next;
                for (int k = i+1; k < Length ; k++)
                {
                    
                    if (crntj.Value != crnti.Value)
                    {
                        crntj = crntj.Next;
                    }
                    else
                    {
                        Node tmp = crntj;
                        tmp = tmp.Next;
                        
                        PopByIndex(k);
                        k -= 1;
                        crntj = tmp;
                    }
                    
                }
                crnti = crnti.Next;
            }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1ED1.DLL
{
    public class LISTADE<T>
    {
        public class Node
        {
            public Node NextNode;
            public Node PreviusNode;
            public T Item;

            public Node(Node NpreviusNode, Node NnextNode, T Nitem)
            {
                this.Item = Nitem;
                this.NextNode = NnextNode;
                this.PreviusNode = NpreviusNode;
            }
        }
        Node FirstNode = new Node(null, null, default(T));
        Node LastNode = new Node(null, null, default(T));
        int Size = 0;

        public LISTADE()
        {
            FirstNode.NextNode = LastNode;
            LastNode.PreviusNode = FirstNode;
        }//builder

        public void AddItem(T item)
        {
            Node newNode = new Node(LastNode.PreviusNode, LastNode, item);

            LastNode.PreviusNode.NextNode = newNode;
            LastNode.PreviusNode = newNode;
            Size++;
        }

        public T Get(int id)
        {
            Node temp = FirstNode.NextNode;
            for (int i = 0; i < this.Size; i++)
            {
                if (temp.Item.Equals(id)) return temp.Item;
                else temp = temp.NextNode;
            }
            return default(T);
        }

        public int GetSize()
        {
            return Size;
        }

        public bool IsEmpty()
        {
            if (Size == 0) return true;
            return false;
        }

        public T Remove(int ItemToDelete)
        {
            if (!this.IsEmpty())
            {
                Node temp = FirstNode.NextNode;
                for (int i = 0; i < Size; i++)
                {
                    if (temp.Item.Equals(ItemToDelete))
                    {
                        temp.PreviusNode.NextNode = temp.NextNode;
                        temp.NextNode.PreviusNode = temp.PreviusNode;
                        temp.PreviusNode = null;
                        temp.NextNode = null;
                        Size--;
                        return temp.Item;
                    }
                    else temp = temp.NextNode;
                }
            }
            return default(T);
        }

        public void Set(int ItemID, T newData)
        {
            Node temp = FirstNode.NextNode;
            for (int i = 0; i < this.Size; i++)
            {
                if (temp.Item.Equals(ItemID)) temp.Item = newData;
                else temp = temp.NextNode;
            }
        }

        public List<T> ToList()
        {
            List<T> TempList = new List<T>();
            Node tempNode = FirstNode.NextNode;
            for (int i = 0; i < Size; i++)
            {
                TempList.Add(tempNode.Item);
                tempNode = tempNode.NextNode;
            }
            return TempList;
        }

        public T GetFirst()
        {
            return FirstNode.Item;
        }

        public T GetNext(T item)
        {
            Node temp = FirstNode.NextNode;
            for (int i = 0; i < this.Size; i++)
            {
                if (temp.Item.Equals(item)) return temp.NextNode.Item;
                else temp = temp.NextNode;
            }
            return default(T);
        }
    }





    }
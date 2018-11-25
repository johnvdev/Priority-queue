using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ToDoList
{
    class PriorityQueue 
    {
        private ToDo first;

        public int Count
        {
            get
            {
                int c = 0;//number of items
                ToDo current = first;
                while (current != null)//keep looping until the last items next doesnt exist
                {
                    c++;//add to number of items
                    current = current.Next;//shift forward in the list
                }
                return c;
            }
        }
        

        public void Enqueue(ToDo newT)
        {
            if(first == null)//first item in the list
            {
                first = newT;
            }
            else
            {
                ToDo node = first;
                ToDo prev = null;

                while(node !=null)
                {
                    if(newT.Priority <= node.Priority && (node.Next == null ||newT.Priority > node.Next.Priority))
                    {
                        newT.Next = node.Next;
                        node.Next = newT;
                        break;
                    }
                    else if(newT.Priority >= node.Priority && (node.Next == null || newT.Priority > node.Next.Priority))
                    {
                        if(prev == null)
                        {
                            newT.Next = node;
                            first = newT;
                            break;
                        }
                        else
                        {
                            prev.Next = newT;
                            newT.Next = node;
                            break;

                        }
                    }
                    else
                    {
                        prev = node;
                        node = node.Next;
                    }

                }
            }
        }

        public void Dequeue()//most important done first so we shift to the next most important
        {
            first = first.Next;
        }

        public ToDo Peek()//find most important
        {
            return first;
        }
        public void Clear()//we clear our todo list
        {
            first = null;
        }
        public List<KeyValuePair<string,int>> Statistics()
        {
            List<KeyValuePair<string, int>> stats = new List<KeyValuePair<string, int>>();
            ToDo node = first;
            int low = 0;
            int normal = 0;
            int high = 0;
            int crit = 0;
            int total = 0;

            while (node !=null)
            {
                if (node.Priority == 1) low++;
                if (node.Priority == 2) normal++;
                if (node.Priority == 3) high++;
                if (node.Priority == 4) crit++;
                total++;
                node = node.Next;
            }
            stats.Add(new KeyValuePair<string, int>("Low", low));
            stats.Add(new KeyValuePair<string, int>("Normal", normal));
            stats.Add(new KeyValuePair<string, int>("High", high));
            stats.Add(new KeyValuePair<string, int>("Critical", crit));
            stats.Add(new KeyValuePair<string, int>("Total", total));

            return stats;
        }
    }
}

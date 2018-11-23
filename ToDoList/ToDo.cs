using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class ToDo : IEquatable<ToDo>
    {
        private string name;
        private int priority;
        private ToDo next;


        public string Task { get { return name; } }
        public int Priority { get { return priority; } }
        public ToDo Next
        {
            get { return next; }
            set { next = value; }
        }

        public ToDo (string n, int p)
        {
            name = n;
            priority = p;
            next = null;
        }

        public static bool operator <=(ToDo td1, ToDo td2)
        {
            if (td1 == null || td2 == null)
                throw new ArgumentNullException();

            else return (td1.priority <= td2.priority);
        }

        public static bool operator >=(ToDo td1, ToDo td2)
        {
            if (td1 == null || td2 == null)
                throw new ArgumentNullException();

            else return (td1.priority >= td2.priority);
        }



        public bool Equals(ToDo other)
        {
            return this.name == other.name;
        }
    }
}

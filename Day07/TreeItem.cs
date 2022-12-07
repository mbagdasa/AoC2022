using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    public class TreeItem
    {
        public TreeItem ?Parent { get; set; }
        public List<TreeItem> Children { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int Level { get; set; }

        public TreeItem(string name)
        {
            Name = name;
            Children = new List<TreeItem>();
        }

        public void printTree()
        {
            Console.WriteLine($"- {String.Concat(Enumerable.Repeat("  ", this.Level))}{this.Name} ({this.Size})");

            foreach (var child in Children)
            { 
                child.printTree();
            }
        }

        //public void setDirSize()
        //{
            
        //    foreach (var child in Children)
        //    {
        //        child.printTree();
        //    }
        //}


        public TreeItem findChild(string name)
        {
            foreach (var child in Children)
            {
                if (child.Equals(name))
                {
                    return child;
                }
                else
                {
                    return child.findChild(name);
                }
            }

            return null;
            
        }
    }
}

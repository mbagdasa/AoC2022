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

        public int GetSizeDirThreshold(int sum)
        {
            if (this.Size < 100000 && this.Children.Count > 0)
            {
                sum += this.Size;
            }

            foreach (var child in Children)
            {
                sum = child.GetSizeDirThreshold(sum);
            }

            return sum;
        }

        public void GetSmallestDir(int sizeToDelete, List<int> folders)
        {
            if (this.Size > sizeToDelete && this.Children.Count > 0)
            {
                folders.Add(this.Size);
            }

            foreach (var child in Children)
            {
                child.GetSmallestDir(sizeToDelete, folders);
            }
        }

        public int SetDirSize()
        {
            var size = this.Size;
            foreach (var child in Children)
            {
                size += child.SetDirSize();
            }
            this.Size = size;
            return size;
        }

    }
}

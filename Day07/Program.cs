using Input;

namespace Day07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputList = ReadPuzzleInput.GetFullText(7).Split("|")
                                    .Where(x => !string.IsNullOrEmpty(x))
                                    .Select(x => x.Split(" ")
                                    .Where(x => !string.IsNullOrEmpty(x))
                                    .ToList());

            TreeItem ?currentDirectory = null;
            foreach (var item in inputList)
            {
                if (item[1].Equals("ls"))
                {
                    continue;
                }

                // is command?
                if (item[0].Equals("$") && item[1].Equals("cd") && item[2].Equals(".."))
                {
                    //parent von currentDirectory als currentDirectory setzen
                    var parentDirectory = currentDirectory.Parent;
                    currentDirectory = parentDirectory;
                }
                else if (item[0].Equals("$") && item[1].Equals("cd"))
                {
                    if (currentDirectory is null)
                    {
                        currentDirectory = new TreeItem(item[2]);
                    }
                    //currentDirectory.Level++;
                    if (currentDirectory.Children.Count > 0)
                    {
                        currentDirectory = currentDirectory.Children.FirstOrDefault(x => x.Name == item[2]);
                    }
                }
                else
                {
                    
                    var child = new TreeItem(item[1])
                    {
                        Name = item[1],
                        Size = item[0].Equals("dir") ? 0 : int.Parse(item[0]),
                        Parent = currentDirectory,
                        Level = currentDirectory.Level + 1
                    };

                    currentDirectory.Children.Add(child);
                }   
            }

            while (currentDirectory.Parent is not null)
            {
                currentDirectory = currentDirectory.Parent;
            }

            var run = currentDirectory.SetDirSize();
            currentDirectory.printTree();
            Console.WriteLine(currentDirectory.GetSizeDirThreshold(0));

            var diff =  70000000 - currentDirectory.Size;
            var sizeToDelete = 30000000 - diff;
            List<int> folders = new();
            Console.WriteLine(diff);

            currentDirectory.GetSmallestDir(sizeToDelete, folders);
            Console.WriteLine(folders.Min());
        }
    }

}
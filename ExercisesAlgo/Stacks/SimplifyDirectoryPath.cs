using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Stacks
{
    public class SimplifyDirectoryPath
    {
        public void Execute()
        {
            var result = simplifyPath("/../");
            result.Dump();
        }
        public string simplifyPath(string A)
        {
            var pathStack = new List<string>();
            var path = A.Split('/');
            foreach (var dir in path)
            {
                if (dir.Equals(".."))
                {
                    if (pathStack.Count > 0)
                    {
                        pathStack.RemoveAt(pathStack.Count - 1);
                    }
                }
                else if (!dir.Equals(".") && !string.IsNullOrEmpty(dir))
                {
                    pathStack.Add(dir);
                }
            }
            var result = new StringBuilder();
            foreach (var item in pathStack)
            {
                result.Append("/");
                result.Append(item);
            }
            if (result.Length == 0)
            {
                result.Append("/");
            }
            return result.ToString();
        }
    }
}

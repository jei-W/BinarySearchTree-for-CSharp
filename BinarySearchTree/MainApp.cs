using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class MainApp
    {
        static void Main( string[] args )
        {
            BinarySearchTree tree = new BinarySearchTree();

            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(7);
            tree.Insert(8);
            tree.Insert(11);

            tree.PostorderTraversal(tree.rootNode);
            Console.WriteLine("\n");
            tree.PreorderTraversal(tree.rootNode);
            Console.WriteLine("\n");
            tree.InorderTraversal(tree.rootNode);
        }
    }
}

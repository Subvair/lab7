using System;

class Program
{
  static void Main()
  {
    var tree = new BinaryTree<int>();

    tree.Insert(5);
    tree.Insert(3);
    tree.Insert(7);
    tree.Insert(1);
    tree.Insert(4);

    Console.WriteLine("In-order traversal with foreach:");
    foreach (int value in tree)
    {
      Console.Write(value + " ");
    }

    Console.WriteLine("\nFiltered traversal (even numbers):");
    foreach (int evenValue in tree.FilteredTraversal(node => node.Value % 2 == 0))
    {
      Console.Write(evenValue + " ");
    }

    Console.WriteLine("\nManual iteration using Next():");
    BinaryTreeNode<int> iteratedNode;
    while ((iteratedNode = tree.Next()) != null)
    {
      Console.Write(iteratedNode.Value + " ");
    }
  }
}

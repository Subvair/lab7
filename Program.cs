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

        Console.WriteLine("Foreach (in-order):");
        foreach (var value in tree)
            Console.Write(value + " ");

        Console.WriteLine("\nExternal iterator (четные значения):");
        foreach (var value in tree.ExternalIterator(n => n.Value % 2 == 0))
            Console.Write(value + " ");

        Console.WriteLine("\nTesting Next():");
        var node = tree.GetRoot().Left; 
        var next = tree.Next(node);
        Console.WriteLine($"Next of {node.Value} is {(next != null ? next.Value.ToString() : "null")}");
    }
}

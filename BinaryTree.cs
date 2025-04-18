using System;
using System.Collections;
using System.Collections.Generic;

public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
{
  private BinaryTreeNode<T> root;

  public void Insert(T value)
  {
    if (root == null)
      root = new BinaryTreeNode<T>(value);
    else
      Insert(root, value);
  }

  private void Insert(BinaryTreeNode<T> node, T value)
  {
    if (value.CompareTo(node.Value) < 0)
    {
      if (node.Left == null)
      {
        node.Left = new BinaryTreeNode<T>(value) { Parent = node };
      }
      else Insert(node.Left, value);
    }
    else
    {
      if (node.Right == null)
      {
        node.Right = new BinaryTreeNode<T>(value) { Parent = node };
      }
      else Insert(node.Right, value);
    }
  }

  public IEnumerator<T> GetEnumerator()
  {
    foreach (var node in InOrderTraversal(root))
      yield return node.Value;
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

  private IEnumerable<BinaryTreeNode<T>> InOrderTraversal(BinaryTreeNode<T> node)
  {
    if (node != null)
    {
      foreach (var n in InOrderTraversal(node.Left))
        yield return n;

      yield return node;

      foreach (var n in InOrderTraversal(node.Right))
        yield return n;
    }
  }
  public BinaryTreeNode<T> Next(BinaryTreeNode<T> x)
  {
    if (x.Right == null)
    {
      if (x.Parent == null || x == x.Parent.Right)
        return null;
      else
        return x.Parent;
    }
    else
    {
      var y = x.Right;
      while (y.Left != null)
        y = y.Left;
      return y;
    }
  }

  public BinaryTreeNode<T> Previous(BinaryTreeNode<T> x)
  {
    if (x.Left == null)
    {
      if (x.Parent == null || x == x.Parent.Left)
        return null;
      else
        return x.Parent;
    }
    else
    {
      var y = x.Left;
      while (y.Right != null)
        y = y.Right;
      return y;
    }
  }

  public IEnumerable<T> ExternalIterator(Func<BinaryTreeNode<T>, bool> predicate)
  {
    foreach (var node in InOrderTraversal(root))
    {
      if (predicate(node))
        yield return node.Value;
    }
  }

  public BinaryTreeNode<T> GetRoot() => root;
}

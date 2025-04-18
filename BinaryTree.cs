using System;
using System.Collections;
using System.Collections.Generic;

public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
{
  private BinaryTreeNode<T> _root;
  private BinaryTreeNode<T> _currentNode;

  public void Insert(T value)
  {
    if (_root == null)
    {
      _root = new BinaryTreeNode<T>(value);
      return;
    }

    InsertNode(_root, value);
  }

  private void InsertNode(BinaryTreeNode<T> currentNode, T value)
  {
    if (value.CompareTo(currentNode.Value) < 0)
    {
      if (currentNode.Left == null)
      {
        currentNode.Left = new BinaryTreeNode<T>(value) { Parent = currentNode };
      }
      else
      {
        InsertNode(currentNode.Left, value);
      }
    }
    else
    {
      if (currentNode.Right == null)
      {
        currentNode.Right = new BinaryTreeNode<T>(value) { Parent = currentNode };
      }
      else
      {
        InsertNode(currentNode.Right, value);
      }
    }
  }

  public IEnumerator<T> GetEnumerator()
  {
    foreach (BinaryTreeNode<T> node in InOrderTraversal(_root))
    {
      yield return node.Value;
    }
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

  private IEnumerable<BinaryTreeNode<T>> InOrderTraversal(BinaryTreeNode<T> currentNode)
  {
    if (currentNode != null)
    {
      foreach (var leftNode in InOrderTraversal(currentNode.Left))
      {
        yield return leftNode;
      }

      yield return currentNode;

      foreach (var rightNode in InOrderTraversal(currentNode.Right))
      {
        yield return rightNode;
      }
    }
  }

  public BinaryTreeNode<T> Next()
  {
    if (_currentNode == null)
    {
      _currentNode = _root;
      while (_currentNode.Left != null)
      {
        _currentNode = _currentNode.Left;
      }
      return _currentNode;
    }

    _currentNode = _currentNode++;
    return _currentNode;
  }

  public BinaryTreeNode<T> Previous()
  {
    _currentNode = _currentNode--;
    return _currentNode;
  }

  public BinaryTreeNode<T> Current()
  {
    return _currentNode;
  }

  public IEnumerable<T> FilteredTraversal(Func<BinaryTreeNode<T>, bool> predicate)
  {
    foreach (BinaryTreeNode<T> node in InOrderTraversal(_root))
    {
      if (predicate(node))
      {
        yield return node.Value;
      }
    }
  }

  public BinaryTreeNode<T> GetRoot()
  {
    return _root;
  }
}
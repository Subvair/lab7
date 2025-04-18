using System;

public class BinaryTreeNode<T> where T : IComparable<T>
{
  public T Value;
  public BinaryTreeNode<T> Left;
  public BinaryTreeNode<T> Right;
  public BinaryTreeNode<T> Parent;

  public BinaryTreeNode(T value)
  {
    Value = value;
  }

  public static BinaryTreeNode<T> operator ++(BinaryTreeNode<T> node)
  {
    if (node.Right == null)
    {
      if (node.Parent == null || node == node.Parent.Right)
      {
        return null;
      }

      return node.Parent;
    }
    else
    {
      var nextNode = node.Right;
      while (nextNode.Left != null)
      {
        nextNode = nextNode.Left;
      }

      return nextNode;
    }
  }

  public static BinaryTreeNode<T> operator --(BinaryTreeNode<T> node)
  {
    if (node.Left == null)
    {
      if (node.Parent == null || node == node.Parent.Left)
      {
        return null;
      }

      return node.Parent;
    }
    else
    {
      var previousNode = node.Left;
      while (previousNode.Right != null)
      {
        previousNode = previousNode.Right;
      }

      return previousNode;
    }
  }
}
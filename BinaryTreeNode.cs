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
}
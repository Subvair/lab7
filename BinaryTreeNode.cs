using System;

public class BinaryTreeNode<T> where T : IComparable<T>
{
  public T Value;
  public BinaryTreeNode<T> Left, Right, Parent;

  public BinaryTreeNode(T value)
  {
    Value = value;
  }
}

using System;
using System.Collections;

class Node
{
    public Node next;
    public int data;
    public Node(int d)
    {
        data = d;
        next = null;
    }
}

class NodeBST
{
    public NodeBST left, right;
    public int data;
    public NodeBST(int data)
    {
        this.data = data;
        left = right = null;
    }
}

class Solution
{
    public static Node insert(Node head, int data)
    {
        if (head == null)
        {
            return new Node(data);
        }
        else if (head.next == null)
        {
            head.next = new Node(data);
        } else
        {
            //recursion
            insert(head.next, data);
        }
        return head;
    }
    public static void display(Node head)
    {
        Node start = head;
        while (start != null)
        {
            Console.Write(start.data + " ");
            start = start.next;
        }
    }

    //Binary Search Tree
    static NodeBST insert(NodeBST root, int data)
    {
        if (root == null)
        {
            return new NodeBST(data);
        }
        else
        {
            NodeBST cur;
            if (data <= root.data)
            {
                cur = insert(root.left, data);
                root.left = cur;
            }
            else
            {
                cur = insert(root.right, data);
                root.right = cur;
            }
            return root;
        }
    }
    static int getHeight(NodeBST root)
    {
        //Write your code here
        if (root==null)
        {
            return -1;
        }
        int leftDepth = getHeight(root.left);
        int rightDepth = getHeight(root.right);

        return (leftDepth > rightDepth ? leftDepth : rightDepth) + 1;
    }

    //BST Level-Order Traversal
    static void levelOrder(NodeBST root)
    {
        Queue q = new Queue();
        q.Enqueue(root);

        while(q.Count != 0)
        {
            NodeBST tree = (NodeBST)q.Dequeue();

            Console.Write(tree.data+" ");

            if (tree.left != null)
            {
                q.Enqueue(tree.left);
            }
            if (tree.right != null)
            {
                q.Enqueue(tree.right);
            }
        }
    }

    static void Main(String[] args)
    {

        #region Day15: Linked List
        Console.WriteLine("LINKED LIST");
        Node head = null;
        Console.Write("No. of entries: ");
        int T = Int32.Parse(Console.ReadLine());
        while (T-- > 0)
        {
            int data = Int32.Parse(Console.ReadLine());
            head = insert(head, data);
        }
        display(head);
        #endregion

        #region Day22: Binary Search Trees
        Console.WriteLine("\n\nBINARY SEARCH TREES");
        NodeBST root = null;
        Console.Write("No. of entries: ");
        int input = Int32.Parse(Console.ReadLine());
        while (input -- > 0)
        {
            int data = Int32.Parse(Console.ReadLine());
            root = insert(root, data);
        }
        int height = getHeight(root);
        Console.WriteLine("Height: "+height);
        #endregion

        #region Day23: BST Level-Order Traversal
        levelOrder(root);
        #endregion

        Console.ReadKey();
    }
}

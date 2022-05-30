using System;

namespace Binary_Search_Tree_Implementation
{
    class Node
    {
        public int data;
        public Node right;
        public Node left;
        public Node(int data)
        {
            this.data = data;
        }
        public Node()
        {

        }
    }
    class BinaryTree
    {
        Node root;
        public Node Root { get { return root; } }
        public BinaryTree()
        {
            root = null;
        }
        public void insert(int item)
        {
            Node newNode = new Node(item);
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (item < current.data)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newNode;
                            break;
                        }
                    }
                }
            }
        }

        //delete node from tree
        public void delete(int item)
        {
            Node nodeDelete = findNode(item);
            if (nodeDelete == null)
            {
                return;
            }
            Node parent = findParentNode(nodeDelete.data);

            //Node has two child
            if (nodeDelete.left != null && nodeDelete.right != null)
            {
                Node maxLeftParent = findParentNode(findMaxmum(nodeDelete.left));
                Node newParent = findNode(findMaxmum(nodeDelete.left));
                //newParent.right = nodeDelete.right;
                //newParent.left = nodeDelete.left;
                //newParent = nodeDelete;
                //nodeDelete = null;

                if (newParent.data >= maxLeftParent.data)
                {
                    nodeDelete.data = newParent.data;
                    maxLeftParent.right = newParent.left;
                }
                else if (newParent.data < maxLeftParent.data)
                {
                    nodeDelete.data = newParent.data;
                    maxLeftParent.left = null;
                }
                return;
            }
            //Node has no child
            if (nodeDelete.left == null && nodeDelete.right == null)
            {

                if (nodeDelete.data < parent.data)
                {
                    parent.left = null;
                }
                else
                {
                    parent.right = null;
                }
                return;
            }

            //Node has one child only
            if (nodeDelete.data < parent.data)
            {
                if ((nodeDelete.left == null && nodeDelete.right != null))
                {
                    parent.left = nodeDelete.right;
                    return;
                }
                else if ((nodeDelete.left != null && nodeDelete.right == null))
                {
                    parent.left = nodeDelete.left;
                    return;
                }
            }
            else
            {
                if ((nodeDelete.left == null && nodeDelete.right != null))
                {
                    parent.right = nodeDelete.right;
                    return;
                }
                else if ((nodeDelete.left != null && nodeDelete.right == null))
                {
                    parent.right = nodeDelete.left;
                    return;
                }
            }


        }

        //Tree traversal using three different methods
        public void InOrder(Node root)
        {
            if (!(root == null))
            {
                InOrder(root.left);
                Console.Write($"{root.data}  ");
                InOrder(root.right);
            }
        }
        public void preOrder(Node root)
        {
            if (!(root == null))
            {
                Console.Write($"{root.data}  ");
                preOrder(root.left);
                preOrder(root.right);
            }
        }
        public void postOrder(Node root)
        {
            if (!(root == null))
            {
                postOrder(root.left);
                postOrder(root.right);
                Console.Write($"{root.data}  ");
            }
        }

        //find specific node in tree
        public Node findNode(int key)
        {
            Node current = root;
            while (current.data != key)
            {
                if (key < current.data)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
                if (current == null)
                {
                    return null;
                }
            }
            return current;
        }
        public Node findParentNode(int key)
        {
            Node parent = null;
            Node current = root;
            while (current.data != key)
            {
                if (key < current.data)
                {
                    parent = current;
                    current = current.left;
                }
                else
                {
                    parent = current;
                    current = current.right;
                }
                if (current == null)
                {
                    return null;
                }
            }
            return parent;
        }

        //find max and min value in tree
        public int findMinimum(Node Root)
        {
            Node current = Root;
            while (current.left != null)
            {
                current = current.left;
            }
            return current.data;

        }
        public int findMaxmum(Node Root)
        {
            Node current = Root;
            while (current.right != null)
            {
                current = current.right;
            }
            return current.data;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.insert(5);
            tree.insert(1);
            tree.insert(20);
            tree.insert(7);
            tree.insert(7);
            tree.insert(10);
            tree.insert(22);
            tree.insert(3);
            tree.insert(0);
            tree.insert(2);
            tree.insert(9);

            Console.WriteLine("PreOrder Tree:    ");
            tree.preOrder(tree.Root);

            Console.WriteLine("\nInOrder Tree:    ");
            tree.InOrder(tree.Root);

            Console.WriteLine("\nPostOrder Tree:    ");
            tree.postOrder(tree.Root);

            Console.WriteLine("\nMaxmum value: " + tree.findMaxmum(tree.Root));
            Console.WriteLine("\nMinimum value: " + tree.findMinimum(tree.Root));

            tree.delete(20);

            Console.WriteLine("\nInOrder Tree:    ");
            tree.InOrder(tree.Root);
        }
    }
}

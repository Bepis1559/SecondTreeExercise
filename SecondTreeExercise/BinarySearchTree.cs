using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SecondTreeExercise
{
    internal class BinarySearchTree
    {
        private Node? root;

        private readonly List<int> RightSubtree = [];

        public BinarySearchTree()
        {
            root = null;
        }


        private Node InsertRecursive(Node node, int data)
        {
            if (node == null) return new(data);

            if (data < node.Data)
            {
                node.Left = InsertRecursive(node.Left, data);
            }
            else if (data > node.Data)
            {
                node.Right = InsertRecursive(node.Right, data);
            }

            return node;
        }

        public void Insert(int data)
        {
            root = InsertRecursive(root, data);
        }

        private Node? SearchForElementRecursive(Node? node, int data)
        {
            if (node != null)
            {
                if (data > node.Data)
                {
                    return SearchForElementRecursive(node.Right, data);
                }
                else if (data < node.Data)
                {
                    return SearchForElementRecursive(node.Left, data);
                }
            }
            return node;
        }
        public Node? GetNode(int data)
        {
            Node? foundNode = SearchForElementRecursive(root, data);
            return foundNode;
        }

        private Node? GetParentNodeRecursive(Node? node, int data)
        {
            if (node != null)
            {
                if (data == node?.Left?.Data || data == node?.Right?.Data)
                {
                    return node;
                }
                else if (data < node?.Data)
                {
                    return GetParentNodeRecursive(node.Left, data);
                }
                else if (data > node?.Data)
                {
                    return GetParentNodeRecursive(node.Right, data);
                }
            }
            return null;
        }
        public Node? GetParentNode(int data)
        {
            return GetParentNodeRecursive(root, data);
        }

        public Node? DeleteNode(int data)
        {
            Node? node = GetNode(data);
            if (node == null) return node;

            if (node != null)
            {
                if (IsLeaf(node))
                {
                    Console.WriteLine("IsLeaf was called");
                    DeleteLeaf(node);
                }
                else if (HasOneChild(node))
                {
                    Console.WriteLine("HasOneChild was called");
                    DeleteSingleChildNode(node);
                }
                else if (HasTwoChildren(node))
                {
                    Console.WriteLine("HasTwoChildren was called");
                    DeleteTwoChildrenNode(node);
                }
            }
            return node;
        }

        private void DeleteTwoChildrenNode(Node? node)
        {
            List<int> rightSubtree = GetRightSubtree(node);
            int dataOfNodeToDelete = node.Data;
            int smallestValueInRightSubtree = rightSubtree.Min();
            Node smallestNodeInRightSubtree = GetNode(smallestValueInRightSubtree);
            smallestNodeInRightSubtree.Data = dataOfNodeToDelete;
            node.Data = smallestValueInRightSubtree;
            if (node.Left?.Data == dataOfNodeToDelete)
            {
                node.Left = null;
            }
            else if (node.Right?.Data == dataOfNodeToDelete)
            {
                node.Right = null;
            }
        }


        public List<int> GetRightSubtree(Node? node)
        {
            GetRightSubtreeRecursive(node != null ? node?.Right : root?.Right);
            return RightSubtree;

        }

        private void GetRightSubtreeRecursive(Node node)
        {
            if (node != null)
            {
                RightSubtree.Add(node.Data);
                GetRightSubtreeRecursive(node.Left);
                GetRightSubtreeRecursive(node.Right);
            }
            return;
        }
        private void DeleteSingleChildNode(Node node)
        {
            int nodeData = node.Data;
            Node? parent = GetParentNode(nodeData);
            if (nodeData > parent?.Data)
            {
                if (node.Left != null)
                {
                    parent.Right = node.Left;
                }
                else if (node.Right != null)
                {
                    parent.Right = node.Right;
                }

            }
            else if (nodeData < parent?.Data)
            {
                if (node.Left != null)
                {
                    parent.Left = node.Left;
                }
                else if (node.Right != null)
                {
                    parent.Left = node.Right;
                }
            }
        }
        private void DeleteLeaf(Node node)
        {
            int nodeData = node.Data;
            Node? parent = GetParentNode(nodeData);
            if (parent?.Left?.Data == nodeData)
            {
                parent.Left = null;
            }
            else if (parent?.Right?.Data == nodeData)
            {
                parent.Right = null;
            }
        }
        private bool HasTwoChildren(Node? node)
        {
            return node?.Left != null && node?.Right != null;
        }

        private bool HasOneChild(Node? node)
        {
            return (node?.Left != null && node?.Right == null) || (node?.Left == null && node?.Right != null);
        }

        private bool IsLeaf(Node? node)
        {
            return node?.Left == null && node?.Right == null;
        }



        public void InorderTraversal()
        {
            InorderTraversalRecursive(root);
        }

        public void PreorderTraversal()
        {
            PreorderTraversalRecursive(root);
        }

        public void PostorderTraversal()
        {
            PostorderTraversalRecursive(root);
        }

        // left - root - right
        private void InorderTraversalRecursive(Node node)
        {
            if (node != null)
            {
                InorderTraversalRecursive(node?.Left);
                Console.Write(node.Data + " ");
                InorderTraversalRecursive(node?.Right);
            }
        }

        // root - left - right
        private void PreorderTraversalRecursive(Node node)
        {
            if (node != null)
            {
                Console.Write(node.Data + " "); // Visit the current node (root)
                PreorderTraversalRecursive(node.Left); // Recursively traverse the left subtree
                PreorderTraversalRecursive(node.Right); // Recursively traverse the right subtree
            }
        }

        // left-right-root
        private void PostorderTraversalRecursive(Node node)
        {
            if (node != null)
            {
                PostorderTraversalRecursive(node.Left); // Recursively traverse the left subtree
                PostorderTraversalRecursive(node.Right); // Recursively traverse the right subtree
                Console.Write(node.Data + " "); // Visit the current node (root)
            }
        }
    }
}

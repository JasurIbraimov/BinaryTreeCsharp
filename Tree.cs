using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Tree<T> where T : IComparable<T>
    {
        public Node<T>? Root { get; private set; }

        public Tree()
        {
            Root = null;
        }

        /* Insert */
        public void Insert(T data)
        {
            Root = InsertRecursive(Root, data); // Start of the recursion
        }


        /* Insert Recursive  */
        private static Node<T> InsertRecursive(Node<T>? node, T data)
        {
            // If this node is empty
            if (node is null)
            {
                return new Node<T>(data); // Stop the recursion and set a new node 
            }

            // If this node is not empty
            // Check if its data is less than inserting data
            if (data.CompareTo(node.Data) < 0)
            {
                node.Left = InsertRecursive(node.Left, data); // Start the recursion to the left 
            }
            // If its data is greater than inserting data
            else
            {
                node.Right = InsertRecursive(node.Right, data); // Start the recursion to the right 
            }

            // Stop the recursion by returning the node
            return node;
        }

        /* M1: Height of the tree */
        public int Height()
        {
            return HeightRecursive(Root); // Start of the recursion
        }

        /* Height of the tree Recursive  */
        private static int HeightRecursive(Node<T>? node)
        {
            if (node is null) return 0; // If its the last node return 0
            return Math.Max(HeightRecursive(node.Left), HeightRecursive(node.Right)) + 1; // Find max value between left and right sides
        }

        /* M2: Contains */
        public bool Contains(T value)
        {
            return ContainsRecursive(Root, value); // Start of the recursion
        }

        /* Contains recursive */
        private static bool ContainsRecursive(Node<T>? node, T value)
        {
            if (node is null) return false; // If its the last node return false (Not contains!)
            int comparison = value.CompareTo(node.Data); // Find the value of the comparison
            if (comparison == 0) return true; // If the comparison gives 0 then return true (Contains!)
            if (comparison < 0) return ContainsRecursive(node.Left, value); // If the comparison gives less than 0, go to the left
            return ContainsRecursive(node.Right, value); // Otherwise go to the right
        }

        /* M3: Min */
        public T Min()
        {
            if (Root is null) throw new InvalidOperationException("Tree is empty");
            return MinRecursive(Root).Data; // Start of the recursion
        }

        /* Min recursive */
        private static Node<T> MinRecursive(Node<T> node)
        {
            return node.Left is null ? node : MinRecursive(node.Left); // Until its the last node on the left go to the left
        }

        /* M3: Max */
        public T Max()
        {
            if (Root is null) throw new InvalidOperationException("Tree is empty");
            return MaxRecursive(Root).Data; // Start of the recursion
        }

        /* Max recursive */
        private static Node<T> MaxRecursive(Node<T> node)
        {
            return node.Right is null ? node : MaxRecursive(node.Right); // Until its the last node on the right go to the right
        }

        /* M4: Sum */
        public T Sum()
        {
            return SumRecursive(Root); // Start of the recursion
        }

        /* M4: Sum recursive */
        private static dynamic SumRecursive(Node<T>? node)
        {
            if (node is null) return 0; // Stop the recursion if its the last node
            return node.Data + SumRecursive(node.Left) + SumRecursive(node.Right); // Sum the current node, go to the left side, go to the right side 
        }


        /* M5: Transform to descending order */
        public void TransformToDescendingOrder()
        {
            List<T> values = new List<T>();
            InOrderTraversal(Root, values);
            Root = null; // Clear the tree
            for (int i = values.Count - 1; i >= 0; i--)
            {
                Insert(values[i]);
            }
        }

        private void InOrderTraversal(Node<T>? node, List<T> values)
        {
            if (node is null) return;
            InOrderTraversal(node.Left, values);
            values.Add(node.Data);
            InOrderTraversal(node.Right, values);
        }


        /* M6: Update successors count */
        private void UpdateSuccessorCount(Node<T>? node)
        {
            if (node is null) return; // If its the last node return
            node.SuccessorCount = GetSuccessorCount(node.Left) + GetSuccessorCount(node.Right) + 1; // Sum left and right successor counts
        }

        private int GetSuccessorCount(Node<T>? node)
        {
            return node is null ? 0 : node.SuccessorCount; // If its the last node return 0 else return its successor count
        }

        /* M7: Path to a number */
        public string? PathToNumber(T value)
        {
            return PathToNumberRecursive(Root, value, "/"); // Start of the recursion
        }

        private static string? PathToNumberRecursive(Node<T>? node, T value, string path)
        {
            if (node is null) return null; // If node is null, value not found
            int comparison = value.CompareTo(node.Data);
            if (comparison == 0) return path + node.Data.ToString(); // If value found, return the path

            if (comparison < 0)
            {
                var leftPath = PathToNumberRecursive(node.Left, value, path + "L/"); // Go to the left side
                if (leftPath != null) return leftPath;
            }
            else
            {
                var rightPath = PathToNumberRecursive(node.Right, value, path + "R/"); // Go to the right side
                if (rightPath != null) return rightPath;
            }

            return null;
        }

        /* M8: Number for a path */
        public T NumberForPath(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new InvalidPathException("Invalid path");

            Node<T>? current = Root;
            foreach (var dir in path.Split('/', StringSplitOptions.RemoveEmptyEntries))
            {
                if (dir == "L")
                {
                    if (current?.Left == null) throw new InvalidPathException("Invalid path");
                    current = current.Left;
                }
                else if (dir == "R")
                {
                    if (current?.Right == null) throw new InvalidPathException("Invalid path");
                    current = current.Right;
                }
                else
                {
                    if (current?.Data.ToString() == dir) return current.Data;
                    else throw new InvalidPathException("Invalid path");
                }

            }
            throw new InvalidPathException("Invalid path");
        }
    }
}

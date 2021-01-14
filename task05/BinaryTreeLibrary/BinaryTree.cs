using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace BinaryTreeLibrary
{
    /// <summary>
    /// Class describing functionality of binary tree.
    /// </summary>
    /// <typeparam name="T">The element type which support compare methods.</typeparam>
    public class BinaryTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// The left subsidiary tree.
        /// </summary>
        public BinaryTree<T> LeftTree { get; set; }

        /// <summary>
        /// The right subsidiary tree.
        /// </summary>
        public BinaryTree<T> RightTree { get; set; }

        /// <summary>
        /// The parent tree.
        /// </summary>
        public BinaryTree<T> ParentTree { get; set; }

        /// <summary>
        /// The Value of node. 
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Inits a binary tree.
        /// </summary>
        /// <param name="value">The element which support compare methods.</param>
        public BinaryTree(T value)
        {
            LeftTree = null;
            RightTree = null;
            ParentTree = null;

            this.Value = value;
        }

        /// <summary>
        /// Inits a subsidiary binary tree.
        /// </summary>
        /// <param name="value">The value to insert.</param>
        /// <param name="parent">The parent tree.</param>
        private BinaryTree(T value, BinaryTree<T> parent)
        {
            LeftTree = null;
            RightTree = null;
            ParentTree = parent;

            this.Value = value;
        }

        private BinaryTree() { }

        /// <summary>
        /// Finds and returns a tree(node of tree) by this value. 
        /// </summary>
        /// <param name="value">The node value.</param>
        /// <returns></returns>
        public BinaryTree<T> FindNode(T value)
        {
            return FindNode(value, this);
        }

        /// <summary>
        /// Finds and returns a tree(node of tree) by this value. 
        /// </summary>
        /// <param name="value">The node value.</param>
        /// <param name="tree">The current tree.</param>
        /// <returns></returns>
        private BinaryTree<T> FindNode(T value, BinaryTree<T> tree)
        {
            if (tree == null)
                return null;

            if (value.CompareTo(tree.Value) == 0)
                return tree;

            if (value.CompareTo(tree.Value) > 0)
                return FindNode(value, tree.RightTree);

            if (value.CompareTo(tree.Value) < 0)
                return FindNode(value, tree.LeftTree);

            return null;
        }

        /// <summary>
        /// Inserts a new value to the binary tree.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void Insert(T value)
        {
            if (value.CompareTo(this.Value) > 0)
            {
                if (RightTree == null)
                    RightTree = new BinaryTree<T>(value, this);
                else
                    RightTree.Insert(value);
            }

            if (value.CompareTo(this.Value) < 0)
            {
                if (LeftTree == null)
                    LeftTree = new BinaryTree<T>(value, this);
                else
                    LeftTree.Insert(value);
            }

            if (value.CompareTo(this.Value) == 0)
                this.Value = value;
        }

        /// <summary>
        /// Returns the binary tree in string format.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            GetValueString(builder, this);

            return builder.ToString();
        }

        /// <summary>
        /// Forms the value string of all trees.
        /// </summary>
        /// <param name="builder">The StringBuilder object.</param>
        /// <param name="tree">The current tree.</param>
        private void GetValueString(StringBuilder builder, BinaryTree<T> tree)
        {
            if (tree == null)
                return;

            GetValueString(builder, tree.LeftTree);
            builder.Append(tree.Value.ToString() + "\n");

            if (tree.RightTree != null)
                GetValueString(builder, tree.RightTree);
        }

        /// <summary>
        /// Deletes a tree(node) by this value.
        /// </summary>
        /// <param name="value">The tree(node) value.</param>
        /// <returns></returns>
        public bool Delete(T value)
        {
            BinaryTree<T> removalTree = FindNode(value);

            // If a tree(node) is not exists.
            if (removalTree == null)
                return false;

            // If a tree(node) haven`t childs.
            if (removalTree.LeftTree == null && removalTree.RightTree == null)
            {
                BinaryTree<T> tempTree = removalTree.ParentTree;

                if (tempTree.LeftTree == removalTree)
                    tempTree.LeftTree = null;
                else
                    tempTree.RightTree = null;

                return true;
            }

            // If a tree(node) have two childs.
            if (removalTree.LeftTree != null && removalTree.RightTree != null)
            {
                BinaryTree<T> tempLeftTree = removalTree.RightTree;

                while (tempLeftTree.LeftTree != null)
                    tempLeftTree = tempLeftTree.LeftTree;

                // If the left node of the right subtree isn`t exists.
                if (removalTree.RightTree.LeftTree == null)
                {
                    removalTree.Value = removalTree.RightTree.Value;
                    removalTree.RightTree = removalTree.RightTree.RightTree;
                }
                else
                {
                    removalTree.Value = tempLeftTree.Value;
                    tempLeftTree.ParentTree.LeftTree = null;
                }

                return true;
            }

            // If a tree(node) have a one right child.
            if (removalTree.LeftTree == null && removalTree.RightTree != null)
            {
                removalTree.Value = removalTree.RightTree.Value;
                removalTree.RightTree = removalTree.RightTree.RightTree;
                removalTree.LeftTree = null;

                return true;
            }

            // If a tree(node) have a one left child.
            if (removalTree.LeftTree != null && removalTree.RightTree == null)
            {
                removalTree.Value = removalTree.LeftTree.Value;
                removalTree.LeftTree = removalTree.LeftTree.LeftTree;
                removalTree.RightTree = null;

                return true;
            }

            return false;
        }

        #region (De)Seriazlize methods

        /// <summary>
        /// Serializes the object to xml.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void Serialize(string filePath)
        {
            var dccs = new DataContractSerializerSettings() { PreserveObjectReferences = true };
            var dcs = new DataContractSerializer(typeof(BinaryTree<T>), dccs);

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                dcs.WriteObject(fs, this);
            }
        }

        /// <summary>
        /// Returns deserialized object. 
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static BinaryTree<T> Deserialize(string filePath)
        {
            var dccs = new DataContractSerializerSettings() { PreserveObjectReferences = true };
            var dcs = new DataContractSerializer(typeof(BinaryTree<T>), dccs);

            using (XmlReader reader = XmlReader.Create(filePath))
            {
                return (BinaryTree<T>)dcs.ReadObject(reader);
            }
        }
        #endregion

        #region Balancing algoritm (DSW)

        /// <summary>
        /// Returns a new balanced tree.
        /// </summary>
        /// <returns></returns>
        public BinaryTree<T> BalanceTree()
        {
            BinaryTree<T> root = new BinaryTree<T>();
            
            root.RightTree = this;
            int size = GetNodeCount(this) + 1;

            TreeToVine(root);
            VineToTree(root, size);

            root.RightTree.ParentTree = null;
            AddParents(root.RightTree);

            return root.RightTree;
        }

        private int GetNodeCount(BinaryTree<T> tree)
        {
            if (tree.LeftTree == null && tree.RightTree == null)
                return 1;

            int left;
            int right;

            if (tree.LeftTree != null)
                left = GetNodeCount(tree.LeftTree);
            else
                left = 0;

            if (tree.RightTree != null)
                right = GetNodeCount(tree.RightTree);
            else
                right = 0;

            return left + right + 1;
        }

        private void TreeToVine(BinaryTree<T> root)
        {
            BinaryTree<T> tail = root;
            BinaryTree<T> rest = tail.RightTree;
            while (rest != null)
            {
                if (rest.LeftTree == null)
                {
                    tail.ParentTree = rest.ParentTree;
                    tail = rest;
                    rest = rest.RightTree;

                }
                else
                {
                    rest.ParentTree = null;

                    BinaryTree<T> temp = rest.LeftTree;
                    rest.LeftTree = temp.RightTree;
                    temp.RightTree = rest;
                    rest = temp;
                    tail.RightTree = temp;

                }
            }
        }

        private void VineToTree(BinaryTree<T> root, int size)
        {
            int leaves = (int)(Math.Pow(2, Math.Floor(Math.Log(size + 1))) - 1);
            Compress(root, leaves);
            size = size - leaves;
            while (size > 1)
            {
                Compress(root, size / 2);
                size = size / 2;
            }

        }

        private void Compress(BinaryTree<T> root, int count)
        {
            BinaryTree<T> scanner = root;
            for (int i = 1; i < count; i++)
            {
                BinaryTree<T> child = scanner.RightTree;
                child.ParentTree = scanner.ParentTree;
                scanner.RightTree = child.RightTree;
                scanner = scanner.RightTree;
                child.RightTree = scanner.LeftTree;
                scanner.LeftTree = child;
                child.ParentTree = scanner.ParentTree;
            }
            root.ParentTree = null;
        }

        private void AddParents(BinaryTree<T> tree)
        {
            if (tree.LeftTree != null && tree.LeftTree.ParentTree == null)
                tree.LeftTree.ParentTree = tree;

            if (tree.RightTree != null && tree.RightTree.ParentTree == null)
                tree.RightTree.ParentTree = tree;

            if (tree.LeftTree != null)
                AddParents(tree.LeftTree);
            if (tree.RightTree != null)
                AddParents(tree.RightTree);
        }

        #endregion
    }
}

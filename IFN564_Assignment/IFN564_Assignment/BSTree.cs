using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace IFN564_Assignment
{
    class BSTree
    {
        private BTreeNode root;
        private bool genreActive = false;
        private String genreSelected;
        public BSTree()
        {
            root = null;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public void Insert(DVD dvd)
        {
            if (root == null)
                root = new BTreeNode(dvd);
            else
                Insert(dvd, root);

        }

        //inserts movies in a binary tree based on the title.
        public void Insert(DVD dvd, BTreeNode ptr)
        {
            if (dvd.getTitle().CompareTo(ptr.Item.getTitle()) < 0) 
            {
                if (ptr.LChild == null)
                    ptr.LChild = new BTreeNode(dvd);
                else
                    Insert(dvd, ptr.LChild);
            }
            else if (dvd.getTitle().CompareTo(ptr.Item.getTitle()) == 0) //if title is same then increase quantity by 1
            {
                ptr.Item.increaseQuantity();
            }
            else
            {
                if (ptr.RChild == null)
                    ptr.RChild = new BTreeNode(dvd);
                else Insert(dvd, ptr.RChild);
            }

        }

        public void Delete(DVD dvd)
        {
            //search for dvd and its parent
            BTreeNode ptr = root; // search reference
            BTreeNode parent = null; // parent of ptr
            while ((ptr != null) && (dvd.getTitle().CompareTo(ptr.Item.getTitle()) != 0))
            {
                parent = ptr;
                if (dvd.getTitle().CompareTo(ptr.Item.getTitle()) < 0) // move to the left child of ptr
                    ptr = ptr.LChild;
                else
                    ptr = ptr.RChild;
            }

            if (ptr != null) // if the search was successful
            {
                // case 3: item has two children
                if ((ptr.LChild != null) && (ptr.RChild != null))
                {
                    // find the right-most node in left subtree of ptr
                    if (ptr.LChild.RChild == null) // a special case: the right subtree of ptr.LChild is empty
                    {
                        ptr.Item = ptr.LChild.Item;
                        ptr.LChild = ptr.LChild.LChild;
                    }
                    else
                    {
                        BTreeNode p = ptr.LChild;
                        BTreeNode pp = ptr; // parent of p
                        while (p.RChild != null)
                        {
                            pp = p;
                            p = p.RChild;
                        }
                        // copy the item at p to ptr
                        ptr.Item = p.Item;
                        pp.RChild = p.LChild;
                    }
                }
                else // cases 1 & 2: item has no or only one child
                {
                    BTreeNode c;
                    if (ptr.LChild != null)
                        c = ptr.LChild;
                    else
                        c = ptr.RChild;

                    // remove node ptr
                    if (ptr == root) //need to change root
                        root = c;
                    else
                    {
                        if (ptr == parent.LChild)
                            parent.LChild = c;
                        else
                            parent.RChild = c;
                    }
                }
            }
        }

        //binary search to search a movie title in the b-tree.
        public DVD search(string movieTitle)
        {
            return search(movieTitle, root);
        }

        private DVD search(string movieTitle, BTreeNode root)
        {
            if (root != null)
            {
                if (movieTitle.CompareTo(root.Item.getTitle()) == 0)
                    return root.Item;
                else if (movieTitle.CompareTo(root.Item.getTitle()) < 0)
                    return search(movieTitle, root.LChild);
                else
                    return search(movieTitle, root.RChild);
            }
            else 
                return null;
        }

        public void InOrderTraverse()
        {

            InOrderTraverse(root);
            Console.WriteLine();
        }

        public void InOrderTraverse(BTreeNode root)
        {

            if (root != null && !genreActive) //and get title == true;
            {
                InOrderTraverse(root.LChild);
                Console.WriteLine(root.Item.getTitle() + " | Quantity: " + root.Item.getQuantity());
                InOrderTraverse(root.RChild);
            }
            else if(root != null)
            {
                InOrderTraverse(root.LChild);
                if (root.Item.getGenre().CompareTo(genreSelected) == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Title:           " + root.Item.getTitle());
                    Console.WriteLine("Starring:        " + root.Item.getStarring());
                    Console.WriteLine("Director:        " + root.Item.getDirector());
                    Console.WriteLine("Duration:        " + root.Item.getDuration() + "min");
                    Console.WriteLine("Classification:  " + root.Item.getClassification());
                    Console.WriteLine("Release Date:    " + root.Item.getReleaseDate());
                    Console.WriteLine("Quantity:        " + root.Item.getQuantity());
                }
                InOrderTraverse(root.RChild);
            }
        }

        public void selectGenre(String gen)
        {
            genreSelected = gen;
        }

        public void changeGenreStatus(bool x)
        {
            genreActive = x;
        }
    }
}

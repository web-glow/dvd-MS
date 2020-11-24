using System;
using System.Collections.Generic;
using System.Text;

namespace IFN564_Assignment
{
    class BTreeNode
    {
		private DVD dvd; // value
		private BTreeNode left; // reference to its left child 
		private BTreeNode right; // reference to its right child

		public BTreeNode(DVD dvd)
		{
			this.dvd = dvd;
			left = null;
			right = null;
		}

		public DVD Item
		{
			get { return dvd; }
			set { dvd = value; }
		}

		public BTreeNode LChild
		{
			get { return left; }
			set { left = value; }
		}

		public BTreeNode RChild
		{
			get { return right; }
			set { right = value; }
		}
	}
}

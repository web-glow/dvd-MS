using System;
using System.Collections.Generic;
using System.Text;

namespace IFN564_Assignment
{
    class QuickSort
    {
        private Borrower[] borrowerArr;
        private int len;

        public void sort(Borrower[] arr, int length)
        {
            if (arr == null || arr.Length == 0) 
                return;
            this.borrowerArr = arr;
            Console.WriteLine(borrowerArr[0].getFirstName()); 
            this.len = arr.Length;
            quickSort(0, length);
        }
        //sorts according to phone number. (as it will be unique to each customer).
        public void quickSort(int lowerIndex, int higherIndex)
        {
            int left = lowerIndex;
            int right = higherIndex;
            String pivot = this.borrowerArr[lowerIndex + (higherIndex - lowerIndex) / 2].getPhoneNum();

            while (left <= right)
            {
                while (this.borrowerArr[left].getPhoneNum().CompareTo(pivot) < 0)
                {
                    left++;
                }
                while (this.borrowerArr[right].getPhoneNum().CompareTo(pivot) > 0)
                {
                    right--;
                }

                if (left <= right)
                {
                    swapBorrower(left, right);
                    left++;
                    right--;
                }
            }
            //recursively calling quickSort
            if (lowerIndex < right)
            {
                quickSort(lowerIndex, right);
            }
            if (left < higherIndex)
            {
                quickSort(left, higherIndex);
            }
        }

        public void swapBorrower(int i, int j)
        {
            Borrower temprory = this.borrowerArr[i];
            this.borrowerArr[i] = this.borrowerArr[j];
            this.borrowerArr[j] = temprory;
        }
    }
}

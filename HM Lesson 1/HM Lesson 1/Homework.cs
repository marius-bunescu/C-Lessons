using System;
using System.Collections.Generic;

namespace C_Sharp_Lesson_3_Homework
{
    public class Homework
    {
        public void GetCentralElementFromMatrix(int[,] matrixOfIntegers)
        {
            /*print to console the central element from matrixOfIntegers, if not exist print: "This matrix doesn't have a central element"
             * |   input           | result             |
             * |-------------------|--------------------|
             * | {                 |                    |
             * |  { 1,   3,  5},   |    The central     |
             * |  {-1, 100, 11},   |  element is 100    |
             * |  { 2,  15, 44}    |                    |
             * |  }                |                    |
             * |----------------------------------------|
             * |{                  |                    |
             * | { 1,  6, 21,  8 },| This matrix doesn't|
             * | { 5, -4,  5,  7 },| have a central     |
             * | {77,  5,  0, 74 } |  element           |
             * | }                 |                    |
             * ------------------------------------------
             *    
             */
            int rows = matrixOfIntegers.GetLength(0);
            int columns = matrixOfIntegers.GetLength(1);

            if (rows % 2 != 0 && columns % 2 != 0)
            {
                Console.WriteLine(matrixOfIntegers[rows / 2, columns / 2]);
            }
            else
            {
                Console.WriteLine("\nThis matrix doesn't have a central element");
            }


        }
        public void GetSummOfDiagonalsElements(int[,] matrixOfIntegers)
        {
            /*print to console the central element from matrixOfIntegers, if not exist print: "This matrix doesn't have a central element"
             * |   input           | result              |
             * |-------------------|---------------------|
             * | {                 |                     |
             * |  { 1,   3,  5},   | First diagonal: 145 |
             * |  {-1, 100, 11},   | Second diagonal: 107|
             * |  { 2,  15, 44}    |                     |
             * |  }                |                     |
             * |-----------------------------------------|
             * |{                  |                     |
             * | { 1,  6, 21,  8 },| This matrix doesn't |
             * | { 5, -4,  5,  7 },| have a diagonals    |
             * | {77,  5,  0, 74 } |                     |
             * | }                 |                     |
             * ------------------------------------------
             *    
             */
            int first = 0, second = 0;
            if (matrixOfIntegers.GetLength(0) == matrixOfIntegers.GetLength(1))
            {
                for (int i = 0; i < matrixOfIntegers.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixOfIntegers.GetLength(0); j++)
                    {
                        if (i == j)
                        {
                            first += matrixOfIntegers[i, j];
                        }

                        if ((i + j) == (matrixOfIntegers.GetLength(0) - 1))
                        {
                            second += matrixOfIntegers[i, j];
                        }
                    }
                }
                Console.WriteLine("Principal Diagonal: " + first);

                Console.WriteLine("Secondary Diagonal: " + second);
            }
            else
            {
                Console.WriteLine("\nThis  matrix doesn't have diagonals");
            }
        }

        public void StarPrinter(int triangleHight)
        {
            /* Write a programm that will print a triagle of stars  with hight = triangleHight
             *  Example: triangleHight = 3;
             *  Result:   *
             *           * *
             *          * * * 
             */


            int i, j, k, space = 0;
            space = triangleHight;
            for (i = 1; i <= triangleHight; i++)
            {

                for (j = 1; j <= space; j++)
                {
                    Console.Write(" ");
                }
                space--;

                for (k = 1; k <= i; k++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }


       
        }
          
   



        public void SortList(IList<int> listOfNumbers)
        {
            

            var result_set = listOfNumbers.OrderBy(num => num);

      
            Console.WriteLine("Sorted in Ascending order:");
            foreach (int value in result_set)
            {
                Console.Write(value + " ");
            }

        }
        public static void Main(String[] args)
        {
            Homework homework = new Homework();
            IList<int> list = new List<int>() { -5, 8, -7, 0, 44, 121, -7 };
       

            int[,] matrix = new int[3, 3] {
                { 1,   3,  5},
                { 2, 3, 5},
                {100, 56 , -54} };
            int[,] matrix2 = new int[3, 4] {
                { 1,   3,  5,   6},
                { 2,   3,  5,  78},
                {100, 56 , -54, 6} };

            //homework.GetCentralElementFromMatrix(matrix);
            //homework.GetCentralElementFromMatrix(matrix2);
            //homework.GetSummOfDiagonalsElements(matrix);
            //homework.GetSummOfDiagonalsElements(matrix2);
            //homework.StarPrinter(5);
            //homework.SortList(list);
        }

    }
}

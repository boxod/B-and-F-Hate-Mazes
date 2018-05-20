using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryTree: Grid{

    // Use this for initialization
    Grid newMaze;

    //Constructor that takes in number of rows and columns
    public BinaryTree(int nRows, int nColumns)
    {
        Number_Rows = nRows;
        Number_Columns = nColumns;
    }

    // Load Binary tree algorithm and return a List
    public List<Cell> returnBinaryList ()
    {
        newMaze.createGrid();
        newMaze.configureCellsList();
        

        int size = newMaze.getCellsList().Count;

        foreach (Cell i in newMaze.getCellsList())
        {
            int rndm = Random.Range(0, 10);
            if (rndm < 5 && i.getNeighbourNorth() != null)
            {
                i.linkCell(i, i.getNeighbourNorth(), true);
            }
            else if (i.getNeighbourNorth() == null && i.getNeighbourEast() != null)
            {
                i.linkCell(i, i.getNeighbourEast(), true);
            }
            if (rndm >= 5 && i.getNeighbourEast() != null)
            {
                i.linkCell(i, i.getNeighbourEast(), true);
            }
            else if (i.getNeighbourEast() == null && i.getNeighbourNorth() != null)
            {
                i.linkCell(i, i.getNeighbourNorth(), true);
            }
        }
        //int ct = 0;
        //foreach (Cell i in newMaze.getCellsList())
        //{
        //    Debug.Log("Cell " + ct + " Row: " + i.getCellRow() + " Column: " + i.getCellColumn());
        //    List<Cell> linkedCells = i.getLinkedList();
        //    int ct1 = 0;
        //    foreach (Cell j in linkedCells)
        //    {
        //        Debug.Log("Linked Cell " + ct1 + " Row: " + j.getCellRow() + " Column: " + j.getCellColumn());
        //        ct1++;
        //    }

        //    ct++;
        //}

        return cellList;
    }

    // Load Binary Tree algorithm and return an Array
    public Cell[,] returnBinaryArray()
    {

        newMaze = new Grid(Number_Rows,Number_Columns);
        newMaze.configureCellsArray();
        cellArray =  newMaze.getCellArray();
        //newMaze.configureCellsList();


        //Debug.Log("Maze Size: " + myArr.Length);
        for (int i = Number_Rows-1; i>=0;i--)
        {
            for(int j = 0;j<Number_Columns;j++)
            {
                float rndm = Random.Range(0, 9);

                if (rndm <5)
                {
                    if(newMaze.getCellFromArray(i,j).getNeighbourNorth() != null)
                    {
                        newMaze.getCellFromArray(i, j).linkCell(newMaze.getCellFromArray(i, j), newMaze.getCellFromArray(i, j).getNeighbourNorth(), true);
                    }
                    else if (newMaze.getCellFromArray(i, j).getNeighbourNorth() == null && newMaze.getCellFromArray(i, j).getNeighbourEast() != null)
                    {
                        newMaze.getCellFromArray(i, j).linkCell(newMaze.getCellFromArray(i, j), newMaze.getCellFromArray(i, j).getNeighbourEast(), true);
                    }
                }
                else
                {
                    if(newMaze.getCellFromArray(i, j).getNeighbourEast() != null)
                    {
                        newMaze.getCellFromArray(i, j).linkCell(newMaze.getCellFromArray(i,j), newMaze.getCellFromArray(i, j).getNeighbourEast(), true);
                    } else if (newMaze.getCellFromArray(i, j).getNeighbourEast() == null && newMaze.getCellFromArray(i, j).getNeighbourNorth() != null)
                    {
                        newMaze.getCellFromArray(i, j).linkCell(newMaze.getCellFromArray(i, j), newMaze.getCellFromArray(i, j).getNeighbourNorth(), true);
                    }
                }


                

            }
        }

       // printCellsInConsole();

        return cellArray;

    }

    

}

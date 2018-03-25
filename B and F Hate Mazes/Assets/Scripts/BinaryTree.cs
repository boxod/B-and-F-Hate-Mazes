using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryTree : MonoBehaviour {

    // Use this for initialization

    private int Number_Rows;
    private int Number_Columns;
    CreateGrid.Grid newMaze;
    CreateCell.Cell[,] myArr;

    public BinaryTree(int nRows, int nColumns)
    {
        Number_Rows = nRows;
        Number_Columns = nColumns;
    }

    // Load Binary tree algorithm using a List
    public void returnBinaryList ()
    {
        newMaze.createGrid();
        newMaze.configureCellsList();
        

        int size = newMaze.getCellsList().Count;
        Debug.Log("Random please: " + size);

        foreach (CreateCell.Cell i in newMaze.getCellsList())
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
            Debug.Log("Random ");
        }
        int ct = 0;
        foreach (CreateCell.Cell i in newMaze.getCellsList())
        {
            Debug.Log("Cell " + ct + " Row: " + i.getCellRow() + " Column: " + i.getCellColumn());
            List<CreateCell.Cell> linkedCells = i.getLinkedList();
            int ct1 = 0;
            foreach (CreateCell.Cell j in linkedCells)
            {
                Debug.Log("Linked Cell " + ct1 + " Row: " + j.getCellRow() + " Column: " + j.getCellColumn());
                ct1++;
            }

            ct++;
        }
    }

    public CreateCell.Cell[,] returnBinaryArray()
    {

        newMaze = new CreateGrid.Grid(Number_Rows,Number_Columns);
        newMaze.configureCellsArray();
        myArr =  newMaze.getCellArray();

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

        //for (int i = Number_Rows - 1; i >= 0; i--)
        //{
        //    for (int j = 0; j < Number_Columns; j++)
        //    {
        //        Debug.Log("CC Row: " + newMaze.getCellFromArray(i, j).getCellRow() + " Column: " + newMaze.getCellFromArray(i, j).getCellColumn());
        //        foreach (CreateCell.Cell c in newMaze.getCellFromArray(i, j).getLinkedList())
        //        {
        //            Debug.Log("Linked Cell: Row: " + c.getCellRow() + " Column: " + c.getCellColumn());
        //        }
        //    }
        //}

        return myArr;

    }

    

}

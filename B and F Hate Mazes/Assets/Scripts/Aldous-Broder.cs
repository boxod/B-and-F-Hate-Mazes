using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aldous_Broder {

    // Use this for initialization
    private int Number_Rows;
    private int Number_Columns;
    CreateGrid.Grid newMaze;
    CreateCell.Cell[,] myArr;


    public Aldous_Broder(int nRows, int nColumns)
    {
        Number_Rows = nRows;
        Number_Columns = nColumns;
    }

    public CreateCell.Cell[,] returnAldous_BroderArray()
    {

        newMaze = new CreateGrid.Grid(Number_Rows, Number_Columns);
        newMaze.configureCellsArray();
        myArr = newMaze.getCellArray();
        int rRow = Random.Range(0, Number_Rows - 1);
        int rColumn = Random.Range(0, Number_Columns - 1);
        int unvisited = (Number_Rows * Number_Columns) - 1;

        CreateCell.Cell Cell = newMaze.getCellFromArray(rRow,rColumn);

        while(unvisited > 0)
        {
            CreateCell.Cell Neighbour = new CreateCell.Cell();
            int rNeighbour = Random.Range(0, 100);
            // Random East Neighbour
            if (rNeighbour < 25)
            {
                Neighbour = Cell.getNeighbourEast();
            }
            //Random West Neighbour
            if (rNeighbour >= 25 && rNeighbour < 50)
            {
                Neighbour = Cell.getNeighbourWest();
            }
            //Random South Neighbour
            if (rNeighbour >= 50 && rNeighbour < 75)
            {
                Neighbour = Cell.getNeighbourSouth();
            }
            //Random North Neighbour
            if (rNeighbour >= 75)
            {
                Neighbour = Cell.getNeighbourNorth();
            }


            if (Neighbour != null)
            {
                if (Neighbour.getLinkedList().Count == 0)
                {
                    Cell.linkCell(Cell, Neighbour, true);
                    newMaze.getCellFromArray(Cell.getCellRow(), Cell.getCellColumn()).linkCell(newMaze.getCellFromArray(Cell.getCellRow(), Cell.getCellColumn()), newMaze.getCellFromArray(Neighbour.getCellRow(), Neighbour.getCellColumn()), true);

                    unvisited--;
                }

                Cell = newMaze.getCellFromArray(Neighbour.getCellRow(), Neighbour.getCellColumn());
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

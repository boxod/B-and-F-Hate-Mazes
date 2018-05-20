using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aldous_Broder: Grid {

    // Use this for initialization
    //private int Number_Rows;
    //private int Number_Columns;
    Grid newMaze;
    //Cell[,] myArr;


    public Aldous_Broder(int nRows, int nColumns)
    {
        Number_Rows = nRows;
        Number_Columns = nColumns;
    }

    public Cell[,] returnAldous_BroderArray()
    {

        newMaze = new Grid(Number_Rows, Number_Columns);
        newMaze.configureCellsArray();
        cellArray = newMaze.getCellArray();
        int rRow = Random.Range(0, Number_Rows - 1);
        int rColumn = Random.Range(0, Number_Columns - 1);
        int unvisited = (Number_Rows * Number_Columns) - 1;

        Cell Cell = newMaze.getCellFromArray(rRow,rColumn);

        while(unvisited > 0)
        {
            Cell Neighbour = new Cell();
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

        return cellArray;
    }

}

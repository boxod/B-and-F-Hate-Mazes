using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prim {

    private int Number_Rows;
    private int Number_Columns;
    CreateGrid.Grid newMaze;
    CreateCell.Cell[,] myArr;
    List<CreateCell.Cell> myList;
	
    public Prim(int Rows, int Columns)
    {
        Number_Rows = Rows;
        Number_Columns = Columns;
    }

    public CreateCell.Cell[,] returnPrimArray()
    {
        newMaze = new CreateGrid.Grid(Number_Rows, Number_Columns);
        newMaze.configureCellsArray();
        myArr = newMaze.getCellArray();

        List<CreateCell.Cell> active = new List<CreateCell.Cell>();
        int rRow = Random.Range(0,Number_Rows-1);
        int rColumn = Random.Range(0,Number_Columns-1);

        active.Add(newMaze.getCellFromArray(rRow,rColumn));

        while(active.Count != 0)
        {
           int rActiveCell = Random.Range(0, active.Count - 1);
           int unlinkedNeighbours = 0;
            bool hE = false, hW = false, hS = false, hN = false;

           //Check Eastern Neighbour
           if(newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourEast() != null)
            {
                if(newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourEast().getLinkedList().Count == 0)
                {
                    unlinkedNeighbours++;
                    hE = true;
                }
            }

           //Check Western Neighbour
           if (newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourWest() != null)
            {
                if (newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourWest().getLinkedList().Count == 0)
                {
                    unlinkedNeighbours++;
                    hW = true;
                }
            }

           //Check Southern Neighbour
           if (newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourSouth() != null)
            {
                if (newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourSouth().getLinkedList().Count == 0)
                {
                    unlinkedNeighbours++;
                    hN = true;
                }
            }

           //Check Northen Neighbour
           if (newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourNorth() != null)
            {
                if (newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourNorth().getLinkedList().Count == 0)
                {
                    unlinkedNeighbours++;
                    hS = true;
                }
            }


            if (unlinkedNeighbours == 0)
            {
                active.Remove(active[rActiveCell]);
            }
            else
            {
                int rNeighbour = Random.Range(0, 100);
                // Random East Neighbour
                if (rNeighbour < 25 && hE == true)
                {
                    if (newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourEast() != null)
                    {
                        newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).linkCell(newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()), newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourEast(),true);
                        active.Add(newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourEast());
                    }
                }
                //Random West Neighbour
                if (rNeighbour >= 25 && rNeighbour < 50 && hW == true)
                {
                    if (newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourWest() != null)
                    {
                        newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).linkCell(newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()), newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourWest(), true);
                        active.Add(newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourWest());
                    }
                }
                //Random South Neighbour
                if (rNeighbour >= 50 && rNeighbour < 75 && hS == true)
                {
                    if (newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourSouth() != null)
                    {
                        newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).linkCell(newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()), newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourSouth(), true);
                        active.Add(newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourSouth());
                    }
                }
                //Random North Neighbour
                if (rNeighbour >= 75 && hN == true)
                {
                    if (newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourNorth() != null)
                    {
                        newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).linkCell(newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()), newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourNorth(), true);
                        active.Add(newMaze.getCellFromArray(active[rActiveCell].getCellRow(), active[rActiveCell].getCellColumn()).getNeighbourNorth());
                    }
                }
            }

        }
    return myArr;
    }
}

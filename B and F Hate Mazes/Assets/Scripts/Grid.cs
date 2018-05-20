using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Grid 
    {
        //Grid attributes
        protected List<Cell> cellList = new List<Cell>();
        protected int Number_Rows;
        protected int Number_Columns;
        protected Cell[,] cellArray;

        //Empty constructor
        public Grid()
        {

        }

        //Constructor taking in number of rows and columns
        public Grid(int nRows, int nColumns)
        {
            Number_Rows = nRows;
            Number_Columns = nColumns;
            cellArray = new Cell[nRows, nColumns];
            createGrid();
            //configureCellsList();
            //configureCellsArray();

        }

        //return list of cells;
        public List<Cell> getCellsList()
        {
            return cellList;
        }

        //convert array of cells to list of cells
        public Cell[,] convertListToArray(List<Cell> cellsList)
        {
            
            Cell[,] myCellArray = new Cell[Number_Rows,Number_Columns];
            try
            {
                foreach (Cell i in cellsList)
                {
                    myCellArray[i.getCellRow(), i.getCellColumn()] = i;
                }
            }
            catch(Exception e)
            {
                Debug.Log("Error: " + e.Message);
            }
            return myCellArray;
        }
        
        // return array of cells
        public Cell[,] getCellArray()
        {
            return cellArray;
        }

        //Returns a cell from the cellArray based on the selected row and collumn
        public Cell getCellFromArray(int cRow, int cColumn)
        {
            Cell rCell = cellArray[cRow,cColumn];
            if (rCell != null)
            {
                return rCell;
            }
            else
            {
                return null;
            }
        }

        //Returns a cell from the cellList based on the selected row and collumn
        public Cell getCellFromList(int cRow, int cColumn)
        {
            Cell rCell = null;
            foreach(Cell i in cellList)
            {
                if(i.getCellRow() == cRow && i.getCellColumn() == cColumn)
                {
                    rCell = i;
                }
            }


            return rCell;
        }

        //fill the grid with cells
        public void createGrid()
        {
            for(int i = 0;i<Number_Rows;i++)
                for(int j = 0;j<Number_Columns;j++)
                {
                    Cell newCell = new Cell(i,j);
                    cellArray[i, j] = newCell;
                    cellList.Add(newCell);
                }
        }

        //configure cells from the list by setting their neighbours
        public void configureCellsList ()
        {
            foreach(Cell i in cellList)
            {
                foreach (Cell j in cellList)
                {

                    //Set Neighbour North
                    if (i.getCellRow() != 0)
                    {
                        if (j.getCellColumn() == i.getCellColumn() && j.getCellRow() - 1 == i.getCellRow())
                        {
                            i.setneighbourNorth(j);
                        }
                    }
                    else
                    {
                        i.setneighbourNorth(null);
                    }

                    //Set Neighbour South
                    if (i.getCellRow() != Number_Rows - 1)
                    {
                        if (j.getCellColumn() == i.getCellColumn() && j.getCellRow() + 1 == i.getCellRow())
                        {
                            i.setneighbourSouth(j);
                        }
                    }
                    else
                    {
                        i.setneighbourSouth(null);
                    }

                    //Set Neighbour East
                    if (i.getCellColumn() != 0)
                    {
                        if (j.getCellRow() == i.getCellRow() && j.getCellColumn() + 1 == i.getCellColumn())
                        {
                            i.setneighbourEast(j);
                        }
                    }
                    else
                    {
                        i.setneighbourWest(null);
                    }

                    //SetNeighbour West
                    if (i.getCellColumn() != Number_Columns - 1)
                    {
                        if (j.getCellRow() == i.getCellRow() && j.getCellColumn() - 1 == i.getCellColumn())
                        {
                            i.setneighbourWest(j);
                        }
                    }
                    else
                    {
                        i.setneighbourWest(null);
                    }
                }
            }
        }

        //configure cells from array by setting their neighbours
        public void configureCellsArray()
        {
            for(int i = 0; i<Number_Rows;i++)
            {
                for(int j = 0;j<Number_Columns; j++)
                {
                    // Set Neighbour North
                    if (i != 0)
                    {
                        cellArray[i, j].setneighbourNorth(cellArray[i-1,j]);
                    }
                    if(i == 0)
                    {
                        cellArray[i, j].setneighbourNorth(null);
                    }
                    
                    // Set Neighbour South
                    if(i != Number_Rows - 1)
                    {
                        cellArray[i, j].setneighbourSouth(cellArray[i + 1, j]);
                    }
                    if(i == Number_Rows - 1)
                    {
                        cellArray[i, j].setneighbourSouth(null);
                    }

                    // Set Neighbour West
                    if(j != 0)
                    {
                        cellArray[i, j].setneighbourWest(cellArray[i,j-1]);
                    }
                    if(j == 0)
                    {
                        cellArray[i, j].setneighbourWest(null);
                    }

                    //Set Neighbour East
                    if(j != Number_Columns -1)
                    {
                        cellArray[i, j].setneighbourEast(cellArray[i,j+1]);
                    }
                    if(j == Number_Columns - 1)
                    {
                        cellArray[i, j].setneighbourEast(null);
                    }
                }
            }
        }

        //Used for debuging generation algorithms
        //This method shows each cells column and row together with the columns and rows of all connected cells
        public void printCellsInConsole()
        {

        for (int i = Number_Rows - 1; i >= 0; i--)
        {
            for (int j = 0; j < Number_Columns; j++)
            {
                Debug.Log("CC Row: " + getCellFromArray(i, j).getCellRow() + " Column: " + getCellFromArray(i, j).getCellColumn());
                foreach (Cell c in getCellFromArray(i, j).getLinkedList())
                {
                    Debug.Log("Linked Cell: Row: " + c.getCellRow() + " Column: " + c.getCellColumn());
                }
            }
        }
    }
}
    


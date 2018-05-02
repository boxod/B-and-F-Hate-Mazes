using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid  {

    //Grid Class inherits Cell Class
    public class Grid : CreateCell
    {
        List<Cell> cellList = new List<Cell>();
        private int number_Rows;
        private int number_Columns;
        Cell[,] cellArray;


        public Grid()
        {

        }
        public Grid(int nRows, int nColumns)
        {
            number_Rows = nRows;
            number_Columns = nColumns;
            cellArray = new Cell[nRows, nColumns];
            createGrid();
            //configureCellsList();
            //configureCellsArray();

        }

        public List<Cell> getCellsList()
        {
            return cellList;
        }

        public Cell[,] convertListToArray(List<Cell> cellsList)
        {
            
            Cell[,] myCellArray = new Cell[number_Rows,number_Columns];
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

        public Cell[,] getCellArray()
        {
            return cellArray;
        }

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

        public void createGrid()
        {
            for(int i = 0;i<number_Rows;i++)
                for(int j = 0;j<number_Columns;j++)
                {
                    Cell newCell = new Cell(i,j);
                    cellArray[i, j] = newCell;
                    cellList.Add(newCell);
                }
        }

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
                    if (i.getCellRow() != number_Rows - 1)
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
                    if (i.getCellColumn() != number_Columns - 1)
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

        public void configureCellsArray()
        {
            for(int i = 0; i<number_Rows;i++)
            {
                for(int j = 0;j<number_Columns; j++)
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
                    if(i != number_Rows - 1)
                    {
                        cellArray[i, j].setneighbourSouth(cellArray[i + 1, j]);
                    }
                    if(i == number_Rows - 1)
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
                    if(j != number_Columns -1)
                    {
                        cellArray[i, j].setneighbourEast(cellArray[i,j+1]);
                    }
                    if(j == number_Columns - 1)
                    {
                        cellArray[i, j].setneighbourEast(null);
                    }
                }
            }
        }
    }
    




    //public Material Floor_Material;
    //public int Maze_width;
    //public int Maze_length;


}

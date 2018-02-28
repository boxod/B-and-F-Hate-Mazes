﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour {

    //Grid Class inherits Cell Class
    public class Grid : CreateCell
    {
        List<Cell> allCellsList = new List<Cell>();
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
            return allCellsList;
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

        public void createGrid()
        {
            for(int i = 0;i<number_Rows;i++)
                for(int j = 0;j<number_Columns;j++)
                {
                    Cell newCell = new Cell(i,j);
                    cellArray[i, j] = newCell;
                }
        }

        public void configureCellsList ()
        {
            foreach(Cell i in allCellsList)
            {
                foreach(Cell j in allCellsList)
                {
                    // Set neighbour North
                    if(j.getCellColumn() == i.getCellColumn() && i.getCellRow()-1 == j.getCellRow())
                    {
                        i.setneighbourNorth(j);
                        break;
                    }
                    else
                    {
                        i.setneighbourNorth(null);
                    }
                    // Set neighbour South
                    if (j.getCellColumn() == i.getCellColumn() && i.getCellRow()+1 == j.getCellRow())
                    {
                        i.setneighbourSouth(j);
                        break;
                    }
                    else
                    {
                        i.setneighbourSouth(null);
                    }
                    // Set neighbour West
                    if (j.getCellColumn() == i.getCellColumn()-1 && i.getCellRow() == j.getCellRow())
                    {
                        i.setneighbourWest(j);
                        break;
                    }
                    else
                    {
                        i.setneighbourWest(null);
                    }
                    // Set neighbour East
                    if (j.getCellColumn() == i.getCellColumn()+1 && i.getCellRow() == j.getCellRow())
                    {
                        i.setneighbourEast(j);
                        break;
                    }
                    else
                    {
                        i.setneighbourEast(null);
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
                    
                    // Set Neighbour South
                    if(i != number_Rows - 1)
                    {
                        cellArray[i, j].setneighbourSouth(cellArray[i + 1, j]);
                    }

                    // Set Neighbour West
                    if(j != 0)
                    {
                        cellArray[i, j].setneighbourWest(cellArray[i,j-1]);
                    }

                    //Set Neighbour East
                    if(j != number_Columns -1)
                    {
                        cellArray[i, j].setneighbourEast(cellArray[i,j+1]);
                    }
                }
            }
        }
    }
    




    public Material Floor_Material;
    public int Maze_width;
    public int Maze_length;

	// Use this for initialization
    void Start()
    {

        
        
        
    }



    // Update is called once per frame
    void Update () {
		
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell {


        private int cell_Row;
        private int cell_Column;
        private Cell neighbour_North;
        private Cell neighbour_South;
        private Cell neighbour_East;
        private Cell neighbour_West;
        private List<Cell> linkedCellsList = new List<Cell>();


        //Neighbours Getters and Setters
        //North
        //Set North neighbour
        public void setneighbourNorth(Cell nNorth)
        {
            neighbour_North = nNorth;
        }
        //Get North neighbour
        public Cell getNeighbourNorth()
        {
            return neighbour_North;
        }
        //South
        public void setneighbourSouth(Cell nSouth)
        {
            neighbour_South = nSouth;
        }
        public Cell getNeighbourSouth()
        {
            return neighbour_South;
        }
        //East
        public void setneighbourEast(Cell nEast)
        {
            neighbour_East = nEast;
        }
        public Cell getNeighbourEast()
        {
            return neighbour_East;
        }
        //West
        public void setneighbourWest(Cell nWest)
        {
            neighbour_West = nWest;
        }
        public Cell getNeighbourWest()
        {
            return neighbour_West;
        }

        //Get linked Cells list
        public List<Cell> getLinkedList()
        {
            return linkedCellsList;
        }

        //Get Cell Coordonates
        public int getCellRow()
        {
            return cell_Row;
        }
        public int getCellColumn()
        {
            return cell_Column;
        }


        // Sets all neighbours at once
        public void setAllNeighbours(Cell N_Cell, Cell S_Cell, Cell E_Cell, Cell W_Cell)
        {
            neighbour_East = E_Cell;
            neighbour_North = N_Cell;
            neighbour_South = S_Cell;
            neighbour_West = W_Cell;
        }

        //Empty constructor
        public Cell()
        {
 
        }
        //Cell coordinates constructor
        public Cell(int cellRow, int cellColumn)
        {
            cell_Row = cellRow;
            cell_Column = cellColumn;
        }
 
        //Link Cells together
        public void linkCell( Cell currentCell, Cell linkedCell, bool bound)
        {

            //Debug.Log("currentCell r " + currentCell.getCellRow() + " currCell c " + currentCell.getCellColumn());
           // Debug.Log("linkedCell r " + linkedCell.getCellRow() + " lnikedCell c " + linkedCell.getCellColumn());

            try
            {
                linkedCellsList.Add(linkedCell);
                if (bound == true)
                {
                    linkedCell.linkCell(linkedCell, currentCell, false);
                }

            }
            catch(System.Exception e)
            {
                Debug.Log("Null Exception linkCell: " + e.Message);
            }
            
        }
        //Unlink the Cells
        public void unlinkCell(Cell currentCell, Cell unlinkedCell, bool unbound)
        {
            linkedCellsList.Remove(unlinkedCell);
            if(unbound == true)
            {
                unlinkedCell.unlinkCell(unlinkedCell,currentCell,false);
            }
        }  

        //Check if Cell c is linked t current Cell
        // returns true if yes
        public bool isLinked(Cell C)
        {
            bool link = false;
            foreach(Cell i in linkedCellsList)
            {
                if (C != null && i != null)
                {
                    if (i.getCellRow() == C.getCellRow() && i.getCellColumn() == C.getCellColumn())
                    {
                        link = true;
                    }
                }
            }
            return link;
        }

      
    }
    



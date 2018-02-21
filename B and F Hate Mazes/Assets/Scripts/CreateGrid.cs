using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour {

    //Grid Class inherits Cell Class
    public class Grid : CreateCell
    {
        List<Cell> allCells = new List<Cell>();
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
            createGrid();
            configureCells();

        }

        public void createGrid()
        {
            for(int i = 0;i<number_Rows;i++)
                for(int j = 0;j<number_Columns;j++)
                {
                    Cell newCell = new Cell(i,j);
                    allCells.Add(newCell);
                }
        }

        public void configureCells()
        {
            foreach(Cell i in allCells)
            {
                foreach(Cell j in allCells)
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
    

    }
    




    public Material Floor_Material;
    public int Maze_width;
    public int Maze_length;

	// Use this for initialization
    void Start()
    {

        GameObject Floor = Instantiate(Resources.Load("Floor", typeof(GameObject))) as GameObject;
        
        
    }



    // Update is called once per frame
    void Update () {
		
	}
}

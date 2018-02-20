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

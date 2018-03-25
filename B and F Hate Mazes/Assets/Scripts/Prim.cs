using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prim : MonoBehaviour {

    private int Number_Rows;
    private int Number_Columns;
    CreateGrid.Grid newMaze;
    CreateCell.Cell[,] myArr;
	
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



        return myArr;
    }

}

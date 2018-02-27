using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMaze : MonoBehaviour {

    BinaryTree createnewMaze;
    public GameObject xWallPrefab;
    public GameObject zWallPrefab;
    public GameObject betweenWallsPrefab;
    public int Rows = 1;
    public int Columns = 1;
    public float distanceBetweenObjects = 0.1f;
    private float xStartingPoint = 0;
    private float zStartingPoint = 0;

    // Use this for initialization
    void Start() {
        createnewMaze = new BinaryTree(Rows, Columns);
        CreateCell.Cell[,] MazeArray = createnewMaze.returnBinaryArray();
        float wallPrefabLength = xWallPrefab.GetComponent<Renderer>().bounds.size.x;
        float betweenPrefabLength = betweenWallsPrefab.GetComponent<Renderer>().bounds.size.x;


        GameObject Floor = Instantiate(Resources.Load("Floor", typeof(GameObject))) as GameObject;

        for (int i = 0; i <= Rows; i++)
        {
            for (int j = 0; j <= Columns; j++)
            {
                Vector3 pos = new Vector3(xStartingPoint + (2 * distanceBetweenObjects + wallPrefabLength + betweenPrefabLength) * j, 0, (zStartingPoint + (2 * distanceBetweenObjects + wallPrefabLength + betweenPrefabLength) * i) * -1);
                Instantiate(betweenWallsPrefab, pos, Quaternion.identity);
            }
        }



        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {

                if (j == 0)
                {
                    Vector3 pos = new Vector3(xStartingPoint + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * j, 0, (zStartingPoint + (wallPrefabLength + betweenPrefabLength + distanceBetweenObjects) / 2 + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * i) * -1);
                    Instantiate(zWallPrefab, pos, Quaternion.identity);
                }
                if (i == 0)
                {
                    Vector3 pos = new Vector3(xStartingPoint + (wallPrefabLength + betweenPrefabLength + distanceBetweenObjects) / 2 + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * j, 0, (zStartingPoint + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * i) * -1);
                    Instantiate(xWallPrefab, pos, Quaternion.identity);
                }
                if (j == Columns - 1)
                {
                    Vector3 pos = new Vector3(xStartingPoint + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * (j + 1), 0, (zStartingPoint + (wallPrefabLength + betweenPrefabLength + distanceBetweenObjects) / 2 + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * i) * -1);
                    Instantiate(zWallPrefab, pos, Quaternion.identity);
                }
                if (i == Rows - 1)
                {
                    Vector3 pos = new Vector3(xStartingPoint + (wallPrefabLength + betweenPrefabLength + distanceBetweenObjects) / 2 + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * j, 0, (zStartingPoint + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * (i + 1)) * -1);
                    Instantiate(xWallPrefab, pos, Quaternion.identity);
                }

            }
        }


        //int[,] connectionsArray = new int[Rows + 1, Columns + 1];
        //for (int i = 0; i <= Rows; i++)
        //{
        //    for (int j = 0; j <= Columns; j++)
        //    {
        //        connectionsArray[i, j] = 0;
        //    }
        //}

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                //if(MazeArray[i,j].isLinked(MazeArray[i, j].getNeighbourSouth()) == false)
                //{
                //    Vector3 pos = new Vector3(xStartingPoint + (wallPrefabLength + betweenPrefabLength + distanceBetweenObjects) / 2 + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * j, 0, (zStartingPoint + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * i) * -1);
                //    Instantiate(xWallPrefab, pos, Quaternion.identity);
                //}
                //Debug.Log("ArrayCell[" + i + " , " + j + "] EastNeigbour: Row: " + MazeArray[i,j].getNeighbourEast().getCellRow() + " Column: " + MazeArray[i, j].getNeighbourEast().getCellColumn());

                if (MazeArray[i, j].isLinked(MazeArray[i, j].getNeighbourEast()) == false)
                {
                    if (MazeArray[i, j].getNeighbourEast() != null)
                    {
                        //Debug.Log("ArrayCell[" + i + " , " + j + "] EastNeigbour: Row: " + MazeArray[i, j].getNeighbourEast().getCellRow() + " Column: " + MazeArray[i, j].getNeighbourEast().getCellColumn() + " Are Linked : " + MazeArray[i, j].isLinked(MazeArray[i, j].getNeighbourEast()));

                        int ni = MazeArray[i, j].getNeighbourEast().getCellRow();
                        int nj = MazeArray[i, j].getNeighbourEast().getCellColumn();
                        Vector3 pos = new Vector3(xStartingPoint + (wallPrefabLength + betweenPrefabLength + distanceBetweenObjects) / 2 + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * nj, 0, (zStartingPoint + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * ni) * -1);
                        Instantiate(xWallPrefab, pos, Quaternion.identity);
                    }
                }

                if (MazeArray[i, j].isLinked(MazeArray[i, j].getNeighbourSouth()) == false)
                {
                    if (MazeArray[i, j].getNeighbourSouth() != null)
                    {
                        int ni = MazeArray[i, j].getNeighbourSouth().getCellRow();
                        int nj = MazeArray[i, j].getNeighbourSouth().getCellColumn();
                        Vector3 pos = new Vector3(xStartingPoint + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * nj, 0, (zStartingPoint + (wallPrefabLength + betweenPrefabLength + distanceBetweenObjects) / 2 + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * ni) * -1);
                        Instantiate(zWallPrefab, pos, Quaternion.identity);

                    }
                }
            }
        }




    }


    

    // Update is called once per frame
    void Update () {
		
	}
}

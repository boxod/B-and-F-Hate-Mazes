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

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {

                if (j == 0)
                {
                    Vector3 pos2 = new Vector3(xStartingPoint + (wallPrefabLength + betweenPrefabLength + distanceBetweenObjects) / 2 + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * i, 0, (zStartingPoint + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * j) * -1);
                    Instantiate(xWallPrefab, pos2, Quaternion.identity);            
                }
                if(i == 0)
                {
                    Vector3 pos3 = new Vector3(xStartingPoint + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * i, 0, (zStartingPoint + (wallPrefabLength + betweenPrefabLength + distanceBetweenObjects) / 2 + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * j) * -1);
                    Instantiate(zWallPrefab, pos3, Quaternion.identity);
                }
                if(j == Columns-1)
                {
                    Vector3 pos2 = new Vector3(xStartingPoint + (wallPrefabLength + betweenPrefabLength + distanceBetweenObjects) / 2 + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * i, 0, (zStartingPoint + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * (j +1)) * -1);
                    Instantiate(xWallPrefab, pos2, Quaternion.identity);
                }
                if(i == Rows-1)
                {
                    Vector3 pos3 = new Vector3(xStartingPoint + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * (i+1), 0, (zStartingPoint + (wallPrefabLength + betweenPrefabLength + distanceBetweenObjects) / 2 + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * j) * -1);
                    Instantiate(zWallPrefab, pos3, Quaternion.identity);
                }
                List<CreateCell.Cell> linkedCells = MazeArray[i, j].getLinkedList();
                foreach(CreateCell.Cell a in linkedCells)
                {
                    int r = a.getCellRow();
                    int c = a.getCellColumn();
                }
            }
        }

        for (int i = 0; i <= Rows; i++)
        {
            for (int j = 0; j <= Columns; j++)
            {
                Vector3 pos = new Vector3(xStartingPoint + (2 * distanceBetweenObjects + wallPrefabLength + betweenPrefabLength)* i, 0, (zStartingPoint + (2 * distanceBetweenObjects + wallPrefabLength + betweenPrefabLength) * j) *-1);
                Instantiate(betweenWallsPrefab, pos, Quaternion.identity);
            }
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}

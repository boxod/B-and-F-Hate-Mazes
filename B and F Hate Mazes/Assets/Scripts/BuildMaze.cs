using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMaze : MonoBehaviour {

    private class centreOfCells
    {
        public float cellXCoordinate = 0.0f;
        public float cellZCoordinate = 0.0f;
        public float cellYCoordinate = 0.0f;


        public centreOfCells(float cellX, float cellY, float cellZ)
        {
            cellXCoordinate = cellX;
            cellYCoordinate = cellY;
            cellZCoordinate = cellZ;
        }


    }

    BinaryTree createnewMaze;
    //BinaryTree createNewMaze2;
    [SerializeField]
    public enum MazeType {Binary,Prim};
    public MazeType myMaze;
    public GameObject xWallPrefab;
    public GameObject zWallPrefab;
    public GameObject betweenWallsPrefab;
    public int Rows = 1;
    public int Columns = 1;
    public float distanceBetweenObjects = 0.1f;
    private float xStartingPoint = 0.0f;
    private float zStartingPoint = 0.0f;
    private float yStartingPoint = 0.0f;

    public GameObject PlayerPrefab;
    public GameObject LightDropPrefab;

    private centreOfCells[,] arrayOfCellsCentre;
    public Transform SpawnLocation;





    // Use this for initialization
    void Start() {
        GameObject Floor = Instantiate(Resources.Load("Floor", typeof(GameObject))) as GameObject;

        Rows = Random.Range(4,10);
        Columns = Random.Range(4,10);

        CreateMazeWalls();

        LightDrop lightDrop = new LightDrop(PlayerPrefab, LightDropPrefab);
        lightDrop.setNumberLightDrops(Rows,Columns);




    }


    public void placePlayer()
    {
        int columnorRow = Random.Range(0, 11);



        int posX = Random.Range(0,Rows-1);
        int posZ = Random.Range(0,Columns-1);
        Vector3 playerPosition = new Vector3(arrayOfCellsCentre[posX,posZ].cellXCoordinate, arrayOfCellsCentre[posX, posZ].cellYCoordinate,arrayOfCellsCentre[posX,posZ].cellZCoordinate);
        Quaternion playerRotation = new Quaternion(0,0,0,0);
        Instantiate(PlayerPrefab,playerPosition,playerRotation);
    }

    public void CreateMazeWalls()
    {
        createnewMaze = new BinaryTree(Rows, Columns);
        CreateCell.Cell[,] MazeArray = createnewMaze.returnBinaryArray();
        float wallPrefabLength = xWallPrefab.GetComponent<Renderer>().bounds.size.x;
        float betweenPrefabLength = betweenWallsPrefab.GetComponent<Renderer>().bounds.size.x;
        arrayOfCellsCentre = new centreOfCells[Rows,Columns];


        for (int i = 0; i <= Rows; i++)
        {
            for (int j = 0; j <= Columns; j++)
            {
                Vector3 pos = new Vector3((xStartingPoint + (2 * distanceBetweenObjects + wallPrefabLength + betweenPrefabLength) * i) * -1, yStartingPoint, (zStartingPoint + (2 * distanceBetweenObjects + wallPrefabLength + betweenPrefabLength) * j) * -1);
                Instantiate(betweenWallsPrefab, pos, Quaternion.identity);
                if (i < Rows && j<Columns)
                { 
                    arrayOfCellsCentre[i, j] = new centreOfCells((xStartingPoint + (2 * distanceBetweenObjects + wallPrefabLength + betweenPrefabLength) * i + (2 * distanceBetweenObjects + wallPrefabLength + betweenPrefabLength) / 2) * -1, yStartingPoint, (zStartingPoint + (2 * distanceBetweenObjects + wallPrefabLength + betweenPrefabLength) * j + (2 * distanceBetweenObjects + wallPrefabLength + betweenPrefabLength) / 2) * -1);
                }
            }
        }

        placePlayer();

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {

                if (i == 0)
                {
                    Vector3 pos = new Vector3((xStartingPoint + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * i) * -1, yStartingPoint, (zStartingPoint + (wallPrefabLength + betweenPrefabLength + distanceBetweenObjects) / 2 + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * j) * -1);
                    Instantiate(zWallPrefab, pos, Quaternion.identity);
                }
                if (j == 0)
                {                  
                    Vector3 pos = new Vector3((xStartingPoint + (wallPrefabLength + betweenPrefabLength + distanceBetweenObjects) / 2 + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * i) * -1, yStartingPoint, (zStartingPoint + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * j) * -1);
                    Instantiate(xWallPrefab, pos, Quaternion.identity);

                }
                if (j == Columns - 1)
                {
                        Vector3 pos = new Vector3((xStartingPoint + (wallPrefabLength + betweenPrefabLength + distanceBetweenObjects) / 2 + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * i) * -1, yStartingPoint, (zStartingPoint + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * (j+ 1)) * -1);

                        Instantiate(xWallPrefab, pos, Quaternion.identity);
                }
                if (i == Rows - 1)
                {
                    Vector3 pos = new Vector3((xStartingPoint + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * (i + 1)) * -1, yStartingPoint, (zStartingPoint + (wallPrefabLength + betweenPrefabLength + distanceBetweenObjects) / 2 + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * j) * -1);
                    Instantiate(zWallPrefab, pos, Quaternion.identity);
                }

            }
        }


        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (MazeArray[i, j].getNeighbourEast() != null && MazeArray[i, j].isLinked(MazeArray[i, j].getNeighbourEast()) == false)
                {
                    int nEastRow = MazeArray[i, j].getNeighbourEast().getCellRow();
                    int nEastColumn = MazeArray[i, j].getNeighbourEast().getCellColumn();
                    Vector3 pos = new Vector3((xStartingPoint + (wallPrefabLength + betweenPrefabLength + distanceBetweenObjects) / 2 + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * nEastRow) * -1, yStartingPoint, (zStartingPoint + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * nEastColumn) * -1);
                    Instantiate(xWallPrefab, pos, Quaternion.identity);
                }

                if (MazeArray[i, j].getNeighbourSouth() != null && MazeArray[i, j].isLinked(MazeArray[i, j].getNeighbourSouth()) == false)
                {
                    int nSouthRow = MazeArray[i, j].getNeighbourSouth().getCellRow();
                    int nSouthColumn = MazeArray[i, j].getNeighbourSouth().getCellColumn();
                    Vector3 pos = new Vector3((xStartingPoint + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * nSouthRow) * -1, yStartingPoint, (zStartingPoint + (wallPrefabLength + betweenPrefabLength + distanceBetweenObjects) / 2 + (2 * distanceBetweenObjects + betweenPrefabLength + wallPrefabLength) * nSouthColumn) * -1);
                    Instantiate(zWallPrefab, pos, Quaternion.identity);
                }
            }
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}

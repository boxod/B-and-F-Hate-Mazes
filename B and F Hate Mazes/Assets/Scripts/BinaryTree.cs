using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryTree : MonoBehaviour {

    // Use this for initialization
    CreateGrid.Grid newMaze = new CreateGrid.Grid(5,5);
    
    
	void Start () {
        newMaze.createGrid();
        newMaze.configureCells();

        foreach (CreateCell.Cell i in newMaze.getCellsList())
        {
            int rndm = Random.Range(0,10);
            if(rndm <5 && i.getNeighbourNorth() != null)
            {
                i.linkCell(i,i.getNeighbourNorth(),true);
            }
            else if(i.getNeighbourNorth() == null && i.getNeighbourEast() != null)
            {
                i.linkCell(i,i.getNeighbourEast(),true);
            }
            if(rndm >=5 && i.getNeighbourEast() != null)
            {
                i.linkCell(i,i.getNeighbourEast(),true);
            }
            else if(i.getNeighbourEast() == null && i.getNeighbourNorth() != null)
            {
                i.linkCell(i,i.getNeighbourNorth(),true);
            }
        }
        
        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

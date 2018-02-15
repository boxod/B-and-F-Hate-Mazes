using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCell : MonoBehaviour {

	//Cell Class
    public class Cell
    {
        private int cell_Row;
        private int cell_Column;
        private Cell neighbour_North;
        private Cell neighbour_South;
        private Cell neighbour_East;
        private Cell neighbour_West;

        public Cell()
        {
            cell_Row = 1;
            cell_Column = 1;
        }

    }
    

    
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

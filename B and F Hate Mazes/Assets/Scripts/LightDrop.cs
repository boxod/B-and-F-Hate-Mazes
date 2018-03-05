using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDrop : MonoBehaviour {

    private GameObject PlayerPrefab;
    private GameObject LightDropPrefab;
    private int lightDropCharges = 0;
    private int totalLightDrops = 0;
    
    
    public LightDrop(GameObject playerP, GameObject lightDropP)
    {
        PlayerPrefab = playerP;
        LightDropPrefab = lightDropP;
    }

    public void setNumberLightDrops(int mazeRows, int mazeColumns)
    {
        totalLightDrops = (mazeRows * mazeColumns) / 3;
    }
    public int getNumberLightDrops()
    {
        return lightDropCharges;
    }

    public void placeLightCharge(float xCoordinate, float yCoordinate, float zCoordinate, Animation lightDropFall)
    {
        Vector3 lightPoz = new Vector3(xCoordinate,yCoordinate,zCoordinate);
        Quaternion lightRoatation = new Quaternion(0,0,0,0);
        Instantiate(LightDropPrefab, lightPoz, lightRoatation);        
    }
    public void removeLightCharge()
    {

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

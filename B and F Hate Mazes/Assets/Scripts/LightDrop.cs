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

    public void placeLightCharge()
    {

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

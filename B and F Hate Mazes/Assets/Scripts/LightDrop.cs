using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDrop : MonoBehaviour
{

    private GameObject PlayerPrefab;
    private GameObject LightDropPrefab;
    private int lightDropCharges = 0;
    private int totalLightDrops = 0;
    private float lXCoord;
    private Transform lightDropCoordinates;

    // Constructor that sets the number of drops and prefab
    public LightDrop(GameObject playerP, GameObject lightDropP, int mazeRows, int mazeColumns)
    {
        PlayerPrefab = playerP;
        LightDropPrefab = lightDropP;
       
    }

    public LightDrop()
    {
        
    }

    public void setNumberLightDrops(int mazeRows, int mazeColumns)
    {
        totalLightDrops = (mazeRows * mazeColumns) / 3;
    }
    public int getNumberLightDrops()
    {
        return lightDropCharges;
    }

    public void placeLightCharge(float xCoordinate, float yCoordinate, float zCoordinate)
    {
        Vector3 lightPoz = new Vector3(xCoordinate, yCoordinate, zCoordinate);
        Quaternion lightRoatation = new Quaternion(0, 0, 0, 0);
        Instantiate(LightDropPrefab, lightPoz, lightRoatation);
        LightDrop newLightDrop = new LightDrop();

    }
    public void removeLightCharge(LightDrop currentDrop)
    {
        Destroy(currentDrop.LightDropPrefab);
    }

    public bool areSame(LightDrop currD, LightDrop checkD)
    {
        bool isTrue = false;
        if (currD == checkD)
        {
            isTrue = true;
        }
        return isTrue;
    }

}


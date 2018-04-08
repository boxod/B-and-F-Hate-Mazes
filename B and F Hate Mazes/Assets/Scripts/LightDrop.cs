using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDrop : MonoBehaviour
{

    private GameObject LightDropPrefab;
    private Transform lightDropCoordinates;




    // Constructor for lightdrop that also places them in the game as prefabs when called
    public LightDrop(GameObject lightDropP, Transform lightDropLocation)
    {
        LightDropPrefab = lightDropP;
        lightDropCoordinates = lightDropLocation;
        placeLightCharge(lightDropLocation);
       
    }


    public void placeLightCharge(Transform lightDropLocation)
    {
        float xCoordinate = 0, yCoordinate = 0, zCoordinate = 0; 
        Vector3 lightPoz = new Vector3(xCoordinate, yCoordinate, zCoordinate);
        Quaternion lightRoatation = new Quaternion(0, 0, 0, 0);
        Instantiate(LightDropPrefab, lightPoz, lightRoatation);
    }

    public void removeLightCharge()
    {
        Destroy(LightDropPrefab);
    }

    

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDrop : MonoBehaviour
{

    private GameObject LightDropPrefab;
    private GameObject playerPrefab;


    public LightDrop()
    {

    }

    // Constructor for lightdrop that also places them in the game as prefabs when called
    public LightDrop(GameObject lightDropP, GameObject pPrefab)
    {
        LightDropPrefab = lightDropP;
        playerPrefab = pPrefab;
        placeLightCharge(playerPrefab);
       
    }


    public void placeLightCharge(GameObject pPrefab)
    {
        Vector3 lightPoz = pPrefab.transform.position;
        lightPoz.y = lightPoz.y + 0.5f;
        Quaternion lightRoatation = new Quaternion(0, 0, 0, 0);
        Instantiate(LightDropPrefab, lightPoz, lightRoatation);
    }

    public void removeLightCharge()
    {
        Destroy(LightDropPrefab);
    }

    

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LightDrops : MonoBehaviour {

    public GameObject LightDrop;
    public Transform PlayerPrefab;
    public HUDScript HUD;

    private int currentLightDrops;
    private int maxNumberDrops = 5;
    private bool isNearDrop = false;
    private GameObject closeDrop;

    private List<GameObject> myLightDrops = new List<GameObject>();
    
    public void placeCharge()
    {
        HUD.updateCharges(5);
    }

	

    public void DropEvent()
    {
        if (isNearDrop == false)
        {
            dropDrop();
        }
        else
        {
            pickupDrop();
        }
    }

    public void pickupDrop()
    {
        if(closeDrop != null)
        {
            DestroyObject(closeDrop);
            currentLightDrops++;
            HUD.closeMessagePanel();
            isNearDrop = false; 
        }
        Debug.Log("Pickup");
    }
    public void dropDrop()
    {
        if (currentLightDrops != 0)
        {
            Vector3 lPos = new Vector3(PlayerPrefab.position.x, PlayerPrefab.position.y + 0.5f, PlayerPrefab.position.z);
            ////Debug.Log("Drop: " + currentLightDrops + " pos before change: X:" + myLightDrops[currentLightDrops - 1].transform.position.x + " Y: " + myLightDrops[currentLightDrops - 1].transform.position.y + " Z: " + myLightDrops[currentLightDrops - 1].transform.position.z);
            //myLightDrops[currentLightDrops - 1].transform.position = lPos;


            //myLightDrops[currentLightDrops - 1].gameObject.SetActive(true);
            //Debug.Log("Is it active: " + myLightDrops[currentLightDrops - 1].active);

            Instantiate(LightDrop, lPos, PlayerPrefab.rotation);


            currentLightDrops--;
        }
        else if(currentLightDrops == 0)
        {
            HUD.openNoMoreDropsPanel();
        }
        Debug.Log("Drop");
    }

    public void Start()
    {
        currentLightDrops = maxNumberDrops;
        //for (int i = 0; i < maxNumberDrops; i++)
        //{
        //    Instantiate(LightDrop, PlayerPrefab.position, PlayerPrefab.rotation);
        //    LightDrop.gameObject.SetActive(false);
        //    myLightDrops.Add(LightDrop);
        //}

    }

    public void Update()
    {
        HUD.updateCharges(currentLightDrops);
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("Drop F");
            DropEvent();
        }

    }

    // Bogdan Code:
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LightDrop")
        {
            //Debug.Log("Light Here");
            HUD.openMessagePanel("");
            isNearDrop = true;
            closeDrop = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "LightDrop")
        {
           // Debug.Log("No Light Here");
            HUD.closeMessagePanel();
            isNearDrop = false;
            closeDrop = null;
        }
    }
}


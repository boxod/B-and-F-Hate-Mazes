using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LightDrops : MonoBehaviour {

    public GameObject LightDrop;
    public Transform PlayerPrefab;
    public HUDScript HUD;

    public AudioSource OnDrop;
    public AudioSource OnPickup;

    private int currentLightDrops;
    private int maxNumberDrops = 8;
    private bool isNearDrop = false;
    private GameObject closeDrop;

    //private List<GameObject> myLightDrops = new List<GameObject>();
    
    public void placeCharge()
    {
        HUD.updateCharges(maxNumberDrops);
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
            OnPickup.Play();
            DestroyObject(closeDrop);
            currentLightDrops++;
            HUD.closeMessagePanel();
            isNearDrop = false; 
        }
    }
    public void dropDrop()
    {
        if (currentLightDrops != 0)
        {
            OnDrop.Play();
            Vector3 lPos = new Vector3(PlayerPrefab.position.x, PlayerPrefab.position.y + 0.5f, PlayerPrefab.position.z);
            Quaternion spawnRotation = Quaternion.Euler(-90, 0, 0);
            Instantiate(LightDrop, lPos, spawnRotation);

            currentLightDrops--;
        }
        else if(currentLightDrops == 0)
        {
            HUD.openNoMoreDropsPanel();
        }
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
        if(Input.anyKey == true)
        {
            HUD.hideInstructions();
        }
        HUD.updateCharges(currentLightDrops);
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("Drop F");
            DropEvent();
        }
        try
        {
            if (Input.GetButtonDown("A_Button"))
            {
                DropEvent();
            }
        }
        catch(Exception e)
        {
            Debug.Log("No input detected: " + e.Message);
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


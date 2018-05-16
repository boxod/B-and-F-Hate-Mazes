using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class HUDScript : MonoBehaviour {


    public GameObject MessagePanel;
    public GameObject LightDropCharges;
    public GameObject NoMoreDrops;
    
 

	// Use this for initialization
	void Start () {
		
	}
	
    public void openMessagePanel (string text)
    {
        if(NoMoreDrops.active == true)
        {
            NoMoreDrops.SetActive(false);
        }
        MessagePanel.SetActive(true);
        
    }

    public void closeMessagePanel()
    {
        MessagePanel.SetActive(false);
    }

    public void updateCharges(int charges)
    {
        String text = charges.ToString();
        LightDropCharges.GetComponent<TextMeshProUGUI>().SetText(text); 
        
    }

    public void openNoMoreDropsPanel()
    {
        NoMoreDrops.SetActive(true);
        
    }



    // Update is called once per frame
    void Update () {
		
	}
}

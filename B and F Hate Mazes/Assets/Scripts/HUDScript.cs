using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class HUDScript : MonoBehaviour {


    public GameObject MessagePanel;
    public GameObject LightDropCharges;

 

	// Use this for initialization
	void Start () {
		
	}
	
    public void openMessagePanel (string text)
    {
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

	// Update is called once per frame
	void Update () {
		
	}
}

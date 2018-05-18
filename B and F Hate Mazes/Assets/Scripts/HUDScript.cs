using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class HUDScript : MonoBehaviour {


    public GameObject MessagePanel;
    public GameObject LightDropCharges;
    public GameObject NoMoreDrops;
    public GameObject Instructions;

    public void openMessagePanel(string text)
    {
        if (NoMoreDrops.active == true)
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

    public void hideInstructions()
    {
        Instructions.SetActive(false);
    }

    public void openNoMoreDropsPanel()
    {
        StartCoroutine(OpenNoMoreDropsPanel());
    }

    public IEnumerator OpenNoMoreDropsPanel()
    {
        Debug.Log("Start Waiting");
        NoMoreDrops.SetActive(true);
        yield return new WaitForSeconds(2);
        NoMoreDrops.SetActive(false);

    }

}

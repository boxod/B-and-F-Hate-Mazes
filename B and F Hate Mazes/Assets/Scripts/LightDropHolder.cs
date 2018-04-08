using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDropHolder : MonoBehaviour {

    public GameObject PlayerPrefab;
    public GameObject LightDropPrefab;
    public int maxNumOfDrops = 16;
    int currentNumberofDrops = 0;

    private List<LightDrop> LightDropList;

    public void addLighDrop()
    {
        LightDrop newLightDrop = new LightDrop(LightDropPrefab, PlayerPrefab.transform);
        LightDropList.Add(newLightDrop);
        currentNumberofDrops++;
    }

    public void removeLightDrop(LightDrop lightDrop)
    {
        lightDrop.removeLightCharge();
        LightDropList.Remove(lightDrop);
        currentNumberofDrops--;
    }


    // Update is called once per frame
    void Update()
    {
        bool isLightKeyDown = Input.GetKeyDown(KeyCode.F);
       
            if (isLightKeyDown == true)
            {

                if (currentNumberofDrops < maxNumOfDrops)
                {
                addLighDrop();
                Debug.Log("Place LightDrop");
                }
                
            }
    }


    
}

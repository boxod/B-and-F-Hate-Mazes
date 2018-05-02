using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDropHolder : MonoBehaviour {

    public GameObject PlayerPrefab;
    public GameObject LightDropPrefab;

    private int maxNumOfDrops = 5;
    int currentNumberofDrops = 0;

    int testct = 0;
    private int mazeRows = 5;
    private int mazeColumns = 5;
    private Transform playerLocation;

    // Variables for GUI
    public static float messageDisplayTimer;
    public static bool dsp = false;
   


    public void Start ()
    {

    }


    public void addLighDrop()
    {
        testct++;
        Debug.Log("Was in addLight " + testct + " times");
        //Vector3 lightPoz = PlayerPrefab.transform.position;
        //lightPoz.y = lightPoz.y + 0.5f;
        //Quaternion lightRoatation = new Quaternion(0, 0, 0, 0);
        //Instantiate(LightDropPrefab, lightPoz, lightRoatation);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) == true)
        {
            if (currentNumberofDrops < maxNumOfDrops)
            {
                addLighDrop();
                currentNumberofDrops++;
            }
            if (currentNumberofDrops == maxNumOfDrops)
            {
                if (dsp == false)
                {
                    messageDisplayTimer = 2;
                }
            }
        }
        
    }


}

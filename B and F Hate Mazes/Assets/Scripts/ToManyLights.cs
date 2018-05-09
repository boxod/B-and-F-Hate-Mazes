using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToManyLights : MonoBehaviour {

    Rect rect;
    Texture texture;
    float messageDisplayTimer;
    // Use this for initialization
    void Start () {
        float size = Screen.width * 0.1f;
        rect = new Rect(Screen.width/2.0f - size/2.0f,Screen.height * 0.3f,size,size);
        texture = Resources.Load("Textures/ToManyLightsText") as Texture;
	}
	
	// Update is called once per frame
	void Update () {
        //messageDisplayTimer = LightDropHolder.messageDisplayTimer;
        if (messageDisplayTimer > 0)
        {
            messageDisplayTimer -= Time.deltaTime;
            Debug.Log("MDT: " + messageDisplayTimer);
        }
    }
    void OnGUI()
    {
        if (messageDisplayTimer > 0)
        {
            messageDisplayTimer -= Time.deltaTime;
            GUI.DrawTexture(rect, texture);
        }
    }
}

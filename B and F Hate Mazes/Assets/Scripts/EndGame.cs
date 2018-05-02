using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    public GameObject Player;
    public string LoadLevel = "End Game Scene";

    private void OnTriggerEnter(Collider collision)
    {      
        //Debug.Log("Player Name (prefab): " + Player.name);
        string collName = Player.name + "(Clone)";
        Debug.Log("Collname: " + collName);
        Debug.Log("collision.GameObject.name: " + collision.gameObject.name);

        if (string.Compare(collision.gameObject.name,collName) == 0)
        {
            //float x = collision.gameObject.transform.position.x;
            //float y = collision.gameObject.transform.position.y;
            //float z = collision.gameObject.transform.position.z;
            //Debug.Log("collision x = " + x + " collision y = " + y + " collision z = " + z);
            //Application.LoadLevel(LoadLevel);

            SceneManager.LoadScene(LoadLevel, LoadSceneMode.Additive);

        }
    } 
}

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;//***

public class Engel : MonoBehaviour
{
    private Scene scene;
    
    private void Awake()
    {
        scene = SceneManager.GetActiveScene();//aktif scene
        Debug.Log(scene.name);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))  //engele player çarparsa
        {
          
           
            SceneManager.LoadScene(scene.name);//baþa dön
            score.lives--;
            
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft: MonoBehaviour
{
    [SerializeField] float speed = 30; //Groundが動く速さ
    PlayerConttrore playerControllerScript;
    float leftBound = 15;
  
    void Start()
    {
      playerControllerScript = GameObject.Find("Player").GetComponent<PlayerConttrore>();
    }

    void Update()
    {
        if(playerControllerScript.gameOver == false) { 
         transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);}
    }
}

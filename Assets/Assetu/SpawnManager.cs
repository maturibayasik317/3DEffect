using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;//障害物プレハブ
    Vector3 spawnPosb = new Vector3(25,0,0);// スポーンする場所
    float elapsedTime;//経過時間
    PlayerConttrore playerContollerScript;

    private void Start() {
        playerContollerScript = GameObject.Find("Player").GetComponent<PlayerConttrore>();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;//毎Fの時間を足していく
       if(elapsedTime > 2.0f && !playerContollerScript.gameOver) {
            Instantiate(obstaclePrefab, spawnPosb, obstaclePrefab.transform.rotation);
            elapsedTime = 0.0f;//経過時間リセット
        }
    }
}

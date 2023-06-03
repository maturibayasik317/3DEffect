using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConttrore : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    [SerializeField] float gravityModifier;//重力調整値
    [SerializeField] float jumpForce;//ジャンプ力
    [SerializeField] bool isOnGround;//地面についていかどうか
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] ParticleSystem dirtParticle;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーを押されて、かつ、地面にいたら
        if(Input.GetKeyDown(KeyCode.Space)　&& isOnGround) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  
            isOnGround = false;
            dirtParticle.Stop(); } //ジャンプした＝地面にいない
    }
    //衝突が起きたら
    private void OnCollisionEnter(Collision collision) {
        //ぶつかった相手（collision）のタグがGroundなら
        if(collision.gameObject.CompareTag("Ground")) { 
            isOnGround = true;
            explosionParticle.Play();
            dirtParticle.Play();
        }
        else if(gameObject.CompareTag("Obstacle")) {
            dirtParticle.Stop();
        }
    }
}

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
<<<<<<< HEAD
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] ParticleSystem dirtParticle;
=======
    public  bool gameOver = false;
    Animator playerAnime;

>>>>>>> 696b88fe1dd41dc3e76e98a06b39461afa0eabc8
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーを押されて、かつ、地面にいたら
        if(Input.GetKeyDown(KeyCode.Space)　&& !gameOver) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  
<<<<<<< HEAD
            isOnGround = false;
            dirtParticle.Stop(); } //ジャンプした＝地面にいない
=======
            isOnGround = false; } 
        playerAnime.SetTrigger("Jump_trig");
>>>>>>> 696b88fe1dd41dc3e76e98a06b39461afa0eabc8
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
        if(collision.gameObject.CompareTag("Obstacle")) {
            gameOver = true;
            playerAnime.SetBool("Death_b", true);
            playerAnime.SetInteger("DeathType_int",1);
        }  
    }
}

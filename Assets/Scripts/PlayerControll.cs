using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControll : MonoBehaviour
{
    private bool jump = false;
    public float moveForce = 20;
    public float maxSpeed = 10;
    public float jumpFoce = 700;
    public Transform groundCheck;

    private float hForce = 1;
    private bool grounded = false;
    private bool spinDash = false;
    private Rigidbody2D rb2d;
    private bool isAlive = true;

    public int hForceShot;
    // Start is called before the first frame update
    private Animator anim;

    public Rigidbody2D coinsPreFab;
    public Transform coinSpawner;

    public GameObject shield;
    private bool hadShot= false;
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        anim.SetBool("OnGround", grounded);
        if (grounded)
        {
            anim.SetBool("Jump", false);
        }

        anim.SetBool("SpinDash", spinDash);

        if (spinDash)
        {
            hForce = 0.01f;
            if(rb2d.velocity.x <= 1)
            {
                spinDash = false;
                hForce = 1;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            anim.SetFloat("Speed", rb2d.velocity.x);

            rb2d.AddForce(Vector2.right * hForce * moveForce);
            if (rb2d.velocity.x > maxSpeed)
            {
                rb2d.velocity = new Vector2(Math.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

            }
            if (jump && !hadShot){
                anim.SetBool("Jump", true);
                rb2d.AddForce(new Vector2(0, jumpFoce));
                jump = false;
            }
        }
    }

    public void Jump() {
        if (grounded)
        {
            jump = true;
        }
    }

    public void SpinDash() {
        if (grounded && !hadShot)
        {
            spinDash = true;
        }
    }

    public void HadShot()
    {
        if (hadShot)
        {
            return; 
        }
        else if(isAlive && !hadShot)
        {
            if(LevelManeger.levelManeger.GetCoins() > 0)
            {
                hadShot = true;
                spinDash = false;
                jump = false;
                anim.SetBool("Jump", false);
                anim.SetBool("SpinDash", false);
                rb2d.velocity = Vector2.zero;
                anim.SetTrigger("Shot");
                rb2d.AddForce(new Vector2(hForceShot, 10), ForceMode2D.Impulse);
                hForce = 0;

                int allCoins = LevelManeger.levelManeger.GetCoins();
                if(allCoins > 9)
                {
                    allCoins = 10;
                }
                LevelManeger.levelManeger.ResetCoins();
                for (int i = 0; i < allCoins; i++)
                {
                    Rigidbody2D tempCoins = Instantiate(coinsPreFab, coinSpawner.position, Quaternion.identity) as Rigidbody2D;
                    int randomForceX = UnityEngine.Random.Range(-20, 5);
                    int randomForceY = UnityEngine.Random.Range(1, 10);
                    tempCoins.AddForce(new Vector2(randomForceX, randomForceY), ForceMode2D.Impulse);

                }
            }
            else{
                Died();
            }
        }
    }

    public void EndShot()
    {
        hadShot = false;
        hForce = 1;
    }

    public void Died()
    {
        if (isAlive)
        {
            isAlive = false;
            spinDash = false;
            jump = false;
            anim.SetBool("Jump", false);
            anim.SetBool("SpinDash", false);
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            anim.SetBool("Died", true);
            Invoke("GameOver", 2f);
        }
    }

    private void GameOver()
    {
        LevelManeger.levelManeger.GameOver();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    private Rigidbody2D rbd;
    private Animator anim;
    public float velocidade = 5;
    public float pulo = 400;
    private bool chao = true;
    private bool right = true;
 
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        chao = true;
        transform.parent = collision.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        chao = false;
        transform.parent = null;
    }
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float velY;

        if(x == 0)
        {
            anim.SetBool("parado", true);
        }
        if(x != 0 && chao)
        {
            anim.SetBool("parado", false);
        }
        else
        {
            anim.SetBool("parado", true);
        }

        if (right && x < 0 || !right && x > 0)
        {
            right = !right;
            transform.Rotate(new Vector2(0, 180));
        }

        if (chao)
        {
            velY = 0;
        }
        else
        {
            velY = rbd.velocity.y;
        }
        rbd.velocity = new Vector2(x * velocidade, velY );

        if (Input.GetKeyDown(KeyCode.Space) && chao)
        {
            chao = false;
            rbd.AddForce(new Vector2(0,pulo));
        }
    }
}

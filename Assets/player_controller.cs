using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_controller : MonoBehaviour
{
    private Rigidbody2D rbd;
    private Animator anim;
    public float velocidade = 5;
    public float pulo = 400;
    private bool chao = false;
    private bool right = true;
    public LayerMask enemyMask;
    public LayerMask groundMask;
    public LayerMask gemMask;
    public GameObject prefabExplosion;
    public GameObject countGems;
    private TextMesh count;
    public static int countNumber = 0;
    public static int countGemsinGame = 0;


    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        count = countGems.GetComponent<TextMesh>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "colisores") {
            transform.parent = collision.transform;
            chao = true;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "door")
        {
            if(countNumber == countGemsinGame)
            {
                SceneManager.LoadScene("finalGame");
            }
        }
    }



    void Update()
    {
        count.text = countNumber + "/" + countGemsinGame;

        float x = Input.GetAxis("Horizontal");
        bool y = Input.GetKey(KeyCode.S);
        float velY;

        if(y)
        {
            anim.SetBool("abaixado", true);
            GetComponent<BoxCollider2D>().enabled = false;
            velocidade = 1;
        }
        else
        {
            anim.SetBool("abaixado", false);
            GetComponent<BoxCollider2D>().enabled = true;
            velocidade = 5;
        }

        if(x == 0.0f)
        {
            anim.SetBool("parado", true);
        }
        if(x != 0.0f)
        {
            anim.SetBool("parado", false);
        }
        else
        {
            anim.SetBool("parado", true);
        }

        if (right && x < 0.0f || !right && x > 0.0f)
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
        rbd.velocity = new Vector2(x * velocidade, velY);

        if (Input.GetKeyDown(KeyCode.Space) && chao)
        {
            transform.parent = null;
            chao = false;
            rbd.AddForce(new Vector2(0,pulo));
        }

        RaycastHit2D hit;
        RaycastHit2D hitGround;
        RaycastHit2D hitCoin;

        hit = Physics2D.Raycast(transform.position, -transform.up, 1f, enemyMask);
        if(hit.collider != null)
        {
            Destroy(hit.collider.gameObject);
            Instantiate(prefabExplosion, new Vector2(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y), Quaternion.identity) ;
        }
        hitGround = Physics2D.Raycast(transform.position, -transform.up, 0.8f, groundMask);
        if (hitGround.collider == null)
        {
            transform.parent = null;
            chao = false;
        }
        hitGround = Physics2D.Raycast(transform.position, transform.right, 0.1f, groundMask);
        if (hitGround.collider != null)
        {
            chao = false;
            rbd.velocity = new Vector2(x , -50);
        }
        hitGround = Physics2D.Raycast(transform.position, -transform.right, 0.1f, groundMask);
        if (hitGround.collider != null)
        {
            chao = false;
            rbd.velocity = new Vector2(x, -50);
        }
        hitCoin = Physics2D.Raycast(transform.position, -transform.up, 0.5f, gemMask);
        if (hitCoin.collider != null)
        {
            Destroy(hitCoin.collider.gameObject);
            countNumber += 1;
        }
        hitCoin = Physics2D.Raycast(transform.position, -transform.right, 0.5f, gemMask);
        if (hitCoin.collider != null)
        {
            Destroy(hitCoin.collider.gameObject);
            countNumber += 1;
        }
      
    }
}

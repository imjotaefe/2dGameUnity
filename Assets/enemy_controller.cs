using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controller : MonoBehaviour
{
    public float velocity = 5;
    private Rigidbody2D rbd;
    public LayerMask mask;
    public LayerMask playerMask;
    public float distancia = 5;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        rbd.velocity = new Vector2(velocity, 0);
        RaycastHit2D hit;
        RaycastHit2D hitPlayer;

        hit = Physics2D.Raycast(transform.position, transform.right, distancia, mask);
        if(hit.collider != null)
        {
            velocity = velocity * -1;
            rbd.velocity = new Vector2(velocity, 0);
            transform.Rotate(new Vector2(0, 180));
        }

        hitPlayer = Physics2D.Raycast(transform.position, -transform.right, 0.5f, playerMask);
        if (hitPlayer.collider != null)
        {
            Destroy(hitPlayer.collider.gameObject);
        }
        hitPlayer = Physics2D.Raycast(transform.position, transform.right, 0.5f, playerMask);
        if (hitPlayer.collider != null)
        {
            Destroy(hitPlayer.collider.gameObject);
        }
    }
}

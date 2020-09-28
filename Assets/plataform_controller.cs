using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataform_controller : MonoBehaviour
{

    private float count = 0;
    public float velocity = 10;
    private Vector2 initialPosition;
    public float height = 1;
    public float width = 1;
    public bool trigger = false;

    void Start()
    {
        initialPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        trigger = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        trigger = false;
    }

    void Update()
    {
        if (trigger)
        {
            count += velocity * Time.deltaTime;
        float posX = Mathf.Cos(count) * width;
        float posY = Mathf.Sin(count) * height;

        Vector2 actualPos = new Vector2(posX, posY);

        transform.position = initialPosition + actualPos;

            if(count >= 2 * Mathf.PI)
            {
                count = 2 * Mathf.PI - count;
            }
        }
    }
}

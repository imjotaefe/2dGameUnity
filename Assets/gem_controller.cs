using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gem_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            Destroy(gameObject, 0.1f);// Destroy the object -after- the sound played
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

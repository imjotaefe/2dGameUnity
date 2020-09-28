using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_camera : MonoBehaviour
{
    public GameObject player;
    public float offset_y = 2;
    void Start()
    {
        
    }


    void Update()
    {
        Vector3 posicao = new Vector3(player.transform.position.x, player.transform.position.y + offset_y, -10);
        this.transform.position = posicao;
    }
}

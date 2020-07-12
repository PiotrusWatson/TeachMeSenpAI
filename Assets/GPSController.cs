﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSController : MonoBehaviour
{
    Transform player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
          player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.position = Vector3.Lerp(transform.position, playerPosition, speed);
    }
}

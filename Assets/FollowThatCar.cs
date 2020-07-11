using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThatCar : MonoBehaviour
{
    public Transform playerCar;
    public float followSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if (playerCar == null){
            playerCar = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerCar.position, followSpeed);
    }
}

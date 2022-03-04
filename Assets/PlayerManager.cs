using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerManager : NetworkBehaviour
{

    private Vector3 forceToPush;
    private float speed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        forceToPush = new Vector3(0f, 0f, 0f);
        speed = 10f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOwner)
        {
            forceToPush = new Vector3(0f, 0f, 0f);
            if (Input.GetKey(KeyCode.UpArrow)){
                forceToPush.z = 1 * speed;
            }
            if (Input.GetKey(KeyCode.DownArrow)){
                forceToPush.z = -1 * speed;
            }
            if (Input.GetKey(KeyCode.LeftArrow)){
                forceToPush.x = -1 * speed;
            }
            if (Input.GetKey(KeyCode.RightArrow)){
                forceToPush.x = 1 * speed;
            }
            rb.AddForce(forceToPush);
        }
    }
}

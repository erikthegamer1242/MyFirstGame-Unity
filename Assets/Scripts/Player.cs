using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbodyComponet;
    bool jump;
    bool touchGrass;
    private float horizontal;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponet = GetComponent<Rigidbody>();
        jump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && touchGrass) { 
            jump = true;
        }
        horizontal = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        if (jump)
        {
            rigidbodyComponet.AddForce(8 * Vector3.up, ForceMode.VelocityChange);
            jump = false;
            touchGrass = false;
        }
        rigidbodyComponet.velocity = new Vector3(horizontal, rigidbodyComponet.velocity.y, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        touchGrass = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}

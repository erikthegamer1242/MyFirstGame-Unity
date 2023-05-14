using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int jumpMultiplier = 7;
    private Rigidbody rigidbodyComponet;
    bool jump;
    bool touchGrass;
    private float sprint = 1f;
    private float horizontal;
    private float vertical;
    public AudioSource playCoin;
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
        if (Input.GetKeyDown(KeyCode.LeftShift) && touchGrass)
        {
            sprint = 3f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprint = 1f;
        }
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
    }
    private void FixedUpdate()
    {
        if (jump)
        {
            rigidbodyComponet.AddForce(jumpMultiplier * Vector3.up, ForceMode.VelocityChange);
            jump = false;
            touchGrass = false;
            
        }
        rigidbodyComponet.velocity = new Vector3(horizontal * sprint, rigidbodyComponet.velocity.y, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        touchGrass = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        playCoin.Play();
        ScoreManager.instance.AddPoint();
    }
}

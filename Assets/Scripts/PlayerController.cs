using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbd;
    public float jump=50;
    public float frwdSpeed = 10;
    Animator robotrun;
    public bool onGround = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidbd = GetComponent<Rigidbody>();
        robotrun = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if(Input.GetKeyDown(KeyCode.Space)){
        robotrun.SetTrigger("Jump");
        rigidbd.AddForce(Vector3.up*jump);
        //transform.Translate(Vector3.up*jump*Time.deltaTime);
        //rigidbd.transform.position = transform.position;
        onGround = false;
        
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            //rigidbd.AddForce(Vector3.right*speed);
            transform.Translate(Vector3.forward*frwdSpeed*Time.deltaTime);
            robotrun.SetBool("walk",true);
            //robotrun.SetTrigger("Idle");
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            //rigidbd.AddForce(Vector3.right*frwdSpeed);
            transform.Translate(Vector3.right*frwdSpeed*Time.deltaTime);
            robotrun.SetTrigger("Walk_right");
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(Vector3.left*frwdSpeed*Time.deltaTime);
            robotrun.SetBool("Walk_left",true);
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground")){
            onGround = true;
        }
    }
}

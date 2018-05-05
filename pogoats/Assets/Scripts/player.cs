using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public float moveSpeed;
	public  float minJump;
	//public float forwardJumpForce;
	public float maxJumpForce;

    private bool onGround;
    private float jumpPressure;
    private Rigidbody rbody;

	// Use this for initialization
	void Start () {
        onGround = true;
        jumpPressure = 0f;
        maxJumpForce = 10f;
        rbody = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

		//transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime, 0f , moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);

        if (onGround)
        {
            //holding the jump button
            if (Input.GetButton("Jump"))
            {
                if (jumpPressure < maxJumpForce)
                {
                    jumpPressure += Time.deltaTime * 10f;
                }
                else
                {
                    jumpPressure = maxJumpForce;
                }               
            }
            //not holding jump button
            else
            {
                //jump//
                if (jumpPressure > 0f)
                {
                    jumpPressure = jumpPressure + minJump;
					Vector3 vertJumpVector = new Vector3(0f, jumpPressure, 0f);
					Vector3 horizJumpVector = transform.forward * (jumpPressure/2);
					rbody.AddForce(vertJumpVector + horizJumpVector, ForceMode.Impulse);
                    jumpPressure = 0f;
                    onGround = false;
                }
            }
        }		
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
    }
}

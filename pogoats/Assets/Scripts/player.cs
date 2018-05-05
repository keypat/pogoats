using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public float moveSpeed;

    private bool onGround;
    private float jumpPressure;
    private float minJump;
    private float maxJumpPressure;
    private Rigidbody rbody;

	// Use this for initialization
	void Start () {
        onGround = true;
        jumpPressure = 0f;
        minJump = 2f;
        maxJumpPressure = 10f;
        rbody = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime, 0f , moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);

        if (onGround)
        {
            //holding the jump button
            if (Input.GetButton("Jump"))
            {
                if (jumpPressure < maxJumpPressure)
                {
                    jumpPressure += Time.deltaTime * 10f;
                }
                else
                {
                    jumpPressure = maxJumpPressure;
                }               
            }
            //not holding jump button
            else
            {
                //jump//
                if (jumpPressure > 0f)
                {
                    jumpPressure = jumpPressure + minJump;
					rbody.velocity = new Vector3(0f, jumpPressure, jumpPressure/10f);
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

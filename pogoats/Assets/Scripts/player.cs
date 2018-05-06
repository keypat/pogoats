using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

	public float moveSpeed;
	public  float minJump;
	//public float forwardJumpForce;
	public float maxJumpForce;

    private bool onGround;
    public float jumpPressure;
    private Rigidbody rbody;
	
	public Slider powerBar;
	
	public KeyCode right;
	public float rotationSpeed;
	public KeyCode left;
	public KeyCode jump;
	public float airSpeed;
	
	public AudioSource jumpSound;
	public AudioSource collideSound;
	
	
	// Use this for initialization
	void Start () {
        onGround = true;
        jumpPressure = 0f;
        maxJumpForce = 10f;
		//rotationSpeed = 50;
        rbody = GetComponent<Rigidbody>();
		//powerBar.minValue = minJump;
		//powerBar.maxValue = maxJumpForce+minJump;

	}
	
	// Update is called once per frame
	void Update () {

		//transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime, 0f , moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
        
		if (Input.GetKeyUp(jump))
			jumpSound.Play();
		
        if (onGround)
        {
			if (Input.GetKey(left))
				transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
			if (Input.GetKey(right))
				transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            //holding the jump button
            if (Input.GetKey(jump))
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
					Vector3 horizJumpVector = transform.forward * (jumpPressure/2f);
					rbody.AddForce(vertJumpVector + horizJumpVector, ForceMode.Impulse);
                    jumpPressure = 0f;
                    onGround = false;
                }
            }
        } else { 
			if (Input.GetKey(left)) {
				transform.Rotate(-Vector3.up * rotationSpeed * 1.4f * Time.deltaTime);
				rbody.AddForce(-transform.right*(airSpeed),ForceMode.Force);
			}
			if (Input.GetKey(right)) {
				transform.Rotate(Vector3.up * rotationSpeed * 1.4f * Time.deltaTime);
				rbody.AddForce(transform.right*(airSpeed),ForceMode.Force);
			}
		
			//rbody.AddForce(transform.forward*airSpeed, ForceMode.Force);
		}	
		powerBar.value = jumpPressure;		
	}

    private void OnCollisionEnter(Collision other)
    {	
		if (other.gameObject.CompareTag("Player"))
			collideSound.Play();
		
        if (other.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
    }
}

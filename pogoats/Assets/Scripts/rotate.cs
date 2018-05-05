using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {
	public float rotationSpeed;
	// Use this for initialization
	void Start () {
		rotationSpeed = 5;
		Debug.Log ("hi");
	}
	
	// Update is called once per frame
	void Update () {
		float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
		transform.RotateAround(Vector3.up, rotationX);
	}
}

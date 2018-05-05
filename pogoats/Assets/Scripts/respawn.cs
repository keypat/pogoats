using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {

	public Transform startingLocation;
	public GameObject player1;
	public GameObject player2;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == player1)
			player1.transform.position = startingLocation.position;
		if(other.gameObject == player2)
			player2.transform.position = startingLocation.position;
	}

}

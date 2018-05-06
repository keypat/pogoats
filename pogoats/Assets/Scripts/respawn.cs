using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	public Vector3 respawnLocation;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player1) 
			player1.transform.position = respawnLocation;
		if (other.gameObject == player2) 
			player2.transform.position = respawnLocation;
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {

	public Transform startingLocation;
	public GameObject player;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == player)
			player.transform.position = startingLocation.position;
	}

}

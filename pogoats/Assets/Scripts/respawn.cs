using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	public player player1Script;
	public player player2Script;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == player1)
			player1.transform.position = player1Script.mostRecentGroundPosition;
		if(other.gameObject == player2)
			player2.transform.position = player2Script.mostRecentGroundPosition;
	}

}

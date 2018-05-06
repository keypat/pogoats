using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finalRock : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;
    public Text timer;
    public Text timer2;
    public timer timerScript;
    public timer timerScript2;
    //public Text winTag;
    public GameObject winScreen;
    public GameObject winScreen2;

	public GameObject loseScreen;
	public GameObject loseScreen2;

    public player p1MoveScript;
    public player p2MoveScript;

	public Rigidbody p1RigBod;
	public Rigidbody p2RigBod;




	void Start()
	{
		timerScript = player1.GetComponent<timer>();
		timerScript2 = player2.GetComponent<timer>();
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject == player1) 
		{
			winScreen.SetActive (true);
			loseScreen2.SetActive (true);
		} 
		else 
		{
			winScreen2.SetActive (true);
			loseScreen.SetActive (true);
		}
		
		p1RigBod.constraints = RigidbodyConstraints.FreezeAll;
		p2RigBod.constraints = RigidbodyConstraints.FreezeAll;
		p1MoveScript.enabled = false;
		p2MoveScript.enabled = false;
		timerScript.keepTiming = false;
		timerScript2.keepTiming = false;
	}
}

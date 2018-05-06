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

    public player p1MoveScript;
    public player p2MoveScript;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player1)
        {
            winScreen.SetActive(true);
            p2MoveScript.enabled = false;
            timerScript.keepTiming = false;
            //winTag.text = "Player 1 wins @ " + timer.text;
        }
            
        if (other.gameObject == player2)
        {
            winScreen2.SetActive(true);
            p1MoveScript.enabled = false;
            timer2.enabled = false;
            timerScript2.keepTiming = false;
            //winTag.text = "Player 2 wins @ " + timer2.text;
        }
       // Scene
    }
}

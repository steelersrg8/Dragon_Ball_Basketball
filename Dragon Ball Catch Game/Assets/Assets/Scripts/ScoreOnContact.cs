using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreOnContact : MonoBehaviour {

    public Text scoreText;
    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
        UpdateScore();
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "bad")
        {
            score -= 2;     //score = score - 2
        }
        else
        {
            score++;
        }
        
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}

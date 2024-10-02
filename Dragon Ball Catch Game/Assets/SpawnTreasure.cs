using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTreasure : MonoBehaviour {

    public GameObject goodtreasure;
    public GameObject badtreasure;

    float timer = 0;



	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        timer++;


        if(timer == 60){

            float random = Random.Range(-1.0f, 1.0f);
            if (random < 0){

                Instantiate(goodtreasure, new Vector3(Random.Range(-4.0f, 4.0f), transform.position.y, 0), Quaternion.identity);
            } else{
                Instantiate(badtreasure, new Vector3(Random.Range(-4.0f, 4.0f), transform.position.y, 0), Quaternion.identity);

            }
            timer = 0;


        }






	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TreasureSpawner : MonoBehaviour {

    public Camera cam;

    public GameObject[] treasures;
    
    public Text timeLeftText;
    public GameObject gameOverRoot;
    public GameObject titleRoot;
    public playerControls playerControls;

    public float timeLimitSeconds = 10.0f;

    private bool gameStarted;
    private float maxWidth;
    private int stageNumber;

    // Use this for initialization
    void Start () {
        if (cam == null)
        {
            cam = Camera.main;
        }

        stageNumber = 0;
        gameStarted = false;
        gameOverRoot.SetActive(false);
        UpdateTimeText();

        Vector3 targetWidth = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        float treasurewidth= treasures[0].GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - treasurewidth;
    }

    public void StartGame()
    {
        playerControls.movementEnabled = true;
        gameStarted = true;
        titleRoot.SetActive(false);
        StartCoroutine(SpawnTreasure());
    }
	
	void FixedUpdate () {
        if(gameStarted == true)
        {
            timeLimitSeconds -= Time.deltaTime;
            if (timeLimitSeconds < 0.0f)
            {
                timeLimitSeconds = 0.0f;
            }
            UpdateTimeText();
        }
    }

    void UpdateTimeText()
    {
        timeLeftText.text = timeLimitSeconds.ToString("F2");
    }

    IEnumerator SpawnTreasure()
    {
        yield return new WaitForSeconds(1.0f);

        while (timeLimitSeconds > 0.0f)
        {
            GameObject treasure = treasures[Random.Range(0, treasures.Length)];

            Vector3 spawnPosition = new Vector3(
            Random.Range(-maxWidth, maxWidth),
            transform.position.y,
            0.0f
            );
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(treasure, spawnPosition, spawnRotation);

            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }

        yield return new WaitForSeconds(1.0f);

        stageNumber++;
        if(stageNumber >= 3)
        {
            gameOverRoot.SetActive(true);
        }
        else
        {
            timeLimitSeconds = 10.0f;
            StartCoroutine(SpawnTreasure());
        }
        
    }
}

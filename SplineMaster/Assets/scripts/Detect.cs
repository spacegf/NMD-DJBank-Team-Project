using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Detect : MonoBehaviour {
    
	public Text scoreText;
    private int score;
	//private int HiScore;
	//public Text HiScoreText;
	
	 float currCountdownValue;
	public Text timeText;
    private float time;
	
	public LB_Leaderboard _scoreManager;
	
	public KeyCode k = KeyCode.K;
	
	//public Transform shot;
	//public Transform target;
    //public float speed;
	public GameObject Shot;
    public Transform shotSpawn;
	
	float totalTime = 180f;
	private static bool gameOver;
	
	
    void Start ()
    {
		score = 0;
        UpdateScore ();
	}
	
	
	 void Update()
    {
		totalTime -= Time.deltaTime;
        UpdateLevelTimer(totalTime );
		
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
		if (Input.GetKeyUp(k)){
				Fire();
					
        transform.Rotate(0, 0, 0);
        transform.Translate(0, 0, z);
		}
	}
	
	void GameOver()
    {
		if (gameOver == true) {
				Debug.Log("End");
				PlayerPrefs.SetInt("score", score);
				SceneManager.LoadScene("gameOver");
		 }
		 	}
	
	void Fire()
    {
        
        var shot = (GameObject)Instantiate(
            Shot,
            shotSpawn.position,
            shotSpawn.rotation);
        
        shot.GetComponent<Rigidbody>().velocity = shot.transform.forward * 60;
        Destroy(shot, 2.0f);        
    }
	
		void OnTriggerStay(Collider other){
	 if(other.gameObject.tag == "Enemy"){
			if (Input.GetKeyUp(k)){
				Fire();
					
			}
	}
}
         public void AddScore(int gain)
    {
        score += gain;
        UpdateScore ();
    }
	void UpdateScore()
    {
		print("Score: " + score);
		scoreText.GetComponent<Text>().text = "" + score;
        
    }


public void UpdateLevelTimer(float totalSeconds)
         {
             int minutes = Mathf.FloorToInt(totalSeconds / 60f);
             int seconds = Mathf.RoundToInt(totalSeconds % 60f);
 
             string formatedSeconds = seconds.ToString();
 
             if (seconds == 60)
             {
                 seconds = 0;
                 minutes += 1;
             }
 
            timeText.GetComponent<Text>().text = minutes.ToString("00") + ":" + seconds.ToString("00");
			//Debug.Log("Countdown: " + minutes.ToString("00") + ":" + seconds.ToString("00"));
			 if (seconds == 0){
				 if (minutes == 0){
			gameOver = true;
			GameOver();
			}
			}
         }
		 
}
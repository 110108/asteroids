using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public GameObject hazards;
	public GameObject player;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	private int cyka;
	
	public Text scoreText;
	//public Text livesText;
	public Text restartText;
	public Text gameOverText;
	public bool gameOver;
//	public int lives;

	private bool restart;
	private int score;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	
	void Update ()
	{
		if (player == null)
		{
			restart = true;
		}
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (gameOver==false)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards;
				cyka = (Random.Range(0, 40));
				if(cyka==0 && gameOver==false){
					Vector3 playerPos = player.transform.position;
					playerPos.z = +10; 
					Vector3 playerDirection = player.transform.forward;
					Quaternion playerRotation = player.transform.rotation;
					float spawnDistance = 10;
					Vector3 spawnPos = playerPos + playerDirection*spawnDistance;
					Quaternion spawnRotation = Quaternion.identity;
					Instantiate (hazard, spawnPos, spawnRotation);
				}
				else{
					if (gameOver == false) 
					{
						Vector3 playerPos = player.transform.position;
						Vector3 spawncalc = new Vector3 (Random.Range (playerPos.x - spawnValues.x, playerPos.x + spawnValues.x), Random.Range (playerPos.y - spawnValues.y, playerPos.y + spawnValues.y), Random.Range (playerPos.z + 10, playerPos.z + spawnValues.z));
						Vector3 spawnPosition = spawncalc;
						Quaternion spawnRotation = Quaternion.identity;
						Instantiate (hazard, spawnPosition, spawnRotation);
					}
				}
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
//		livesText.text = "Lives: " + lives;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
//		lives--;
	}
}
using UnityEngine;
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
	
//	public GUIText scoreText;
//	public GUIText restartText;
//	public GUIText gameOverText;
	
//	private bool gameOver;
//	private bool restart;
//	private int score;
	
	void Start ()
	{
//		gameOver = false;
//		restart = false;
//		restartText.text = "";
//		gameOverText.text = "";
//		score = 0;
//		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	
//	void Update ()
//	{
//		if (restart)
//		{
//			if (Input.GetKeyDown (KeyCode.R))
//			{
//                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//			}
//		}
//	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
//				cyka = (5);
				GameObject hazard = hazards;
				cyka = (Random.Range(0, 30));
				if(cyka==0){
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
					Vector3 playerPos = player.transform.position;
					Vector3 spawncalc= new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-spawnValues.y,spawnValues.y), Random.Range (10,spawnValues.z));
					Vector3 spawnPosition = playerPos + spawncalc;
					Quaternion spawnRotation = Quaternion.identity;
					Instantiate (hazard, spawnPosition, spawnRotation);
				}
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
//			if (gameOver)
//			{
//				restartText.text = "Press 'R' for Restart";
//				restart = true;
//				break;
//			}
		}
	}
	
//	public void AddScore (int newScoreValue)
//	{
//		score += newScoreValue;
//		UpdateScore ();
//	}
//	
//	void UpdateScore ()
//	{
//		scoreText.text = "Score: " + score;
//	}
//	
//	public void GameOver ()
//	{
//		gameOverText.text = "Game Over!";
//		gameOver = true;
//	}
}
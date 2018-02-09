﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public GameObject hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
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
				GameObject hazard = hazards;
				new int cyka=Random(0,9);
				Vector3 spawnPosition = new Vector3;
				if(cyka==0){
				spawnPosition= (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-spawnValues.y,spawnValues.y), Random.Range (5,spawnValues.y));
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				}
				else{
					spawnPosition= (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-spawnValues.y,spawnValues.y), Random.Range (5,spawnValues.y));
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
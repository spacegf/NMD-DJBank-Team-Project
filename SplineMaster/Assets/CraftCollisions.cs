using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftCollisions : MonoBehaviour {

	private bool invulnerable = false;//invulnerable after collision
	public float invTime = 5;//adjust invulnerability period
	public float lives = 5;
	

	private void OnCollisionEnter(Collision collision)
	{
		if (!invulnerable && lives > 0)
		{
			invulnerable = true;
			lives -= 1;
			Invoke("resetInvulnerability", invTime);
		}
		else if (lives <= 0)
		{
			endGame();
		}
	}
	void resetInvulnerability()
	{
		invulnerable = false;
		//this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
	}
	void endGame()
	{
		Debug.Log("Game Over");
	}
}

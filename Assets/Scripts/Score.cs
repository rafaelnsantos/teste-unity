using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	public int score = 50;					// The player's score.
	private SpriteRenderer scoreBar;
	private Vector3 scoreScale;
	private PlayerControl playerControl;	// Reference to the player control script.
	private int previousScore = 50;			// The score in the previous frame.


	void Awake ()
	{
		
		score += 50;
		// Setting up the reference.
		scoreBar = GameObject.Find("ScoreBar").GetComponent<SpriteRenderer>();
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
		scoreScale = scoreBar.transform.localScale;
		

	}


	void Update ()
	{
		// Set the score text.
		GetComponent<GUIText>().text = "Score: " + score;
		
		// If the score has changed...
		if(previousScore != score){
			// ... play a taunt.
			playerControl.StartCoroutine(playerControl.Taunt());
			UpdateHealthBar();
			if(score <= 0 || score>=100){
				Application.LoadLevel(Application.loadedLevel);				
			}	

		}
		

		// Set the previous score to this frame's score.
		previousScore = score;
	}

	public void UpdateHealthBar ()
	{
		// Set the health bar's colour to proportion of the way between green and red based on the player's health.
		scoreBar.material.color = Color.Lerp(Color.green, Color.red, 1 - score * 0.01f);

		// Set the scale of the health bar to be proportional to the player's health.
		scoreBar.transform.localScale = new Vector3(scoreScale.x * score * 0.01f, 1, 1);
	}

}

using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	private float maxTime = 30.0f;
	private float current;
	// Use this for initialization
	void Start () {
		current = maxTime;
	}
	
	// Update is called once per frame
	void Update () {
		current -= Time.deltaTime;
		
		GetComponent<GUIText>().text = ""+Mathf.Ceil(current);

		if(current <= 20.0f){

			if(GameObject.Find("Score").GetComponent<Score>().score >=0){
				GameObject.Find("Score").GetComponent<GUIText>().text = "uhul";
			}else
			{
				GameObject.Find("Score").GetComponent<GUIText>().text = "deu bão não";
			}
			StartCoroutine("reload");
		}

	}

	IEnumerator reload(){

			yield return new WaitForSeconds(2);
			Application.LoadLevel(Application.loadedLevel);
	}
}

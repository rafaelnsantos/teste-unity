using UnityEngine;
using System.Collections;

public class FollowTimer : MonoBehaviour {


	public Vector3 offset;			// The offset at which the Health Bar follows the player.
	
	private Transform camera;		// Reference to the player.
	// Use this for initialization
	void Awake () {
		camera = GameObject.Find("mainCamera").transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = camera.position + offset;
	}
}

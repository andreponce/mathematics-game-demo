using UnityEngine;
using System.Collections;

public class LookPerson : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Update ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (2*transform.position-Game.instance.person.transform.position);
	}
}

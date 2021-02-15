using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Npc : MonoBehaviour {

	private Quaternion initialRotation;
	private bool lookPerson = false;
	private float minDistance = 5.25f;

	public Dialog dialog;

	// Use this for initialization
	void Start () {
		initialRotation = transform.rotation;
		dialog.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		if (distance < minDistance) {
			Vector3 position = Game.instance.head.transform.position;
			position.y = 0;
			//transform.LookAt(position);
			transform.DOLookAt (position, 1.0f).SetEase(Ease.Linear);
			if(!lookPerson) dialog.show ();
			lookPerson = true;
		} else if (distance>=minDistance && lookPerson) {
			transform.DORotateQuaternion (initialRotation,1.0f).SetEase(Ease.Linear);
			lookPerson = false;
			dialog.hide ();
		}
	}
}

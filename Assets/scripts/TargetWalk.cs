using UnityEngine;
using System.Collections;

public class TargetWalk : MonoBehaviour {

	public CanvasGroup target;
	private GameObject head;
	private GameObject person;

	private bool walking = false;

	// Use this for initialization
	void Start () {
		head = Game.instance.head;
		person = Game.instance.person;
		target.transform.LookAt (2*target.transform.position-head.transform.position);
	}

	// Update is called once per frame
	void Update () {
		if (Game.started) {
			transform.eulerAngles = new Vector3 (0, head.transform.eulerAngles.y, 0);
			float angleDistance = Mathf.Max (Vector3.Angle (target.transform.forward, head.transform.forward), 3);
			target.alpha = Mathf.Min (1 - Mathf.Min (angleDistance / 15, 1), .75f);

			if (walking) {
				Vector3 direction = head.transform.forward;
				direction.y = 0;
				person.transform.Translate (direction * Time.deltaTime * 4);
				//person.transform.Translate (Vector3.up * Time.deltaTime, Space.World);
			}
		}
	}

	private void _startWalk()
	{
		walking = true;
	}

	public void walk()
	{
		Invoke("_startWalk", 1.0f);
	}

	public void stopWalk()
	{
		walking = false;
		CancelInvoke("_startWalk");
	}
}

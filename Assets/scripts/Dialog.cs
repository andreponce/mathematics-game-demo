using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {

	public Conversas conversas;
	public GameObject iniciarConversa;

	public bool enable = true;

	// Use this for initialization
	void Awake () {
		conversas.gameObject.SetActive (false);
		iniciarConversa.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void show()
	{
		if (enable) {
			gameObject.SetActive (true);
			iniciarConversa.gameObject.SetActive (true);
		}
	}

	public void hide()
	{
		gameObject.SetActive (false);
		conversas.gameObject.SetActive (false);
		iniciarConversa.gameObject.SetActive (false);
	}

	private void _startTalk()
	{
		conversas.gameObject.SetActive (true);
		iniciarConversa.gameObject.SetActive (false);
		conversas.setup ();
	}

	public void startTalk()
	{
		Invoke ("_startTalk",Game.timeClick);
	}

	public void stopTalk()
	{
		conversas.gameObject.SetActive (false);
	}

	public void _finishTalk()
	{
		conversas.gameObject.SetActive (false);
		iniciarConversa.gameObject.SetActive (true);
	}

	public void finishTalk()
	{
		Invoke ("_finishTalk",Game.timeClick);
	}
		
}

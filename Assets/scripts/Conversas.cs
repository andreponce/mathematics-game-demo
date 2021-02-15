using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Conversas : MonoBehaviour {

	public Text txt;
	public Text[] buttonsTxt;
	public GameObject respostasBts;
	public GameObject okBt;
	
	private int m_index = -1;
	public string[] texts;
	public string[] textButtons;
	public int correct;
	private bool ok = false;

	public int index
	{
		get { return m_index; }
		set { m_index = value; }
	}

	// Use this for initialization
	void Awake () {
		respostasBts.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setup()
	{
		print (Game.instance.index);
		print (index);
		if (Game.instance.index == index) {
			txt.text = texts [1];

			int i = 0;
			foreach(string text in textButtons)
			{
				buttonsTxt [i].text = text;
				i++;
			}
			respostasBts.SetActive (true);
			okBt.SetActive (false);
		} else {
			if (ok && Game.instance.finish)
				txt.text = "Que bom que você conseguiu!";
			else  txt.text = texts [ok?2:0];
			respostasBts.SetActive (false);
			okBt.SetActive (true);
		}
	}

	private int tempIndex;

	private void _resposta()
	{
		if (tempIndex == correct && !ok) {
			txt.text = texts [2];
			ok = true;
			Game.instance.index++;
			if (Game.instance.index > 4) {
				Game.instance.mulherDaGoiaba.gameObject.SetActive (true);
				Game.instance.finish = true;
			}
		}else txt.text = texts [3];
		respostasBts.SetActive (false);
		okBt.SetActive (true);
	}

	public void resposta(int index)
	{
		tempIndex = index;
		Invoke ("_resposta",Game.timeClick);
	}
}

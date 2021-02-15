using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public static Game instance;
	public static bool started = false;
	public static float timeClick = 1.5f;

	public Dialog dialogStart;
	public TargetWalk targetWalk;
	public GameObject person;
	public GameObject head;
	public Npc mulherDaGoiaba;

	public Npc[] npcs;
	public Npc[] npcs_sequence;
	public int index;
	public bool finish = false;

	void Awake()
	{
		Npc engenheiro = npcs [0];
		Npc policial   = npcs [1];
		Npc derpina    = npcs [2];
		Npc bombeiro   = npcs [3];
		Npc goiabeira  = npcs [4];
		Npc medica     = npcs [5];
		Npc empresario = npcs [6];
		Npc punk 	   = npcs [7];

		bombeiro.dialog.enable = false;

		npcs_sequence = new Npc[]{policial,medica,engenheiro,empresario,punk};

		int i = 0;
		foreach(Npc npc in npcs_sequence)
		{
			npc.dialog.conversas.index = i;
			i++;
		}

		//engenheiro
		engenheiro.dialog.conversas.texts = new string[] {
			"Não conheço nenhuma vendedora de goiabas ..",
			"Verdade, conheço a Derpina, mas só digo se você me ajudar em um cálculo extremamente difícil. Quanto é 5% de 200,00 reais?",
			"Excelente!! Eu a vi agora a pouco vendendo goiabas para um homem de terno e gravata ..",
			"Quem sabe na próxima .."
		};
		engenheiro.dialog.conversas.textButtons = new string[] {"10","5","20","200","100"};
		engenheiro.dialog.conversas.correct = 0;

		//policial
		policial.dialog.conversas.texts = new string[] {
			"",
			"Se você me ajudar posso te dar uma dica. Eu comprei 500 balas comi 305 e dei 120 para meu irmão. Com quantas balas eu fiquei?",
			"Isso mesmo!! Ouvi falar sobre uma médica que adora goiabas, talvez vovê devesse falar com ela.",
			"Quem sabe na próxima .."
		};
		policial.dialog.conversas.textButtons = new string[] {"85","75","70","65","60"};
		policial.dialog.conversas.correct = 1;

		//derpina
		derpina.dialog.conversas.texts = new string[] {
			"Já viu esse sol hoje?? Pena que não sei pra qual direção fica a praia ..",
			"",
			"",
			""
		};

		//bombeiro
		bombeiro.dialog.conversas.texts = new string[] {
			"Vendedora de goiaba? Hummm ..",
			"",
			"",
			""
		};

		//goiabeira
		goiabeira.dialog.conversas.texts = new string[] {
			"Olá!! Você quer goiabas?? Claro, quantas você quer? =)",
			"",
			"",
			""
		};
		goiabeira.dialog.conversas.textButtons = new string[] {"fim"};
		goiabeira.dialog.conversas.correct = 0;

		//medica
		medica.dialog.conversas.texts = new string[] {
			"Você parece bem ...",
			"Adoro goiabas!! Você me ajuda e eu te ajudo, ok? Não sou muito boa com matemática, quanto é 5+5x5?",
			"Obrigada! Faz tempo que eu não a vejo, ela é amiga de um engenheiro que trabalha na cidade, ele deve saber onde ela está.",
			"Quem sabe na próxima .."
		};
		medica.dialog.conversas.textButtons = new string[] {"25","28","50","20","30"};
		medica.dialog.conversas.correct = 4;

		//empresario
		empresario.dialog.conversas.texts = new string[] {
			"Você me assustou ..",
			"Sei onde ela está, te digo se você me ajudar. Um dia tem 24 horas, 1 hora tem 60 minutos e 1 minuto tem 60 segundos, que fração da hora corresponde a 35 minutos?",
			"Humm, faz sentido! Ela disse que estava indo encontrar com aquele sujeito que me da medo, aquele com cabelo vermelho e calça rasgada.",
			"Quem sabe na próxima .."
		};
		empresario.dialog.conversas.textButtons = new string[] {"7/4","7/12","35/24","60/35","1/35"};
		empresario.dialog.conversas.correct = 1;

		//punk
		punk.dialog.conversas.texts = new string[] {
			"...",
			"Te proponho um desafio, se você acertar eu te digo onde ela está. Minha vizinha está morando aqui há 5 anos. Há quantos dias ela está morando aqui? Considerando que um dos anos é bissexto.",
			"Ótimo! Ela foi vizitar algum parente no cemitério, se você correr ela ainda deve estar lá.",
			"Errou feio, errou rude!"
		};
		punk.dialog.conversas.textButtons = new string[] {"1827","1836","1900","1826","1800"};
		punk.dialog.conversas.correct = 3;

		instance = this;
	}

	// Use this for initialization
	void Start () {
		mulherDaGoiaba.gameObject.SetActive (false);
		dialogStart.conversas.gameObject.SetActive (true);
		targetWalk.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void _startGame()
	{
		Destroy (dialogStart.gameObject);
		started = true;
		targetWalk.gameObject.SetActive (true);
	}

	public void startGame()
	{
		Invoke("_startGame", timeClick);
	}
		
}

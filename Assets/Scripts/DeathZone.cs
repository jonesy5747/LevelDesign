using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

	private GameObject gc;

	void Start()
	{
		gc = GameObject.FindGameObjectWithTag("GameController");
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			gc.gameObject.GetComponent<GameController>().Deaths++;
			other.GetComponent<Player>().ResetPlayer();
		}
	}
}

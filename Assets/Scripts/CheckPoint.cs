using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
			other.GetComponent<Player> ().ResetPosition = transform.position;
	}
}

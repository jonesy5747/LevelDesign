using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWindZone : MonoBehaviour
{
    public GameObject windZone;
    public GameObject particle;
    public GameObject push;
    // Start is called before the first frame update
    void Start()
    {
        windZone.SetActive(false);
        particle.SetActive(false);
        push.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            windZone.SetActive(true);
            particle.SetActive(true);
            push.SetActive(true);
        }
    }
}

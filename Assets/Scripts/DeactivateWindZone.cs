using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateWindZone : MonoBehaviour
{
    public GameObject windZone;
    public GameObject particle;
    public GameObject push;
    public GameObject fan;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            windZone.SetActive(false);
            particle.SetActive(false);
            push.SetActive(false);

            fan.GetComponent<Animator>().SetBool("FanOn", false);
        }
    }
}

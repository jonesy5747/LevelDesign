using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWindmill : MonoBehaviour
{

    public GameObject windmill;
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
            windmill.GetComponent<Animator>().SetTrigger("buttonActivated");
            Destroy(gameObject.GetComponent<Collider>());
        }
    }
}

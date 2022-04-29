using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPlayer2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            other.GetComponent<Rigidbody>().AddForce(0, 0, 150);
        }
    }
}

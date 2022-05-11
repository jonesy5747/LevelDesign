using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{ 

    public GameObject gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gc.GetComponent<GameController>().Deaths == 1)
            {
                gc.GetComponent<GameController>().WinText.text = "Hole In 1";
            }
            if (gc.GetComponent<GameController>().Deaths > 1 && gc.GetComponent<GameController>().Deaths <= 10)
            {
                gc.GetComponent<GameController>().WinText.text = "Eagle";
            }
            if (gc.GetComponent<GameController>().Deaths > 10 && gc.GetComponent<GameController>().Deaths <= 20)
            {
                gc.GetComponent<GameController>().WinText.text = "Birdie";
            }
            if (gc.GetComponent<GameController>().Deaths > 20 && gc.GetComponent<GameController>().Deaths <= 30)
            {
                gc.GetComponent<GameController>().WinText.text = "Par";
            }
            if (gc.GetComponent<GameController>().Deaths > 30 && gc.GetComponent<GameController>().Deaths <= 40)
            {
                gc.GetComponent<GameController>().WinText.text = "Bogey";
            }
            if (gc.GetComponent<GameController>().Deaths > 40)
            {
                gc.GetComponent<GameController>().WinText.text = "Double Bogey";
            }

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Victory");
        }
    }
}

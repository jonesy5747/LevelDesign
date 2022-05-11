using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject Player;
	public GameObject LevelStart;
	public GameObject LevelGoal;

	public Vector3 StartOffset;

	public Text ScoreText;
	public Text TimeText;
	public Text DeathText;
	public Text WinText;

	private int CurrentScene;

	[HideInInspector] public int Score;
	[HideInInspector] public int Deaths;
	private float TimeElapsed;
	private string FormattedTime;
	private string FormattedMinutes;
	private string FormattedSeconds;


	public GameObject windZone;
	public GameObject particle;
	public GameObject push;
	public GameObject fan;
	public GameObject timer;

	public Camera cutscene;
	public Camera camera;

	void Start ()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		Player.transform.position = LevelStart.transform.position + StartOffset;

		Score = 0;
		Deaths = 0;
		TimeElapsed = 0.0f;
		UpdateUI ();

		windZone.SetActive(false);
		particle.SetActive(false);
		push.SetActive(false);

		cutscene.enabled = true;
		camera.enabled = false;

		Player.SetActive(false);
		StartCoroutine(cameraWait());

	}

	public IEnumerator cameraWait()
    {
		Debug.Log("cutscene");
		yield return new WaitForSeconds(14f);
			cutscene.enabled = false;
			camera.enabled = true;
			timer.GetComponent<Timer>().timerIsRunning = true;
			Player.SetActive(true);

	}
	
	void Update ()
	{
		TimeElapsed += Time.deltaTime;
		UpdateUI ();
		if (Input.GetKey (KeyCode.KeypadEnter))
			GoToNextScene ();

		if (Score >= 8)
        {
			windZone.SetActive(true);
			particle.SetActive(true);
			push.SetActive(true);

			fan.GetComponent<Animator>().SetBool("FanOn", true);
		}
	}

	public void GoToNextScene()
	{
		Debug.Log (SceneManager.sceneCountInBuildSettings);
		Debug.Log (SceneManager.GetActiveScene ().buildIndex);

		if (SceneManager.GetActiveScene().buildIndex-1 == SceneManager.sceneCountInBuildSettings)
			SceneManager.LoadScene (0);
		else
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex+1);
	}

	private void UpdateUI()
	{
		if ((Mathf.Floor (TimeElapsed / 60)) < 1)
			FormattedMinutes = "00";
		else if ((Mathf.Floor(TimeElapsed / 60)) < 10)
			FormattedMinutes = "0" + Mathf.Floor(TimeElapsed / 60);
		else
			FormattedMinutes = Mathf.Floor(TimeElapsed / 60).ToString();

		if ((Mathf.Floor (TimeElapsed % 60)) < 10)
			FormattedSeconds = "0" + Mathf.Floor (TimeElapsed % 60);
		else
			FormattedSeconds = Mathf.Floor (TimeElapsed % 60).ToString();

		FormattedTime = FormattedMinutes + ":" + FormattedSeconds;
		if (ScoreText != null)
        {
			ScoreText.text = "Fan: " + Score.ToString() + "/8";
		}
		if (TimeText != null)
        {
			TimeText.text = FormattedTime;
		}
		if (DeathText != null)
		{
			DeathText.text = "Strokes: " + Deaths.ToString();
		}
	}
}

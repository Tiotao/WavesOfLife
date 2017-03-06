using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
	public Button _Button;
	public Text _Text;
	public InputField _Input;
	public GameObject Data;
	public GameObject _player;
	public AudioSource _buttonSound;
    public GameObject _TouchController;
	public GameObject _Hint;
	// Use this for initialization
	void Start () {
		_Button = GetComponentInChildren<Button> ();
		_Text = GetComponentInChildren<Text> ();
		_Input = GetComponentInChildren<InputField> ();
		_Button.onClick.AddListener (TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Backspace)) {
			_Input.text = "";
		}
	
	}
	void TaskOnClick()
	{
		Data.GetComponent<data> ().Name ="";
		_player.SetActive(true);
		_player.GetComponent<AutoMove>().enabled = true;
        _TouchController.SetActive(true);
		_Hint.SetActive(true);
        DontDestroyOnLoad (Data);
		this.gameObject.SetActive (false);
		if (!_buttonSound.isPlaying) {
			_buttonSound.Play ();
		}
	//	Debug.Log (name);
	}
}

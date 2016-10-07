using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Vuforia;

public class SkinToneSelector : MonoBehaviour {

	public GameObject ringMask;
	public GameObject braceletMask;
	public Color colorPressed;
	public static Color globalColor;
	public static bool globalTorchEnabled = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//forward
		if (Input.GetKeyDown (KeyCode.JoystickButton13) == true) {
			SkinToneSelector.globalTorchEnabled = false;
			UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex+1);
		}

		//back
		if (Input.GetKeyDown (KeyCode.JoystickButton8) == true) {
			SkinToneSelector.globalTorchEnabled = false;
			UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex-1);
		}

		//torch
		if (Input.GetKeyDown (KeyCode.JoystickButton12) == true) {
			globalTorchEnabled = !globalTorchEnabled;
			if (CameraDevice.Instance.SetFlashTorchMode (globalTorchEnabled)) {
				Debug.Log ("Successfully turned flash " + globalTorchEnabled);
			} else {
				Debug.Log ("Failed to set the flash torch " + globalTorchEnabled);
			}
		}
		
	}		

	public void ToggleTorch()
	{
		globalTorchEnabled = !globalTorchEnabled;
		if (CameraDevice.Instance.SetFlashTorchMode (globalTorchEnabled)) {
			Debug.Log ("Successfully turned flash " + globalTorchEnabled);
		} else {
			Debug.Log ("Failed to set the flash torch " + globalTorchEnabled);
		}
	}

	public void GetSkinColor(string Color) {

		Debug.Log ("Skin Color IN: " + Color);

		bool converted = ColorUtility.TryParseHtmlString(Color, out colorPressed);

		Debug.Log ("converted " + converted);
		Debug.Log ("Skin Color OUT: " + colorPressed.r + colorPressed.g + colorPressed.b);

		ringMask.GetComponent<Renderer> ().material.color = colorPressed;
		braceletMask.GetComponent<Renderer> ().material.color = colorPressed;

		globalColor = colorPressed;

	}

	public void StartAR () {
		Debug.Log ("START AR " + globalTorchEnabled);
		CameraDevice.Instance.SetFlashTorchMode (false);
		UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex+1);

	}
}

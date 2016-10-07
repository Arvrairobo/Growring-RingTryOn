using UnityEngine;
using System.Collections;
using Sidema.CarouselPro;
using Vuforia;

public class SingleCarouselController : MonoBehaviour
{
    public Carousel carousel;
	private int carouselIndex;
	private int carouselSelectedIndex;

	public GameObject ring1marker;
	public GameObject ring2marker;
	public GameObject ring3marker;
	public GameObject ring4marker;

	public GameObject ring1menu;
	public GameObject ring2menu;
	public GameObject ring3menu;
	public GameObject ring4menu;

	public GameObject ringMask;
	public GameObject braceletMask;

	public GameObject square1;
	public GameObject square2;
	public GameObject square3;
	public GameObject square4;

	public ParticleSystem particlesMenu;
	public ParticleSystem particlesRing;
	public ParticleSystem particlesBracelet;

	// Use this for initialization
	void Start () {
		StartCoroutine(ActivationRoutine());

	}

	public void ToggleTorch()
	{
		SkinToneSelector.globalTorchEnabled = !SkinToneSelector.globalTorchEnabled;
		if (CameraDevice.Instance.SetFlashTorchMode (SkinToneSelector.globalTorchEnabled)) {
			Debug.Log ("Successfully turned flash " + SkinToneSelector.globalTorchEnabled);
		} else {
			Debug.Log ("Failed to set the flash torch " + SkinToneSelector.globalTorchEnabled);
		}
	}

	private IEnumerator ActivationRoutine()
	{        
		ring1marker.SetActive(true);
		ring2marker.SetActive(false);
		ring3marker.SetActive(false);
		ring4marker.SetActive(false);

		Debug.Log ("Skin Color to AR: " + SkinToneSelector.globalColor);

		ringMask.GetComponent<Renderer> ().material.color = SkinToneSelector.globalColor;
		braceletMask.GetComponent<Renderer> ().material.color = SkinToneSelector.globalColor;

		SkinToneSelector.globalTorchEnabled = false;

		/*
		Debug.Log ("FLASH : " + SkinToneSelector.globalTorchEnabled);

		if (CameraDevice.Instance.SetFlashTorchMode (SkinToneSelector.globalTorchEnabled)) {
			Debug.Log ("Successfully turned flash " + SkinToneSelector.globalTorchEnabled);
		} else {
			Debug.Log ("Failed to set the flash torch " + SkinToneSelector.globalTorchEnabled);
		}
		*/

		yield return new WaitForSeconds(0);
	}

    void Update()
	{
		//spin right
		if (Input.GetAxis ("Axis 1") > 0f) {
			carousel.Next ();
		}
		//spin left
		if (Input.GetAxis ("Axis 1") < 0f) {
			carousel.Previous ();
		}

		//select ring
		if (Input.GetKey (KeyCode.JoystickButton14) == true) {

			if (carousel.selectedSlotIndex == 0) {
				ring1marker.SetActive (true);
				ring2marker.SetActive (false);
				ring3marker.SetActive (false);
				ring4marker.SetActive (false);

				ring1menu.SetActive (false);
				ring2menu.SetActive (true);
				ring3menu.SetActive (true);
				ring4menu.SetActive (true);

				particlesRing.Play ();


			} else if (carousel.selectedSlotIndex == 1) {
				ring1marker.SetActive (false);
				ring2marker.SetActive (true);
				ring3marker.SetActive (false);
				ring4marker.SetActive (false);

				ring1menu.SetActive (true);
				ring2menu.SetActive (false);
				ring3menu.SetActive (true);
				ring4menu.SetActive (true);

				particlesRing.Play ();

			} else if (carousel.selectedSlotIndex == 2) {
				ring1marker.SetActive (false);
				ring2marker.SetActive (false);
				ring3marker.SetActive (true);
				ring4marker.SetActive (false);

				ring1menu.SetActive (true);
				ring2menu.SetActive (true);
				ring3menu.SetActive (false);
				ring4menu.SetActive (true);

				particlesRing.Play ();

			} else if (carousel.selectedSlotIndex == 3) {
				ring1marker.SetActive (false);
				ring2marker.SetActive (false);
				ring3marker.SetActive (false);
				ring4marker.SetActive (true);

				ring1menu.SetActive (true);
				ring2menu.SetActive (true);
				ring3menu.SetActive (true);
				ring4menu.SetActive (false);

				particlesBracelet.Play ();

			}

			//play particles
			particlesMenu.Play ();

			//carouselSelectedIndex = carousel.selectedSlotIndex; 
			//Debug.Log ("Carousel Selected Slot Index : " + carouselSelectedIndex);

		}

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
			SkinToneSelector.globalTorchEnabled = !SkinToneSelector.globalTorchEnabled;
			if (CameraDevice.Instance.SetFlashTorchMode (SkinToneSelector.globalTorchEnabled)) {
				Debug.Log ("Successfully turned flash " + SkinToneSelector.globalTorchEnabled);
			} else {
				Debug.Log ("Failed to set the flash torch " + SkinToneSelector.globalTorchEnabled);
			}
		}
	}


		
	public void NoStereo () {
		SkinToneSelector.globalTorchEnabled = false;
		UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex+1);


	}

		public void GoBack () {
			SkinToneSelector.globalTorchEnabled = false;
			UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex-1);

		}
           
}


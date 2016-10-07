using UnityEngine;
using System.Collections;
using Sidema.CarouselPro;

public class SwapRings : MonoBehaviour {

	public GameObject ring1marker;
	public GameObject ring2marker;
	public GameObject ring3marker;
	public GameObject ring4marker;

	public GameObject ring1menu;
	public GameObject ring2menu;
	public GameObject ring3menu;
	public GameObject ring4menu;


	public Carousel carousel;


	// Use this for initialization
	void Start () {

		//StartCoroutine(ActivationRoutine());
		
	}

	void update ()
	{

		//spin right
		if (Input.GetAxis ("Axis 1") > 0f)
			carousel.Next ();
			Debug.Log ("Carousel Next");

		//spin left
		if (Input.GetAxis ("Axis 1") < 0f)
			carousel.Previous ();
			Debug.Log ("Carousel Previous");

		//select ring
		if (Input.GetKey (KeyCode.JoystickButton14) == true)
			carousel.Previous ();

	}
	
		private IEnumerator ActivationRoutine()
	{        
		ring1marker.SetActive(false);
		ring2marker.SetActive(false);
		ring3marker.SetActive(false);
		ring4marker.SetActive(false);
		yield return new WaitForSeconds(0);
	}

	public void SwapToRing1a () {
		Debug.Log ("Ring 1");
		ring1marker.SetActive(true);
		ring2marker.SetActive(false);
		ring3marker.SetActive(false);
		ring4marker.SetActive(false);

		ring1menu.SetActive(false);
		ring2menu.SetActive(true);
		ring3menu.SetActive(true);
		ring4menu.SetActive(true);

	}

	public void SwapToRing2a () {
		Debug.Log ("Ring 2");
		ring1marker.SetActive(false);
		ring2marker.SetActive(true);
		ring3marker.SetActive(false);
		ring4marker.SetActive(false);

		ring1menu.SetActive(true);
		ring2menu.SetActive(false);
		ring3menu.SetActive(true);
		ring4menu.SetActive(true);


	}

	public void SwapToRing3a () {
		Debug.Log ("Ring 3");
		ring1marker.SetActive(false);
		ring2marker.SetActive(false);
		ring3marker.SetActive(true);
		ring4marker.SetActive(false);

		ring1menu.SetActive(true);
		ring2menu.SetActive(true);
		ring3menu.SetActive(false);
		ring4menu.SetActive(true);


	}

	public void SwapToRing4a () {
		Debug.Log ("Ring ");
			ring1marker.SetActive(false);
			ring2marker.SetActive(false);
			ring3marker.SetActive(false);
			ring4marker.SetActive(true);

			ring1menu.SetActive(true);
			ring2menu.SetActive(true);
			ring3menu.SetActive(true);
			ring4menu.SetActive(false);


	}




}

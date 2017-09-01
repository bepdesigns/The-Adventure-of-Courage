using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirstBarScript : MonoBehaviour {

	[SerializeField]
	private Image ThirstBar;
	public float Thirsty;
	private InputController input;
	private Animator anime;
	public bool canRun;
 

		// Use this for initialization
		void Awake () {
		input = gameObject.GetComponent<InputController>();
	}

		// Update is called once per frame
		void Update () {
		HandleBar ();

		if (input.IsSprinting) {

			Thirsty -= 0.02f;

		}

		if (Thirsty <= 0f) {
			Thirsty = 0f;
			input.IsSprinting = false;
			anime.SetBool ("IsSprinting", false);

		}

			Debug.Log (Thirsty);
		}
		private void HandleBar()
		{
		ThirstBar.fillAmount = Thirsty;
		}
	}

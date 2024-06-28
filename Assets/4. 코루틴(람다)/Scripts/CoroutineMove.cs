using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineMove : MonoBehaviour {

	private IEnumerator RotateCoroutine() {
		float endTime = Time.time + 5;

		while (Time.time < endTime) {
			transform.Rotate(new Vector3(60 * Time.deltaTime, 0, 0));
			yield return null;
		}
	}
	private IEnumerator MoveCoroutine() {
		float endTime = Time.time + 5;

		while (Time.time < endTime) {
			transform.Translate(new Vector3(0, 1f * Time.deltaTime, 0));
			yield return null;
		}
	}

	private IEnumerator MainCoroutine() {
		while (true) {
			moveCoroutine = StartCoroutine(MoveCoroutine());
			yield return moveCoroutine;
			rotateCoroutine = StartCoroutine(RotateCoroutine());
			yield return rotateCoroutine;
		}
	}

	Coroutine mainCoroutine;
	Coroutine moveCoroutine;
	Coroutine rotateCoroutine;

	private void Start() {
		mainCoroutine = StartCoroutine(MainCoroutine());
	}

	public void CoroutineStopButton() {
		if (mainCoroutine != null) StopCoroutine(mainCoroutine);
		if (moveCoroutine != null) StopCoroutine(moveCoroutine);
		if (rotateCoroutine != null) { StopCoroutine(rotateCoroutine); }
	}

}

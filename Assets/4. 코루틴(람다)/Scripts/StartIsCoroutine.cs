using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartIsCoroutine : MonoBehaviour {

	//Start 메시지 함수는 반환형이 IEnumerator일 경우 자동으로 코루틴이 된다.
	IEnumerator Start() {
		print(@"""Start"" start.");
		yield return new WaitForSeconds(5f);
		print(@"""Start"" end.");
	}

}

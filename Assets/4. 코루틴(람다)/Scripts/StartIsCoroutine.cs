using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartIsCoroutine : MonoBehaviour {

	//Start �޽��� �Լ��� ��ȯ���� IEnumerator�� ��� �ڵ����� �ڷ�ƾ�� �ȴ�.
	IEnumerator Start() {
		print(@"""Start"" start.");
		yield return new WaitForSeconds(5f);
		print(@"""Start"" end.");
	}

}

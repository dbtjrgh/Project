using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour {

	private void Start() {

		//IEnumerator someEnum = SomeEnumerator();
		//while (someEnum.MoveNext()) {
		//	print(someEnum.Current);
		//}

		//IEnumerator<int> someIntEnum = SomeIntEnumerator();
		//int a = 1000;
		//while (someIntEnum.MoveNext()) {
		//	a -= someIntEnum.Current;
		//	print(a);
		//}

		//foreach (Transform child in transform) {
		//	print(child.name);
		//}

		//IEnumerator thisIsCoroutine = ThisIsCoroutine();
		//thisIsCoroutine.MoveNext();
		//print("�ڷ�ƾ �ѽ���Ŭ �Ѱ��");

		//StartCoroutine(thisIsCoroutine);

		//StartCoroutine(SecondsCoroutine(10, 0.5f));
		//StartCoroutine(RealtimeSecondsCoroutine(10, 0.5f));

		StartCoroutine(UntilCoroutine());

	}

	private IEnumerator SomeEnumerator() {
		yield return "����";
		yield return 1;
		yield return false;
		yield return new object();
	}
	private IEnumerator<int> SomeIntEnumerator() {
		yield return 6;
		yield return 2;
		yield return 923;
		yield return -323;
	}
	private IEnumerator ThisIsCoroutine() {
		print("�ڷ�ƾ �����ߴ�");
		yield return new WaitForSeconds(1f);//MoveNext()�� ȣ�� �Ǹ� ���⼭ ���.
		print("1�� ������");
		yield return new WaitForSeconds(3f);
		print("3�� �� ������");
		yield return new WaitForSeconds(4f);
		print("4�� �� ������");
	}
	private IEnumerator SecondsCoroutine(int count, float interval) {
		float timeTemp = 0;
		for (int i = 0; i < count; i++) {

			print($"���ӿ��� {i} �� ȣ��, {timeTemp} �� ����");

			timeTemp += interval;
			yield return new WaitForSeconds(interval);
		}
	}
	private IEnumerator RealtimeSecondsCoroutine(int count, float interval) {
		float timeTemp = 0;
		for (int i = 0; i < count; i++) {

			print($"������ {i} �� ȣ��, {timeTemp} �� ����");

			timeTemp += interval;
			yield return new WaitForSecondsRealtime(interval);
		}
	}
	public bool continueKey;
	private IEnumerator UntilCoroutine() {

		//WaitUnil : �Ű������� �Ѿ �Լ��� return�� false �϶� ���, true �϶� �Ѿ.
		yield return new WaitUntil( ()=> { return continueKey; } );

		print("��Ƽ�� Ű�� True�� ��");

		//WaitWhile : �Ű������� �Ѿ �Լ��� return�� true�϶� ���, false �϶� �Ѿ.
		yield return new WaitWhile( ()=> { return continueKey; } );

		print("��Ƽ�� Ű�� False�� ��");

	}
}

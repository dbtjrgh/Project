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
		//print("코루틴 한싸이클 넘겼다");

		//StartCoroutine(thisIsCoroutine);

		//StartCoroutine(SecondsCoroutine(10, 0.5f));
		//StartCoroutine(RealtimeSecondsCoroutine(10, 0.5f));

		StartCoroutine(UntilCoroutine());

	}

	private IEnumerator SomeEnumerator() {
		yield return "하이";
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
		print("코루틴 시작했다");
		yield return new WaitForSeconds(1f);//MoveNext()가 호출 되면 여기서 대기.
		print("1초 지났다");
		yield return new WaitForSeconds(3f);
		print("3초 더 지났다");
		yield return new WaitForSeconds(4f);
		print("4초 더 지났다");
	}
	private IEnumerator SecondsCoroutine(int count, float interval) {
		float timeTemp = 0;
		for (int i = 0; i < count; i++) {

			print($"게임에서 {i} 번 호출, {timeTemp} 초 지남");

			timeTemp += interval;
			yield return new WaitForSeconds(interval);
		}
	}
	private IEnumerator RealtimeSecondsCoroutine(int count, float interval) {
		float timeTemp = 0;
		for (int i = 0; i < count; i++) {

			print($"실제로 {i} 번 호출, {timeTemp} 초 지남");

			timeTemp += interval;
			yield return new WaitForSecondsRealtime(interval);
		}
	}
	public bool continueKey;
	private IEnumerator UntilCoroutine() {

		//WaitUnil : 매개변수로 넘어간 함수의 return이 false 일때 대기, true 일때 넘어감.
		yield return new WaitUntil( ()=> { return continueKey; } );

		print("컨티뉴 키가 True가 됨");

		//WaitWhile : 매개변수로 넘어간 함수의 return이 true일때 대기, false 일때 넘어감.
		yield return new WaitWhile( ()=> { return continueKey; } );

		print("컨티뉴 키가 False가 됨");

	}
}

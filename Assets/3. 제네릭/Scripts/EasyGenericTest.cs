using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyGenericTest : MonoBehaviour {
	public CubeParent cubeFrom;
	public CubeParent cubeTo;

	private void Awake() {
		
		//cubeFrom�� colors, xPositions, scales �迭�� ���� �����ϰ� ����.
		cubeTo.colors = ArrayCopy<Color>(cubeFrom.colors);
		cubeTo.xPositions = ArrayCopy<int>(cubeFrom.xPositions);
		cubeTo.scales = ArrayCopy<float>(cubeFrom.scales);

	}

	//private Color[] ArrayCopy(Color[] from) {
	//	Color[] to = new Color[from.Length];

	//	for(int i=0; i < from.Length; i++) {
	//		to[i] = from[i];
	//	}

	//	return to;
	//}

	private T1[] ArrayCopy<T1>(T1[] from) {
		T1[] @return = new T1[from.Length];

		for (int i = 0; i < from.Length; i++) {
			@return[i] = from[i];
		}

		return @return;
	}

}

/* ���׸� Ȱ���� ũ�� 2����
 * 1. ���׸��� ����Ͽ� ���ǵ� Ŭ������ �ڷ������� ��� �Ǵ� �Լ��� ȣ��
 * ���� ) List<int> : List��� Ŭ������ ����ϴµ�, �ȿ��� ��޵� �ڷ����� int.
 * ����2) GetComponent<T>() : ���� ������Ʈ�� ������ ������Ʈ�� ã�µ�, T Ŭ������ ������Ʈ�� ã�´�. 
 * 
 * 2. ���� ���׸��� ����� Ŭ���� �Ǵ� �Լ��� ����
 * */

public class GenericExample : MonoBehaviour {

	public List<int> intList = new List<int>();
	public Dictionary<int, int> intDictionary = new Dictionary<int, int>();

	private void Start() {
		new GameObject().AddComponent<SpriteRenderer>();

		//StructT<Vector3> a;
		//ClassT<GameObject> b;
		//NewT<object> c;
		//ParentT<Child> d;
		//InterfaceT<string> e;
	}
}
class NoneDefaultConstructorClass {
	public NoneDefaultConstructorClass(int a) {}
}
class Parent { }
class Child : Parent { }

//Ŭ�������� ����ϴ� ���׸� �ڷ����� ��������� ����� �� �ִ�.
class StructT<T> where T : struct{ }//1. ����ü�� �����ϰ�
class ClassT<T> where T : class { } //2. Ŭ������ �����ϰ�
class NewT<T> where T : new() { }   //3. �Ķ���Ͱ� ���� �⺻ �����ڸ� ������ Ŭ������ �����ϰ�
class ParentT<T> where T : Parent { }//4. ParentŬ������ ����� Ŭ������ �����ϰ�
class InterfaceT<T> where T : IComparable { } //5. IComparable �������̽��� ������ Ŭ������ �����ϰ�
class MultiT<T1,T2,T3> where T1 : struct where T2 : class where T3 : new() {}
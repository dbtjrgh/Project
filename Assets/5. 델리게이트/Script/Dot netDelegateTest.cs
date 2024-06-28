using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// public delegate void SomeA(int a);

public class DotnetDelegateTest : MonoBehaviour
{
	// Action 델리게이트
	//	ㄴ 기본적인 형태의 델리게이트를 Dotnet에서 기본적으로 정의하여 제공
	// 반환형이 없는 Method.
	Action action;

	// Action 델리게이트에 제네릭 타입은 파라미터 타입을 지정
	Action<int> actionWithIntParam;
	Action<float, float> actionWithTwoFloatParam;

	// Func 델리게이트
	//	ㄴ 반환형이 있는 형태의 델리게이트를 Dotnet에서 기본적으로 정의하여 제공.
	Func<object> Func;

    // Func 델리게이트는 제네릭 타입 중 맨 앞은 파라미터 타입 지정, 그 뒤로 반환형
    Func<string, int> parseFunc;

	// Predicate 델리게이트
	//	ㄴ 반환형이 bool이고, 1개 이상의 파라미터가 있는 형태의 델리게이트.
	Predicate<float> predicate;

	// Func<float, bool>

	private void Start()
	{
		action = SomeAction;
        actionWithIntParam = SomeActionWithParam;
		parseFunc = Parse;

		// Predicate 사용 이유
		List<int> intList = new List<int>();

		intList.Add(5);
		intList.Add(6);
		intList.Add(7);
		intList.Add(8);
		intList.Add(9);

		// intList에서 짝수만 뽑아오고 싶다.
		List<int> evenList = intList.FindAll(IsEven);
		foreach(int i in evenList)
		{
			print(i);
		}

		// predicate의 경우, 일부 컬렉션 함수의 조건 판단을 위한 정의를 
		// bool을 리턴하는 함수의 형태로 받기 위해 활용됨.

		// 짝수를 Findall 할 때 무명 메서드를 사용할 경우
		List<int> evemListByAnonymouysMethod = intList.FindAll(delegate(int param)
		{
			return param % 2 == 0;
		}
		);
		
	}

	private void SomeAction()
	{

	}

	private void SomeActionWithParam(int a)
	{
		// 파라미터 A로 무언가를 한다 가정
	}

	private int Parse(string param)
	{
		return int.Parse(param);
	}

	private bool IsEven(int param)
	{
		return param % 2 == 0;
	}



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// public delegate void SomeA(int a);

public class DotnetDelegateTest : MonoBehaviour
{
	// Action ��������Ʈ
	//	�� �⺻���� ������ ��������Ʈ�� Dotnet���� �⺻������ �����Ͽ� ����
	// ��ȯ���� ���� Method.
	Action action;

	// Action ��������Ʈ�� ���׸� Ÿ���� �Ķ���� Ÿ���� ����
	Action<int> actionWithIntParam;
	Action<float, float> actionWithTwoFloatParam;

	// Func ��������Ʈ
	//	�� ��ȯ���� �ִ� ������ ��������Ʈ�� Dotnet���� �⺻������ �����Ͽ� ����.
	Func<object> Func;

    // Func ��������Ʈ�� ���׸� Ÿ�� �� �� ���� �Ķ���� Ÿ�� ����, �� �ڷ� ��ȯ��
    Func<string, int> parseFunc;

	// Predicate ��������Ʈ
	//	�� ��ȯ���� bool�̰�, 1�� �̻��� �Ķ���Ͱ� �ִ� ������ ��������Ʈ.
	Predicate<float> predicate;

	// Func<float, bool>

	private void Start()
	{
		action = SomeAction;
        actionWithIntParam = SomeActionWithParam;
		parseFunc = Parse;

		// Predicate ��� ����
		List<int> intList = new List<int>();

		intList.Add(5);
		intList.Add(6);
		intList.Add(7);
		intList.Add(8);
		intList.Add(9);

		// intList���� ¦���� �̾ƿ��� �ʹ�.
		List<int> evenList = intList.FindAll(IsEven);
		foreach(int i in evenList)
		{
			print(i);
		}

		// predicate�� ���, �Ϻ� �÷��� �Լ��� ���� �Ǵ��� ���� ���Ǹ� 
		// bool�� �����ϴ� �Լ��� ���·� �ޱ� ���� Ȱ���.

		// ¦���� Findall �� �� ���� �޼��带 ����� ���
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
		// �Ķ���� A�� ���𰡸� �Ѵ� ����
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

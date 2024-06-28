using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Delegate (�븮��)
// C++�� �Լ� �����Ϳ� ������ ���
// �޼��带 ����ó�� ���������� Ȱ���� �� �ִ� ���

// Delegate ���� -> ������ (���۷���)�ڷ���ó�� ������ �����ϵ��� �����ؾ��Ѵ�.
// [������] delegate [��ȯ��] [�̸�] ([�Ű����� ����]); 
// delegate�� ���� ��ġ�� class, enum �� �� ����.

public delegate float SomeDelegateMethod(float x, float y);
public delegate void OtherDeilegateMethod(string message);

public class DelegateTest : MonoBehaviour
{ 
    public float x;
    public float y;

    // delegate �ʵ� ����
    public SomeDelegateMethod someDelegate;
    public OtherDeilegateMethod otherDelegate;

    private void Start()
    {
        //someDelegate = Plus;
        //someDelegate = Minus;
        //someDelegate = Multiple;
        //someDelegate = Divide;
        //otherDelegate = PrintMessage;

        // �Ű������� �Ͻ��� ĳ������ ������ ��쿡�� ����
        otherDelegate = print;

        // Delegate�� �ν��Ͻ��� �����ϴ� �������� ������.
        otherDelegate = null;
        //otherDelegate = new OtherDeilegateMethod(PrintMessage);

        // �� ����� ����  ( ?. ������ �ϸ�, ?���� ������ null�ϰ�� �������� ����.
        // otherDelegate("");
        otherDelegate ?. Invoke("");

        //if(otherDelegate != null)
        //{
        //    otherDelegate("");
        //}
    }

    public void CalcChange(int i)
    {
        switch (i)
        {
            case 0:
                someDelegate = Plus;
                break;
            case 1:
                someDelegate = Minus;
                break;
            case 2:
                someDelegate = Multiple;
                break;
            case 3:
                someDelegate = Divide;
                break;
        }
    }

    public void ButtonClock()
    {
        print(someDelegate?.Invoke(x, y));
    }

    public float Plus(float x, float y)
    {
        return x + y;
    }

    public float Minus(float x, float y)
    {
        return x - y;
    }

    public float Multiple(float x, float y)
    {
        return x * y;
    }

    public float Divide(float x, float y)
    {
        return x / y;
    }

    public void PrintMessage(string message)
    {
        print(message);
    }


}

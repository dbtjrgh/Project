using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class AnonymousMethodTest : MonoBehaviour
{

    // ���� �ż����?
    // Ŭ���� ���� �ִ� ���� �ƴ� �޼��� ������ ���ǵǴ� �޼���
    // �޼��忡 �̸��� ������, Delegate�� �Ҵ��ϱ� ���ؼ���
    // �ش� Delegate�� �Ű������� ��ȯ���� Ÿ���� ��ġ�ؾ� ��.
    System.Action someAction;
    System.Action<int, float> autoCastPlus;
    System.Func<int, string> someFunc;
    System.Func<int,int,string> someFunc2;

    // ���� �޼����� ���� : 1ȸ������ ���Ǵ� �Լ��� ���Ǹ� ���� �Լ� �ۿ��� �� �ʿ䰡 ����
    // �������� �����ϴ� ������ �ִ�. ���� ���������� ���Ǵ� ��������Ʈ ������ �Ҵ��ϴ� ������ ���� ���
    // �ش� ��Ŀ���� ����Ǹ� �޸� �Ҵ��� �����ϹǷ� ���ʿ��ϰ� �Լ��� �޸𸮸� �����ϴ� ���� ������ �� ����.
    // ���� �޼����� ���� : ��������Ʈ ü�̴��� ����� ��, �ش� �޼��常 ü�ο��� �����ϴ� ���� �Ұ���.
    // ����, �� �޼��忡�� ���� �������� ���� �ÿ� ������ �������� ������ �� �ִ�.

    // ���ٽ� : ����޼����� ���� ǥ��


    private void Awake()
    {
        someAction = delegate ()
        {
            print("Anonymous Method Called.");
        };

        autoCastPlus = delegate (int a, float b) 
        {
            int result = a + (int)b;
            print(result);
        };

        
        autoCastPlus?.Invoke(1, 1.1f);

        // ���� �޼��带 �Ҵ��� ��� �Ű����� ������ �ʿ� ���ٸ� ���� ����
        autoCastPlus += delegate
        {
            print("Calc Finished!");
        };
        someFunc = delegate (int a)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("�Էµ� �Ķ���ʹ� ");
            sb.Append(a);
            sb.Append(" �Դϴ�.");

            return sb.ToString();
        };

        // ���ٽ� ǥ�����
        someAction += (/*�Ķ����*/) => { /*�Լ� ����*/ };

        // delegate Ű���� ��� => ��ȣ�� ���� ����޼��� ���� ���.
        someFunc += (int a) => { return a + "is intager."; };
        // �Ű������� �ڷ����� return Ű���� ���� ����
        someFunc += (a) => a + "is intager.";
        // �Ű������� 2�� �̻��� ��� �ݵ�� ��ȣ �ȿ� �Ű��������� ����.
        someFunc2 = (a, b) => $"{a} + {b} = {a + b}";

    }
    private void Start()
    {
        someAction?.Invoke();
        someAction?.Invoke();
        autoCastPlus?.Invoke(1, 1.1f);
        print(someFunc?.Invoke(923));
    }
}

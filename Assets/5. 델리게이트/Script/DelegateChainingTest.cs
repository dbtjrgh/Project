using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateChainingTest : MonoBehaviour
{
	private OtherDeilegateMethod otherDelegate;

    private void Start()
    {
        // ��������Ʈ �ν��Ͻ� ����, MessageTrim���� �ʱ�ȭ
        otherDelegate = MessageTrim;

        // ��������Ʈ ü�ο� MessageAllTrim �߰�
        otherDelegate += MessageAllTrim;

        // ��������Ʈ ü�ο� MessageDuplicate �߰�
        otherDelegate += MessageDuplicate;

        // ��������Ʈ ü�ο� MessageLower �߰�
        otherDelegate += MessageLower;

        // ��������Ʈ ü�ο� MessageAllTrim ����
        otherDelegate -= MessageAllTrim;

        otherDelegate?.Invoke(" Hello World  ");

        otherDelegate += MessageDuplicate;
        otherDelegate += MessageDuplicate;
        otherDelegate += MessageDuplicate;

        // ��������Ʈ �ν��Ͻ��� ���� �����ؼ� ����.
        //otherDelegate = MessageTrim;

        otherDelegate -= MessageDuplicate;

        // ��������Ʈ ü���� ������ Stack����
        // ���� �޼ҵ� �߿����� ���� ����� ���ŵȴ�.
        otherDelegate?.Invoke(" Hello World ");
    }

    private void MessageTrim(string message)
    {
        // string.Trim() : ���ڿ����� ������ �����Ͽ� ��ȯ
        print(message.Trim());
    }
    private void MessageAllTrim(string message)
    {
        // string.Replace()�� �̿��Ͽ� ���ڿ� ������ ������� ��� ����
        print(message.Replace(" ", ""));
    }
    private void MessageDuplicate(string message)
    {
        print(message + message);
    }

    private void MessageLower(string message)
    {
        // string.ToLower() : ���ڿ��� ������ �빮�ڸ� ��� �ҹ��ڷ� �ٲ� ��ȯ
        print(message.ToLower());
    }
}

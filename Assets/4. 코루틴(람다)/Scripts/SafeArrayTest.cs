using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SafeArray<T> : MonoBehaviour
{
    private T[] array; // ���� �迭�� ������ �ʵ�

    // ������: �迭�� ũ�⸦ �޾Ƽ� �迭�� �ʱ�ȭ
    public SafeArray(int size)
    {
        if (size < 0) // �迭 ũ�Ⱑ ������ ��� ��� �޽����� ���
        {
            Debug.LogWarning("ũ��� ������ �� �� �����ϴ�. �⺻ ũ�� 0���� ����");
            size = 0;
        }
        array = new T[size]; // �迭�� ������ ũ��� �ʱ�ȭ
    }

    // �ε��� : �迭 ��ҿ� ������ �� ��� get�� set �����ڸ� ����
    public T this[int index]
    {
        get => Get(index); // Get �޼��带 ȣ���Ͽ� ���� ��ȯ
        set => Set(index, value); // Set �޼��带 ȣ���Ͽ� ���� ����
    }

    // Get �޼��� : ������ �ε����� ���� ��ȯ
    // ������ ����� ��� �޽����� ����ϰ� �⺻���� ��ȯ
    public T Get(int index)
    {
        if (IsIndexValid(index)) // �ε����� ��ȿ���� �˻�
        {
            return array[index]; // ��ȿ�� ��� �迭�� ���� ��ȯ
        }
        Debug.LogWarning("��� : �ε����� ������ ���"); // ��ȿ���� ���� ��� ��� �޽����� ���
        return default(T); // �⺻���� ��ȯ
    }

    // Set �޼��� : ������ �ε����� ���� ����
    // ������ ����� ��� �޽����� ���
    public void Set(int index, T value)
    {
        if (IsIndexValid(index)) // �ε����� ��ȿ���� �˻�
        {
            array[index] = value; // ��ȿ�� ��� �迭�� ���� ����
        }
        else
        {
            Debug.LogWarning("��� : �ε����� ������ ���"); // ��ȿ���� ���� ��� ��� �޽����� ���
        }
    }

    // �ε����� ��ȿ���� �˻��ϴ� ���� �޼���
    private bool IsIndexValid(int index)
    {
        return index >= 0 && index < array.Length; // �ε����� 0 �̻��̰� �迭 ���̺��� ������ Ȯ��
    }

    // �迭�� ���̸� ��ȯ�ϴ� �Ӽ�
    public int Length => array.Length; // �迭�� ���̸� ��ȯ
}

public class SafeArrayTest : MonoBehaviour
{
    void Start()
    {
        // ũ�Ⱑ 30�� ������ SafeArray�� ����
        SafeArray<int> safeArray = new SafeArray<int>(30);

        // �ε��� 0�� ���� ����
        safeArray[0] = 10;

        // �ε��� 29�� ���� ����
        safeArray[29] = 20;

        // ������ ���� ���
        Debug.Log(safeArray[0]);  // ���: 10
        Debug.Log(safeArray[29]); // ���: 20

        // �� �ڵ�� �ε����� ������ ������Ƿ� ��� �޽����� ����ϰ� �⺻��(int�� ��� 0)�� ��ȯ
        Debug.Log(safeArray[30]);

        // �� �ڵ�� �ε����� ������ ������Ƿ� ��� �޽����� ����ϰ� ���� ���� X
        safeArray[30] = 30;
    }
}
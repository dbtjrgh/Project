using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollectionTest : MonoBehaviour
{
    // ���� �������� (�÷���)
    // �����͸� ���������� ����� �� �ִ� Ŭ������ ����
    // 1. �迭
    // 2. ����Ʈ(��̸���Ʈ)
    // 3. ��ųʸ�(�ؽ����̺�)
    // 4. ���� / ť

    /*
        ��� ���� ���� ���� - �迭�� List, ArrayList, Dictionary �� �������� �������ּ���.

       List

       C# ������ ���׸� Ÿ���� List�� �����Ǹ� ���������� ���� �迭�� ����մϴ�.
       
       ���׸� Ÿ���̱� ������ �ڽ� ��ڽ��� �ȿ���� Ÿ�� �������� ���ɻ��� ������ �ֽ��ϴ�.
       
       ���� �迭�� ����ϱ� ������ ����Ʈ�� �������� �߰�/������ ���� 1�� �ð����⵵
       
       �߰��� �����͸� insert�ϰ� �� �� �������� �����͸� �̵� ���Ѿ� �� n�� �ð� ���⵵�� ����
       
       insert�� ���� ��� �� ȿ������ �� �ֽ��ϴ�.
       
       ArrayList

       C# ���� ArrayList�� ���׸��� ���ԵǱ� �� �ַ� ����ϴ� �ڷᱸ���� � Ÿ���� ��ü�� ������ �� �ֽ��ϴ�.
       
       ������ �ڽ� ��ڽ��� �Ͼ Ÿ�� �������� �������� ������ ������ �� �ֽ��ϴ�.
       
       Dictionary

       Dictionary �ڷᱸ���� Hashtable�� ������� Key-Value Pair�� ���·� �����͸� �����մϴ�.
       
       Hashtable ����̱� ������ � �����͸� �˻��� �� 1�� �ð����⵵�� �����ϴ�.
       
       Hashtable�� buckets�� entries��� �� ���� �迭�� ���� �����մϴ�.
       
       buckets�� �ؽ��ڵ带 ������� entries�� �ε����� �ش��ϴ� ���� �����մϴ�.
       
       entries���� key�� value�� ����˴ϴ�.
       
       Summary

       List�� ���� �迭�� ����ϴ� �ڷᱸ���� ���׸��� �����մϴ�.
       
       ArrayList�� � Ÿ���� ��ü�� ������ �� �ְ� �ڽ� ������ �Ͼ ���׸� ����Ʈ�� ���ؼ�
       
       Ÿ�� �������� �������� ������ ������ �� �ֽ��ϴ�.
       
       Dictionary�� hashtable�� ������� key-value pair�� �����ϴ� �ڷᱸ�� �̸� Ű�� ���ϼ��� �����մϴ�.
       
       key�� ������� �˻��� �� List�� ���ؼ� ���� ���� ������ �ֽ��ϴ�.
     
    */

    #region �迭


    // ������ �迭�� �����Ѵ�.
    // �⺻������ �迭�� ���۷��� Ÿ���̱� ������ �ʱ�ȭ �Ҵ��� ���� ������ Null ����
    private int[] intArray = new int[5];

	// ���ͷ� Ÿ���� �ʱⰪ �Ҵ��� ���� �ʾƵ� �⺻���� �Ҵ��.
	private int[] someInt;

    // �ʱ� �Ҵ簪�� Unity ������ ���� ��ü�� �� ����.
    public int[] publicIntArray = new int[10];
    // public int[] publicIntArray;



    private void Reset()
    {
        // Reset �޽��� �Լ� : ����Ƽ �ν����Ϳ��� Reset�� �����ϸ� ȣ��
        // ���� ������ �ʱⰪ �Ҵ� ���� ��, ȣ���.
        publicIntArray = new int[15];
    }

    #endregion


    #region ����Ʈ

    // �迭�� ����� ����� �Ѵ�.
    // ���������� ũ�� ������ ����.
    // ��� �� ���� ����� �����ϴ� �Լ��� ���Ե� Ŭ����.

    private List<int> intList = new List<int>();

    public List<int> publicIntList;

    public List<GameObject> gameObjects;

    private ArrayList arrayList = new ArrayList();

    // ArrayList�� public���� �ص� ����Ƽ ������ ���� �Ұ�.
    public ArrayList publicArrayList;

    #endregion


    #region ��ųʸ�

    public GameObject cube;
    public GameObject sphere;
    public GameObject cylinder;
    public GameObject capsule;

   // private Dictionary<int, string> dictionary = new Dictionary<int, string>();
    private Dictionary<string, GameObject> dictionary 
        = new Dictionary<string, GameObject>();

    // �ؽ����̺�
    private Hashtable hashtable = new Hashtable();

    // Dictionary�� public���� �ص� ����Ƽ ������ ���� �Ұ�.
    public Dictionary<string, GameObject> publicDictionay;

    // �迭                :     �������⵵ (����) �ð����⵵ (����)
    // ��ųʸ�(�ؽ����̺�) :     �������⵵ (����) �ð����⵵ (����)

    #endregion


    #region ���� / ť

    // ����
    private Stack<int> intStack = new Stack<int>();

    // ť
    private Queue<int> intQueue = new Queue<int>();

    #endregion

    // ������Ƽ

    private int a;
    public int A { get { return a; } set { a = value; } }

    // ĸ��ȭ

    private int a_1;

    // setter �޼ҵ�
    public void SetA_1(int value)
    {
        if (value > 100)
        {
            print("�߸��� ���� �ԷµǾ����ϴ�.");
            a_1 = 100;
        }
        else
        {
            a_1 = value;
        }
    }

    public int GetA_1()
    {    
        return a_1; 
    }


    private void Start()
    {
        // �迭
		print(someInt);

        Array.Fill<int>(intArray, 1);

        //for(int i = 0; i <intArray.Length; i++)
        //{
        //    print(intArray[i]);
        //}

        //foreach(int someInt in intArray)
        //{
        //    print(someInt);
        //}

        foreach (int someInt in publicIntArray)
        {
            print(someInt);
        }

        // ����Ʈ
        intList.Add(1);
        intList.Add(2);
        intList.Add(3);
        intList.Add(4);
        intList.Add(5);

        //foreach(int someInt in intList)
        //{
        //    print(someInt);
        //}

        print(intList[4]);

        // ����Ʈ�� �̿��� ������Ʈ

        foreach (GameObject obj in gameObjects)
        {
            print(obj.name);
        }

        // ArrayList�� List�� ���� ���·� Ȱ�� �� �� ������
        // �������� �ڷ����� �������� ������, �⺻������ Boxing �Ǿ� �Ҵ��.

        arrayList.Add(1);
        arrayList.Add(1.2f);
        arrayList.Add(new GameObject("���� ���� ��ü"));
        arrayList.Add(new ArrayList());

        foreach (object element in arrayList)
        {
            print(element);
        }

        print((arrayList[2] as GameObject).name);


        // ��ųʸ�
        dictionary.Add("cube", cube);
        dictionary.Add("sphere", sphere);
        dictionary.Add("cylinder", cylinder);
        dictionary.Add("capsule", capsule);


        // ����Ʈ ����
        print(intList[0]);

        // ��ųʸ� ����
        dictionary["cube"].GetComponent<Renderer>().material.color = Color.red;
        dictionary["sphere"].GetComponent<Renderer>().material.color = Color.blue;
        dictionary["cylinder"].GetComponent<Renderer>().material.color = Color.green;
        dictionary["capsule"].GetComponent<Renderer>().material.color = Color.yellow;

        // �ؽ����̺�
        hashtable.Add("a", 1);
        hashtable.Add(3f, new GameObject());

        // ����

        // Push = �Ҵ�
        intStack.Push(5);
        intStack.Push(4);
        intStack.Push(3);
        intStack.Push(2);
        intStack.Push(1);

        // Pop = ���
        print(intStack.Pop()); // 1
        print(intStack.Pop()); // 2
        print(intStack.Pop()); // 3

        intStack.Push(6);
        intStack.Push(7);

        print(intStack.Pop()); // 7
        print(intStack.Pop()); // 6
        print(intStack.Pop()); // 4
        print(intStack.Pop()); // 5

        // ť

        // Enqueue = �Է�
        intQueue.Enqueue(1);
        intQueue.Enqueue(2);
        intQueue.Enqueue(3);
        intQueue.Enqueue(7);
        intQueue.Enqueue(6);

        // Dequeue = ���
        print(intQueue.Dequeue()); // 1
        print(intQueue.Dequeue()); // 2
        print(intQueue.Dequeue()); // 3

        intQueue.Enqueue(4);
        intQueue.Enqueue(5);

        print(intQueue.Dequeue()); // 7
        print(intQueue.Dequeue()); // 6
        print(intQueue.Dequeue()); // 4
        print(intQueue.Dequeue()); // 5



    }
}
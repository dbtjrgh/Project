using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollectionTest : MonoBehaviour
{
    // 오늘 수업내용 (컬렉션)
    // 데이터를 묶음단위로 취급할 수 있는 클래스의 집합
    // 1. 배열
    // 2. 리스트(어레이리스트)
    // 3. 딕셔너리(해쉬테이블)
    // 4. 스택 / 큐

    /*
        기술 면접 예상 질문 - 배열과 List, ArrayList, Dictionary 의 차이점을 설명해주세요.

       List

       C# 에서는 제네릭 타입의 List가 제공되며 내부적으로 동적 배열을 사용합니다.
       
       제네릭 타입이기 때문에 박싱 언박싱이 팔요없어 타입 안정성과 성능상의 이점이 있습니다.
       
       동적 배열을 사용하기 떄문에 리스트에 끝에서만 추가/삭제할 경우는 1의 시간복잡도
       
       중간에 데이터를 insert하게 될 때 나머지의 데이터를 이동 시켜야 해 n의 시간 복잡도를 가져
       
       insert가 많을 경우 비 효율적일 수 있습니다.
       
       ArrayList

       C# 에서 ArrayList는 제네릭이 도입되기 전 주로 사용하던 자료구조로 어떤 타입의 객체든 저장할 수 있습니다.
       
       하지만 박싱 언박싱이 일어나 타입 안정성이 떨어지고 성능이 떨어질 수 있습니다.
       
       Dictionary

       Dictionary 자료구조는 Hashtable을 기반으로 Key-Value Pair의 형태로 데이터를 저장합니다.
       
       Hashtable 기반이기 때문에 어떤 데이터를 검색할 때 1의 시간복잡도를 가집니다.
       
       Hashtable은 buckets와 entries라는 두 개의 배열을 통해 동작합니다.
       
       buckets는 해시코드를 기반으로 entries의 인덱스에 해당하는 값을 저장합니다.
       
       entries에는 key와 value가 저장됩니다.
       
       Summary

       List는 동적 배열을 사용하는 자료구조로 제네릭을 제공합니다.
       
       ArrayList는 어떤 타입의 객체등 저장할 수 있고 박싱 언방싱이 일어나 제네릭 리스트에 비해서
       
       타입 안정성이 떨어지고 성능이 떨어질 수 있습니다.
       
       Dictionary는 hashtable을 기반으로 key-value pair를 저장하는 자료구조 이며 키의 유일성을 보장합니다.
       
       key를 기반으로 검색할 때 List에 비해서 성능 상의 이점이 있습니다.
     
    */

    #region 배열


    // 정수형 배열을 선언한다.
    // 기본적으로 배열은 레퍼런스 타입이기 때문에 초기화 할당을 하지 않으면 Null 상태
    private int[] intArray = new int[5];

	// 리터럴 타입은 초기값 할당을 하지 않아도 기본값이 할당됨.
	private int[] someInt;

    // 초기 할당값은 Unity 엔진에 의해 대체될 수 있음.
    public int[] publicIntArray = new int[10];
    // public int[] publicIntArray;



    private void Reset()
    {
        // Reset 메시지 함수 : 유니티 인스펙터에서 Reset을 실행하면 호출
        // 전역 변수의 초기값 할당 수행 후, 호출됨.
        publicIntArray = new int[15];
    }

    #endregion


    #region 리스트

    // 배열과 비슷한 기능을 한다.
    // 유동적으로 크기 변경이 가능.
    // 요소 비교 등의 기능을 지원하는 함수가 포함된 클래스.

    private List<int> intList = new List<int>();

    public List<int> publicIntList;

    public List<GameObject> gameObjects;

    private ArrayList arrayList = new ArrayList();

    // ArrayList는 public으로 해도 유니티 내에서 수정 불가.
    public ArrayList publicArrayList;

    #endregion


    #region 딕셔너리

    public GameObject cube;
    public GameObject sphere;
    public GameObject cylinder;
    public GameObject capsule;

   // private Dictionary<int, string> dictionary = new Dictionary<int, string>();
    private Dictionary<string, GameObject> dictionary 
        = new Dictionary<string, GameObject>();

    // 해시테이블
    private Hashtable hashtable = new Hashtable();

    // Dictionary는 public으로 해도 유니티 내에서 수정 불가.
    public Dictionary<string, GameObject> publicDictionay;

    // 배열                :     공간복잡도 (낮음) 시간복잡도 (높음)
    // 딕셔너리(해시테이블) :     공간복잡도 (높음) 시간복잡도 (낮음)

    #endregion


    #region 스택 / 큐

    // 스택
    private Stack<int> intStack = new Stack<int>();

    // 큐
    private Queue<int> intQueue = new Queue<int>();

    #endregion

    // 프로퍼티

    private int a;
    public int A { get { return a; } set { a = value; } }

    // 캡슐화

    private int a_1;

    // setter 메소드
    public void SetA_1(int value)
    {
        if (value > 100)
        {
            print("잘못된 값이 입력되었습니다.");
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
        // 배열
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

        // 리스트
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

        // 리스트를 이용한 오브젝트

        foreach (GameObject obj in gameObjects)
        {
            print(obj.name);
        }

        // ArrayList는 List와 같은 형태로 활용 할 수 있지만
        // 데이터의 자료형을 제한하지 않으며, 기본적으로 Boxing 되어 할당됨.

        arrayList.Add(1);
        arrayList.Add(1.2f);
        arrayList.Add(new GameObject("내가 만든 객체"));
        arrayList.Add(new ArrayList());

        foreach (object element in arrayList)
        {
            print(element);
        }

        print((arrayList[2] as GameObject).name);


        // 딕셔너리
        dictionary.Add("cube", cube);
        dictionary.Add("sphere", sphere);
        dictionary.Add("cylinder", cylinder);
        dictionary.Add("capsule", capsule);


        // 리스트 참조
        print(intList[0]);

        // 딕셔너리 참조
        dictionary["cube"].GetComponent<Renderer>().material.color = Color.red;
        dictionary["sphere"].GetComponent<Renderer>().material.color = Color.blue;
        dictionary["cylinder"].GetComponent<Renderer>().material.color = Color.green;
        dictionary["capsule"].GetComponent<Renderer>().material.color = Color.yellow;

        // 해시테이블
        hashtable.Add("a", 1);
        hashtable.Add(3f, new GameObject());

        // 스택

        // Push = 할당
        intStack.Push(5);
        intStack.Push(4);
        intStack.Push(3);
        intStack.Push(2);
        intStack.Push(1);

        // Pop = 출력
        print(intStack.Pop()); // 1
        print(intStack.Pop()); // 2
        print(intStack.Pop()); // 3

        intStack.Push(6);
        intStack.Push(7);

        print(intStack.Pop()); // 7
        print(intStack.Pop()); // 6
        print(intStack.Pop()); // 4
        print(intStack.Pop()); // 5

        // 큐

        // Enqueue = 입력
        intQueue.Enqueue(1);
        intQueue.Enqueue(2);
        intQueue.Enqueue(3);
        intQueue.Enqueue(7);
        intQueue.Enqueue(6);

        // Dequeue = 출력
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
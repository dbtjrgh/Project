using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SafeArray<T> : MonoBehaviour
{
    private T[] array; // 내부 배열을 저장할 필드

    // 생성자: 배열의 크기를 받아서 배열을 초기화
    public SafeArray(int size)
    {
        if (size < 0) // 배열 크기가 음수일 경우 경고 메시지를 출력
        {
            Debug.LogWarning("크기는 음수가 될 수 없습니다. 기본 크기 0으로 설정");
            size = 0;
        }
        array = new T[size]; // 배열을 지정된 크기로 초기화
    }

    // 인덱서 : 배열 요소에 접근할 때 사용 get과 set 접근자를 제공
    public T this[int index]
    {
        get => Get(index); // Get 메서드를 호출하여 값을 반환
        set => Set(index, value); // Set 메서드를 호출하여 값을 설정
    }

    // Get 메서드 : 지정된 인덱스의 값을 반환
    // 범위를 벗어나면 경고 메시지를 출력하고 기본값을 반환
    public T Get(int index)
    {
        if (IsIndexValid(index)) // 인덱스가 유효한지 검사
        {
            return array[index]; // 유효한 경우 배열의 값을 반환
        }
        Debug.LogWarning("경고 : 인덱스가 범위를 벗어남"); // 유효하지 않은 경우 경고 메시지를 출력
        return default(T); // 기본값을 반환
    }

    // Set 메서드 : 지정된 인덱스에 값을 설정
    // 범위를 벗어나면 경고 메시지를 출력
    public void Set(int index, T value)
    {
        if (IsIndexValid(index)) // 인덱스가 유효한지 검사
        {
            array[index] = value; // 유효한 경우 배열의 값을 설정
        }
        else
        {
            Debug.LogWarning("경고 : 인덱스가 범위를 벗어남"); // 유효하지 않은 경우 경고 메시지를 출력
        }
    }

    // 인덱스가 유효한지 검사하는 헬퍼 메서드
    private bool IsIndexValid(int index)
    {
        return index >= 0 && index < array.Length; // 인덱스가 0 이상이고 배열 길이보다 작은지 확인
    }

    // 배열의 길이를 반환하는 속성
    public int Length => array.Length; // 배열의 길이를 반환
}

public class SafeArrayTest : MonoBehaviour
{
    void Start()
    {
        // 크기가 30인 정수형 SafeArray를 생성
        SafeArray<int> safeArray = new SafeArray<int>(30);

        // 인덱스 0에 값을 설정
        safeArray[0] = 10;

        // 인덱스 29에 값을 설정
        safeArray[29] = 20;

        // 설정한 값을 출력
        Debug.Log(safeArray[0]);  // 출력: 10
        Debug.Log(safeArray[29]); // 출력: 20

        // 이 코드는 인덱스가 범위를 벗어났으므로 경고 메시지를 출력하고 기본값(int의 경우 0)을 반환
        Debug.Log(safeArray[30]);

        // 이 코드는 인덱스가 범위를 벗어났으므로 경고 메시지를 출력하고 값을 설정 X
        safeArray[30] = 30;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggleTest : MonoBehaviour
{

	public Toggle[] toggles;

    private void Awake()
    {
        toggles = GetComponentsInChildren<Toggle>();
    }

    private void Start()
    {
        // toggles의 동작을 동적으로 할당하기위해
        // toggles.Addlistener 호출

        for (int i = 0; i < toggles.Length; i++)
        {
            // i 변수만 참조할 경우, 모든 루프가 종료 될 때까지 값이 바뀌기 때문에
            // 해당 루프에서의 i값을 Stack에 별도로 캡쳐하기 위하여 변수 1개를 사용함.
            int index = i;
            toggles[i].onValueChanged.AddListener
            (delegate (bool isOn)
                 {
                     if(isOn)
                     {  
                         OnToggleValueChange(index);
                     }
                 }
            );
        }


    }
    public void OnToggleValueChange(int index)
	{
        print($"Toggle {index} is On");
	}
}

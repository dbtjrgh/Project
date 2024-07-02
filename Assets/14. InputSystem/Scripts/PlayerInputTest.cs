using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Player Input Test 컴포넌트는 반드시 Character Controller 컴포넌트가 있어야지만 정상 작동 하도록
// 구현이 되어 있기 때문에, 오브젝트에 Character Controller 컴포넌트 부착을 강제함.
[RequireComponent(typeof(CharacterController))]

public class PlayerInputTest : MonoBehaviour
{
    private CharacterController cc;
    public float moveSpeed;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Move(Vector2 inputValue)
    {
        Vector3 moveDir = new Vector3 (inputValue.x,0,inputValue.y);
        cc.Move(moveDir * Time.deltaTime * moveSpeed);
    }

    public bool useInputManager;

    private void Update()
    {
        if (useInputManager)
        {
            Vector2 inputValue = Vector2.zero;

            // GetAxis와 GetAxisRaw의 차이는 InputManager 세팅의 Gravity와 Sensitivity값을 무시한다.

            inputValue.x = Input.GetAxisRaw("Horizontal"); // x축 값. a : negative, d : positive x : 
            inputValue.y = Input.GetAxisRaw("Vertical"); // y축 값. s : negative, w : positive
            Move(inputValue);
        }
        else
        {
            cc.Move(moveDir * Time.deltaTime * moveSpeed);
        }
    }

    private Vector3 moveDir;
    // PlayerInput 컴포넌트가 기기 입력에 맞게 SendMessage()를 통해 호출.
    private void OnMove(InputValue inputValue)
    {
        Vector2 inputVector = inputValue.Get<Vector2>();
        moveDir = new Vector3(inputVector.x, 0, inputVector.y);
    }

    private void OnAttack(InputValue inputValue)
    {
        print("공격");
    }

}

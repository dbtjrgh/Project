using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Player Input Test ������Ʈ�� �ݵ�� Character Controller ������Ʈ�� �־������ ���� �۵� �ϵ���
// ������ �Ǿ� �ֱ� ������, ������Ʈ�� Character Controller ������Ʈ ������ ������.
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

            // GetAxis�� GetAxisRaw�� ���̴� InputManager ������ Gravity�� Sensitivity���� �����Ѵ�.

            inputValue.x = Input.GetAxisRaw("Horizontal"); // x�� ��. a : negative, d : positive x : 
            inputValue.y = Input.GetAxisRaw("Vertical"); // y�� ��. s : negative, w : positive
            Move(inputValue);
        }
        else
        {
            cc.Move(moveDir * Time.deltaTime * moveSpeed);
        }
    }

    private Vector3 moveDir;
    // PlayerInput ������Ʈ�� ��� �Է¿� �°� SendMessage()�� ���� ȣ��.
    private void OnMove(InputValue inputValue)
    {
        Vector2 inputVector = inputValue.Get<Vector2>();
        moveDir = new Vector3(inputVector.x, 0, inputVector.y);
    }

    private void OnAttack(InputValue inputValue)
    {
        print("����");
    }

}

using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    private bool isOpen = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        if (!isOpen)
        {
            OpenChest();
        }
        else if (isOpen)
        {
            CloseChest();
        }
        isOpen = !isOpen;
    }

    private void OpenChest()
    {
        // Open 애니메이션 실행
        animator.SetBool("isOpen", true);
        Debug.Log("상자 열림");
    }

    private void CloseChest()
    {
        // Close 애니메이션 실행
        animator.SetBool("isOpen", false);
        Debug.Log("상자 닫힘");
    }
}
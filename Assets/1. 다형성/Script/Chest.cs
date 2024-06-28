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
        // Open �ִϸ��̼� ����
        animator.SetBool("isOpen", true);
        Debug.Log("���� ����");
    }

    private void CloseChest()
    {
        // Close �ִϸ��̼� ����
        animator.SetBool("isOpen", false);
        Debug.Log("���� ����");
    }
}
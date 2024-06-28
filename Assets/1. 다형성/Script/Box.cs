using UnityEngine;

public class Box : MonoBehaviour, IHitable , IInteractable
{
    private bool isGrabbed = false;
    private Rigidbody rb;

    public float maxDamage = 10;
    public LayerMask someLayer;
    public Transform playerHead; 
    public float grabDistance = 1.5f; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isGrabbed)
        {
            Vector3 targetPosition = playerHead.position + playerHead.up * grabDistance;
            rb.MovePosition(Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f));
        }
    }

    public void Hit(float damage)
    {
        if (damage >= maxDamage)
        {
            Destroy(gameObject);
        }

        Debug.Log($"{name} hitted and damaged: {damage}");
    }

    public void Interact()
    {
        if (!isGrabbed)
        {
            GrabBox();
        }
        else if (isGrabbed)
        {
            LayBox();
        }
        isGrabbed = !isGrabbed;
    }

    private void GrabBox()
    {
        Debug.Log("Debug.Log(\"상자 들기\");");
        Vector3 offset = playerHead.position - transform.position;

        transform.position = playerHead.position;

        transform.localPosition += offset;
    }

    private void LayBox()
    {
        Debug.Log(" Debug.Log(\"상자 놓기\");");
        rb.velocity = Vector3.zero; 
        Vector3 targetPosition = playerHead.position + playerHead.forward * 2f;
        transform.position = targetPosition;
    }
}
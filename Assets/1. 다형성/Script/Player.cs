using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 dir;

    public Bullet bulletPrefab;
    public Transform shotPoint;
    public CharacterController cc;
    public InteractionUI interactionUI;


    public float damage = 10;
    public float speed;
    public float maxHP = 100;
    public float currentHP = 100;

    private IInteractable currentInteractable;

    public void Hit(float damage)
    {
        currentHP -= damage;
        print($"Player take damage : {damage}, current hp : {currentHP}");
    }

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        interactionUI.HidePrompt(); // 자막 숨기기
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }

        // 플레이어 이동 및 점프
        if (cc.isGrounded)
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");

            dir = new Vector3(h, 0, v) * speed;

            if (dir != Vector3.zero)
            {
                transform.rotation = Quaternion.Euler(0, Mathf.Atan2(h, v) * Mathf.Rad2Deg, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                dir.y = 7.5f;
            }
        }
        dir.y += Physics.gravity.y * Time.deltaTime;
        cc.Move(dir * Time.deltaTime);

        // F 상호작용
        if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }


    void OnTriggerEnter(Collider other)
    {
        // 충돌한 콜라이더의 부모 게임 오브젝트에서 IInteractable 인터페이스를 구현한 컴포넌트를 가져옴.
        IInteractable interactable = other.GetComponentInParent<IInteractable>();

        // 상호작용이 가능한 컴포넌트가 발견되었는지 확인
        if (interactable != null)
        {
            // 발견된 상호작용 가능한 컴포넌트를 currentInteractable 변수에 할당
            currentInteractable = interactable;

            // 상호작용 프롬프트 UI를 표시
            interactionUI.ShowPrompt(); 
        }
    }

    void OnTriggerExit(Collider other)
    {
        IInteractable interactable = other.GetComponentInParent<IInteractable>();
        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable = null;
            interactionUI.HidePrompt(); 
        }
    }

    public void Shot()
    {
        Bullet bullet = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);

        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 10f, ForceMode.Impulse);
        bullet.damage = damage;
        bullet.targetLayer = (1 << LayerMask.NameToLayer("Box")) + (1 << LayerMask.NameToLayer("Monster"));

        Destroy(bullet, 3f);
    }
}
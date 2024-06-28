using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ShooterPlayer : MonoBehaviour
{
    public Gun[] guns; // �� �迭
    private int currentGun = 0; //���� �������� ���� Index
    public TargetFollower subHandTarget; //Two Bone IK�� Target�� ����ٴ� ���
    public TargetFollower subHandHint; //Two Bone IK�� Hint�� ����ٴ� ���

    public float moveSpeed;
    private Animator animator;
    public AnimationClip reloadClip;
    public Rig rig;
    private bool isReloading = false;
    private bool isTossgrenade = false;
    private bool isWalk = false;

	private void Awake()
    {
		animator = GetComponent<Animator>();
	}
	private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        { //�� ��ư�� ���������� ����
            if(currentGun == 0)
            {
                ChangeWeapon(1);
            } else {
                ChangeWeapon(0);
            }
            //ChangeWeapon(currentGun == 0 ? 1 : 0);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Tossgrenade();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            WalkRunToggle();
        }

        Vector3 moveDir = Vector3.zero;
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");
		//new Vector3(Input.GetAxis("Horizontal"), 0 ,Input.GetAxis("Vertical"));

		Move(moveDir);
	}
	public void ChangeWeapon(int index)
    {
        guns[currentGun].gameObject.SetActive(false);
        currentGun = index;
        guns[currentGun].gameObject.SetActive(true);
        subHandTarget.target = guns[currentGun].subHandTarget;
        subHandHint.target = guns[currentGun].subHandHint;
    }

    public void Move(Vector3 moveDir)
    {
        if(isWalk)
        {
            transform.Translate(moveDir * Time.deltaTime * moveSpeed);
            animator.SetFloat("Xposition", moveDir.x);
            animator.SetFloat("Yposition", moveDir.z);
            animator.SetFloat("Speed", moveDir.magnitude);
        }
        else
        {
            transform.Translate(moveDir * Time.deltaTime * moveSpeed * 2);
            animator.SetFloat("Xposition", moveDir.x);
            animator.SetFloat("Yposition", moveDir.z);
            animator.SetFloat("Speed", moveDir.magnitude * 2);
        }
       
    }

    public void WalkRunToggle()
    {
        isWalk = !isWalk;
    }

    public void Reload() 
    {
        if (isReloading)
        {
            return;
        }
        isReloading = true;
        rig.weight = 0;
        animator.SetTrigger("Reload");
        //������ �� �ٽ� isReloading = false ���ֱ� ���� �ڷ�ƾ
        StartCoroutine(Coroutine(reloadClip.length));
    }

    public void Tossgrenade() 
    {
        if (isReloading)
        {
            return;
        }
        isTossgrenade = true;
        rig.weight = 0;
        animator.SetTrigger("Tossgrenade");
        //������ �� �ٽ� isReloading = false ���ֱ� ���� �ڷ�ƾ
        StartCoroutine(Coroutine(reloadClip.length));
    }

    IEnumerator Coroutine(float duration) 
    {
        
        
        yield return null;

    }


}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ShooterPlayer : MonoBehaviour
{
    public Gun[] guns; // 총 배열
    private int currentGun = 0; //현재 장착중인 총의 Index
    public TargetFollower subHandTarget; //Two Bone IK의 Target이 따라다닐 대상
    public TargetFollower subHandHint; //Two Bone IK의 Hint가 따라다닐 대상

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
        { //탭 버튼을 누를때마다 수행
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
        //재장전 후 다시 isReloading = false 해주기 위한 코루틴
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
        //재장전 후 다시 isReloading = false 해주기 위한 코루틴
        StartCoroutine(Coroutine(reloadClip.length));
    }

    IEnumerator Coroutine(float duration) 
    {
        
        
        yield return null;

    }


}

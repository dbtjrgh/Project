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
    public AnimationClip tossGrenadeClip;
    public Rig rig;
    private bool isReloading = false;
    private bool isTossingGrenade = false;
    private bool isWalk = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        { //탭 버튼을 누를때마다 수행
            if (currentGun == 0)
            {
                ChangeWeapon(1);
            }
            else
            {
                ChangeWeapon(0);
            }
            //ChangeWeapon(currentGun == 0 ? 1 : 0);
        }

        if (Input.GetKeyDown(KeyCode.R) && !isReloading && !isTossingGrenade)
        {
            Reload();
        }

        if (Input.GetKeyDown(KeyCode.G) && !isReloading && !isTossingGrenade)
        {
            TossGrenade();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            WalkRunToggle();
        }

        Vector3 moveDir = Vector3.zero;
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");

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
        if (isWalk)
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
        StartCoroutine(AnimationCoroutine(reloadClip.length));
        animator.SetTrigger("Reload");
    }

    public void TossGrenade()
    {
        if (isTossingGrenade)
        {
            return;
        }
        isTossingGrenade = true;
        StartCoroutine(AnimationCoroutine(tossGrenadeClip.length));
        animator.SetTrigger("Tossgrenade");
    }

    IEnumerator AnimationCoroutine(float duration)
    {
        float elapsedTime = 0f;

        // Weight 값을 0으로 서서히 줄이기
        while (elapsedTime < duration / 2)
        {
            rig.weight = Mathf.Lerp(1, 0, elapsedTime / (duration / 2));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        rig.weight = 0;

        // 애니메이션 클립의 나머지 시간 기다리기
        yield return new WaitForSeconds(duration / 2);

        elapsedTime = 0f;

        // Weight 값을 1로 서서히 증가시키기
        while (elapsedTime < duration / 2)
        {
            rig.weight = Mathf.Lerp(0, 1, elapsedTime / (duration / 2));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        rig.weight = 1;

        // 상태 초기화
        isReloading = false;
        isTossingGrenade = false;
    }
}
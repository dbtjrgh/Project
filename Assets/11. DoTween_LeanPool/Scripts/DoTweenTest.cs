using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class DoTweenTest : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        DOTween.To(
            () => 0f,
            x =>
            {
                Vector3 start = Vector3.right * (Time.time - 1f);
                Vector3 end = start + (Vector3.up * x);
                Debug.DrawLine(start, end, Color.red, 10);
            },
           1f,
           1f   
            ). SetEase(Ease.Linear);
    }
    // 버튼에서 On Click으로 호출할 public 함수
    // DoPunch : 클릭시 펀치 효과
    public void DoPunch(Transform target)
    {
        target.DOComplete();
        target.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 1f);
    }

    // DoShake : 클릭 시 흔들리는 효과
    public void DoShake(Transform target)
    {
        target.DOComplete();
        target.DOShakePosition(1f, 10);
        target.DOShakeRotation(1f, 40);
    }

    // DoMove : 
    public void DoMove(Transform target)
    {
        target.DOComplete();
        // target.DOMove(target.position + (Vector3.up * 10), 1);   
        target.DOMove(target.position + (Vector3.up * 20), 1).SetEase(Ease.InOutQuad); // 보간 수치 함수를 Ease라고 표현
    }

    public void DoColor(Graphic target)
    {
        target.DOComplete();
        target.DOColor(new Color(Random.value, Random.value, Random.value), 1f).SetEase(Ease.InElastic);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    [SerializeField] float bulletTime; // 총알 생성용 시간
    [SerializeField] Rigidbody rigid; // 점프 코루틴 코드용 리지드바디
    Coroutine jumpDelayRoutine; // 딜레이점프 코루틴 생성
    void Start()
    {
        // 코루틴 개념 이해용 코루틴
        Coroutine coroutine = StartCoroutine(Routine());
        // 코루틴을 활용한 총알 생성 반복
        Coroutine bulletSpwanRoutine = StartCoroutine(BulletRoutine());
    }

    private void Update()
    {
        Debug.Log("Update");

        // 코루틴을 활용한 딜레이점프 구현
        if (Input.GetAxisRaw("Jump") == 1 && jumpDelayRoutine == null)
        {
            jumpDelayRoutine = StartCoroutine(DelayJump());
        }
        else if(Input.GetKeyDown(KeyCode.M) && jumpDelayRoutine != null)
        {
            StopCoroutine(jumpDelayRoutine); // 함수가 아니라 코루틴 변수를 입력해야함
            jumpDelayRoutine = null;
        }
    }

    IEnumerator Routine()
    {
        Debug.Log("coroutine 0");
        yield return new WaitForSeconds(1f);
        Debug.Log("coroutine 1");
        yield return new WaitForSeconds(1f);
        Debug.Log("coroutine 2");
        yield return new WaitForSeconds(1f);
        Debug.Log("coroutine 3");
        yield return new WaitForSeconds(1f);
        Debug.Log("coroutine 4");
    }

    IEnumerator BulletRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletTime);
            Debug.Log("총알 생성"); // => 총알생성 코드
        }
    }

    IEnumerator DelayJump()
    {
        Debug.Log("3");
        yield return new WaitForSeconds(1f);
        Debug.Log("2");
        yield return new WaitForSeconds(1f);
        Debug.Log("1");

        rigid.AddForce(Vector3.up * 2f, ForceMode.Impulse); // 점프코드
    }

    //코루틴 시간 지연
    // yield return null; // 한프레임 지연
    // yield return new WaitForSeconds(); // n초간 시간 지연
    // yield return new WaitForSecondsRealtime(); // 현실 n초간 시간 지연
    // yield return new WaitForFixedUpdat(); // FixedUpdate 까지 지연
    // yield return new WaitForEndOfFrame(); // 프레임 끝까지 지연
    // yield return new WaitUntil(() => ture); // 조건이 충족할때까지 지연
}

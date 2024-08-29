using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReceiver : MonoBehaviour
{
    [SerializeField] Rigidbody rigid; // 이벤트를 실행할 리지드바디를 받을 자료형
    [SerializeField] EventTester tester; // 이벤트를 실행시킬 객체를 받을 자료형

    // 활성화하면서 이벤트를 추가해줘야 할 경우
    private void OnEnable()
    {
        tester.OnScream.AddListener(Jump);
    }

    // 비활성화 하면서 이벤트를 제거해줘야 할 경우
    private void OnDisable()
    {
        tester.OnScream.RemoveListener(Jump);
    }
    // 이벤트 함수
    public void Jump()
    {
        rigid.AddForce(Vector3.up * 8f, ForceMode.Impulse);
    }
}

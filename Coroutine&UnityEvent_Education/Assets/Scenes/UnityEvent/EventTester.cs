using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTester : MonoBehaviour
{
    public UnityEvent OnScream; // 이벤트를 받을 유니티 이벤트 자료형
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Scream();
        }
    }

    // 플레이어가 이벤트를 발생시킬 행동 함수
    public void Scream()
    {
        Debug.Log("플레이어가 소리를 지름");
        OnScream?.Invoke();
    }
}

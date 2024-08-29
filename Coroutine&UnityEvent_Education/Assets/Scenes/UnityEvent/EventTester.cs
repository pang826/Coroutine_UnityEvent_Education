using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTester : MonoBehaviour
{
    public UnityEvent OnScream; // �̺�Ʈ�� ���� ����Ƽ �̺�Ʈ �ڷ���
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Scream();
        }
    }

    // �÷��̾ �̺�Ʈ�� �߻���ų �ൿ �Լ�
    public void Scream()
    {
        Debug.Log("�÷��̾ �Ҹ��� ����");
        OnScream?.Invoke();
    }
}

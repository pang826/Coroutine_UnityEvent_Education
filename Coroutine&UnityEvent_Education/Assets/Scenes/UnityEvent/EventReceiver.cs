using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReceiver : MonoBehaviour
{
    [SerializeField] Rigidbody rigid; // �̺�Ʈ�� ������ ������ٵ� ���� �ڷ���
    [SerializeField] EventTester tester; // �̺�Ʈ�� �����ų ��ü�� ���� �ڷ���

    // Ȱ��ȭ�ϸ鼭 �̺�Ʈ�� �߰������ �� ���
    private void OnEnable()
    {
        tester.OnScream.AddListener(Jump);
    }

    // ��Ȱ��ȭ �ϸ鼭 �̺�Ʈ�� ��������� �� ���
    private void OnDisable()
    {
        tester.OnScream.RemoveListener(Jump);
    }
    // �̺�Ʈ �Լ�
    public void Jump()
    {
        rigid.AddForce(Vector3.up * 8f, ForceMode.Impulse);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    [SerializeField] float bulletTime; // �Ѿ� ������ �ð�
    [SerializeField] Rigidbody rigid; // ���� �ڷ�ƾ �ڵ�� ������ٵ�
    Coroutine jumpDelayRoutine; // ���������� �ڷ�ƾ ����
    void Start()
    {
        // �ڷ�ƾ ���� ���ؿ� �ڷ�ƾ
        Coroutine coroutine = StartCoroutine(Routine());
        // �ڷ�ƾ�� Ȱ���� �Ѿ� ���� �ݺ�
        Coroutine bulletSpwanRoutine = StartCoroutine(BulletRoutine());
    }

    private void Update()
    {
        Debug.Log("Update");

        // �ڷ�ƾ�� Ȱ���� ���������� ����
        if (Input.GetAxisRaw("Jump") == 1 && jumpDelayRoutine == null)
        {
            jumpDelayRoutine = StartCoroutine(DelayJump());
        }
        else if(Input.GetKeyDown(KeyCode.M) && jumpDelayRoutine != null)
        {
            StopCoroutine(jumpDelayRoutine); // �Լ��� �ƴ϶� �ڷ�ƾ ������ �Է��ؾ���
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
            Debug.Log("�Ѿ� ����"); // => �Ѿ˻��� �ڵ�
        }
    }

    IEnumerator DelayJump()
    {
        Debug.Log("3");
        yield return new WaitForSeconds(1f);
        Debug.Log("2");
        yield return new WaitForSeconds(1f);
        Debug.Log("1");

        rigid.AddForce(Vector3.up * 2f, ForceMode.Impulse); // �����ڵ�
    }

    //�ڷ�ƾ �ð� ����
    // yield return null; // �������� ����
    // yield return new WaitForSeconds(); // n�ʰ� �ð� ����
    // yield return new WaitForSecondsRealtime(); // ���� n�ʰ� �ð� ����
    // yield return new WaitForFixedUpdat(); // FixedUpdate ���� ����
    // yield return new WaitForEndOfFrame(); // ������ ������ ����
    // yield return new WaitUntil(() => ture); // ������ �����Ҷ����� ����
}

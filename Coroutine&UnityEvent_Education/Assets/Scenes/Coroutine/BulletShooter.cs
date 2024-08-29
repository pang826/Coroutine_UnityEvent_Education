using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ����� �����ϱ� ���� ��ũ��Ʈ
public class BulletShooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab; // �Ѿ� ������
    [SerializeField] float repeatTime; // �߻簣�ݽð�

    [SerializeField] Coroutine bulletSpawnRoutine;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            bulletSpawnRoutine = StartCoroutine(BulletSpawnRoutine());
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(bulletSpawnRoutine);
        }
    }

    IEnumerator BulletSpawnRoutine()
    {
        WaitForSeconds delay = new WaitForSeconds(repeatTime); // ĳ��
        while(true)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            // yield return new WaitForSeconds(repeatTime); => �������� Ŭ������ �����ϱ⿡ ������ �÷��Ϳ� �δ��� ��
            yield return delay; // => ������ �÷��Ϳ� �ξ� ������ ��
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 연사 기능을 구현하기 위한 스크립트
public class BulletShooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab; // 총알 프리팹
    [SerializeField] float repeatTime; // 발사간격시간

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
        WaitForSeconds delay = new WaitForSeconds(repeatTime); // 캐싱
        while(true)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            // yield return new WaitForSeconds(repeatTime); => 돌때마다 클래스를 생성하기에 가비지 컬렉터에 부담이 됨
            yield return delay; // => 가비지 컬렉터에 훨씬 도움이 됨
        }
    }
}

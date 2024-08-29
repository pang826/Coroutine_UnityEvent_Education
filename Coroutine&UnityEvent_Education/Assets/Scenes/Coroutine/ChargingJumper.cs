using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingJumper : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    [SerializeField] float ChargingTime;

    Coroutine chargerCoroutine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            chargerCoroutine = StartCoroutine(ChargerRoutine());
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(chargerCoroutine);
            rigid.AddForce(Vector3.up * ChargingTime, ForceMode.Impulse);
        }
    }

    IEnumerator ChargerRoutine()
    {
        ChargingTime = 0;
        WaitForSeconds delay = new WaitForSeconds(0.1f);
        while (true)
        {
            yield return delay;
            ChargingTime += 0.1f;
        }
    }
}

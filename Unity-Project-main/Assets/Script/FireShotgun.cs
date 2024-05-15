using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShotgun : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePos;
    public int bulletCount = 5; // 한 번에 발사할 총알의 수
    public float spreadAngle = 45f; // 총알이 퍼지는 각도
    public bool fireRate; // 총알이 발사 간격 조절

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !fireRate) {
            FireShotgunBullets();
            fireRate = true;
            StartCoroutine(ResetFireRate());
        }
    }

    IEnumerator ResetFireRate()
    {
        yield return new WaitForSeconds(0.7f);
        fireRate = false;
    }

    void FireShotgunBullets()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float bulletAngle = spreadAngle * ((float)i / (bulletCount - 1)) - spreadAngle / 2;
            Quaternion bulletRotation = Quaternion.Euler(FirePos.transform.rotation.eulerAngles + new Vector3(0, bulletAngle, 0));
            Instantiate(Bullet, FirePos.transform.position, bulletRotation);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRifle : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePos;
    // Start is called before the first frame update
    private int Firecnt = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z)) {
            Firecnt++;
            if(Firecnt % 50 == 0)
                Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
        }
    }
}

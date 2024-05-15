using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 3f;
    public float rotationSpeed = 200.0f;
    public GameObject[] weapons;
    public GameObject equipedWeapon;
    public Image[] weaponImages;

    bool sDown1;
    bool sDown2;
    bool sDown3;
        
    // public bool[] hasWeapons;

    Vector3 lookDirection;

    // Start is called before the first frame update
    void Awake() {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        GetInput();
        Swap();

        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed).normalized;
        
        if (!(xInput == 0 && zInput == 0)) {
            transform.position += newVelocity * speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, 
                                Quaternion.LookRotation(newVelocity), Time.deltaTime * rotationSpeed);
        }

        playerRigidbody.velocity = newVelocity;
    }

    void GetInput(){
        sDown1 = Input.GetButtonDown("Swap1");
        sDown2 = Input.GetButtonDown("Swap2");
        sDown3 = Input.GetButtonDown("Swap3");
    }

    void Swap() {
        int weaponIndex = -1;
        if(sDown1) weaponIndex = 0;
        if(sDown2) weaponIndex = 1;
        if(sDown3) weaponIndex = 2;

        if (sDown1 || sDown2 || sDown3) {
            if(equipedWeapon != null)
                equipedWeapon.SetActive(false);
                
            equipedWeapon = weapons[weaponIndex];
            weapons[weaponIndex].SetActive(true);

            // 무기 이미지 업데이트
            for (int i = 0; i < weaponImages.Length; i++) {
                if (i == weaponIndex) {
                    weaponImages[i].color = Color.white; // 선택된 무기 이미지를 밝게
                    weaponImages[i].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f); // 선택된 무기 이미지를 크게
                } else {
                    weaponImages[i].color = Color.gray; // 선택되지 않은 무기 이미지를 흐리게
                    weaponImages[i].transform.localScale = Vector3.one; // 선택되지 않은 무기 이미지를 원래 크기로
                }
            }
        }
    }
}

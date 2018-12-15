using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{

    [SerializeField] Camera camera;
    public float damage=10;

    PlayerHealth playerhealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit raycastHit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out raycastHit))
        {
            Debug.Log(raycastHit.transform.name);
            if (raycastHit.transform.name == "Wood")
            {
                Debug.Log("Hit Wood");
            }

            playerhealth = raycastHit.transform.GetComponent<PlayerHealth>();

            if (playerhealth != null)
            {
                playerhealth.takeDamage(damage);
            }

        }
    }
}

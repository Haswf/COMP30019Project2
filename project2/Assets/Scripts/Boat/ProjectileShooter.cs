using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{

    public GameObject prefab;
    public GameObject barrel;
    public GameObject aimingObject;
    public int speed;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(prefab);
            projectile.transform.position = transform.position + new Vector3(0, 0, 0);
            projectile.transform.eulerAngles = transform.eulerAngles + new Vector3(0, 90, 0);
            Vector3 aimingDirection = (aimingObject.transform.position - barrel.transform.position).normalized + new Vector3(0, 0.5f, 0);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = aimingDirection * speed;
        }
    }
}

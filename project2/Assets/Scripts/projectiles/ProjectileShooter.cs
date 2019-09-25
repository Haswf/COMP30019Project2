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
    void Start()
    {
        prefab = Resources.Load("Projectile") as GameObject;


    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(prefab) as GameObject;
            projectile.transform.position = transform.position;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            Vector3 aimingDirection = (aimingObject.transform.position - barrel.transform.position).normalized;
            rb.velocity = aimingDirection * speed;
        }
    }
}

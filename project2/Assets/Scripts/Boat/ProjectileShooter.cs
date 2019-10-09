using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{

    public GameObject prefab;
    public Barrel[] barrels;
    public GameObject aimingObject;
    public float time;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        for(int i =0;i < barrels.Length; i++)
        {
            Vector3 Vo = CalculateVeolocity(aimingObject.transform.position, barrels[i].barrel.transform.position, time);
            if (Input.GetMouseButtonDown(0))
            {
                GameObject projectile = Instantiate(prefab);
                ShellController sc = projectile.GetComponent<ShellController>();
                sc.ShipID = this.GetInstanceID();
                print("Projectile created: " + GetInstanceID());
                projectile.transform.position = transform.position + new Vector3(0, 0, 0);
                projectile.transform.eulerAngles = transform.eulerAngles + new Vector3(0, 90, 0);
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.velocity = Vo;
            }

        }
        //Vector3 Vo = CalculateVeolocity(aimingObject.transform.position, barrel.transform.position, time);
        //if(Input.GetMouseButtonDown(0))
        //{
        //    GameObject projectile = Instantiate(prefab);
        //    projectile.transform.position = transform.position + new Vector3(0, 0, 0);
        //    projectile.transform.eulerAngles = transform.eulerAngles + new Vector3(0, 90, 0);
        //    Rigidbody rb = projectile.GetComponent<Rigidbody>();
        //    rb.velocity = Vo;
        //}
    }
    
    Vector3 CalculateVeolocity(Vector3 target, Vector3 origin, float time)
    {
        //define the distance x and y first
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0;
        
        //create a float the reprensent our distance
        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;

        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }
}

[System.Serializable]
public struct Barrel
{
    public string name;
    public GameObject barrel;
    public bool isFront;
}
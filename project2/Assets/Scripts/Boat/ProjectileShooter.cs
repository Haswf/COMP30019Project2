using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{

    public GameObject shellPrefab;
    public GameObject explosionPrefab;
    public BarrelType[] barrels;
    public GameObject aimingObject;
    private float timeToTarget;
    public float shellSpeed;
    public float loadingTime;
    public float explosionScale = 10;
    public Vector3 InstantiateOffset;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateOffset = new Vector3(0, -0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {    
        for(int i =0;i < barrels.Length; i++) {
            // Unable to shoot if the cannon is loading
            if (barrels[i].loadingTimeLeft > 0)
            {    
                // Reduce loadingTimeLeft
                barrels[i].loadingTimeLeft -= Time.deltaTime;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                FireShell(barrels[i].cannon.transform);
                CreateExplosion(barrels[i].cannon.transform); 
                barrels[i].loadingTimeLeft = loadingTime;
            }
        }
    }

    // Calculate time taken for shell to hit target
    float CalculateFlyingTime(Vector3 barrelPosition, Vector3 targetPosition)
    {
        return new Vector2(barrelPosition.x - targetPosition.x, barrelPosition.z - targetPosition.z).magnitude / shellSpeed;
    }
    
    void FireShell(Transform cannonTransform)
    {    
        Vector3 barrelPosition = cannonTransform.position;
        Vector3 targetPosition = aimingObject.transform.position;
        Vector3 shellVelocity = CalculateVeolocity(targetPosition,
            cannonTransform.transform.position,
            CalculateFlyingTime(barrelPosition, targetPosition));
        GameObject projectile = Instantiate(shellPrefab);
        projectile.transform.SetParent(cannonTransform);
        projectile.transform.localPosition = InstantiateOffset;
        projectile.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
        projectile.GetComponent<ShellController>().shipID = transform.GetInstanceID();
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = shellVelocity;
    }

    void CreateExplosion(Transform cannonTransform)
    {
        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.SetParent(cannonTransform);
        explosion.transform.localScale = new Vector3(explosionScale,explosionScale,explosionScale);
        explosion.transform.localPosition = InstantiateOffset;
    }

    Vector3 CalculateVeolocity(Vector3 target, Vector3 origin, float time)
    {
        //define the distance x and y first
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0;
        
        //create a float the represent our distance
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
public struct BarrelType
{
    public string name;
    public GameObject cannon;
    public float loadingTimeLeft;
}
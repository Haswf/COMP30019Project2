using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGunController : MonoBehaviour
{

    public GameObject shellPrefab;
    public GameObject explosionPrefab;
    public BarrelType[] guns;
    private GameObject _target;
    private HealthManager _healthManager;
    private float shellSpeed = Settings.EnemyShellSpeed;
    private float loadingTime= Settings.EnemyLoadingTime;
    private int spread = Settings.EnemyOffset;
    
    public float explosionScale = 10;
    public Vector3 instantiateOffset;
    private float firingDistance = 2000;
    // Start is called before the first frame update
    public void Start()
    {
        _healthManager = transform.GetComponent<HealthManager>();
        instantiateOffset = new Vector3(0, -0.5f, 0);
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].cannon = guns[i].gun.transform.GetChild(0).gameObject;
            guns[i].loaded = true;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            // Make gun looks at target
            _target = GameObject.Find("Gem_bismack Variant");
            guns[i].gun.transform.LookAt(_target.transform);
            Debug.Log("target.transform = " + _target.transform.position);
            // Rotate gun by 90 degrees with respect to x axis to fix model rotation
            guns[i].gun.transform.rotation *= Quaternion.Euler(-90, 0, 0);
            // update loading time
            guns[i] = UpdateLoadingTime(guns[i]);

            
            float dist = Vector3.Distance(_target.transform.position, transform.position);
            // Shot if the gun has been loaded and left key of mouse was pressed
            if (guns[i].loaded && dist < firingDistance && _healthManager.getIsAlive())
            {
                FireShell(guns[i], _target);
                CreateExplosion(guns[i].cannon.transform);
                // reset loading time
                guns[i].loadingTimeLeft = loadingTime;
            }
        }
    }

    // Calculate time taken for shell to hit target
    private float CalculateFlyingTime(Vector3 gunPosition, Vector3 targetPosition)
    {
        return new Vector2(gunPosition.x - targetPosition.x, gunPosition.z - targetPosition.z).magnitude / shellSpeed;
    }
    
    void FireShell(BarrelType gun, GameObject _target)
    {
        // Position of shooting cannon
        Vector3 cannonPosition = gun.cannon.transform.position;
        // Position of current target

        Vector3 targetPosition = _target.transform.position + new Vector3(0, 5, 0);
        // Add a random offset to target to simulate air drag.
        targetPosition += new Vector3(UnityEngine.Random.Range(-spread, spread), 0, UnityEngine.Random.Range(-spread, spread));

        

        // Create a projectile at the end of cannon
        GameObject shell = Instantiate(shellPrefab);
        shell.GetComponent<ShellController>().damage = Settings.EnemyDamage;
        shell.transform.SetParent(gun.cannon.transform);
        shell.transform.localPosition = instantiateOffset;
        shell.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
        // line up shell with tge cannon
        shell.transform.parent = null;
        // Assign instanceID of shooting boat to shell controller
        shell.GetComponent<ShellController>().shipID = transform.GetInstanceID();
        shell.GetComponent<ShellController>().FiringBoat = this.gameObject;
        // Assign initial velocity of the shell based on target position and calculated flying time
        Rigidbody rb = shell.GetComponent<Rigidbody>();
        rb.velocity = CalculateVelocity(targetPosition,
            cannonPosition,
            CalculateFlyingTime(cannonPosition, targetPosition));
    }

    void CreateExplosion(Transform cannonTransform)
    {
        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.SetParent(cannonTransform);
        explosion.transform.localScale = new Vector3(explosionScale, explosionScale, explosionScale);
        explosion.transform.localPosition = instantiateOffset;
    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        //define the distance x and y first
        Vector3 distance = target - origin;
        Vector3 distanceXz = distance;
        distanceXz.y = 0;

        //create a float the represent our distance
        float sy = distance.y;
        float sxz = distanceXz.magnitude;

        float vxz = sxz / time;
        float vy = sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXz.normalized;
        result *= vxz;
        result.y = vy;

        return result;
    }
    private BarrelType UpdateLoadingTime(BarrelType bal)
    {
        if (bal.loadingTimeLeft > 0)
        {
            bal.loadingTimeLeft -= Time.deltaTime;
            bal.loaded = false;
        }

        else
        {
            bal.loaded = true;
        }

        return bal;
    }
}




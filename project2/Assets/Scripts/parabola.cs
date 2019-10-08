using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class parabola : MonoBehaviour
{    
    public GameObject Prefab;
    public GameObject aimObject;
    public GameObject shootObject;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        void LaunchProjectile()
        {
            Vector3 Vo = CalculateVeolocity(aimObject.transform.position, shootObject.transform.position, 1f);
//        transform.rotation = Quaternion.LookRotation(Vo);

            if (Input.GetMouseButtonDown(0))
            {
                GameObject proj = Instantiate(Prefab);
                proj.transform.position = transform.position + new Vector3(0, 0, 0);
                proj.transform.eulerAngles = transform.eulerAngles + new Vector3(0, 90, 0);
                Rigidbody obj = proj.GetComponent<Rigidbody>(); 
                obj.velocity = Vo;
            }
        }
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


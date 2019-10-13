using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    //radis for searching target
    public float radiusForSearchTarget = 2000.0f;

    // distance to the target
    public float stopDistence = 2000f;

    // angle between the target and the ship itself
    private float stopDegreeMax = 180f;
    private float stopDegreeMiddle = 90f;
    private float stopDegreeMin = 0f;
    // target
    public GameObject target;
    private char inputMovement;
    private char inputRotation;
    AIBoatController aIBoatController;
    // Start is called before the first frame update
    void Start()
    {
        //stopDistence = Vector3.Distance(transform.position, target.transform.position);
        aIBoatController = GetComponent<AIBoatController>();
    }
    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(transform.position, target.transform.position);
        Vector3 tarDir = (target.transform.position - transform.position).normalized;

        bool tarIsLeft = Vector3.Cross(transform.forward, tarDir).y > 0;

        float angle = Vector3.Angle(transform.forward, tarDir);
        if (dis < stopDistence)
        {
            // move to the target
            if(angle > stopDegreeMiddle && angle < stopDegreeMax)
            {
                new WaitForSeconds(2);
                inputMovement = 'W';
                Debug.Log("try this !!!!!!!!!!!");
            }
            else
            {
                inputMovement = 'W';
            }
            
        }
        else
        {
            inputMovement = 'S';
        }
        //rotate_to
        
        //    float y = 0;
        //    if (angle < stopDegreeMax)
        //    {
        //        if (tarIsLeft)
        //        {
        //            y += Time.deltaTime * 10;
        //            //transform.localRotation = Quaternion.Euler(0, y, 0);
        //        }
        //        else
        //        {
        //            y -= Time.deltaTime * 10;
        //            transform.localRotation = Quaternion.Euler(0, y, 0);
        //        }
        //    }
        //    Debug.Log("dis = " + dis + "         input = " + inputMovement + "  angle = " + angle + "   tarIsLeft = " + tarIsLeft);
        //}

       // between these two degrees means that the target is behind the AI boat
            if (angle > stopDegreeMin && angle < stopDegreeMiddle)
        {
            if (tarIsLeft)
            {

                inputRotation = 'A';

            }
            else
            {

                inputRotation = 'D';
                //if (aIBoatController.GetCurrentSpeed() > 0)
                //{
                //    inputMovement = 'S';
                //    Debug.Log("you dumb assssssssss");
                //}
                //else
                //{
                //    inputMovement = 'W';
                //}
            }
            // between these two degrees means that the target is in front of the AI boat
        }
        else if (angle > stopDegreeMiddle && angle < stopDegreeMax)
        {
            if (tarIsLeft)
            {
                Debug.Log("you stupid ass");
                inputRotation = 'A';
            }
            else
            {
                inputRotation = 'D';
            }
        }
        else if (Mathf.Abs(angle - 0f) < 1f)
        {
             aIBoatController.SetWaterJetLocalRotationToZero();
        }
        Debug.Log("dis = " + dis + "         input = " + inputMovement + "  angle = " + angle + "   tarIsLeft = " + tarIsLeft);
        //Debug.Log("angle = "+ angle);
    }

    public char GetInputMovement()
    {
        return inputMovement;
    }
    public char GetInputRotation()
    {
        return inputRotation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    //radis for searching target
    public float radiusForSearchTarget = 10000f;

    // distance to the target

    // angle between the target and the ship itself
    private float stopDegreeMax = 180f;
    private float stopDegreeMiddle = 90f;
    private float stopDegreeMin = 0f;
    private float threshold = 7f;
    // target
    public GameObject target;
    private char inputMovement;
    private char inputRotation;
    private char previousInput = ' ';
    // Start is called before the first frame update
    void Start()
    {
        //stopDistence = Vector3.Distance(transform.position, target.transform.position);

    }
    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(transform.position, target.transform.position);
        Vector3 tarDir = (target.transform.position - transform.position).normalized;

        bool tarIsLeft = Vector3.Cross(transform.forward, tarDir).y < 0;

        float angle = Vector3.Angle(transform.forward, tarDir);
        if (dis < radiusForSearchTarget)
        {
            inputMovement = 'W';
            inputMovement = 'W';
        }
        //rotate_to

        // between these two degrees means that the target is behind the AI boat
        if (tarIsLeft)
        {
            inputRotation = 'A';
            threshold = 2f;
        }
        else
        {
            inputRotation = 'D';
            threshold = 2f;
        }
        if (Mathf.Abs(angle - 0f) < threshold)
        {
            threshold = 7f;
            inputRotation = 'N';
        }

            // between these two degrees means that the target is in front of the AI boat


        Debug.Log("dis = " + dis + "         input = " + inputRotation + "  angle = " + angle + "   tarIsLeft = " + tarIsLeft);
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

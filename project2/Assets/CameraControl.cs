using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera BattleShipCamere;

    public Camera ShellFollowingCamera;

    private ShellFollower _follower;
    // Start is called before the first frame update
    void Start()
    {
        BattleShipCamere.enabled = true;
        ShellFollowingCamera.enabled = false;
        _follower = ShellFollowingCamera.GetComponent<ShellFollower>();
    }

    // Update is called once per frame
    void Update()
    {    
        if (Input.GetKeyDown(KeyCode.F) && _follower.target)
        {
            BattleShipCamere.enabled = !BattleShipCamere.enabled;
            ShellFollowingCamera.enabled = !ShellFollowingCamera.enabled;
        }

        if (_follower.target==null)
        {
            BattleShipCamere.enabled = true;
            ShellFollowingCamera.enabled = false;
        }
    }
}

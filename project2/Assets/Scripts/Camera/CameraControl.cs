using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera BattleShipCamere;

    public Camera ShellFollowingCamera;
    public Camera AimingCamera;
    private ShellFollower _follower;
    private string CurrantCamera;    // Start is called before the first frame update
    void Start()
    {
        CurrantCamera =  "BattleShipCamera";
        BattleShipCamere.enabled = true;
        ShellFollowingCamera.enabled = false;
        AimingCamera.enabled = false;
        _follower = ShellFollowingCamera.GetComponent<ShellFollower>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrantCamera.CompareTo("BattleShipCamera") == 0)
        {
            if (Input.GetKeyDown(KeyCode.F) && _follower.target)
            {
                BattleShipCamere.enabled = !BattleShipCamere.enabled;
                AimingCamera.enabled = false;
                ShellFollowingCamera.enabled = !ShellFollowingCamera.enabled;
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                CurrantCamera = "AimingCamera";
                BattleShipCamere.enabled = false;
                AimingCamera.enabled = true;
                ShellFollowingCamera.enabled = false;
            }
            if (_follower.target == null)
            {
                BattleShipCamere.enabled = true;
                AimingCamera.enabled = false;
                ShellFollowingCamera.enabled = false;
            }
        }
        else if (CurrantCamera.CompareTo("AimingCamera") == 0)
        {
            if (Input.GetKeyDown(KeyCode.F) && _follower.target)
            {
                BattleShipCamere.enabled = false;
                AimingCamera.enabled = !AimingCamera.enabled;
                ShellFollowingCamera.enabled = !ShellFollowingCamera.enabled;
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                CurrantCamera = "BattleShipCamera";
                BattleShipCamere.enabled = true;
                AimingCamera.enabled = false;
                ShellFollowingCamera.enabled = false;
            }
            if (_follower.target == null)
            {
                BattleShipCamere.enabled = false;
                AimingCamera.enabled = true;
                ShellFollowingCamera.enabled = false;
            }
        }
    }
}

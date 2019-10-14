using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{    
    public Camera BattleShipCamera;
    public Camera ShellFollowingCamera;
    public Camera AimingCamera;
    public GameObject playerBoat;

    private ShellFollower _follower;
    private BarrelType[] _guns;
    private int _gunIndex;

    private GameObject _target;
    // Start is called before the first frame update
    void Start()
    {    
        SwitchToBattleshipCamera();
        _target = playerBoat.transform.Find("Target").gameObject;
        _guns = playerBoat.GetComponent<GunController>().guns;
        _follower = ShellFollowingCamera.GetComponent<ShellFollower>();
        AimingCamera.transform.position = _guns[_gunIndex].gun.transform.position + new Vector3(0, 5, 0);
        //AimingCamera.transform.SetParent(_guns[gunIndex].gun.transform);
    }

    public void SwitchToAimingCamera()
    {
        AimingCamera.enabled = true;
        BattleShipCamera.enabled = false;
        ShellFollowingCamera.enabled = false;
    }

    public void SwitchToBattleshipCamera()
    {
        BattleShipCamera.enabled = true;
        AimingCamera.enabled = false;
        ShellFollowingCamera.enabled = false;
    }

    public void SwitchToFollowingCamera()
    {
        ShellFollowingCamera.enabled = true;
        BattleShipCamera.enabled = false;
        AimingCamera.enabled = false;
    }

    public void SwitchBetweenGuns()
    {
        AimingCamera.transform.parent = null;
        _gunIndex++;
        if (_gunIndex >= _guns.Length)
        {
            _gunIndex = 0;
        }
        AimingCamera.transform.position = _guns[_gunIndex].gun.transform.position + new Vector3(0, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {    
        AimingCamera.transform.LookAt(_target.transform);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SwitchToBattleshipCamera();
        }

        else if (Input.GetKeyDown(KeyCode.X) && _follower.target)
        {
            SwitchToFollowingCamera();
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchToAimingCamera();
        }

        if (AimingCamera.enabled)
        {    
            // update the position of camera if the ship is moving
            AimingCamera.transform.position = _guns[_gunIndex].gun.transform.position + new Vector3(0, 5, 0);
            if (Input.GetKeyDown(KeyCode.C))
            {
                SwitchBetweenGuns();
            }
        }
    }
}

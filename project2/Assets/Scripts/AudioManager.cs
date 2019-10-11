using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip generalQuarter;
    public AudioClip[] engineSounds; 
    // Start is called before the first frame update
    private BoatController boatController;
    private AudioSource _audioData;
    void Start()
    {
        boatController = GetComponent<BoatController>();
        _audioData = GetComponent<AudioSource>();
        _audioData.clip = engineSounds[1];
        _audioData.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //ChangeEngineSound();
    }

    void ChangeEngineSound()
    {
        if (boatController.CurrentSpeed < boatController.maxPower * 1/3)
        {
            _audioData.Stop();
            _audioData.clip = engineSounds[0];
            _audioData.Play();
        }
        else if (boatController.CurrentSpeed > boatController.maxPower * 1 / 3)
        {
            _audioData.clip = engineSounds[1];
        }
        else if (boatController.CurrentSpeed > boatController.maxPower * 2 / 3)
        {
            _audioData.clip = engineSounds[2];
        }
    }
}

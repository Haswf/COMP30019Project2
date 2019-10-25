using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Settings : MonoBehaviour
{
    // Volume represent as a percentage.
    public static float Volume = 1;
    public static int Time = 1;
    public static int IslandCount= 5;
    // 0 for noon
    // 1 for sunset
    
    // Player settings
    public static int PlayerOffset = 100;
    public static int PlayerLoadingTime = 10;
    public static int PlayerDamage = 1000;
    public static int PlayerShellSpeed = 1000;
    public static int PlayerMaxPower = 100000;
    public static int PlayerPowerFactor = 20000;
    public static int PlayerMaxSpeed = 30;
    public static int PlayerMaxHealth = 20000;

    // Enemy Settings
    public static int EnemyCount = 0;
    public static int EnemyOffset = 100;
    public static int EnemyLoadingTime = 10;
    public static int EnemyDamage = 1000;
    public static int EnemyShellSpeed = 1000;
    public static int EnemyMaxPower = 100000;
    public static int EnemyPowerFactor = 20000;
    public static int EnemyMaxSpeed = 30;
}

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
    public static float PlayerLoadingTime = 5f;
    public static int PlayerDamage = 1000;
    public static int PlayerShellSpeed = 1000;
    public static int PlayerMaxPower = 50000;
    public static int PlayerPowerFactor = 1000;
    public static int PlayerMaxSpeed = 50;
    public static int PlayerMaxHealth = 40000;

    // Enemy Settings
    public static int EnemyCount = 0;
    public static int EnemyOffset = 100;
    public static float EnemyLoadingTime = 5f;    
    public static int EnemyDamage = 1000;
    public static int EnemyShellSpeed = 1000;
    public static int EnemyMaxPower = 100000;
    public static int EnemyPowerFactor = 20000;
    public static int EnemyMaxSpeed = 20;

    public static int totalEnemy = 2;
}

using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour
{
    public int health;
    public float currentFuel, maxFuel, fuelEfficiency;

    void Start()
    {
        health = 100;
        maxFuel = 200;
        currentFuel = maxFuel;

        //fuel units per step
        fuelEfficiency = 75;
    }

    void ResetStats()
    {
        currentFuel = maxFuel;
    }

}
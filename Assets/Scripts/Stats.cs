using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static int lives;
    public int startLives = 3;

    public static int pumkins;
    public int numberOfPumkins = 10;

    public static int kills;
    public int startKills = 0;

    public static int pum;

    // Start is called before the first frame update
    void Start()
    {
        lives = startLives;
        pumkins = numberOfPumkins;
        kills = startKills;

        pum = numberOfPumkins;
    }
}

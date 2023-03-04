using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helth : MonoBehaviour
{
    [SerializeField] public GameObject Heart1, Heart2, Heart3;

    // Start is called before the first frame update
    void Start()
    {
        Heart1.gameObject.SetActive(false);
        Heart2.gameObject.SetActive(false);
        Heart3.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Stats.lives > 3)
            Stats.lives = 3;

        switch (Stats.lives)
        {
            case 3:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                break;

            case 2:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(false);
                break;

            case 1:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                break;
    }
    }
}

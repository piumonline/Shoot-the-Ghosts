using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{

    [SerializeField]public Text livesText;


    void Update()
    {
        livesText.text = Stats.lives.ToString() + "/3";
    }
}

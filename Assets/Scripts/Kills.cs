using UnityEngine;
using UnityEngine.UI;

public class Kills : MonoBehaviour
{

    [SerializeField]
    public Text killsText;


    void Update()
    {
        killsText.text = Stats.kills.ToString() + " KILLS";
    }
}
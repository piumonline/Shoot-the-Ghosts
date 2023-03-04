using UnityEngine;
using UnityEngine.UI;

public class Pumkins : MonoBehaviour
{

    [SerializeField]
    public Text pumkinsText;


    void Update()
    {
        pumkinsText.text = Stats.pumkins.ToString() +"/"+Stats.pum;
    }
}

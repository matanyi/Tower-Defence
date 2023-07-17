using UnityEngine;
using UnityEngine.UI;

public class ManaCounter : MonoBehaviour
{
    public Text Mana;

    void Update()
    {
        Mana.text = "Mana: " + MageManager.mage_mana;
    }
}
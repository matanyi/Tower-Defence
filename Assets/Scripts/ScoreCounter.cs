using UnityEngine;
using UnityEngine.UI;

public class clicker : MonoBehaviour
{
    public Text textNum;
    public int num = 0;

    public void addNum(int rate)
    {
        num += rate; 
        textNum.text = "Score: " + num.ToString();
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionHandler : MonoBehaviour
{
    public void ChangeScene(int sceneid)
    { 
        SceneManager.LoadScene(sceneid);
    }
}
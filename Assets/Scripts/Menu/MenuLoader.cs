using UnityEngine;

public class MenuLoader : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneResetter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reloads the currently active scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

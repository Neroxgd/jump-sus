using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Solo()
    {
        SceneManager.LoadScene("SampleSceneSolo");
    }


    public void Multi()
    {
        SceneManager.LoadScene("Loading");
    }

    public void QuitMenu()
    {
        Application.Quit();
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Interface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI deaths;
    [SerializeField] private Image jump_barre;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject panel;
    private int nb_death = 0;

    public void CompterDeath()
    {
        nb_death++;
        deaths.text = "deaths: " + nb_death;
    }

    public void jumpBarre(float t)
    {
        jump_barre.fillAmount = Mathf.Lerp(0, 1, t);
    }

    public void QuitMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Respawn()
    {
        playerController.goToSPawn(true);
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            Cursor.lockState = CursorLockMode.None;
            panel.SetActive(true);
            return;
        }
        Cursor.lockState = CursorLockMode.Locked;
        panel.SetActive(false);
    }
}

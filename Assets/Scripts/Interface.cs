using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Interface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI deaths;
    [SerializeField] private TextMeshProUGUI _TimerText;
    [SerializeField] private Image jump_barre;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject panelScore;
    [SerializeField] private TextMeshProUGUI[] FinalScores;
    [SerializeField] private Timer timer;
    private int nb_death = 0;

    public void CompterDeath()
    {
        nb_death++;
        deaths.text = "Deaths: " + nb_death;
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
        AfficheTimer();
        if (timer.IsFinished)
            panelScore.SetActive(true);
        else
            panelScore.SetActive(false);

        if (Keyboard.current.escapeKey.isPressed)
        {
            panelScore.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            panel.SetActive(true);
            return;
        }
        Cursor.lockState = CursorLockMode.Locked;
        panel.SetActive(false);
    }

    public void AfficheTimer()
    {
        _TimerText.text = "Timer: " + timer.ElapsedTime.ToString("F2") + "s";
    }

    public void AfficheFinalScore()
    {
        FinalScores[0].text = "Deaths: " + nb_death.ToString();
        FinalScores[1].text = "Timer: " + timer.ElapsedTime.ToString("F2") + "s";
    }
}

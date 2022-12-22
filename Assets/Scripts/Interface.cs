using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI deaths;
    [SerializeField] private Image jump_barre;
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
    void Update()
    {
        
    }
}

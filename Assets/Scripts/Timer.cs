using UnityEngine;

public class Timer : MonoBehaviour
{
    private float elapsedTime = 0.00f;
    public float ElapsedTime { get { return elapsedTime; } }
    private bool isFinished = false;
    public bool IsFinished { get { return isFinished; } set { isFinished = value; } }

    void Update()
    {
        if (!isFinished)
            elapsedTime += Time.deltaTime;
    }
}

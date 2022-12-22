using UnityEngine;

//UI look player
public class LookPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    void Update()
    {
        transform.LookAt(player);
    }
}


using UnityEngine;

public class HealthTesting : MonoBehaviour
{
    [SerializeField] private MonoBehaviour health;

    private IHealth _health;

    private void Awake()
    {
        _health = health.GetComponent<IHealth>();
        _health.Heal(120);
    }
}
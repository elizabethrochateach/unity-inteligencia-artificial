using System.Collections;
using UnityEngine;

public class ZombieStrategy : MonoBehaviour
{
    [SerializeField] private float time;

    public static ZombieStrategy Instance
    {
        get; private set;
    }

    private Transform _player;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public Vector3 GetPlayerPosition()
    {
        if (_player == null)
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        return _player.position;
    }

    public float GetTime()
    {
        return time;
    }
}
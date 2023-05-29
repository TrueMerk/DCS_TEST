using System;
using System.Collections;
using System.Collections.Generic;
using System.Pool;
using Components;
using Entity.Player;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private int _poolCount = 2;
    [SerializeField] private bool _autoExpand = true;
    [SerializeField] private Health _enemy;
    [SerializeField] private int _spawnRate;
    private Pool <Health> _pool;
    private Player _player;
    
    public List<Health> EnemyList = new List<Health>();
    public bool EnemyExist;
    public Camera playerCamera;
    public float spawnRadius = 10f;

    private void Awake()
    {
        ServiceLocator.Instance.RegisterService(this);
    }

    private void Start()
    {
        _player = ServiceLocator.Instance.GetService<Player>();
        _pool = new Pool <Health> (_enemy, _poolCount, transform)
        {
            AutoExpand = _autoExpand
        };
        StartCoroutine(SpawnEnemyCoroutine(_spawnRate));
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.DeregisterService<EnemyPool>();
    }

    private void CreateEnemy()
    {
        var playerViewportPos = playerCamera.WorldToViewportPoint(transform.position);
        var minViewportPos = new Vector3(0f, 0f, playerViewportPos.z);
        var maxViewportPos = new Vector3(1f, 1f, playerViewportPos.z);
        var minWorldPos = playerCamera.ViewportToWorldPoint(minViewportPos);
        var maxWorldPos = playerCamera.ViewportToWorldPoint(maxViewportPos);
        
        var spawnPosition = GetRandomPositionOutsideViewport(minWorldPos, maxWorldPos);
        
        var rPosition = spawnPosition;
        var enemy = _pool.GetFreeElement();
        enemy.transform.position = rPosition;
        EnemyList.Add(enemy);
        EnemyExist = true;
    }
    
    private Vector3 GetRandomPositionOutsideViewport(Vector3 minWorldPos, Vector3 maxWorldPos)
    {
        var randomPosition = Vector3.zero;
        var positionFound = false;
        var maxAttempts = 10;
        var attempts = 0;
        
        while (!positionFound && attempts < maxAttempts)
        {
            
            randomPosition.x = Random.Range(minWorldPos.x - spawnRadius, maxWorldPos.x + spawnRadius);
            randomPosition.y = 1f; 
            randomPosition.z = Random.Range(minWorldPos.z - spawnRadius, maxWorldPos.z + spawnRadius);
            
            if (!IsPositionInsideViewport(randomPosition, minWorldPos, maxWorldPos))
            {
                positionFound = true;
            }

            attempts++;
        }

        return randomPosition;
    }
    
    private bool IsPositionInsideViewport(Vector3 position, Vector3 minWorldPos, Vector3 maxWorldPos)
    {
        return position.x >= minWorldPos.x && position.x <= maxWorldPos.x
                                           && position.y >= minWorldPos.y && position.y <= maxWorldPos.y;
    }
    
    private IEnumerator SpawnEnemyCoroutine(float rate)
    {
        while (true)
        {
            if (EnemyList.Count == 0)
            {
                EnemyList.Clear();
                for (var i = 0; i < _poolCount; i++)
                {
                    CreateEnemy();
                }
                _poolCount++;
            }
            yield return new WaitForSeconds(rate);
        }
    }
}
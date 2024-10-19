using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerInput playerInput;
    private float fireForce = 20f;
    private float fireInterval = 0.1f;
    private float fireTimer;
    [SerializeField] Transform firePoint;
    [SerializeField] private ObjectPool bulletYellowPool; 

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();    
    }

    private void OnEnable()
    {
        GamePlayEvents.PlayerLevelUp.AddListener(OnPlayerLevelUp);
    }

    private void OnDisable()
    {
        GamePlayEvents.PlayerLevelUp.RemoveListener(OnPlayerLevelUp);
    }

    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > fireInterval && Input.GetKey(playerInput.attackKey))
        {
            Fire();
		}
    }

    private void Fire()
    {
        PooledObject aBullet = bulletYellowPool.GetPooledObject();
        aBullet.transform.position = firePoint.position;
        aBullet.transform.rotation = firePoint.rotation;
        aBullet.gameObject.SetActive(true);
        aBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        fireTimer = 0;
    }

    private void OnPlayerLevelUp()
    {
        fireInterval -= 0.05f;
	}
}

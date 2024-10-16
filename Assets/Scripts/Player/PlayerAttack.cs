using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerInput playerInput;
    private float fireForce = 20f;
    [SerializeField] Transform firePoint;
    [SerializeField] private ObjectPool bulletYellowPool; 

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();    
    }

    private void Update()
    {
        if (Input.GetKeyDown(playerInput.attackKey))
        {
            PooledObject aBullet = bulletYellowPool.GetPooledObject();
            aBullet.transform.position = firePoint.position;
            aBullet.transform.rotation = firePoint.rotation;
            aBullet.gameObject.SetActive(true);
            aBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
		}
    }
}

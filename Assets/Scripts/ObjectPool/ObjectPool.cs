using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private float initPoolSize = 30;
    [SerializeField] PooledObject poolObjectPrefab;

    private Stack<PooledObject> stack;

    private void Awake()
    {
        SetupPool();
    }

    private void SetupPool()
    {
        stack = new Stack<PooledObject>();
        PooledObject instance = null;

	    for (int i=0; i<initPoolSize; i++)
        {
            instance = Instantiate(poolObjectPrefab);
            instance.pool = this;
            instance.gameObject.SetActive(false);
            stack.Push(instance);
		}
	}

    public PooledObject GetPooledObject()
    {
	    if (stack.Count == 0)
        {
            PooledObject newObject = Instantiate(poolObjectPrefab);
            newObject.pool = this;
            newObject.gameObject.SetActive(false);
            stack.Push(newObject);
            return newObject;
		}

        PooledObject instance = stack.Pop();
        return instance;
	}

    public void ReturnToPool(PooledObject anObject)
    {
        if (!stack.Contains(anObject))
        {
            stack.Push(anObject);
            anObject.gameObject.SetActive(false);
        }
    }

}

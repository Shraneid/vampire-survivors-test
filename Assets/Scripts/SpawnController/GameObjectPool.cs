using UnityEngine;
using UnityEngine.Pool;

public class GameObjectPool : MonoBehaviour
{
    public Poolable poolablePrefab;

    public int defaultCapacity = 20;
    public int maxPoolSize = 1000;

    public int CurrentNumberOfObjectsInUse {  get; private set; }

    public IObjectPool<GameObject> Pool { get; private set; }

    private void Awake()
    {
        Pool = new ObjectPool<GameObject>(
            CreatePooledItem, 
            OnTakeFromPool, 
            OnReturnedToPool,
            OnDestroyPoolObject, 
            true, 
            defaultCapacity, 
            maxPoolSize
        );
    }

    private GameObject CreatePooledItem()
    {
        GameObject obj = Instantiate(poolablePrefab.gameObject);
        obj.GetComponent<Poolable>().Pool = Pool;

        return obj;
    }

    private void OnTakeFromPool(GameObject obj) {
        obj.SetActive(true);

        CurrentNumberOfObjectsInUse++;
    }

    private void OnReturnedToPool(GameObject obj) { 
        obj.SetActive(false); 
        
        CurrentNumberOfObjectsInUse--;
    }

    private void OnDestroyPoolObject(GameObject obj) => Destroy(obj);
}
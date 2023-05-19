using UnityEngine;

public interface IPoolSpawnable<T>
{
    public bool CanSpawn();
    public void Spawn(Vector3 position, bool isMoving);
    public bool TrySpawn(Vector3 position, bool isMoving, out T entity);
}

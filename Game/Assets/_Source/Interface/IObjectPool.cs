using UnityEngine;

namespace Interface
{
    public interface IObjectPool
    {
        void ObjectMoving();

        void AddObject(GameObject bullet);
    }
}
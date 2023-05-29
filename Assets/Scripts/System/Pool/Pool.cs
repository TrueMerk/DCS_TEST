using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace System.Pool
{
    public class Pool<T> : IEnumerable where T: MonoBehaviour
    {
        private T _objectPrefab;
        public bool AutoExpand = true;
        private Transform _container;

        private List<T> _pool;

        public Pool(T objectPrefab, int count)
        {
            _objectPrefab = objectPrefab;
            _container = null;
            CreatePool(count);
        }

        public Pool(T objectPrefab, int count, Transform container)
        {
            _objectPrefab = objectPrefab;
            _container = container;
      
            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            _pool = new List<T>();

            for (var i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = UnityEngine.Object.Instantiate(_objectPrefab, _container.transform.position,_container.transform.rotation);
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);
            return createdObject;
        }

        private bool HasFreeElement(out T element)
        {
            foreach (var mono in _pool.Where(mono => !mono.gameObject.activeInHierarchy))
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
            element = null;
            return false;
        }

        public T GetFreeElement()
        {
            if (this.HasFreeElement(out var element))
                return element;
            if (this.AutoExpand)
                return this.CreateObject(true);

            throw new Exception("No free GameObjects in pool");
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
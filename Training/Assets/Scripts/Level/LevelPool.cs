using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class LevelPool
    {
        private Transform _container;
        private List<LevelPart> _pool;
        private GameObject _baseLevelPartPrefab;

        public LevelPool(int poolSize, GameObject baseLevelPartPrefab, Transform container)
        {
            _container = container;
            _baseLevelPartPrefab = baseLevelPartPrefab;
            CreatePool(poolSize);
        }

        public int Lenght => _pool.Count;

        public LevelPart GetFreeElement()
        {
            if (HasFreeElement(out LevelPart element))
                return element;
            return null;
        }

        private void CreatePool(int count)
        {
            _pool = new List<LevelPart>();

            for (int i = 0; i < count; i++)
                CreateObject();
        }

        private LevelPart CreateObject(bool isActiveByDefault = false)
        {
            GameObject levelPart = Object.Instantiate(_baseLevelPartPrefab, _container.position, Quaternion.identity);
            _baseLevelPartPrefab.SetActive(isActiveByDefault);
            _pool.Add(levelPart.GetComponent<LevelPart>());
            return _pool[_pool.Count - 1];
        }

        private bool HasFreeElement(out LevelPart element)
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].gameObject.activeInHierarchy)
                {
                    element = _pool[i];
                    _pool[i].transform.position = _container.position;
                    _pool[i].transform.rotation = _container.rotation;
                    _pool[i].gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }
    }
}
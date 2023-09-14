using System;
using UnityEngine;

namespace Level
{
    [Serializable]
    [CreateAssetMenu(fileName = "LevelData", menuName = "SO/NewLevelData")]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private GameObject baseLevelPartPrefab;
        [SerializeField] private int poolSize;

        public GameObject BaseLevelPartPrefab => baseLevelPartPrefab;
        public int PoolSize => poolSize;
    }
}
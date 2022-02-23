using UnityEngine;

namespace SpaceShooter
{
    [System.Serializable]
    public class Item
    {
        public GameObject prefab;
        public int size;
        public bool expandable;
    }
}
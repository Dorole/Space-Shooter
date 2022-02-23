using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Pool : MonoBehaviour
    {
        #region Singleton
        public static Pool instance;
        private void Awake()
        {
            instance = this;
        }
        #endregion

        public List<Item> items;
        [HideInInspector]
        public List<GameObject> pooledItems = new List<GameObject>();

        private void Start()
        {
            foreach (var item in items)
            {
                for (int i = 0; i < item.size; i++)
                {
                    GameObject o = Instantiate(item.prefab);
                    o.transform.parent = transform;
                    o.SetActive(false);
                    pooledItems.Add(o);
                }
            }
        }

        public GameObject GetObjectFromPool(string tag)
        {
            for (int i = 0; i < pooledItems.Count; i++)
            {
                if (!pooledItems[i].activeInHierarchy && pooledItems[i].tag == tag)
                    return pooledItems[i];
            }

            return null;
        }

    }
}
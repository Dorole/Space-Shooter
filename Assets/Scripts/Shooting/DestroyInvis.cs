using UnityEngine;

namespace SpaceShooter
{
    public class DestroyInvis : MonoBehaviour
    {
        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }
    }
}
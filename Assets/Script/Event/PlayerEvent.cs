using UnityEngine;

namespace Script
{
    public class PlayerEvent : MonoBehaviour
    {
        public delegate void PlayerDie();

        public static event PlayerDie DieEvents;

        public static void Die()
        {
            if (DieEvents != null)
            {
                DieEvents();
            }
        }
    }
}
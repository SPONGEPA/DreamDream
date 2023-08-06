using System;
using UnityEngine;

namespace Script
{
    public class NUCFireEvent : MonoBehaviour
    {
        public delegate void FireAction();

        public static event FireAction FireEvents;

        public static void Fire()
        {
            if (FireEvents != null)
            {
                FireEvents();
            }
        }
    }
}
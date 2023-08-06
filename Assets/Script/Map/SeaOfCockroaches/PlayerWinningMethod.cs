using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Map
{
    public class PlayerWinningMethod : MonoBehaviour
    {
        private List<Cockroach> cockroachesList = new List<Cockroach>();
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col)
            {
                throw new NotImplementedException();
            }
        }
    }
}
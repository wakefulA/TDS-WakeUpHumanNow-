using TDS.Game.Player;
using TDS.Game.Zombie;
using UnityEngine;

namespace TDS.Game.Objects
{
    public class Medicine : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                PlayerHealth playerHealth = col.gameObject.GetComponentInParent<PlayerHealth>();
                playerHealth.ApplyHeal(1);
                Destroy(gameObject);
            }
        }
    }
}
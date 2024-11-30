using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBubble : MonoBehaviour
{
    [SerializeField] Rigidbody selfRb;

    [SerializeField] int oxygenLevelUp = 5;

    private void Start()
    {
        selfRb.AddForce(Vector3.up * 0.1f,ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player playerScript = collision.gameObject.GetComponent<Player>();

            if (playerScript.GetCurrentOxygenLevel() > playerScript.GetMaxParameters()[1] - oxygenLevelUp)
            {
                playerScript.SetCurrentOxygenLevel(playerScript.GetMaxParameters()[1]);
            }
            else
            {
                playerScript.SetCurrentOxygenLevel(playerScript.GetCurrentOxygenLevel() + oxygenLevelUp);
            }
        }

        Destroy(transform.gameObject);
    }
}

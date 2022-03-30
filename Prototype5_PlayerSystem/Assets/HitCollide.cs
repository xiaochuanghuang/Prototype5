
using UnityEngine;

public class HitCollide : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Rock")
        {
            collision.collider.gameObject.SetActive(false);

        }
    }
}

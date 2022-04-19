
using UnityEngine;

public class HitCollide : MonoBehaviour
{
    public Move character;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Players")
        {
 
            character.playerHealth -= 5f;
            this.gameObject.SetActive(false);

        }
    }
}

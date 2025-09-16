using UnityEngine;

public class HelicoDetecteCollisions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider infosCollider)
    {
        if(infosCollider.gameObject.tag == "Ennemi")
        {
            //infosCollider.gameObject.setActive = false;
        }
    }
}

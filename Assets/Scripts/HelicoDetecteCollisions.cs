using UnityEngine;

public class HelicoDetecteCollisions : MonoBehaviour
{
    //DÉCLARATION DE VARIABLES

    private AudioSource audioSource;//Son

    [SerializeField] AudioClip sonCollecte;//Son collecte

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //COLLISION
    void OnTriggerEnter(Collider infosCollider)
    {
        if(infosCollider.gameObject.tag == "bidon")
        {
            //Debug.Log("Détruire objet");
            Destroy(infosCollider.gameObject);

            //Son collecte
            audioSource.PlayOneShot(sonCollecte);
        }
    }
}

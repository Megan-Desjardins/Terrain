using UnityEngine;

public class HelicoDetecteCollisions : MonoBehaviour
{
    //DÉCLARATION DE VARIABLES ////////////////////
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

    //COLLISION //////////////////
    void OnTriggerEnter(Collider infosCollider)
    {
        if(infosCollider.gameObject.tag == "bidon")//Détecte collision avec un bidon
        {
            //Debug.Log("Détruire objet");
            Destroy(infosCollider.gameObject);

            //Ajouter de l'essence
            GetComponent<GestionEssence>().quantiteEssenceActuelle = GetComponent<GestionEssence>().quantiteEssenceActuelle += 20f;
            float essenceClamp = Mathf.Clamp(GetComponent<GestionEssence>().quantiteEssenceActuelle, 0f, 100f);
            GetComponent<GestionEssence>().quantiteEssenceActuelle = essenceClamp;

            //Son collecte
            audioSource.PlayOneShot(sonCollecte);
        }

        if(infosCollider.gameObject.tag == "drone")//Détecte collision avec un drone
        {
            //Exploser hélico
            GetComponent<ExplosionHelico>().Explosion();
        }
    }
}

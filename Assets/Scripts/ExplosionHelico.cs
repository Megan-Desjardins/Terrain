using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionHelico : MonoBehaviour
{
    //DÉCLARATION DE VARIABLES
    [SerializeField] GameObject fxExplosion;//fx Explosion

    [SerializeField] AudioClip sonExplosion;//Son explosion

    [SerializeField] GameObject lumiereOrange;//Lumière orange

    [SerializeField] GameObject CameraDistanceFixe;//Caméra fixe


    private AudioSource audioSource;//Son

    private Rigidbody rb;//Physique


    [SerializeField] bool moteurEnMarche;
       
    public GameObject RefHelice;
    //Hélice avant (afin de l'utiliser comme référence pour savoir si le moteur est en marche)



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       audioSource = GetComponent<AudioSource>();
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vérifier si le moteur est allumé (récupéré variable moteurEnMarche)
        moteurEnMarche = RefHelice.GetComponent<MouvementHelices>().moteurEnMarche;
    }

    //COLLISION ///////////////////////
    void OnCollisionEnter(Collision infosCollision)
    {
        if(infosCollision.gameObject.name == "Terrain")
        {
            //Explosion
            Invoke("Explosion", 0f);
        }
    }

    //fx EXPLOSION ///////////////////////
    public void Explosion()//Public pour pouvoir lancer la fontion lorsque le compteur est à 0 à partir du script Compteur
    {
        //Effet d'explosion activé
        fxExplosion.SetActive(true);

        //Son d'exploxion
        //audioSource.PlayOneShot(sonExplosion);

        //Lumière
        lumiereOrange.SetActive(true);

        //Hélico tombe
        moteurEnMarche = false;
        rb.linearDamping = 0.1f;
        rb.angularDamping = 0.5f;
        rb.constraints = RigidbodyConstraints.None;//Enlève toutes les contraintes du rigidbody

        //Activer caméra fixe
        ChangeCamera(CameraDistanceFixe);

        Invoke("Recommencer", 8f);
    }

    //SCÈNES //////////////////
    void Recommencer()
    {
        SceneManager.LoadScene("Exercice");
    }

    //CHANGER DE CAMÉRAS /////////////////
    private void ChangeCamera(GameObject laCamera)
    {
        //GESTION CAMÉRAS
        //Désactiver la caméra
        Camera.main.gameObject.SetActive(false);

        //Activer la caméra sélectionner
        laCamera.SetActive(true);
    }
}

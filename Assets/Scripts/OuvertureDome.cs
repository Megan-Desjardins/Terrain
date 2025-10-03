using UnityEngine;

public class OuvertureDome : MonoBehaviour
{
    //DÉCLARATION DE VARIABLES
    [SerializeField] bool domeOuvert;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        domeOuvert = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Si on appuie sur O ET que le dome n'est pas ouvert
        if (Input.GetKeyDown(KeyCode.O) && domeOuvert == false)
        {
            //Ouvrir le dome
            GetComponent<Animator>().Play("OuvertureDome");
            //Mettre à jour -> le dome est ouvert (attendre fin de l'animation)
            Invoke("MettreJourDomeOuvert", 2f);

        }

        //Si on appuie sur F ET que le dome est ouvert
        if(Input.GetKeyDown(KeyCode.F) && domeOuvert == true)
        {
            //Debug.Log("Fermer dome");
            //Fermer le dome
            GetComponent<Animator>().Play("FermetureDome");
            //Mettre à jour -> le dome est fermer (attendre fin de l'animation)
            Invoke("MettreJourDomeOuvert", 2f);
        }


    }

    //FONCTION JOUER SON DU DOME
    void JouerSonDome()
    {
        Debug.Log("Son du dome");
        GetComponent<AudioSource>().Play();
    }

    //FONCTION METTRE À JOUR ÉTAT DU DOME
    void MettreJourDomeOuvert()
    {
        if(domeOuvert == false)
        {
            domeOuvert = true;
        }
        else
        {
            domeOuvert = false;
        }
    }

    //Seulement quand le moteur est en marche

}

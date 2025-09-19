using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Compteur : MonoBehaviour
{
    //DÉCLARATION VARIABLES /////////////
    public TextMeshProUGUI zoneTexte;//texte à changer

    public int valCompteur = 0;//valeur du compteur (0 au départ)

    public GameObject refHelico;

    [SerializeField] ExplosionHelico refFonctionExplosion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("CalculCompteur", 1, 1); //à chaque seconde appelle Compteur

        refFonctionExplosion = refHelico.GetComponent<ExplosionHelico>();
    }


    //COMPTEUR /////////////
    void CalculCompteur()
    {
        valCompteur -= 1;
        //convertit la valeur en texte et l'affiche
        zoneTexte.text = valCompteur.ToString();

        if(valCompteur <= 0)
        {
            CancelInvoke();//Arrêter tous les invoke

            //Activer explosion
            refFonctionExplosion.Explosion();
        }
    }
}

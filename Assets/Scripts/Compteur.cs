using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Compteur : MonoBehaviour
{
    //DÉCLARATION VARIABLES /////////////
    public TextMeshProUGUI zoneTexte;//texte à changer

    public int valCompteur = 120;//valeur du compteur (120 au départ)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    void Update()
    {

    }

    //COMPTEUR /////////////
    void CalculCompteur()
    {
        //Debug.Log("Diminuer valeur");
        valCompteur -= 1;

        //Convertit la valeur en texte et l'affiche
        zoneTexte.text = valCompteur.ToString();

        if (valCompteur <= 0)//Si compteur = 0
        {
            CancelInvoke();//Arrêter tous les invoke

            //Activer explosion
            GetComponent<ExplosionHelico>().Explosion();
        }
    }

    public void DemarrerCompteur()
    {
        //Affiche valeur initiale (120)
        zoneTexte.text = valCompteur.ToString();

        //Appeler le compteur à chaque sec
        InvokeRepeating("CalculCompteur", 1f, 1f);

    }
}

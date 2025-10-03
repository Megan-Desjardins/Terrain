using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    //DÉCLARATION DE VARIABLES //////////////
    [SerializeField] GameObject helico;

    [SerializeField] GameObject leTitre;

    [SerializeField] GameObject leBouton;

    [SerializeField] GameObject lesTouches;

    [SerializeField] GameObject cameraFPS;

    public TextMeshProUGUI zoneTexte;

    //DÉBUT PARTIE ///////////////////////
    public void GestionDebutPartie()//La fonction doit être publique pour être visible
    {
        helico.SetActive(true);//Activer l'hélico
        ChangeCamera(cameraFPS);//Activer la caméra FPS et désactiver la caméra active (distance fixe)
        zoneTexte.gameObject.SetActive(true);//Activer le txt compteur (gameObject sinon il ne peux pas activer du texte)
        zoneTexte.gameObject.GetComponent<Compteur>().DemarrerCompteur();//Activer le compteur

        leTitre.SetActive(false);// Désactiver le titre
        lesTouches.SetActive(false);//Désactiver les touches
        leBouton.SetActive(false);//Désactiver le bouton
    }
    
    //CHAGER DE CAMÉRAS /////////////////
    private void ChangeCamera(GameObject laCamera)
    {
        //GESTION CAMÉRAS
        //Désactiver la caméra
        Camera.main.gameObject.SetActive(false);

        //Activer la caméra sélectionner
        laCamera.SetActive(true);
    }
    
}

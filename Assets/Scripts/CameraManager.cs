using UnityEngine;

public class CameraManager : MonoBehaviour//Ne jamais voir plusieurs caméras actives en même temps
{
    //DÉCLARATION DE VARIABLES
    [SerializeField] GameObject CameraEnfant;

    [SerializeField] GameObject CameraFixe;

    [SerializeField] GameObject CameraDistanceConstante;

    [SerializeField] GameObject CameraSuiviFluide;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //DÉTECTION DE TOUCHES
        //Détection des touches pour changer la caméra active
        if(Input.GetKeyDown(KeyCode.Alpha1)) ChangeCamera(CameraEnfant);

        if(Input.GetKeyDown(KeyCode.Alpha2)) ChangeCamera(CameraFixe);

        if(Input.GetKeyDown(KeyCode.Alpha3)) ChangeCamera(CameraDistanceConstante);

        if(Input.GetKeyDown(KeyCode.Alpha4)) ChangeCamera(CameraSuiviFluide);

    }

    private void ChangeCamera(GameObject laCamera)
    {
        //GESTION CAMÉRAS
        //Désactiver la caméra
        Camera.main.gameObject.SetActive(false);

        //Activer la caméra sélectionner
        laCamera.SetActive(true);
    }
}

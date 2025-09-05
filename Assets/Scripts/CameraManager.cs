using UnityEngine;

public class CameraManager : MonoBehaviour//Ne jamais voir plusieurs cam�ras actives en m�me temps
{
    //D�CLARATION DE VARIABLES
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
        //D�TECTION DE TOUCHES
        //D�tection des touches pour changer la cam�ra active
        if(Input.GetKeyDown(KeyCode.Alpha1)) ChangeCamera(CameraEnfant);

        if(Input.GetKeyDown(KeyCode.Alpha2)) ChangeCamera(CameraFixe);

        if(Input.GetKeyDown(KeyCode.Alpha3)) ChangeCamera(CameraDistanceConstante);

        if(Input.GetKeyDown(KeyCode.Alpha4)) ChangeCamera(CameraSuiviFluide);

    }

    private void ChangeCamera(GameObject laCamera)
    {
        //GESTION CAM�RAS
        //D�sactiver la cam�ra
        Camera.main.gameObject.SetActive(false);

        //Activer la cam�ra s�lectionner
        laCamera.SetActive(true);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class GestionEssence : MonoBehaviour
{
    //DÉCLARATIONS DE VARIABLES
    [SerializeField] float quantiteEssenceMax;
    public float quantiteEssenceActuelle;
    [SerializeField] float consommationEssence;
    [SerializeField] Image barreEssence;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        quantiteEssenceActuelle = quantiteEssenceMax;
        InvokeRepeating("DiminutionEssence", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //DIMINUER ESSENCE
    public void DiminutionEssence()
    {
        //seulement si le moteur est allumé
        quantiteEssenceActuelle -= consommationEssence;
        barreEssence.fillAmount = quantiteEssenceActuelle / 100f;

        if (quantiteEssenceActuelle <= 0)
        {
            //CancelInvoke("DiminutionEssence");
            //Explosion
        }
    }
}

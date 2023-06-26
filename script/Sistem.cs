using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistem : MonoBehaviour
{
    public static Sistem instance;
    public int ID;
    public GameObject TempatSpawn;
    // public GameObject Gui_Utama;
    public GameObject[] KoleksiBuah;
    public AudioClip[] SuaraBuah;
    AudioSource Suara;

    private void Awake() {
        instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        ID = 0;
        SpawnObject();
        Suara = gameObject.AddComponent<AudioSource>();
        // Gui_Utama.SetActive(false);

        
    }

    // Update is called once per frame
    public void SpawnObject()
    {
       GameObject BendaSebelumnya = GameObject.FindGameObjectWithTag("Buah");
       if(BendaSebelumnya != null) Destroy(BendaSebelumnya);

       GameObject Benda =  Instantiate(KoleksiBuah[ID]);
       Benda.transform.SetParent(TempatSpawn.transform, false);
       Benda.transform.localScale = new Vector3((float)11.2516,(float)11.2516,(float)11.2516);
       Benda.transform.localPosition = new Vector3((float)0,(float)0,(float)0);
       TempatSpawn.GetComponent<Animation>().Play("timbul");

    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GantiBuah(true);
            
            
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GantiBuah(false);

            
        }
        
    }
    public void GantiBuah(bool Kanan){
        if(Kanan){
            if (ID >= KoleksiBuah.Length - 1)
            {
                ID = 0;
                
            }
            else
            {
                ID ++;
                 
            }

        }
        else
        {
            if (ID <=0)
            {
                ID = KoleksiBuah.Length - 1;
                
            }
            else
            {
                ID --;
                 
            }
            
        }
        SpawnObject();
        PanggilSuaraBuah();

    }

    public void PanggilSuaraBuah(){
        Suara.clip = SuaraBuah[ID];
        Suara.Play();
    }
}

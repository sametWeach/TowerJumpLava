using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroller : MonoBehaviour
{
    private Material mat;
    public GameObject Player;
    public float yavasHiz = 10f;
    float chHigh;
    float vHiz = 0f;
    Score sr;
    bool sonuc;
    int toplamSkor = 0;
    public Texture2D textnew;
    public Animator anim;

    void Start()
    {
        mat = GetComponent<Renderer>().material;        
        sr = Score.instance;
        anim = GetComponent<Animator>();
        sonuc = true;

    }


    void Update()
    {
        if (vHiz < Player.transform.position.y)
        {
            vHiz = Player.transform.position.y;
        }

        chHigh = vHiz / yavasHiz;
       
        mat.SetTextureOffset("_MainTex", new Vector2(0, chHigh));

        toplamSkor = (sr.valueX + sr.enemy_score);

        if (toplamSkor > 500 && sonuc == true)
        {
            sonuc = false;
            LoadNextBG();
        }

        void LoadNextBG()
        {
            StartCoroutine(LoadLevel());
        }

        IEnumerator LoadLevel()
        {
            anim.SetBool("start", true);
            yield return new WaitForSeconds(3f);
            mat.SetTexture("_MainTex", textnew);           
        }


    }
}

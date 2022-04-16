using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TeaserDemoScript : MonoBehaviour
{
    [SerializeField] GameObject demoCard;
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] TextMeshProUGUI enemyHealthText1;
    [SerializeField] Image enemyHealthBar1;
    [SerializeField] TextMeshProUGUI enemyHealthText2;
    [SerializeField] Image enemyHealthBar2;
    [SerializeField] ParticleSystem enemyParticle1;
    [SerializeField] ParticleSystem enemyParticle2;
    [SerializeField] ParticleSystem altarParticle;

    private S_Global g_global;

    private void Awake()
    {
        g_global = S_Global.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        demoCard.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            demoCard.SetActive(true);
            altarParticle.Play();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            demoCard.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            g_global.g_enemyState.enemy1.EnemyAttacked(g_global.g_enemyState.enemy1.e_str_enemyType, 5);
            g_global.g_enemyState.enemy2.EnemyAttacked(g_global.g_enemyState.enemy2.e_str_enemyType, 5);
            enemyParticle1.Play();
            enemyParticle2.Play();
            /*
        enemyHealthText1.text = "7/12";
        enemyHealthText2.text = "10/15";
        enemyHealthBar1.fillAmount = 7 / 12;
        enemyHealthBar2.fillAmount = 10 / 15;*/
        }
    }
}

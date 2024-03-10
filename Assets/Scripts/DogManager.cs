using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogManager : MonoBehaviour
{
    [SerializeField] Slider  dogHpBar;
    private int healt = 100;
    
    

    void Start()
    {
        StartCoroutine(DamageOverTime());
    }

    private IEnumerator DamageOverTime()
    {
        while (healt > 0)
        {

            yield return new WaitForSeconds(2);
            healt -= 3;
            dogHpBar.value = healt;

            if(healt <= 0)
            {
                Debug.Log("köpek hakký rahmetine kavuþtu");
                break;
            }

        }
    }

    
}

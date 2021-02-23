using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{
    public Image imageCooldown;
    public float cooldown = 5;
    bool isCooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Dash abillity
            /*isCooldown = true;*/

            //
            isCooldown = true;
            
        }
        if (isCooldown)
        {
            imageCooldown.fillAmount += 1 / cooldown * Time.deltaTime;
            if (imageCooldown.fillAmount >= 1)
            {
                imageCooldown.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
    
}

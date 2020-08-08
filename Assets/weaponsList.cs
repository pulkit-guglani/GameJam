using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponsList : MonoBehaviour
{
    public bool tranquilizer = true;
    public bool magneticGun = true;
    public bool blaster = true;
    public bool booster = true;
    public bool invisible = true;

    public Image tranquilizerImage;
    public Image magneticGunImage;
    public Image blasterImage;
    public Image boosterImage;
    public Image invisibleImage;
   
    
    // Start is called before the first frame update
    void Start()
    {
        tranquilizerImage.color = tranquilizer ? Color.green:Color.red;
       magneticGunImage.color = magneticGun ? Color.green:Color.red;
       blasterImage.color = blaster ? Color.green:Color.red;
        boosterImage.color = booster ? Color.green:Color.red;
        invisibleImage.color = invisible ? Color.green:Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

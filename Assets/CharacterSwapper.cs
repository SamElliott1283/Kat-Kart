using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwapper : MonoBehaviour
{
    public GameObject player;

    public Dropdown characterDropdown, kartDropdown, hairDropdown, skinDropdown;

    public GameObject catCharacter, boyCharacter, girlCharacter, catKart, boyKart, girlKart;
    private int charInUse = 0;

    private GameObject hairDropdownParent, skinDropdownParent;

    public Material boyHair, boyFace, girlHair, girlFace;

    public Texture boySkin1, boySkin2, boySkin3, girlSkin1, girlSkin2, girlSkin3,
                   boyHair1, boyHair2, boyHair3, girlHair1, girlHair2, girlHair3;

    // Start is called before the first frame update
    void Start()
    {
        AnimController.characterAnim = player.transform.Find("Char").gameObject.GetComponent<Animator>();
        AnimController.kartAnim = player.transform.Find("Kart").gameObject.GetComponent<Animator>();
        AnimController.ready = true;

        characterDropdown.onValueChanged.AddListener(delegate { CharacterChanged(); });
        kartDropdown.onValueChanged.AddListener(delegate { KartChanged(); });

        hairDropdown.onValueChanged.AddListener(delegate { HairChanged(); });
        skinDropdown.onValueChanged.AddListener(delegate { SkinChanged(); });

        hairDropdownParent = hairDropdown.transform.parent.gameObject;
        skinDropdownParent = skinDropdown.transform.parent.gameObject;

        hairDropdownParent.SetActive(false);
        skinDropdownParent.SetActive(false);

        CharacterRotator.objectToRotate = player.transform;
    }

    void CreateNewCharacter(GameObject character, Vector3 position, Quaternion rotation)
    {
        GameObject newChar = Instantiate(character, position, rotation);

        newChar.SetActive(true);
        newChar.name = "Char";
        newChar.transform.parent = player.transform;

        if(hairDropdownParent.activeInHierarchy == false)
        {
            hairDropdownParent.SetActive(true);
        }
        if (skinDropdownParent.activeInHierarchy == false)
        {
            skinDropdownParent.SetActive(true);
        }

        hairDropdown.value = 0;
        skinDropdown.value = 0;

        AnimController.characterAnim = newChar.GetComponent<Animator>();
    }

    void CharacterChanged()
    {
        GameObject previousChar = player.transform.Find("Char").gameObject;
        Vector3 previousPosition = previousChar.transform.position;
        Quaternion previousRotation = previousChar.transform.rotation;

        Destroy(previousChar);

        switch (characterDropdown.value)
        {
            case 0:
                //Cat Character
                CreateNewCharacter(catCharacter, previousPosition, previousRotation);
                charInUse = 0;
                break;
            case 1:
                //Boy Character
                CreateNewCharacter(boyCharacter, previousPosition, previousRotation);
                charInUse = 1;
                break;
            case 2:
                //Girl Character
                CreateNewCharacter(girlCharacter, previousPosition, previousRotation);
                charInUse = 2;
                break;
        }
        CharacterRotator.objectToRotate = player.transform;
    }
    void CreateNewKart(GameObject kart, Vector3 position, Quaternion rotation)
    {
        GameObject newKart = Instantiate(kart, position, rotation);

        newKart.SetActive(true);
        newKart.name = "kart";
        newKart.transform.parent = player.transform;

        hairDropdown.value = 0;
        skinDropdown.value = 0;

        AnimController.kartAnim = newKart.GetComponent<Animator>();
    }

    void KartChanged()
    {
        GameObject previousKart = player.transform.Find("Kart").gameObject;
        Vector3 previousPosition = previousKart.transform.position;
        Quaternion previousRotation = previousKart.transform.rotation;

        Destroy(previousKart);

        switch (kartDropdown.value)
        {
            case 0:
                //Cat Kart
                CreateNewKart(catKart, previousPosition, previousRotation);
                break;
            case 1:
                //Boy Kart
                CreateNewKart(boyKart, previousPosition, previousRotation);
                break;
            case 2:
                //Girl Kart
                CreateNewKart(girlKart, previousPosition, previousRotation);
                break;
        }
        CharacterRotator.objectToRotate = player.transform;
    }

    void HairChanged()
    {
        GameObject currentAvatar = player.transform.Find("Char").Find("Avatar").gameObject;

        Material currentMaterial;
        Material currentMaterial2;

        bool isGirl = false;
        if (charInUse == 2)
        {
            isGirl = true;
        }

        if (isGirl)
        {
            currentMaterial = currentAvatar.GetComponent<Renderer>().materials[2];
            currentMaterial2 = currentAvatar.GetComponent<Renderer>().materials[2];
        }
        else
        {
            currentMaterial = currentAvatar.GetComponent<Renderer>().materials[0];
            currentMaterial2 = currentAvatar.GetComponent<Renderer>().materials[1];
        }

        switch (hairDropdown.value)
        {
            case 0:
                if (isGirl)
                {
                    currentMaterial.SetTexture("_MainTex", girlHair1);
                }
                else
                {
                    currentMaterial.SetTexture("_MainTex", boyHair1);
                    currentMaterial2.SetTexture("_MainTex", boyHair1);
                }
                break;
            case 1:
                if (isGirl)
                {
                    currentMaterial.SetTexture("_MainTex", girlHair2);
                }
                else
                {
                    currentMaterial.SetTexture("_MainTex", boyHair2);
                    currentMaterial2.SetTexture("_MainTex", boyHair2);
                }
                break;
            case 2:
                if (isGirl)
                {
                    currentMaterial.SetTexture("_MainTex", girlHair3);
                }
                else
                {
                    currentMaterial.SetTexture("_MainTex", boyHair3);
                    currentMaterial2.SetTexture("_MainTex", boyHair3);
                }
                break;

        }
    }

    void SkinChanged()
    {
        GameObject currentAvatar = player.transform.Find("Char").Find("Avatar").gameObject;

        Material currentMaterial;
        

        bool isGirl = false;
        if (charInUse == 2)
        {
            isGirl = true;
        }

        if (isGirl)
        {
            currentMaterial = currentAvatar.GetComponent<Renderer>().materials[0];
            
        }
        else
        {
            currentMaterial = currentAvatar.GetComponent<Renderer>().materials[2];
            
        }

        switch (skinDropdown.value)
        {
            case 0:
                if (isGirl)
                {
                    currentMaterial.SetTexture("_MainTex", girlSkin1);
                }
                else
                {
                    currentMaterial.SetTexture("_MainTex", boySkin1);
                    
                }
                break;
            case 1:
                if (isGirl)
                {
                    currentMaterial.SetTexture("_MainTex", girlSkin2);
                }
                else
                {
                    currentMaterial.SetTexture("_MainTex", boySkin2);
                    
                }
                break;
            case 2:
                if (isGirl)
                {
                    currentMaterial.SetTexture("_MainTex", girlSkin3);
                }
                else
                {
                    currentMaterial.SetTexture("_MainTex", boySkin3);
                    
                }
                break;

        }
    }
}

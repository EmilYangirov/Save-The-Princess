using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : LevelSystem
{
    public Transform bone;
    private Character character;
    
    
    private void Start()
    {
        Transform parent = transform.parent;
        character = parent.gameObject.GetComponent<Character>();
        ChooseWeapon(level);
    }

    private void Update()
    {
        BindPosition();
    }

    private void BindPosition()
    {
        transform.position = bone.position;
        transform.rotation = bone.rotation;
    }

    private void ChooseWeapon(int weaponNum)
    {
        int number = 0;
        foreach (Transform child in transform)
        {
            if (number == level)
                child.gameObject.SetActive(true);
            else
                child.gameObject.SetActive(false);

            number++;
        }
        SetStats();
    }

    public override void IncreaseLvl()
    {
        level++;
        ChooseWeapon(level);
    }

    public override void SetStats()
    {
        character.damageModifier = level/2;
        character.ModifyCharacterStats();
    }
}

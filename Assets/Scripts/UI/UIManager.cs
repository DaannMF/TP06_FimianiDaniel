using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {

    private void Awake() {
        CharactersEvents.characterDamaged += CreateDamageText;
        CharactersEvents.characterHealed += CreateHealthText;
        CharactersEvents.characterInvincible += CreateInvincibleText;
    }

    private void OnDestroy() {
        CharactersEvents.characterDamaged -= CreateDamageText;
        CharactersEvents.characterHealed -= CreateHealthText;
        CharactersEvents.characterInvincible -= CreateInvincibleText;
    }

    public void CreateDamageText(GameObject character, Int16 damage) {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);
        GameObject damageText = DamageTextPool.SharedInstance.GetPooledObject();
        damageText.transform.position = spawnPosition;
        damageText.GetComponent<TextMeshProUGUI>().text = damage.ToString();
        damageText.SetActive(true);
    }

    public void CreateHealthText(GameObject character, Int16 heal) {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);
        GameObject healText = HealTextPool.SharedInstance.GetPooledObject();
        healText.transform.position = spawnPosition;
        healText.GetComponent<TextMeshProUGUI>().text = heal.ToString();
        healText.SetActive(true);
    }

    public void CreateInvincibleText(GameObject character) {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);
        GameObject invincibleText = InvincibleTextPool.SharedInstance.GetPooledObject();
        invincibleText.transform.position = spawnPosition;
        invincibleText.SetActive(true);
    }
}

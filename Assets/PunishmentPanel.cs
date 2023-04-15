using System;
using System.Collections;
using UnityEngine;

public class PunishmentPanel : MonoBehaviour {

    public void Punish(System.Action action, float punishmentTime) {
        gameObject.SetActive(true);
        StartCoroutine(PunishmentCoroutine(action, punishmentTime));
    }

    IEnumerator PunishmentCoroutine(Action action, float punishmentTime) {
        for (var time = 0f; time < punishmentTime; time += Time.deltaTime) {
            yield return null;
        }
        gameObject.SetActive(false);
        action.Invoke();
    }
}
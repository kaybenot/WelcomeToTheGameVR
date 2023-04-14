using System;
using System.Collections;
using UnityEngine;

public class PunishmentPanel : MonoBehaviour {
    float punishmentTime=3f;
    public void Punish(System.Action action) {
        gameObject.SetActive(true);
        StartCoroutine(PunishmentCoroutine(action));
    }

    IEnumerator PunishmentCoroutine(Action action) {
        for (var time = 0f; time < punishmentTime; time += Time.deltaTime) {
            yield return null;
        }
        gameObject.SetActive(false);
        action.Invoke();
    }
}
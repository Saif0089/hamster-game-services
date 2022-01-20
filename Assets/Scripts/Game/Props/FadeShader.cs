using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeShader : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Material[] materials;

    public bool isTransparent = false;
    private int triggerCount = 0;

    public HiddenShader hiddenShader;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        materials = meshRenderer.materials;
    }
    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null)
        {
            if (CanOpacity(character))
            {
                SetOpacity();
                triggerCount++;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if(character!= null)
        {
            if (!CanOpacity(character)) return;
            triggerCount--;
            if (isTransparent && triggerCount == 0) SetOpaque();

        }

    }

    public virtual void SetOpacity()
    {
        if (materials != null)
        {
            foreach (Material m in materials)
            {
                {
                    Color fadedColor = m.color;
                    fadedColor.a = 0.3f;
                    m.DOColor(fadedColor, 0.5f);
                    isTransparent = true;
                }
            }
        }
    }

    public virtual void SetOpaque()
    {
        if (materials != null)
        {
            foreach (Material m in materials)
            {
                {
                    Color fadedColor = m.color;
                    fadedColor.a = 1;
                    m.DOColor(fadedColor, 0.5f);
                    isTransparent = false;
                }
            }
        }
    }

    private bool CanOpacity(Character character)
    {
        if (character.Team == GameInstance.Instance._GameStatistic.masterTeam) return true;
        return false;
    }
}
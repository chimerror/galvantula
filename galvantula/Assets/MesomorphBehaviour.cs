using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SkinnedMeshRenderer))]
public class MesomorphBehaviour : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float Cowiness = 0.0f;

    private float CurrentCowiness
    {
        get
        {
            return Mathf.Clamp01(_animator.GetFloat("Cowiness"));
        }

        set
        {
            var clampedValue = Mathf.Clamp01(value);
            _animator.SetFloat("Cowiness", clampedValue);
            Cowiness = clampedValue;
        }
    }

    private Animator _animator;
    private SkinnedMeshRenderer _meshRenderer;
    private Material _cowMaterial;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        _cowMaterial = _meshRenderer.materials[1];
        CurrentCowiness = Cowiness;

    }

    private void Update()
    {
        if (CurrentCowiness != Cowiness)
        {
            CurrentCowiness = Cowiness;
        }

        var currentCowColor = _cowMaterial.color;
        currentCowColor.a = Mathf.Clamp01(CurrentCowiness);
        _cowMaterial.color = currentCowColor;
    }

}

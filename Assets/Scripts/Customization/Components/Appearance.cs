using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using static UnityEngine.GraphicsBuffer;

public class Appearance : MonoBehaviour
{
    [Inject]
    private CustomizationData _customizationData;
    private SkinnedMeshRenderer _currentHairSMR;
    private GameObject _currentHairRig;
    private Transform _rootBone;
    private Transform _neckBone;

    private void Start()
    {
        _rootBone = GetComponentInChildren<RootBone>().gameObject.transform;
        _neckBone = GetComponentInChildren<NeckBone>().gameObject.transform;
    }
 
    public void SetHair(int hairID)
    {
        if (_currentHairSMR != null) Destroy(_currentHairSMR.gameObject);
        if (_currentHairSMR != null) Destroy(_currentHairRig);
        _currentHairRig = Instantiate(_customizationData.GetHair(hairID).rootBone, _neckBone);
        //_currentHairSMR =  Instantiate(_customizationData.GetHair(hairID).skinnedMeshRenderer, transform);
        //_currentHairSMR.rootBone = _rootBone;
        Debug.Log(_customizationData.GetHairColor(hairID));
    }

    public void SetHairColor(int hairColorID)
    {
        _currentHairSMR.material.color = _customizationData.GetHairColor(hairColorID);
        Debug.Log(_customizationData.GetHairColor(hairColorID));
    }

    public void SetSkinColor(int skinColorID)
    {
        //_skinMaterial.color = _customizationData.GetSkinColor(skinColorID);
        Debug.Log(_customizationData.GetHairColor(skinColorID));
    }
}

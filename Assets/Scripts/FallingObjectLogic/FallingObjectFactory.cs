using System;
using System.Collections;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FallingObjectLogic
{
    public class FallingObjectFactory : IPauseObject
    {
     [ContextMenuItem("Check","CheckFallingObject")]  
     [SerializeField] private FallingObjectWithProccent[] _fallingObjects;
     [SerializeField] private PauseController _pauseController;
     [SerializeField] private float _bonuseSpeed = 0;
     [SerializeField] private float _maxBonuseSpeed = 0;
     [SerializeField] private float _createTime;
     [SerializeField] private float _minCreateTime;
     private bool _creating;
     private int _minX, _maxX;
     private int _y;

     private void Awake()
     {
      
         _minX =(int) Camera.main.ScreenToWorldPoint(new Vector3(30,30)).x;
         _maxX = _minX * -1;
         _y =(int) (Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).y * -1)+2 ;

         Debug.Log(_maxX+"  " +_minX+ "  "+_y);
         _creating = true;
         StartCoroutine(CreateFallingObject());
     }

     private IEnumerator CreateFallingObject()
     {
         while (_creating)
         {
             yield return new WaitForSeconds(_createTime);
             FallingObject fallingObject = GetRandomFallingObject();
             if (fallingObject != null && _creating)
             {
                 FallingObject createFallingObject = Instantiate(fallingObject,
                     new Vector3(Random.Range(_minX, _maxX), _y), Quaternion.identity,transform);
                 createFallingObject.Initial(_pauseController);
                 if (_createTime > _minCreateTime)
                 {
                     _createTime = _createTime - 0.005f;
                 }

                 // if (_bonuseSpeed < _maxBonuseSpeed)
                 // {
                 //     _bonuseSpeed = _bonuseSpeed + 0.005f;
                 // }
             }
         }
     }

     private FallingObject GetRandomFallingObject()
     {
          int randomNumber = Random.Range(0,101);
          int lastNumberPr = 0;
         for (int index = 0; index < _fallingObjects.Length; index++)
         {
             if (lastNumberPr < randomNumber && randomNumber <= lastNumberPr + _fallingObjects[index].Procent)
             {
                

                 return _fallingObjects[index].FallingObjects;
             }
             else
             {
             
                 lastNumberPr = lastNumberPr + _fallingObjects[index].Procent;
             }
         }
   
         return null;
     }
     public void CheckFallingObject()
        {
            int count = 0;
            foreach (FallingObjectWithProccent fallingObjectWithProccent in _fallingObjects)
            {
                count += fallingObjectWithProccent.Procent;
            }

         
            if (count != 100)
            {
                Debug.Log(count);
                Debug.Log("trable");
            }
        }

     public override void Pause()
        {
            _creating = false;
            StopCoroutine(CreateFallingObject());
        }

     public override void Play()
        {
            _creating = true;
            StartCoroutine(CreateFallingObject());
        }

        [Serializable]
        private class FallingObjectWithProccent
        {
            [SerializeField] private FallingObject _fallingObjects;
            [Range(1,100)]
            [SerializeField] private int _procent;
            
            public FallingObject FallingObjects=>_fallingObjects;
            public int Procent=>_procent;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Drop : MonoBehaviour {


    public interface IlightDrop
    {
        void OnPickup();
    }

    public class LightDropsEventArgs : EventArgs
    {
        public LightDropsEventArgs(IlightDrop drop)
        {
            LightDrop = drop;
        }
        public IlightDrop LightDrop;
    }

    public Drop ()
    {

    }


    public void onDrop()
    {

    }

    public void onPickup()
    {

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Sim : MonoBehaviour
{
    public Simulation.Behavior Behavior;

    private void OnCollisionEnter2D(Collision2D other)
    {
        throw new NotImplementedException();
    }

    private void ReciveMessage(Sim other)
    {

    }
}
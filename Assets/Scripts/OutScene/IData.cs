
using System;
using UnityEngine;
namespace SwordsAndSandals
{
    public interface IData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
        public float CellScale { get; set; }
        public int Cost { get; set; }
    }
}


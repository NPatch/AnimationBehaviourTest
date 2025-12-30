using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    internal interface IBlocking
    {
        public bool UnblockOnTransition { get; }
        public int TargetTagHash { get; }
        public void BlockStuff(int name_hash);
        public void UnblockStuff(int name_hash);
    }
}

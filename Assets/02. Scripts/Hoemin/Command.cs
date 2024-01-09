using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hoemin
{
    public interface ICommand
    {
        public void Execute();
    }

    public class QSkillCommand : ICommand
    {
        private PlayerInput owner;

        public QSkillCommand(PlayerInput owner)
        {
            this.owner = owner;
        }

        public void Execute()
        {

        }
    }
}


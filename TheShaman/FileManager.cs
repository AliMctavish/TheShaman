using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TheShaman
{
    internal class FileManager
    {
        public List<string> animalFiles = new List<string>();
        public List<string> animalAttackingFiles = new List<string>();
        public List<string> animalWalkingFiles = new List<string>();
        public List<string> secondaryHumanWalking = new List<string>();
        public List<string> humanIdle = new List<string>();
        public List<string> secondaryHumanIdle = new List<string>();
        public List<string> secondaryHumanWalkingFlip = new List<string>();
        public List<string> humanWalking = new List<string>();
        public List<string> humanWalkingFlip = new List<string>();
        public List<string> playerHit = new List<string>();
        public List<string> playerHitFlip = new List<string>();
        public List<string> PlayerIdle = new List<string>();
        public List<string> playerIdleFlip = new List<string>();
        public List<string> playerMoving = new List<string>();
        public List<string> playerMovingFlip = new List<string>();
        public List<string> playerPush = new List<string>();
        public List<string> playerPushFlip = new List<string>();
        public List<string> playerWalkingUp = new List<string>();
        public List<string> playerWalkingDown = new List<string> 
        {"PlayerAnimation/playerWalkingDown1",
        "PlayerAnimation/playerWalkingDown2",
        "PlayerAnimation/playerWalkingDown3"};
        public FileManager()
        {
            for(int i  = 1; i < 12; i++)
            {
                playerHit.Add($"PlayerAnimation/playerHit{i}");
                playerHitFlip.Add($"PlayerFlipAnimation/playerHitFilp{i}");
                if (i < 5) 
                {
                    animalFiles.Add($"AnimalAnimation/animal{i}");
                    animalWalkingFiles.Add($"AnimalAnimation/AnimalWalking{i}");
                    animalAttackingFiles.Add($"AnimalAnimation/AnimalAttacking{i}");
                    secondaryHumanWalking.Add($"HumansAnimation/HumanSecondaryWalking{i}");
                    humanWalkingFlip.Add($"HumansAnimation/HumanWalkingFlip{i}");
                    humanWalking.Add($"HumansAnimation/HumanWalking{i}");
                    secondaryHumanWalkingFlip.Add($"HumansAnimation/HumanSecondaryWalkingFlip{i}");
                    playerMoving.Add($"PlayerAnimation/playerMoving{i}");
                    playerMovingFlip.Add($"PlayerFlipAnimation/playerMoving{i}");
                }
                if (i < 6)
                {
                    secondaryHumanIdle.Add($"HumansAnimation/HumanSecondary{i}");
                    PlayerIdle.Add($"PlayerAnimation/playerIdle{i}");
                    playerIdleFlip.Add($"PlayerFlipAnimation/playerIdle{i}");
                }
                if(i < 8)
                {
                    playerPush.Add($"PlayerAnimation/playerPush{i}");
                    playerPushFlip.Add($"PlayerFlipAnimation/PlayerPushFlip{i}");
                    playerWalkingUp.Add($"PlayerAnimation/playerWalkingUp{i}");
                }
                if (i < 11)
                {
                    humanIdle.Add($"HumansAnimation/HumanIdle{i}");
                }
            }
        }
    }
}

using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TheShaman
{
    internal class FileManager
    {
        private string[] animalFiles = Directory.GetFiles("AnimalAnimation/animal");
        private string[] animalWalkingFiles;
        private string[] animalAttackingFiles;



        public FileManager() 
        {
        }
    }
}

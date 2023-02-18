﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShaman
{
    internal class Maps
    {

        public string[] LoadLevel(int level)
        {


            //  % symbol represent groundBase;
            //  $ symbol represent ground3;
            //  # symbol represent ground1;
            //  . symbol represent empty space;
            //  ? symbol represent chest;
            //  @ symbol represent coins;
            //  ! note ! you should not left a blank space without . symbol , and dont ask why :p


            if (level == 1)
            {
                string[] map = {"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$@@@@@",
                                "@@@@@@#$$$$#$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$#$$$$@@@@@",
                                "@@@@@@$$$$$#%$$$$$##$#$$$$$$$$$$%$$$#%%$$$$$$$$$@@@@@",
                                "@@@@@@$$$$$$$$$$$$$$$$$%$$$$$$$$$$$$$$$$|$$$$$$$@@@@@",
                                "@@@@@@$$$$$$$$$$$$x$$$$|$$#$$$$$$$x$$$$$$$$$$$$$@@@@@",
                                "@@@@@@$$$$$$x$$$%$$$$$$$%$$$$$$$$$$$$%$$$$!$$$$$@@@@@",
                                "@@@@@@$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$@@@@@",
                                "@@@@@@$$x$$$$$$$$$$$|#$$$$$$$$$$$$$$$%$$$$$#$$$$@@@@@",
                                "@@@@@@$$$$$$$#$$$$$$$#$$$$$$$$$#$$$$$$$$$$$##$$$@@@@@",
                                "@@@@@@$$$$$$$$#$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$@@@@@",
                                "@@@@@@$$$$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$$$$$$$$$@@@@@",
                                "@@@@@@$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$@@@@@",
                                "@@@@@@$$$#$$$$$$$$x$$$$$$$$$$$$$$$$$$$$$$$$$$$$$@@@@@",
                                "@@@@@@$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                    };
                return map;

            }
            if (level == 2)
            {
                string[] map = {"$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$$$$$$$$$$$$$$",
                                "$$|$$$$$$$$$$$$$$|$$$$$$$$$$$$$$!$$$$$$$$$|$$$$$$",
                                "$$$$$$$$$$|$!$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$%%$$$$$$$$$$|$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$x$$$$$$|%%$$$$$$$$$$$$$$$$$$",
                                "$$$$$$|#$$$$$$$|$$$$$$$$$$$###$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$##$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$!$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$!$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$|$$$$$$$$$$|$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$",
                                "$$$$$x$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$|$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$x$$$$|$$$$$",
                                "$$$$$$$$$$$$$$!$$$$$$$$$$$$$$$$$%|$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$###$$$$$$$$$$$$$#%$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$%|$$$$$$$$$$|$$$$$$$$$$$$$$$$$$$$$",
                                "$|$$$$$$$$$$$$$%%%$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$",
                                    };

                return map;

            }

            if (level == 3)
            {
                string[] map =  {"$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$$$$$$$$$$$$$$",
                                "$$|$$$$$$$$$$$$$$|$$$$$$$$$$$$$$!$$$$$$$$$|$$$$$$",
                                "$$$$$$$$$$|$!$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$%%$$$$$$$$$$|$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$x$$$$$$|%%$$$$$$$$$$$$$$$$$$",
                                "$$$$$$|#$$$$$$$|$$$$$$$$$$$###$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$##$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$!$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$!$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$|$$$$$$$$$$|$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$",
                                "$$$$$x$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$|$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$x$$$$|$$$$$",
                                "$$$$$$$$$$$$$$!$$$$$$$$$$$$$$$$$%|$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$###$$$$$$$$$$$$$#%$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$%|$$$$$$$$$$|$$$$$$$$$$$$$$$$$$$$$",
                                "$|$$$$$$$$$$$$$%%%$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$",
                                    };
                return map;         
                                    
            }
            if (level == 4)
            {
                string[] map =  {"$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$$$$$$$$$$$$$$",
                                "$$|$$$$$$$$$$$$$$|$$$$$$$$$$$$$$!$$$$$$$$$|$$$$$$",
                                "$$$$$$$$$$|$!$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$%%$$$$$$$$$$|$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$x$$$$$$|%%$$$$$$$$$$$$$$$$$$",
                                "$$$$$$|#$$$$$$$|$$$$$$$$$$$###$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$##$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$!$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$!$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$|$$$$$$$$$$|$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$",
                                "$$$$$x$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$|$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$x$$$$|$$$$$",
                                "$$$$$$$$$$$$$$!$$$$$$$$$$$$$$$$$%|$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$###$$$$$$$$$$$$$#%$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$%|$$$$$$$$$$|$$$$$$$$$$$$$$$$$$$$$",
                                "$|$$$$$$$$$$$$$%%%$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$",
                                    };
                return map;            
            }                          
            if (level == 5)            
            {
                string[] map =  {"$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$$$$$$$$$$$$$$",
                                "$$|$$$$$$$$$$$$$$|$$$$$$$$$$$$$$!$$$$$$$$$|$$$$$$",
                                "$$$$$$$$$$|$!$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$%%$$$$$$$$$$|$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$x$$$$$$|%%$$$$$$$$$$$$$$$$$$",
                                "$$$$$$|#$$$$$$$|$$$$$$$$$$$###$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$##$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$!$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$!$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$|$$$$$$$$$$|$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$",
                                "$$$$$x$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$|$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$x$$$$|$$$$$",
                                "$$$$$$$$$$$$$$!$$$$$$$$$$$$$$$$$%|$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$###$$$$$$$$$$$$$#%$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$%|$$$$$$$$$$|$$$$$$$$$$$$$$$$$$$$$",
                                "$|$$$$$$$$$$$$$%%%$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$",
                                    };
                return map;
            }
            if (level == 6)
            {
                string[] map =  {"$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$$$$$$$$$$$$$$",
                                "$$|$$$$$$$$$$$$$$|$$$$$$$$$$$$$$!$$$$$$$$$|$$$$$$",
                                "$$$$$$$$$$|$!$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$%%$$$$$$$$$$|$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$x$$$$$$|%%$$$$$$$$$$$$$$$$$$",
                                "$$$$$$|#$$$$$$$|$$$$$$$$$$$###$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$##$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$!$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$!$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$|$$$$$$$$$$|$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$",
                                "$$$$$x$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
                                "$$$$$$|$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$x$$$$|$$$$$",
                                "$$$$$$$$$$$$$$!$$$$$$$$$$$$$$$$$%|$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$###$$$$$$$$$$$$$#%$$$$$$$$$$$$$$$$",
                                "$$$$$$$$$$$$$$$%|$$$$$$$$$$|$$$$$$$$$$$$$$$$$$$$$",
                                "$|$$$$$$$$$$$$$%%%$$$$$$$$$$$$$$$$$$$$$$$$$|$$$$$",
                                    };
                return map;
            }

            return null;

        }






    }
}

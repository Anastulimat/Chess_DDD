using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs.Domaine
{
    public class Echiquier
    {
        public Case[,] cases = new Case[8, 8];
        public Partie partie;

        public Echiquier(Partie partie)
        {
            this.partie = partie;
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    cases[i, j] = new Case(i, j);
                }
            }
        }
    }
}

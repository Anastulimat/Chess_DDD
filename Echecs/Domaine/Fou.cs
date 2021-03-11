using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Echecs.IHM;

namespace Echecs.Domaine
{
    public class Fou : Piece
    {
        public Fou(Joueur joueur) : base(joueur, TypePiece.Fou) { }

        public override bool Deplacer(Case destination)
        {
            if (DeplacementSurLaMemeCouleur(destination))
                return false;

            bool deplacementPossible = false;

            int diffCol = destination.col - this.position.col;
            int diffRow = destination.row - this.position.row;
            int rowToCheck = this.position.row;
            int colTocheck = this.position.col;
            int i = 0;

            if(Math.Abs(diffCol) == Math.Abs(diffRow))
            {
                do
                {
                    if (diffRow < 0)
                    {
                        --rowToCheck;
                    }
                    else if (diffRow > 0)
                    {
                        ++rowToCheck;
                    }

                    if (diffCol < 0)
                    {
                        --colTocheck;

                    }
                    else if (diffCol > 0)
                    {
                        ++colTocheck;
                    }

                    if (joueur.partie.echiquier.cases[rowToCheck, colTocheck].piece == null)
                    {
                        deplacementPossible = true;
                    }
                    else
                    {
                        deplacementPossible = false;
                    }
                    ++i;
                } while (deplacementPossible && i < Math.Abs(diffCol));

                if(i == Math.Abs(diffCol))
                {
                    deplacementPossible = (joueur.partie.echiquier.cases[destination.row, destination.col].piece == null || DeplacementSurLaCouleurInverse(destination));
                }
            }

            return deplacementPossible;
        }
    }
}

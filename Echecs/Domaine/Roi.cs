using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Echecs.IHM;

namespace Echecs.Domaine
{
    public class Roi : Piece
    {
        public Roi(Joueur joueur) : base(joueur, TypePiece.Roi) { }

        public override bool Deplacer(Case destination)
        {
            if (this.DeplacementSurLaMemeCouleur(destination))
                return false;


            bool deplacementPossible = false;

            int diffCol = destination.col - this.position.col;
            int diffRow = destination.row - this.position.row;

            int rowToCheck = this.position.row;
            int colToCheck = this.position.col;
            int i = 0;

            if(Math.Abs(diffCol) <= 1 && Math.Abs(diffRow) <= 1)
            {
                deplacementPossible = true;
            }

            return deplacementPossible;
        }
    }
}

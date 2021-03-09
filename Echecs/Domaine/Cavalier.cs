using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Echecs.IHM;

namespace Echecs.Domaine
{
    public class Cavalier : Piece
    {
        public Cavalier(Joueur joueur) : base(joueur, TypePiece.Cavalier) { }

        public override bool Deplacer(Case destination)
        {
            bool deplacementPossible = false;

            int diffCol = Math.Abs(destination.col - this.position.col);
            int diffRow = Math.Abs(destination.row - this.position.row);

            if ((diffCol == 2 && diffRow == 1) || (diffCol == 1 && diffRow == 2))
            {
                deplacementPossible = true;
            }

            return deplacementPossible;
        }
    }
}

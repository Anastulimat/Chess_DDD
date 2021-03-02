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
            destination.Link(this);

            return true;
        }
    }
}

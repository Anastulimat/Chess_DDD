using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Echecs.IHM;

namespace Echecs.Domaine
{
    public class Case
    {
        // attributs
        public int row;
        public int col;
        public CouleurCamp Couleur { get; set; }

        // associations
        public Piece piece;


        // methodes
        public Case(int x, int y)
        {
            row = x;
            col = y;
        }

        

        public void Link(Piece newPiece)
        {
            // 1. Deconnecter newPiece de l'ancienne case
            newPiece.position = null;
            // 2. Connecter newPiece à cette case
            piece = newPiece;
            newPiece.position = this;

        }

        public void Unlink()
        {
            piece = null;
        }
    }
}

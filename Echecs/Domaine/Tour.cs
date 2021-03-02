using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Echecs.IHM;

namespace Echecs.Domaine
{
    public class Tour : Piece
    {
        public Tour(Joueur joueur) : base(joueur, TypePiece.Tour) { }

        public override bool Deplacer(Case destination)
        {
            bool deplacementPossible = false;

            int diffCol = destination.col - this.position.col;
            int diffRow = destination.row - this.position.row;

            // Déplacement vertical sur une colonne
            if(diffCol == 0 && diffRow != 0)
            {
                Console.WriteLine("diffCol = " + diffCol);
                Console.WriteLine("diffRow = " + diffRow);
                int rowActuel = this.position.row;
                int i = 0;
                // On vérifie si le déplacement est possible et si la voie est libre
                do
                {
                    if (diffRow < 0)
                        rowActuel--;
                    else if (diffRow > 0)
                        rowActuel++;

                    // On vérifie si la case est vide
                    deplacementPossible = joueur.partie.echiquier.cases[rowActuel, this.position.col].piece == null;

                }
                while (deplacementPossible && i < Math.Abs(diffRow));
            }
            destination.Link(this);


            return deplacementPossible;
        }
    }
}

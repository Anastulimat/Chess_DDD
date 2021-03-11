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


            if(Math.Abs(diffCol) <= 1 && Math.Abs(diffRow) <= 1)
            {
                deplacementPossible = true;
            }
            else if(this.premierDeplacement && diffCol == 0 && Math.Abs(diffRow) == 2)
            {
                Piece tour;
                int rowActuel = this.position.row;
                int colActuel = this.position.col;

                if(diffRow == 2)
                {
                    tour = joueur.partie.echiquier.cases[7, colActuel].piece;

                    deplacementPossible = tour != null && tour.GetType() == typeof(Tour) && tour.premierDeplacement
                        && joueur.partie.echiquier.cases[rowActuel + 1, colActuel].piece == null
                        && joueur.partie.echiquier.cases[rowActuel + 2, colActuel].piece == null;
                }
                else if (diffRow == -2)
                {
                    tour = joueur.partie.echiquier.cases[0, colActuel].piece;

                    deplacementPossible = tour != null && tour.GetType() == typeof(Tour) && tour.premierDeplacement
                        && joueur.partie.echiquier.cases[rowActuel - 1, colActuel].piece == null
                        && joueur.partie.echiquier.cases[rowActuel - 2, colActuel].piece == null
                        && joueur.partie.echiquier.cases[rowActuel - 3 , colActuel].piece == null;
                }
            }

            if (this.premierDeplacement && deplacementPossible)
                this.premierDeplacement = false;
            

            return deplacementPossible;
        }
    }
}

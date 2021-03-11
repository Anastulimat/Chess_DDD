using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Echecs.IHM;

namespace Echecs.Domaine
{
    public class Dame : Piece
    {
        public Dame(Joueur joueur) : base(joueur, TypePiece.Dame) { }

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


            /*****************************************************
             * Déplacement de la tour 
             ******************************************************/
            if (diffCol != 0 && diffRow == 0)
            {
                int colTocheck = this.position.col;

                // On vérifie si le déplacement est possible et si la voie est libre
                do
                {
                    if (diffCol < 0)
                        colTocheck--;
                    else if (diffCol > 0)
                        colTocheck++;

                    // On vérifie si la case est vide
                    if (joueur.partie.echiquier.cases[this.position.row, colTocheck].piece == null)
                    {
                        deplacementPossible = true;
                    }
                    else
                    {
                        deplacementPossible = false;
                    }
                    ++i;
                }
                while (deplacementPossible && i < Math.Abs(diffCol));

                // On check si la case destination est autorisée mais il y a une piece d'une couleur dedans
                if (i == Math.Abs(diffCol))
                {
                    deplacementPossible = (joueur.partie.echiquier.cases[destination.row, destination.col].piece == null || DeplacementSurLaCouleurInverse(destination));
                }
            }

            if (diffCol == 0 && diffRow != 0)
            {
                rowToCheck = this.position.row;

                // On vérifie si le déplacement est possible et si la voie est libre
                do
                {
                    if (diffRow < 0)
                        rowToCheck--;
                    else if (diffRow > 0)
                        rowToCheck++;

                    // On vérifie si la case est vide
                    if (joueur.partie.echiquier.cases[rowToCheck, this.position.col].piece == null)
                    {
                        deplacementPossible = true;
                    }
                    else
                    {
                        deplacementPossible = false;
                    }
                    ++i;
                }
                while (deplacementPossible && i < Math.Abs(diffRow));

                // On check si la case destination est autorisée mais il y a une piece d'une couleur dedans
                if (i == Math.Abs(diffRow))
                {
                    deplacementPossible = (joueur.partie.echiquier.cases[destination.row, destination.col].piece == null || DeplacementSurLaCouleurInverse(destination));
                }
            }



            /*****************************************************
             * Déplacement du fou
             ******************************************************/
            if (Math.Abs(diffCol) == Math.Abs(diffRow))
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
                        --colToCheck;

                    }
                    else if (diffCol > 0)
                    {
                        ++colToCheck;
                    }

                    if (joueur.partie.echiquier.cases[rowToCheck, colToCheck].piece == null)
                    {
                        deplacementPossible = true;
                    }
                    else
                    {
                        deplacementPossible = false;
                    }
                    ++i;
                } while (deplacementPossible && i < Math.Abs(diffCol));

                if (i == Math.Abs(diffCol))
                {
                    deplacementPossible = (joueur.partie.echiquier.cases[destination.row, destination.col].piece == null || DeplacementSurLaCouleurInverse(destination));
                }
            }

            return deplacementPossible;
        }
    }
}

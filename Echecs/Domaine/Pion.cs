using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Echecs.IHM;

namespace Echecs.Domaine
{
    public class Pion : Piece
    {
        public Pion(Joueur joueur) : base(joueur, TypePiece.Pion) { }


        public override bool Deplacer(Case destination)
        {
            if (DeplacementSurLaMemeCouleur(destination))
                return false;

            bool deplacementPossible = false;

            // Blancs
            if(this.info.couleur == CouleurCamp.Blanche)
            {
                if(PremierDeplacementPossible(destination) || destination.col - this.position.col == -1)
                {
                    if ((destination.row - this.position.row == 0 && !DeplacementSurLaCouleurInverse(destination))
                        || (Math.Abs(destination.row - this.position.row) == 1 && DeplacementSurLaCouleurInverse(destination)))
                    {
                        deplacementPossible = true;
                    }

                    // Prise en pasasnt pour les blancs à droite
                    if (destination.row - this.position.row == 1 
                        && joueur.partie.echiquier.cases[this.position.row + 1, this.position.col].piece != null
                        && joueur.partie.echiquier.cases[this.position.row + 1, this.position.col].piece.GetType() == typeof(Pion)
                        && joueur.partie.echiquier.cases[this.position.row + 1, this.position.col].piece.deplacementDeuxCases
                        && joueur.partie.echiquier.cases[this.position.row + 1, this.position.col].piece.info.couleur != this.info.couleur)
                    {
                        deplacementPossible = true;
                    }

                    // Prise en pasasnt pour les blancs à guache
                    if (destination.row - this.position.row == -1
                        && joueur.partie.echiquier.cases[this.position.row - 1, this.position.col].piece != null
                        && joueur.partie.echiquier.cases[this.position.row - 1, this.position.col].piece.GetType() == typeof(Pion)
                        && joueur.partie.echiquier.cases[this.position.row - 1, this.position.col].piece.deplacementDeuxCases == true
                        && joueur.partie.echiquier.cases[this.position.row - 1, this.position.col].piece.info.couleur != this.info.couleur)
                    {
                        deplacementPossible = true;
                    }
                }
            }

            //Noirs
            else
            {
                if (PremierDeplacementPossible(destination) || destination.col - this.position.col == 1)
                {
                    if ((destination.row - this.position.row == 0 && !DeplacementSurLaCouleurInverse(destination)) 
                        || (Math.Abs(destination.row - this.position.row) == 1 && DeplacementSurLaCouleurInverse(destination)))
                    {
                        deplacementPossible = true;
                    }

                    // Prise en pasasnt pour les noirs à droite
                    if (destination.row - this.position.row == 1
                        && joueur.partie.echiquier.cases[this.position.row + 1, this.position.col].piece != null
                        && joueur.partie.echiquier.cases[this.position.row + 1, this.position.col].piece.GetType() == typeof(Pion)
                        && joueur.partie.echiquier.cases[this.position.row + 1, this.position.col].piece.deplacementDeuxCases
                        && joueur.partie.echiquier.cases[this.position.row + 1, this.position.col].piece.info.couleur != this.info.couleur)
                    {
                        deplacementPossible = true;
                    }

                    // Prise en pasasnt pour les noirs à guache
                    if (destination.row - this.position.row == -1
                        && joueur.partie.echiquier.cases[this.position.row - 1, this.position.col].piece != null
                        && joueur.partie.echiquier.cases[this.position.row - 1, this.position.col].piece.GetType() == typeof(Pion)
                        && joueur.partie.echiquier.cases[this.position.row - 1, this.position.col].piece.deplacementDeuxCases == true
                        && joueur.partie.echiquier.cases[this.position.row - 1, this.position.col].piece.info.couleur != this.info.couleur)
                    {
                        deplacementPossible = true;
                    }
                }
            }

            if (!premierDeplacement)
                deplacementDeuxCases = false;

            if (deplacementPossible && premierDeplacement)
                premierDeplacement = false;


            return deplacementPossible;
        }



        /**
         * Vérifier si on peut déplacer le pion de deux cases au début du  
         */
        private bool PremierDeplacementPossible(Case destination)
        {
            bool deplacementPossible = false;

            //Blanc
            if(this.info.couleur == CouleurCamp.Blanche)
            {
                if(premierDeplacement 
                    && destination.col - this.position.col == -2 
                    && joueur.partie.echiquier.cases[this.position.row, this.position.col - 1].piece == null
                    && joueur.partie.echiquier.cases[this.position.row, this.position.col - 2].piece == null)
                {
                    deplacementPossible = true;
                    deplacementDeuxCases = true;
                }
            }
            //Noir
            else
            {
                if (premierDeplacement
                    && destination.col - this.position.col == 2
                    && joueur.partie.echiquier.cases[this.position.row, this.position.col + 1].piece == null
                    && joueur.partie.echiquier.cases[this.position.row, this.position.col + 2].piece == null)
                {
                    deplacementPossible = true;
                    deplacementDeuxCases = true;
                }
            }

            return deplacementPossible;
        }
    }
}

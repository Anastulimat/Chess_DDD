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

        private bool premierDeplacement = true;

        public override bool Deplacer(Case destination)
        {
            bool deplacementPossible = false;

            // Blancs
            if(this.info.couleur == CouleurCamp.Blanche)
            {
                Console.WriteLine("PremierDeplacementPossible(destination) = " + PremierDeplacementPossible(destination));
                if(PremierDeplacementPossible(destination) || destination.col - this.position.col == -1 && destination.row - this.position.row == 0)
                {
                    deplacementPossible = true;
                }
            }

            //Noirs
            else
            {
                if(PremierDeplacementPossible(destination) || destination.col - this.position.col == 1 && destination.row - this.position.row == 0)
                {
                    deplacementPossible = true;
                }
            }

            if (deplacementPossible && premierDeplacement)
                premierDeplacement = false;

            return deplacementPossible;
        }

        private bool PremierDeplacementPossible(Case destination)
        {
            bool deplacementPossible = false;

            if(this.info.couleur == CouleurCamp.Blanche)
            {
                if(premierDeplacement 
                    && destination.col - this.position.col == -2 
                    && joueur.partie.echiquier.cases[this.position.row, this.position.col - 1].piece == null
                    && joueur.partie.echiquier.cases[this.position.row, this.position.col - 2].piece == null)
                {
                    deplacementPossible = true;
                }
            }
            else
            {
                if (premierDeplacement
                    && destination.col - this.position.col == 2
                    && joueur.partie.echiquier.cases[this.position.row, this.position.col + 1].piece == null
                    && joueur.partie.echiquier.cases[this.position.row, this.position.col + 2].piece == null)
                {
                    deplacementPossible = true;
                }
            }

            return deplacementPossible;
        }
    }
}

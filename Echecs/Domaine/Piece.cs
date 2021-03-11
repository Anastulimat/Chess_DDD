using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Echecs.IHM;

namespace Echecs.Domaine
{
    abstract public class Piece
    {
        // attributs
        public InfoPiece info;
        public bool premierDeplacement = true;

        // associations
        public Joueur joueur;
        public Case position;

        // methodes
        public Piece(Joueur joueur, TypePiece type)
        {
			this.joueur = joueur;
            info = InfoPiece.GetInfo(joueur.couleur, type);
        }

        public abstract bool Deplacer(Case destination);

        public bool DeplacementSurLaMemeCouleur(Case destination)
        {
            return destination.piece != null && destination.piece.joueur.couleur == this.joueur.couleur;
        }

        public bool DeplacementSurLaCouleurInverse(Case destination)
        {
            return destination.piece != null && destination.piece.joueur.couleur != this.joueur.couleur;
        }
    }
}

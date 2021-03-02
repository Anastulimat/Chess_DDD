using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Echecs.IHM;

namespace Echecs.Domaine
{
    public class Joueur
    {
        // attributs
        public CouleurCamp couleur;

        // associations
        public Partie partie;
        public List<Piece> pieces = new List<Piece>();

        // methodes
        public Joueur(Partie partie, CouleurCamp couleur)
        {
            this.couleur = couleur;
            this.partie = partie;

            // Creation des pieces du joueur
            pieces.Add(new Roi(this));
            pieces.Add(new Dame(this));

            pieces.Add(new Tour(this));
            pieces.Add(new Tour(this));

            pieces.Add(new Fou(this));
            pieces.Add(new Fou(this));

            pieces.Add(new Cavalier(this));
            pieces.Add(new Cavalier(this));

            for(int i = 0; i < 8; i++)
            {
                pieces.Add(new Pion(this));
            }
        }

        // TODO : décommentez lorsque vous auriez implementé les methode Unlink et Link de la classe Case
        public void PlacerPieces(Echiquier echiquier)
        {
            if (couleur == CouleurCamp.Noire)
            {
                //Roi
                echiquier.cases[4, 0].Link(pieces[0]);

                //Dame
                echiquier.cases[3, 0].Link(pieces[1]);

                // Tours
                echiquier.cases[0, 0].Link(pieces[2]);
                echiquier.cases[7, 0].Link(pieces[3]);

                // Fous
                echiquier.cases[2, 0].Link(pieces[4]);
                echiquier.cases[5, 0].Link(pieces[5]);

                // Chevalier
                echiquier.cases[1, 0].Link(pieces[6]);
                echiquier.cases[6, 0].Link(pieces[7]);

                // Pions
                for (int i = 0; i < 8; i++)
                {
                    echiquier.cases[i, 1].Link(pieces[i+8]);
                }
               
            }
            else
            {
                //Roi
                echiquier.cases[4, 7].Link(pieces[0]);

                //Dame
                echiquier.cases[3, 7].Link(pieces[1]);

                // Tours
                echiquier.cases[0, 7].Link(pieces[2]);
                echiquier.cases[7, 7].Link(pieces[3]);

                // Fous
                echiquier.cases[2, 7].Link(pieces[4]);
                echiquier.cases[5, 7].Link(pieces[5]);

                // Chevalier
                echiquier.cases[1, 7].Link(pieces[6]);
                echiquier.cases[6, 7].Link(pieces[7]);

                // Pions
                for (int i = 0; i < 8; i++)
                {
                    echiquier.cases[i, 6].Link(pieces[i + 8]);
                }
            }
        }
    }
}

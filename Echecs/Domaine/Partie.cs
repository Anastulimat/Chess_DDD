using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Echecs.IHM;

namespace Echecs.Domaine
{
    public class Partie : IJeu
    {
        public IEvenements vue
        {
            get { return _vue; }
            set {_vue = value; }
        }

        StatusPartie status
        {
            get { return _status; }
            set
            {
                _status = value;
                vue.ActualiserPartie(_status);
            }
        }



        /* attributs */
        StatusPartie _status = StatusPartie.Reset;


        /* associations */
        IEvenements _vue;
        Joueur blancs;
        Joueur noirs;
        public Echiquier echiquier;




        /* methodes */
        public void CommencerPartie()
        {
            // creation des joueurs
            blancs = new Joueur(this, CouleurCamp.Blanche);
            noirs = new Joueur(this, CouleurCamp.Noire);

            // creation de l'echiquier
            echiquier = new Echiquier(this);

            // placement des pieces
            blancs.PlacerPieces(echiquier);
            foreach (Piece piece in blancs.pieces)
                vue.ActualiserCase(piece.position.row, piece.position.col, piece.info);

            noirs.PlacerPieces(echiquier);
            foreach (Piece piece in noirs.pieces)
                vue.ActualiserCase(piece.position.row, piece.position.col, piece.info);


            // initialisation de l'état
            status = StatusPartie.TraitBlancs;         
        }



        public void DeplacerPiece(int x_depart, int y_depart, int x_arrivee, int y_arrivee)
        {
            // case de départ
            Case depart = echiquier.cases[x_depart, y_depart];

            // case d'arrivée
            Case destination = echiquier.cases[x_arrivee, y_arrivee];

            // deplacer
            bool ok = depart.piece.Deplacer(destination);



            /* TEST */
            //vue.ActualiserCase(x_depart, y_depart, null);
            //vue.ActualiserCase(x_arrivee, y_arrivee, InfoPiece.RoiBlanc);
            /* FIN TEST */

            // changer d'état
            if (ok)
            {
                destination.Link(depart.piece);
                depart.Unlink();
                vue.ActualiserCase(destination.row, destination.col, destination.piece.info);
                vue.ActualiserCase(depart.row, depart.col, null);
                ChangerEtat();
            }
                
        }

        void ChangerEtat(bool echec = false, bool mat = false)
        {
            if (status == StatusPartie.TraitBlancs)
            {
                status = StatusPartie.TraitNoirs;
            }
            else
            {
                status = StatusPartie.TraitBlancs;
            }

        }
    }
}

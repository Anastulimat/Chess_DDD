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
        List<InfoPiece> piecesCapturees;



        /* methodes */
        public void CommencerPartie()
        {
            // creation des joueurs
            blancs = new Joueur(this, CouleurCamp.Blanche);
            noirs = new Joueur(this, CouleurCamp.Noire);

            // creation de l'echiquier
            echiquier = new Echiquier(this);

            //piecesCapturees
            piecesCapturees = new List<InfoPiece>();

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
                
                // Roque
                if(depart.piece.GetType() == typeof(Roi) && Math.Abs(depart.row - destination.row) == 2 && depart.col - destination.col == 0)
                {
                    destination.Link(depart.piece);
                    destination.piece.position = destination;
                    depart.Unlink();

                    vue.ActualiserCase(destination.row, destination.col, destination.piece.info);
                    vue.ActualiserCase(depart.row, depart.col, null);

                    // Deplacement de la tour
                    Case tourDepart;
                    int oldRowTour;
                    int oldColTour = destination.col;

                    Case tourDestination;
                    int newRowTour;
                    int newColTour = destination.col;

                    if(destination.row - depart.row == 2)
                    {
                        oldRowTour = 7;
                        newRowTour = 5;
                    }
                    else
                    {
                        oldRowTour = 0;
                        newRowTour = 3;
                    }
                    tourDepart = echiquier.cases[oldRowTour, oldColTour];
                    tourDestination = echiquier.cases[newRowTour, newColTour];

                    tourDestination.Link(tourDepart.piece);
                    tourDestination.piece.position = tourDestination;
                    tourDepart.Unlink();

                    vue.ActualiserCase(tourDestination.row, tourDestination.col, tourDestination.piece.info);
                    vue.ActualiserCase(tourDepart.row, tourDepart.col, null);
                }

                // La prise en passant
                if (depart.piece.GetType() == typeof(Pion) 
                    && Math.Abs(depart.row - destination.row) == 1 
                    && Math.Abs(depart.col - destination.col) == 1)
                {
                    Console.WriteLine("depart.row - destination.row = " + (depart.row - destination.row));
                    Console.WriteLine("depart.col - destination.col = " + (depart.col - destination.col));

                    if(depart.row - destination.row == -1)
                    {
                        piecesCapturees.Add(echiquier.cases[depart.row + 1, depart.col].piece.info);
                        vue.ActualiserCase(depart.row + 1, depart.col, null);
                    }
                        

                    if (depart.row - destination.row == 1)
                    {
                        piecesCapturees.Add(echiquier.cases[depart.row - 1, depart.col].piece.info);
                        vue.ActualiserCase(depart.row - 1, depart.col, null);
                    }




                    destination.Link(depart.piece);
                    destination.piece.position = destination;
                    depart.Unlink();



                    vue.ActualiserCase(destination.row, destination.col, destination.piece.info);
                    vue.ActualiserCase(depart.row, depart.col, null);
                }

                else
                {

                    // Actualiser Captures
                    if (destination.piece != null)
                    {
                        piecesCapturees.Add(destination.piece.info);
                    }

                    destination.Unlink();
                    destination.Link(depart.piece);
                    destination.piece.position = destination;
                    depart.Unlink();

                    vue.ActualiserCase(destination.row, destination.col, destination.piece.info);
                    vue.ActualiserCase(depart.row, depart.col, null);
                }
                vue.ActualiserCaptures(piecesCapturees);
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

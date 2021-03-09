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
            int i = 0;

            if (diffCol != 0 && diffRow == 0)
            {
                //console.writeline("déplacement vertical sur une colonne");
                //console.writeline("diffcol != 0 && diffrow == 0");
                //console.writeline("diffcol = " + diffcol);
                //console.writeline("diffrow = " + diffrow);

                int colTocheck = this.position.col;

                //Console.WriteLine("colTocheck = " + colTocheck);
                
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
            }

            if (diffCol == 0 && diffRow != 0)
            {
                //Console.WriteLine("Déplacement horizontal sur une ligne !");
                //Console.WriteLine("diffCol == 0 && diffRow != 0");
                //Console.WriteLine("diffCol = " + diffCol);
                //Console.WriteLine("diffRow = " + diffRow);

                int rowToCheck = this.position.row;
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
            }

            return deplacementPossible;
        }
    }
}

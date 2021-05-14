using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace projetBDD
{
    class Program
    {
        static MySqlConnection OpenConnexion()
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=bertrand543";
                //faut mettre les infos de connexions de ta base 
                // database = le nom de ton fichier 
                // password le mots de passe sql, le reste touches pas

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
                Console.WriteLine("CONNEXION OUVERTE");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
            }
            return maConnexion;
        }
        public void Module_statistique(MySqlConnection maConnexion)
        {
            //module stat qui permet de voir les infos importante du module 
            MySqlCommand cmd2 = new MySqlCommand("select c.prenom, c.nom from client c join fidelio f on f.id_fidelio=c.id_fidelio where description = 'Fidélio';", maConnexion);
            cmd2.ExecuteNonQuery();

            MySqlCommand cmd3 = new MySqlCommand("select c.prenom, c.nom from client c join fidelio f on f.id_fidelio=c.id_fidelio where description = 'Fidélio Or';", maConnexion);
            cmd3.ExecuteNonQuery();

            MySqlCommand cmd4 = new MySqlCommand("select c.prenom, c.nom from client c join fidelio f on f.id_fidelio=c.id_fidelio where description = 'Fidélio Platine';", maConnexion);
            cmd4.ExecuteNonQuery();

            MySqlCommand cmd5 = new MySqlCommand("select c.prenom, c.nom from client c join fidelio f on f.id_fidelio=c.id_fidelio where description = 'Fidélio Max';", maConnexion);
            cmd5.ExecuteNonQuery();
            // on selectionne mais on stock pas les données.
            // a voir avec Theo.
        }
        public void Evaluateur(MySqlConnection maConnexion)
        {
            // nbre de clients 
            MySqlCommand cmd2 = new MySqlCommand("select count(*) from client;", maConnexion);
            cmd2.ExecuteNonQuery();

            // Noms des cleints avec le cumul de toutes ses commandes en euros.
            MySqlCommand cmd3 = new MySqlCommand("select c.nom, sum(p.prix) as 'prix piece', sum(v.prix) as 'Prix velo" +
                "from client c join commande co on co.id_client=c.id_client" +
                "join item_com i on i.id_commande=co.id_commande" +
                "join velo v on v.id_velo = i.id_velo" +
                "join piece p on p.id_piece = i.id_piece;", maConnexion);

            //  Liste des produits ayant une quantité en stock <= 2 

            MySqlCommand cmd4 = new MySqlCommand("select id_piece, descritpion " +
                "from piece " +
                "where count(p.id_piece <= 2;", maConnexion);

            //  Nombres de pièces et/ou vélos fournis par fournisseur. 
            MySqlCommand cmd5 = new MySqlCommand("select count(p.id_fournisseur) as 'nbre de pieces' " +
                "from fournisseur f join piece p on p.id_fournisseur=f.num_siret", maConnexion);

            // 
        }
        static void Main(string[] args)
        {
            //on ouvre la connexion a partir de la fonction.
            Console.Clear();
            MySqlConnection maConnexion = OpenConnexion();

            velo unvelo = new velo(76, 23, "paulvelo", "large", "ligne", 40, maConnexion);
            unvelo.stock(maConnexion);
            //unvelo.add(maConnexion);
            //unvelo.Suppression(maConnexion, 76);
            DateTime une = new DateTime(09 / 09 / 09);
            //modele unmodele= new modele(32, une, une, maConnexion);
            //unmodele.add(maConnexion);
            //unmodele.Suppression(maConnexion, 32);
            maConnexion.Close();
        }
    }
}

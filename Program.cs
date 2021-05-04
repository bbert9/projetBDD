using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

#test
namespace projetBDD
{
    class Program
    {
        static void Select(MySqlConnection a)
        {
            string requete = "select * from Velo";
            MySqlCommand command1 = a.CreateCommand();
            command1.CommandText = requete;

            MySqlDataReader reader = command1.ExecuteReader();
            reader.Close();
            command1.Dispose();
        }
        static void CreateAllTables(MySqlConnection a)
        {
            #region Création de table
            //je drop les tables au cas ou pour avoir d'erreurs. 
            string droptable = "drop table if exists Pieces";
            string droptable1 = "drop table if exists Velo;";
            string droptable2 = "drop table if exists Clients_part;";
            string droptable3 = "drop table if exists Fournisseurs;";

            MySqlCommand dropcommand = a.CreateCommand();
            dropcommand.CommandText = droptable;
            MySqlCommand dropcommand1 = a.CreateCommand();
            dropcommand1.CommandText = droptable1;
            MySqlCommand dropcommand2 = a.CreateCommand();
            dropcommand2.CommandText = droptable2;
            MySqlCommand dropcommand3 = a.CreateCommand();
            dropcommand3.CommandText = droptable3;

            //ici j'essayes de creer les tables que le sujet demande de creer.
            string createTable = " CREATE TABLE Pieces (nom VARCHAR(25), num int, description varchar(25), nom_fournisseur varchar(25), prix int, date_intro date, date_discon date, delai varchar(25));"; //marche 
            MySqlCommand command2 = a.CreateCommand();
            command2.CommandText = createTable;

            string createTable2 = " CREATE TABLE Velo (nom VARCHAR(25), num INT, grandeur varchar(25), prix int, pieces varchar(25), date_intro date, date_discon date);";
            MySqlCommand command3 = a.CreateCommand();
            command3.CommandText = createTable2;

            string createTable3 = " CREATE TABLE Clients_part (nom VARCHAR(25), prenom varchar(25), adresse varchar(25), rue varchar(25), zip_code int, ville varchar(25), province varchar(25), telephone varchar(25), courriel varchar(25), Fidelio bool);";
            MySqlCommand command4 = a.CreateCommand();
            command4.CommandText = createTable3;
            //je sias pas si je dois mettre deux tables clients differentes ou en faire mais je vois pas comment

            string createTable4 = " CREATE TABLE Fournisseurs (nom VARCHAR(25), prix int, delai varchar(25));";
            MySqlCommand command5 = a.CreateCommand();
            command4.CommandText = createTable4;
            try
            {
                dropcommand.ExecuteNonQuery();
                dropcommand1.ExecuteNonQuery();
                dropcommand2.ExecuteNonQuery();
                dropcommand3.ExecuteNonQuery();

                command2.ExecuteNonQuery();
                command3.ExecuteNonQuery();
                command4.ExecuteNonQuery();
                command5.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command2.Dispose();
            command3.Dispose();
            command4.Dispose();
            command5.Dispose();
            #endregion
        }
        static MySqlConnection OpenConnexion()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=BDD;" +
                                         "UID=root;PASSWORD=";
                //faut mettre les infos de connexions de ta base 
                // database = le nom de ton fichier 
                // password le mots de passe sql, le reste touches pas

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
            }
            return maConnexion;
            #endregion
        }
        static void Insertion(MySqlConnection a, string table, string forme, string value)
        {
            #region Insertion
             //manque des choses, faudrait mettre nom, prenom ect --> les mettre tous en parametres ? 
            string insertTable = " insert into " + table + " "+forme+"  Values ('" + value + "'');";
            MySqlCommand command6 = a.CreateCommand();
            command6.CommandText = insertTable;
            try
            {
                command6.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }

            command6.Dispose();
            #endregion
        }
        static void Main(string[] args)
        {
            MySqlConnection maConnexion = OpenConnexion();
            CreateAllTables(maConnexion);
            //test insertion dans table velo
            string forme = "nom, num, grandeur, prix, pieces, date_intro, date_discon";
            Insertion(maConnexion, "Velo", forme, "VTT, 13, L, 123, 'couroie', date, date");
            #region Selection 

            //cette partie c'est pour les trucs compliqués

            //string[] valueString = new string[reader.FieldCount];
            //while (reader.Read())
            //{
            //    int first_name = (int)reader["idCourse"];
            //    Console.WriteLine(first_name);

            //    for (int i = 0; i < reader.FieldCount; i++)
            //    {
            //        valueString[i] = reader.GetValue(i).ToString();
            //        Console.Write(valueString[i] + " , ");
            //    }
            //    Console.WriteLine();
            //}
            
            #endregion
            
            //#region Selection avec variable
            //MySqlParameter nom = new MySqlParameter("@nom", MySqlDbType.VarChar);
            //nom.Value = "NICK";

            //string requete4 = "Select * from actor where first_name = @nom;";
            //MySqlCommand command4 = maConnexion.CreateCommand();
            //command4.CommandText = requete4;
            //command4.Parameters.Add(nom);
            //MySqlDataReader reader1 = command4.ExecuteReader();

            //valueString = new string[reader1.FieldCount];
            //while (reader1.Read())
            //{

            //    for (int i = 0; i < reader1.FieldCount; i++)
            //    {
            //        valueString[i] = reader1.GetValue(i).ToString();
            //        Console.Write(valueString[i] + " , ");
            //    }
            //    Console.WriteLine();
            //}
            //reader.Close();
            //#endregion
            maConnexion.Close();

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace projetBDD
{
    public class modele
    {
        int id_modele;
        DateTime date_intro;
        DateTime date_disc;
        public modele(int id_modele, DateTime date_intro, DateTime date_disc, MySqlConnection maConnection)
        {
            this.id_modele = id_modele;
            this.date_intro = date_intro;
            this.date_disc = date_disc;
        }
        public void add(MySqlConnection maConnection)
        {
            MySqlCommand cmd2 = new MySqlCommand("insert into modele values (" + this.id_modele + "," + "'"+this.date_intro + "'" + "," + "'" + this.date_disc + "'" + ");", maConnection);
            cmd2.ExecuteNonQuery();
        }
        public void Suppression(MySqlConnection maConnexion, int id)
        {
            MySqlCommand cmd2 = new MySqlCommand("DELETE FROM modele WHERE id_modele =" + id + ";", maConnexion);
            cmd2.ExecuteNonQuery();
        }
    }
}

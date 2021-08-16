using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Xml.Serialization;
using ElectronicVotingSystem.Models;

namespace ElectronicVotingSystem.DatabaseContext
{
    public class DBContext
    {
        string connectionString = System.Configuration.ConfigurationSettings.AppSettings["DBConnection"].ToString();

        public DBContext()
        {
        }

        public string RegisterUser(Users users)
        {
            var model = new Users();
            string Message = "";
            using (MySqlConnection mySqlCon = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                mySqlCon.Open();
                MySqlCommand cmd = new MySqlCommand("sp_RegisterUser", mySqlCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_Name", users.Name);
                cmd.Parameters.AddWithValue("@p_Mobile", users.Mobile);
                cmd.Parameters.AddWithValue("@p_AadharNumber", users.AadharID);
                cmd.Parameters.AddWithValue("@p_VoterIDnumber", users.VoterID);
                cmd.Parameters.AddWithValue("@p_Email", users.Email);
                cmd.Parameters.AddWithValue("@p_Address", users.Address);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Message = Convert.ToString(reader["ErrorMessage"]);
                }
            }
            return Message;
        }

        public List<PartyList> GetPartyList()
        {
            var response = new List<PartyList>();
            using (var mySqlCon = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                mySqlCon.Open();
                var cmd = new MySqlCommand("sp_CandidateList", mySqlCon);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    response.Add(new PartyList
                    {
                        id = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : -1,
                        PartyName = reader["PartyName"] != DBNull.Value ? reader["PartyName"].ToString() : "",
                        CandidateName = reader["CandidateName"] != DBNull.Value ? reader["CandidateName"].ToString() : "",
                        TotalVotes = reader["TotalVotes"] != DBNull.Value ? Convert.ToInt32(reader["TotalVotes"]) : -1,
                        Url = reader["url"] != DBNull.Value ? reader["url"].ToString() : "",
                    });
                }
            }
            return response;
        }

        public Users Login(string aadharNumber)
        {
            var model = new Users();
            string Message = "";
            using (MySqlConnection mySqlCon = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                mySqlCon.Open();
                MySqlCommand cmd = new MySqlCommand("sp_Login", mySqlCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_AadharNumber", aadharNumber);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    model.Name = reader["name"] != DBNull.Value ? reader["name"].ToString() : "";
                    model.VoterID = reader["voterIDNumber"] != DBNull.Value ? reader["voterIDNumber"].ToString() : "";
                    model.AadharID = reader["aadharNumber"] != DBNull.Value ? reader["aadharNumber"].ToString() : "";
                    model.Mobile = reader["mobile"] != DBNull.Value ? reader["mobile"].ToString() : "";
                    model.Email = reader["email"] != DBNull.Value ? reader["email"].ToString() : "";
                }
            }
            return model;
        }

        public string CreateVote(Users users)
        {
            var model = new Users();
            string Message = "";
            using (MySqlConnection mySqlCon = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                mySqlCon.Open();
                MySqlCommand cmd = new MySqlCommand("sp_createVote", mySqlCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_Name", users.Name);
                cmd.Parameters.AddWithValue("@p_mobile", users.Mobile);
                cmd.Parameters.AddWithValue("@p_aadharID", users.Mobile);
                cmd.Parameters.AddWithValue("@p_VoterID", users.VoterID);
                cmd.Parameters.AddWithValue("@p_email", users.Email);
                cmd.Parameters.AddWithValue("@p_CandidateID", users.CandidateID);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Message = Convert.ToString(reader["ErrorMessage"]);
                }
            }
            return Message;
        }


    }
}
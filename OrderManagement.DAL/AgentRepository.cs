using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using OrderManagement.Models;

namespace OrderManagement.DAL
{
    public class AgentRepository
    {
        private readonly DatabaseHelper _db;

        public AgentRepository()
        {
            _db = new DatabaseHelper();
        }

        public List<Agent> GetAllAgents()
        {
            string query = "SELECT * FROM Agent";
            DataTable result = _db.ExecuteQuery(query);
            List<Agent> agents = new List<Agent>();

            foreach (DataRow row in result.Rows)
            {
                agents.Add(new Agent
                {
                    AgentID = Convert.ToInt32(row["AgentID"]),
                    AgentName = row["AgentName"].ToString(),
                    Address = row["Address"].ToString(),
                    ContactNumber = row["ContactNumber"].ToString(),
                    Email = row["Email"].ToString()
                });
            }

            return agents;
        }

        public Agent GetAgentById(int agentId)
        {
            string query = "SELECT * FROM Agent WHERE AgentID = @AgentID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AgentID", agentId)
            };

            DataTable result = _db.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            DataRow row = result.Rows[0];
            return new Agent
            {
                AgentID = Convert.ToInt32(row["AgentID"]),
                AgentName = row["AgentName"].ToString(),
                Address = row["Address"].ToString(),
                ContactNumber = row["ContactNumber"].ToString(),
                Email = row["Email"].ToString()
            };
        }

        public int AddAgent(Agent agent)
        {
            string query = @"INSERT INTO Agent (AgentName, Address, ContactNumber, Email) 
                            VALUES (@AgentName, @Address, @ContactNumber, @Email);
                            SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AgentName", agent.AgentName),
                new SqlParameter("@Address", agent.Address),
                new SqlParameter("@ContactNumber", agent.ContactNumber),
                new SqlParameter("@Email", agent.Email)
            };

            object result = _db.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }

        public void UpdateAgent(Agent agent)
        {
            string query = @"UPDATE Agent 
                           SET AgentName = @AgentName,
                               Address = @Address,
                               ContactNumber = @ContactNumber,
                               Email = @Email
                           WHERE AgentID = @AgentID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AgentID", agent.AgentID),
                new SqlParameter("@AgentName", agent.AgentName),
                new SqlParameter("@Address", agent.Address),
                new SqlParameter("@ContactNumber", agent.ContactNumber),
                new SqlParameter("@Email", agent.Email)
            };

            _db.ExecuteNonQuery(query, parameters);
        }

        public void DeleteAgent(int agentId)
        {
            string query = "DELETE FROM Agent WHERE AgentID = @AgentID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AgentID", agentId)
            };

            _db.ExecuteNonQuery(query, parameters);
        }

        public List<Agent> GetAgentsWithOrders()
        {
            string query = @"SELECT DISTINCT a.*
                           FROM Agent a
                           JOIN [Order] o ON a.AgentID = o.AgentID";

            DataTable result = _db.ExecuteQuery(query);
            List<Agent> agents = new List<Agent>();

            foreach (DataRow row in result.Rows)
            {
                agents.Add(new Agent
                {
                    AgentID = Convert.ToInt32(row["AgentID"]),
                    AgentName = row["AgentName"].ToString(),
                    Address = row["Address"].ToString(),
                    ContactNumber = row["ContactNumber"].ToString(),
                    Email = row["Email"].ToString()
                });
            }

            return agents;
        }
    }
}

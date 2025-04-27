using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.DAL;
using OrderManagement.Models;

public class AgentManager
{
    private readonly AgentRepository _agentRepo;

    public AgentManager()
    {
        _agentRepo = new AgentRepository();
    }

    public List<Agent> GetAllAgents()
    {
        return _agentRepo.GetAllAgents();
    }

    public Agent GetAgentById(int agentId)
    {
        return _agentRepo.GetAgentById(agentId);
    }

    public int AddAgent(Agent agent)
    {
        // Validate agent data
        if (string.IsNullOrWhiteSpace(agent.AgentName))
            throw new ArgumentException("Agent name cannot be empty");

        if (string.IsNullOrWhiteSpace(agent.Address))
            throw new ArgumentException("Address cannot be empty");

        return _agentRepo.AddAgent(agent);
    }

    public void UpdateAgent(Agent agent)
    {
        // Validate agent data
        if (string.IsNullOrWhiteSpace(agent.AgentName))
            throw new ArgumentException("Agent name cannot be empty");

        if (string.IsNullOrWhiteSpace(agent.Address))
            throw new ArgumentException("Address cannot be empty");

        _agentRepo.UpdateAgent(agent);
    }

    public void DeleteAgent(int agentId)
    {
        _agentRepo.DeleteAgent(agentId);
    }

    public List<Agent> GetAgentsWithOrders()
    {
        return _agentRepo.GetAgentsWithOrders();
    }
}


using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Player
{
	static void Main(string[] args)
	{
		string[] inputs;
		inputs = Console.ReadLine().Split(' ');
		int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
		int L = int.Parse(inputs[1]); // the number of links
		int E = int.Parse(inputs[2]); // the number of exit gateways

		List<Link> links = new List<Link>();
		for (int i = 0; i < L; i++)
		{
			inputs = Console.ReadLine().Split(' ');
			links.Add(new Link(int.Parse(inputs[0]), int.Parse(inputs[1])));
		}
		List<int> gateways = new List<int>();
		for (int i = 0; i < E; i++)
			gateways.Add(int.Parse(Console.ReadLine()));

		// game loop
		while (true)
		{
			int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn

			Link.CloseGateway(SI, gateways, links);
		}
	}
}

public class Link
{
	public int _node1 { get; set; }
	public int _node2 { get; set; }

	public Link(int node1, int node2)
	{
		_node1 = node1;
		_node2 = node2;
	}

	public override string ToString()
	{
		return $"{_node1} {_node2}";
	}

	public override bool Equals(object obj)
	{
		Link link = obj as Link;
		return (_node1 == link._node1 && _node2 == link._node2) || (_node1 == link._node2 && _node2 == link._node1);
	}

	static public void CloseGateway(int agentIndex, List<int> gateways, List<Link> links)
	{
		foreach (int gateway in gateways)
		{
			Link link = new Link(agentIndex, gateway);
			if (links.Contains(link))
			{
				Console.WriteLine(link);
				links.Remove(link);
				return;
			}
		}
		Console.WriteLine(links[new Random().Next(0, links.Count)]);
	}
}
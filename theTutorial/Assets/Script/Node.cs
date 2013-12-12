using System;

	public class Node
	{
		public Node[] childs;
		
		public Node parent;
		
		public string name, command;
	
		public string[] Output;
	
		public int numOutput;
	
		const int MAX_LINES = 10;
		
		public int numChilds;
		
		
		public Node (string title )
		{
			childs = new Node[4];
		
			Output = new string[MAX_LINES];
			numOutput = 0;
			name = title;
			numChilds = 0;
		}
	
		public void insertCommand(string Command){
			command = Command;
		}
		
		public void insertOutput(string output){
			Output[numOutput] = output;
			numOutput++;
		}
		
		 public void insertParent(Node node){
			parent = node;
		}

		
		public void insertchild(Node node){
			childs[numChilds] = node;
			numChilds++;
		}
		
		public Node getChild(int index){
			if(index < numChilds )
				return childs[index];
			else
				return null;
		}
}


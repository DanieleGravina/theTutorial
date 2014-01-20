using System;

	public class Node
	{
		public Node[] childs;
		
		public Node parent;
		
		public string name, command;
	
		public string[] Output;
	
		public string[][] outputs;
	
		public int numOutput;
	
		const int MAX_LINES = 10;
		
		public int numChilds;
	
		public int numberOutputs;
	
		int indexOutputs = 0;
		
		
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
	
		public void nextOutput(){
			indexOutputs++;
			numOutput = 0;
		}
		
		public void insertOutput(string output){
			outputs[indexOutputs][numOutput] = output;
			numOutput++;
		}
	
		public string[] getOutput(textState state){
			int index = 0;
			
			if(name == "cake" && state == textState.CAKE){
				index = 1;
			}
		
			if(name == "scare"){
				if(state == textState.DRESS) index = 1;
				if(state == textState.DRUNK) index = 2;
			    if(state == textState.SCARE_CHILDREN) index = 3;
			}
				
			return outputs[index];
		}
	
		public void insertNumber(int num){
			numberOutputs = num;
			outputs = new string[num][];
			
			for(int i = 0; i < outputs.Length; i++)
				outputs[i] = new string[MAX_LINES];
		
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
				if(index == numChilds && parent != null)
					return parent;
				else 
					return null;
		}
	
		public Node getParent(){
			if(parent != null)
				return parent;
			else
				return null;
		}
}


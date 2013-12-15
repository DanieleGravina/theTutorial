using System;


public class XMLparser
{
	string[] lines;
	Node root;
	int index;
	
	
	public XMLparser (string File)
	{
		lines = System.IO.File.ReadAllLines(File);
		parseLines();
	}
	
	void parseLines(){
		
		root = new Node("root");
		
		Node node = root;
		
		index = 0;
		
		parseNode(node);
		
	}
	
	void parseNode(Node node){
		
		bool nodeParsed = false;
	
		while(!lines[index].Contains("<" + node.name + ">"))
			index++;
		
		index++;
		
		while(!nodeParsed){
			
			while(!lines[index].Contains("<" + "command" + ">"))
				index++;
			
			parseCommand(node);
			
			index++;
			
			while(!lines[index].Contains("<" + "number" + ">"))
				index++;
			
			parseNumber(node);
			
			index++;
			
			for(int i= 0; i < node.numberOutputs; i++){
				while(!lines[index].Contains("<" + "output" + ">"))
					index++;
				
				index++;
				
				parseOutput(node);
				node.nextOutput();
			}
			
			while(!lines[index].Contains("<" + "option" + ">"))
				index++;
			
			index++;
			
			parseOptions(node);
			
			while(!lines[index].Contains("<" + "/" + node.name + ">"))
				index++;
			
			nodeParsed = true;
		}
		
		for(int i =0 ; i < node.numChilds; i++){
				parseNode(node.getChild(i));
		}
	}
	
	void parseCommand(Node node){
		while(!lines[index].Contains("<" + "/" + "command" + ">")){
			node.insertCommand(lines[index]);
			index++;
		}
			
	}
			
	void parseOutput(Node node){
		while(!lines[index].Contains("<" + "/" + "output" + ">")){
			node.insertOutput(lines[index]);
			index++;
		}
	}
	
	void parseOptions(Node node){
		Node child;
		while(!lines[index].Contains("<" + "/" + "option" + ">")){
			child = new Node(lines[index]);
			child.insertParent(node);
			node.insertchild(child);
			index++;
		}
	}
	
	void parseNumber(Node node){
		index++;
		while(!lines[index].Contains("<" + "/" + "number" + ">")){
			node.insertNumber(Convert.ToInt32(lines[index]));
			index++;
		}
	}
	
	
	public Node getRoot(){
		return root;
	}
}


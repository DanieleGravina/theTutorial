using System;

namespace AssemblyCSharp
{
	public class XMLparser
	{
		string[] lines;
		
		public XMLparser (string File)
		{
			lines = System.IO.File.ReadAllLines(File);
			
			parseLines();
		}
		
		void parseLines(){
		}
		
		public void getOutput(){
		}
		
		public void getOption(int index){
		}
		
		public void setOption(int index){
		}
	}
}


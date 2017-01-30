/*
This file is part of Gateway Cheat Compiler (Copyright 2016-2017 Jonas Hülsermann).

Gateway Cheat Compiler is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Gateway Cheat Compiler is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Gateway Cheat Compiler.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway_Cheat_Compiler
{
	class GWCheatFile
	{
		public class GWCheat
		{
			private String name;
			private List<String> commands = new List<String>();

			public GWCheat(String name)
			{
				this.name = name;
			}
			
			public void addCommand(String command)
			{
				commands.Add(command);
			}

			public String getName()
			{
				return name;
			}

			public void setName(String name)
			{
				this.name = name;
			}

			public List<String> getCommands()
			{
				return commands;
			}
		}

		
		private String file = null;
		private List<GWCheat> cheats = new List<GWCheat>();
		
		public GWCheatFile(String file = null)
		{
			if (file != null && System.IO.File.Exists(file))
			{
				this.file = file;
				String[] lines = System.IO.File.ReadAllLines(file);
				parseCheatFile(lines);
			}
		}

		public List<GWCheat> getCheats()
		{
			return cheats;
		}

		public bool exists()
		{
			return file != null && System.IO.File.Exists(file);
		}

		public String getFileName(bool withoutPath = false)
		{
			return withoutPath
				? (file == null ? null : System.IO.Path.GetFileName(file))
				: file;
		}

		public void setOutputFile(String filePath)
		{
			file = filePath;
		}

		public void setCheat(String name, String[] commands)
		{
			GWCheat cheat = new GWCheat(name);
			foreach (String command in commands)
			{
				cheat.addCommand(command);
			}

			int index = cheats.FindIndex(x => x.getName().Equals(name));

			if (index == -1)
				cheats.Add(cheat);
			else
				cheats[index] = cheat;
		}

		public void saveCheatFile()
		{
			List<String> output = new List<String>();

			foreach (GWCheat cheat in cheats)
			{
				output.Add("[" + cheat.getName() + "]");

				foreach (String command in cheat.getCommands())
					output.Add(command);
			}
			output.RemoveAll(x => x.Length == 0 || x.Equals("") || x.Equals("\n") || x.StartsWith("#"));

			System.IO.File.WriteAllLines(file, output);
		}

		public bool renameCheat(String oldName, String newName)
		{
			int index = cheats.FindIndex(x => x.getName().Equals(oldName));

			if (index == -1)
				return false;
			else
				cheats[index].setName(newName);

			return true;
		}

		public bool deleteCheat(String name)
		{
			int index = cheats.FindIndex(x => x.getName().Equals(name));

			if (index == -1)
				return false;
			else
				cheats.RemoveAt(index);
			
			return true;
		}

		public bool moveCheatUp(String name)
		{
			int index = cheats.FindIndex(x => x.getName().Equals(name));

			//if (index == -1 || index == 0)
			if (index <= 0)
				return false;
			else
			{
				GWCheat tmp = cheats[index];
				cheats.RemoveAt(index);
				cheats.Insert(index - 1, tmp);
			}

			return true;
		}

		public bool moveCheatDown(String name)
		{
			int index = cheats.FindIndex(x => x.getName().Equals(name));

			//if (index == -1 || index == 0)
			if (index == -1 || index == cheats.Count - 1)
				return false;
			else
			{
				GWCheat tmp = cheats[index];
				cheats.RemoveAt(index);
				cheats.Insert(index + 1, tmp);
			}

			return true;
		}


		private void parseCheatFile(String[] lines)
		{
			GWCheat cheat = null;
			
			foreach (String line in lines)
			{
				String trimmedLine = line.Trim();

				if (trimmedLine.Length == 0)
					continue;

				if (trimmedLine.StartsWith("["))
				{
					String name = trimmedLine.Substring(1, trimmedLine.Length - 2);
					cheat = new GWCheat(name);
					cheats.Add(cheat);
				}
				else if (cheat != null)
					cheat.addCommand(trimmedLine);
			}
		}
	}
}

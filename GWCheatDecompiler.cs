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
	class GWCheatDecompiler
	{
		public String decompile(String command, String param)
		{
			command = command.ToUpper();
			param = param.ToUpper();

			switch (command[0])
			{
				case '0': return dcmp_mov(32, command.Substring(1), param);
				case '1': return dcmp_mov(16, command.Substring(1), param);
				case '2': return dcmp_mov(8, command.Substring(1), param);
				case '3': return dcmp_if(32, 'g', command.Substring(1), param);
				case '4': return dcmp_if(32, 'l', command.Substring(1), param);
				case '5': return dcmp_if(32, 'e', command.Substring(1), param);
				case '6': return dcmp_if(32, 'd', command.Substring(1), param);
				case '7': return dcmp_if(16, 'g', command.Substring(1), param);
				case '8': return dcmp_if(16, 'l', command.Substring(1), param);
				case '9': return dcmp_if(16, 'e', command.Substring(1), param);
				case 'A': return dcmp_if(16, 'd', command.Substring(1), param);
				case 'B': return dcmp_off("ref", command.Substring(1));
				case 'C': return dcmp_loop("set", param);
				case 'D': switch (command[1])
					{
						case '0': return dcmp_loop("term");
						case '1': return dcmp_loop("exec");
						case '3': return dcmp_off("set", param);
						case '4': return dcmp_data("add", param);
						case '5': return dcmp_data("set", param);
						case '6': return dcmp_data("set32", param);
						case '7': return dcmp_data("set16", param);
						case '8': return dcmp_data("set8", param);
						case '9': return dcmp_data("get32", param);
						case 'A': return dcmp_data("get16", param);
						case 'B': return dcmp_data("get8", param);
						case 'C': return dcmp_off("add", param);
						case 'D': return dcmp_key(param);
						default: return "";
					}
				case 'E': return dcmp_sup(command.Substring(1));
				default: return "";
			}
		}

		public String decompile(String line)
		{
			String command = "", param = "";

			line = line.Replace("\t", "").Trim();
			if (line[0] == '#') return line;
			if (line.Length != 17 || line[8] != ' ') return "";

			String[] parts = line.Split(' ');
			command = parts[0];
			if (parts.Length > 1)
				param = parts[1];

			return decompile(command, param);
		}
		

		private String dcmp_mov(byte bits, String address, String value)
		{
			address = "0x" + removezeroes(address);
			value = getCorrectValueFormat(value);
			
			switch (bits)
			{
				case 32: return "mov32 " + address + " " + value;
				case 16: return "mov16 " + address + " " + value;
				case 8: return "mov8 " + address + " " + value;
				default: return "";
			}
		}

		private String dcmp_if(byte bits, char mode, String address, String value)
		{
			address = "0x" + removezeroes(address);
			value = getCorrectValueFormat(value);
			
			if (bits == 32)
			{
				switch (mode)
				{
					case 'g': return "if32g " + address + " " + value;
					case 'l': return "if32l " + address + " " + value;
					case 'e': return "if32e " + address + " " + value;
					case 'd': return "if32ne " + address + " " + value;
					default: return "";
				}
			}
			else if (bits == 16)
			{
				switch (mode)
				{
					case 'g': return "if16g " + address + " " + value;
					case 'l': return "if16l " + address + " " + value;
					case 'e': return "if16e " + address + " " + value;
					case 'd': return "if16ne " + address + " " + value;
					default: return "";
				}
			}
			else
				return "";
		}

		private String dcmp_off(String mode, String value)
		{
			value = getCorrectValueFormat(value);

			switch (mode)
			{
				case "ref": return "off ref " + value;
				case "set": return "off set " + value;
				case "add": return "off add " + value;
				default: return "";
			}
		}

		private String dcmp_loop(String mode, String value = "")
		{
			value = getCorrectValueFormat(value);

			switch (mode)
			{
				case "set": return "loop set " + value;
				case "exec": return "loop exec";
				case "term": return "term";
				default: return "";
			}
		}

		private String dcmp_data(String mode, String value)
		{
			value = getCorrectValueFormat(value);

			String[] options = { "add", "set", "set32", "set16", "set8", "get32", "get16", "get8" };
			
			return options.Contains(mode)
				? "data " + mode + " " + value
				: "";
		}

		private String dcmp_key(String value)
		{
			String result = "";
			int keys = UInt16.Parse(value, System.Globalization.NumberStyles.HexNumber);

			int z;

			z = keys & 0x1;
			if (z > 0) result += ",A";

			z = keys & 0x2;
			if (z > 0) result += ",B";

			z = keys & 0x4;
			if (z > 0) result += ",Select";

			z = keys & 0x8;
			if (z > 0) result += ",Start";

			z = keys & 0x10;
			if (z > 0) result += ",Right";

			z = keys & 0x20;
			if (z > 0) result += ",Left";

			z = keys & 0x40;
			if (z > 0) result += ",Up";

			z = keys & 0x80;
			if (z > 0) result += ",Down";

			z = keys & 0x100;
			if (z > 0) result += ",R";

			z = keys & 0x200;
			if (z > 0) result += ",L";

			z = keys & 0x400;
			if (z > 0) result += ",X";

			z = keys & 0x800;
			if (z > 0) result += ",Y";

			return result.Length == 0
				? ""
				: "key " + result.Remove(0, 1);
		}

		private String dcmp_sup(String value)
		{
			value = getCorrectValueFormat(value);

			return "sup " + value;
		}


		private String removezeroes(String text)
		{
			if (text.Length == 0)
				return "";
			
			int count = 0;
			while (count < text.Length && text[count++] == '0') ;
			count--;

			text = text.Remove(0, count);
			
			return text.Length == 0
				? "0"
				: text;
		}

		private String getHexString(String value)
		{
			if (value.IndexOf('x') != -1)
				//return UInt32.Parse(value, System.Globalization.NumberStyles.HexNumber).ToString("X");
				return value.Split('x')[1].ToUpper();
			else if (!value.All(Char.IsDigit))
				return value.ToUpper();
			else
				return UInt32.Parse(value).ToString("X");
		}

		private String getCorrectValueFormat(String value)
		{
			if (value == null || value.Length == 0)
				return "";
			
			if (Properties.Settings.Default.decompileNumbersToDecimal)
				return UInt32.Parse(value, System.Globalization.NumberStyles.HexNumber).ToString();
			else
				return "0x" + removezeroes(value);
		}
	}
}

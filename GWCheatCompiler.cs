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
	class GWCheatCompiler
	{
		public String compile(String opcode, String param1, String param2)
		{
			opcode = opcode.ToLower();
			param1 = param1.ToLower();
			param2 = param2.ToLower();
			
			switch (opcode)
			{
				case "mov8": return cmp_mov(8, param1, param2);
				case "mov16": return cmp_mov(16, param1, param2);
				case "mov32": return cmp_mov(32, param1, param2);
				case "if32g": return cmp_if(32, 'g', param1, param2);
				case "if32l": return cmp_if(32, 'l', param1, param2);
				case "if32e": return cmp_if(32, 'e', param1, param2);
				case "if32ne": return cmp_if(32, 'd', param1, param2);
				case "if16g": return cmp_if(16, 'g', param1, param2);
				case "if16l": return cmp_if(16, 'l', param1, param2);
				case "if16e": return cmp_if(16, 'e', param1, param2);
				case "if16ne": return cmp_if(16, 'd', param1, param2);
				case "off": return cmp_off(param1, param2);
				case "loop": return cmp_loop(param1, param2);
				case "term": return cmp_loop("term");
				case "data": return cmp_data(param1, param2);
				case "key": return cmp_key(param1);
				case "sup": return cmp_sup(param1);
				default: return "";
			}
		}
		public String compile(String line)
		{
			String opcode = "", param1 = "", param2 = "";
			
			line = line.Replace("\t", "").Trim();
			if (line[0] == '#') return line;
			if (line.Length == 0) return "";
				
			String[] parts = line.Split(' ');
			opcode = parts[0];
			if (parts.Length > 1)
				param1 = parts[1];
			if (parts.Length > 2)
				param2 = parts[2];

			return compile(opcode, param1, param2);
		}
		
		private String cmp_mov(byte bits, String address, String value)
		{
			address = fillzeroes(getHexString(address), 7);
			value = fillzeroes(getHexString(value), 8);

			switch (bits)
			{
				case 32: return "0" + address + " " + value;
				case 16: return "1" + address + " " + value;
				case 8: return "2" + address + " " + value;
			}

			return "";
		}

		private String cmp_if(byte bits, char mode, String address, String value)
		{
			address = getHexString(address);
			value = getHexString(value);
			
			if (bits == 32)
			{
				value = fillzeroes(value, 8);
				address = fillzeroes(address, 7);

				switch (mode)
				{
					case 'g': return "3" + address + " " + value;
					case 'l': return "4" + address + " " + value;
					case 'e': return "5" + address + " " + value;
					case 'd': return "6" + address + " " + value;
					default: return "";
				}
			}
			else if (bits == 16)
			{
				value = fillzeroes(value, 4);
				address = fillzeroes(address, 8);

				switch (mode)
				{
					case 'g': return "7" + address + " 0000" + value;
					case 'l': return "8" + address + " 0000" + value;
					case 'e': return "9" + address + " 0000" + value;
					case 'd': return "A" + address + " 0000" + value;
					default: return "";
				}
			}
			else
				return "";
		}

		private String cmp_off(String mode, String value)
		{
			value = getHexString(value);
			
			switch (mode)
			{
				case "ref": return "B" + fillzeroes(value, 7) + " 00000000";
				case "set": return "D3000000 " + fillzeroes(value, 8);
				case "add": return "DC000000 " + fillzeroes(value, 8);
				default: return "";
			}
		}

		private String cmp_loop(String mode, String value = "")
		{
			value = getHexString(value);

			switch (mode)
			{
				case "set": return "C0000000 " + fillzeroes(value, 8);
				case "exec":
				case "start": return "D1000000 00000000";
				case "term": return "D0000000 00000000";
				default: return "";
			}
		}

		private String cmp_data(String mode, String value)
		{
			value = fillzeroes(getHexString(value), 8);

			switch (mode)
			{
				case "add": return "D4000000 " + value;
				case "set": return "D5000000 " + value;
				case "set32": return "D6000000 " + value;
				case "set16": return "D7000000 " + value;
				case "set8": return "D8000000 " + value;
				case "get32": return "D9000000 " + value;
				case "get16": return "DA000000 " + value;
				case "get8": return "DB000000 " + value;
				default: return "";
			}
		}

		private String cmp_key(String keys)
		{
			int result = 0;
			String[] splitkeys = keys.Split(',');

			foreach (String key in splitkeys)
			{
				switch (key.ToLower())
				{
					case "a": result += 0x1; break;
					case "b": result += 0x2; break;
					case "se":
					case "select": result += 0x4; break;
					case "st":
					case "start": result += 0x8; break;
					case "ri":
					case "right": result += 0x10; break;
					case "le":
					case "left": result += 0x20; break;
					case "u":
					case "up": result += 0x40; break;
					case "d":
					case "down": result += 0x80; break;
					case "r": result += 0x100; break;
					case "l": result += 0x200; break;
					case "x": result += 0x400; break;
					case "y": result += 0x800; break;
				}
			}

			return result != 0
				? "DD000000 " + fillzeroes(result.ToString("X"), 8)
				: "";
		}

		private String cmp_sup(String value)
		{
			value = fillzeroes(getHexString(value), 7);
			return "E" + value + " 00000000";
		}

		private String fillzeroes(String text, byte length, bool putOnFront = true)
		{
			if (putOnFront)
				while (text.Length < length)
					text = "0" + text;
			else
				while (text.Length < length)
					text += "0";

			return text;
		}

		private String getHexString(String value)
		{
			if (value.Length == 0)
				return "";
			else if (value.IndexOf('x') != -1)
				//return UInt32.Parse(value, System.Globalization.NumberStyles.HexNumber).ToString("X");
				return value.Split('x')[1].ToUpper();
			else if (!value.All(Char.IsDigit))
				return value.ToUpper();
			else
				return UInt32.Parse(value).ToString("X");
		}
	}
}

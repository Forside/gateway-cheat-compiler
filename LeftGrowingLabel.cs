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
using System.Windows.Forms;

namespace Gateway_Cheat_Compiler
{
	class LeftGrowingLabel : Label
	{
		protected override void OnTextChanged(EventArgs e)
		{
			if (this.RightToLeft == RightToLeft.Yes)
			{
				int oldWidth = this.Width;
				base.OnTextChanged(e);
				this.Left = this.Left - (this.Width - oldWidth);
			} else
				base.OnTextChanged(e);
		}
	}
}

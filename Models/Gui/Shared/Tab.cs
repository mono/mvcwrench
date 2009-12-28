//
// Authors:
// Jonathan Pobst (monkey@jpobst.com)
//
// Copyright (C) 2009 Jonathan Pobst
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System.Data;

namespace MvcWrench.Models
{
	public class Tab
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public string Image { get; set; }
		public int Sequence { get; set; }

		public Tab ()
		{
		}

		public Tab (string name, string url, string image, int sequence)
		{
			Name = name;
			Url = url;
			Image = image;
			Sequence = sequence;
		}

		public Tab (DataRow row)
		{
			Id = (int)row["Id"];
			Name = (string)row["Name"];
			Url = (string)row["Url"];
			Image = (string)row["Image"];
			Sequence = (int)row["Sequence"];
		}
	}
}

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWrench.Helpers
{
	public class ExpiringCache
	{
		private int timeout;
		private Dictionary<string, CacheItem> cache = new Dictionary<string,CacheItem> ();
		
		public ExpiringCache (int seconds)
		{
			timeout = seconds;
		}
		
		public void Add (string key, object item, int timeout)
		{
			cache[key] = new CacheItem (timeout, item);
		}
		
		public object Get (string key)
		{
			if (!cache.ContainsKey (key))
				return null;
				
			CacheItem item = cache[key];
			
			if (item.IsExpired) {
				cache.Remove (key);
				return null;
			}
				
			return item.Value;
		}
		
		private class CacheItem
		{
			public DateTime ExpireTime;
			public object Value;
			
			public CacheItem (DateTime expire, object value)
			{
				ExpireTime = expire;
				Value = value;
			}
			
			public CacheItem (int timeout, object value)
			{
				ExpireTime = DateTime.Now.AddSeconds (timeout);
				Value = value;
			}
			
			public bool IsExpired {
				get { return DateTime.Now > ExpireTime; }
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.Helper
{
	[Serializable]
	public class RepositoryException : Exception
	{ public UpdateResultType Type { get; set; }
		public RepositoryException(UpdateResultType type) { Type = type; }
		public RepositoryException(string message, UpdateResultType type) : base(message) { Type = type; }
		public RepositoryException(string message, Exception inner) : base(message, inner) { }
		protected RepositoryException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
